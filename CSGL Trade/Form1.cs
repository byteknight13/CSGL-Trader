using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CSGL_Trade
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private CSGL _csgl = new CSGL();

        private SteamInventory _steamInventory = new SteamInventory();

        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bgwGetItemSchema.IsBusy) { return; }
            if (bgwGetSteamItems.IsBusy) { return; }

            //Reset the Grid Controls.
            ClearGridView(gridControl1);
            ClearGridView(gridControl2);

            gviewItems.ShowLoadingPanel();
            gviewSteamItems.ShowLoadingPanel();

            bgwGetItemSchema.DoWork += BgwLoadItemSchema;

            bgwGetItemSchema.RunWorkerCompleted += RemoveLoadingScreensAndZeroItems;

            bgwGetPricesForMyItems.DoWork += SetMyItemsPrices;

            bgwGetSteamItems.DoWork += BgwLoadSteamInventory;

            bgwGetItemSchema.RunWorkerAsync();

            bgwGetSteamItems.RunWorkerAsync();
        }

        private void bgwGetSteamItems_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private void BgwLoadItemSchema(object sender, EventArgs e)
        {
            var items = _csgl.GetItemSchema();

            if (items == null)
            {
                Console.WriteLine(@"Null dictionary. Exiting method.");
                return;
            }

            //Create the DT and add our new columns.
            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Worth");

            //Iterate through each of the Key/Value pairs
            //returned by the previous "CSGL.GetItemSchema" method
            //and add them to the new DataRows.

            foreach (var entry in items)
            {
                var dr = dt.NewRow();
                dr[0] = entry.Key;
                dr[1] = entry.Value;
                dt.Rows.Add(dr);
            }

            //Threadsafe setting of the datasource.
            Threading.SetControlPropertyThreadSafe(
                gridControl1,
                "DataSource",
                dt);
        }

        private void BgwLoadSteamInventory(object sender, EventArgs e)
        {
            var steamItems = _steamInventory.ParseSteamInventoryJson(_steamInventory.GetInventoryJson());

            var dt = new DataTable();
            dt.Columns.Add("Item Name");
            dt.Columns.Add("Worth");
            Console.WriteLine("Total Items In List From Steam: {0}", steamItems.Count);
            for (var i = 0; i < steamItems.Count; i++)
            {
                var dr = dt.NewRow();
                dr[0] = steamItems[i];
                dt.Rows.Add(dr);
            }

            Threading.SetControlPropertyThreadSafe(
                gridControl2,
                "DataSource",
                dt);
        }

        private void ClearGridView(DevExpress.XtraGrid.GridControl gridControl)
        {
            var dt = new DataTable();
            gridControl.DataSource = dt;
        }

        private void cmdReloadItems_Click(object sender, EventArgs e)
        {
            if (bgwGetItemSchema.IsBusy)
            {
                return;
            }
            if (bgwGetSteamItems.IsBusy)
            {
                return;
            }

            //Reset the Grid Controls.
            ClearGridView(gridControl1);
            ClearGridView(gridControl2);

            gviewItems.ShowLoadingPanel();
            gviewSteamItems.ShowLoadingPanel();

            bgwGetItemSchema.DoWork +=
                BgwLoadItemSchema;

            bgwGetItemSchema.RunWorkerCompleted +=
                RemoveLoadingScreensAndZeroItems;

            bgwGetSteamItems.DoWork +=
                BgwLoadSteamInventory;

            bgwGetPricesForMyItems.DoWork +=
                SetMyItemsPrices;

            bgwGetPricesForMyItems.RunWorkerCompleted += delegate
            {
                Console.WriteLine("Pricing Complete...");
            };
            bgwGetItemSchema.RunWorkerAsync();

            bgwGetSteamItems.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void gridControl1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (gviewItems.SelectedRowsCount != 0)
            {
                var row = gviewItems.GetSelectedRows()[0];
                Console.WriteLine(gviewItems.GetRowCellDisplayText(row, gviewItems.Columns[1]));
            }
        }

        private void gviewItems_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            decimal currencyValue;

            if (e.Column.FieldName == "Worth")
            {
                try
                {
                    if (Decimal.TryParse(e.Value.ToString(), out currencyValue))
                    {
                        e.DisplayText = string.Format("{0:c}", currencyValue);
                        e.Column.SortMode = ColumnSortMode.DisplayText;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void RemoveLoadingScreensAndZeroItems(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            RemoveZeroItems();

            Console.WriteLine("Starting Pricing...");
            bgwGetPricesForMyItems.RunWorkerAsync();

            gviewItems.HideLoadingPanel();
            gviewSteamItems.HideLoadingPanel();

        }

        private void RemoveZeroItems()
        {
            var col = gviewItems.Columns[1];

            for (var i = 0; i < gviewItems.RowCount; i++)
            {
                var val = (string)gviewItems.GetRowCellDisplayText(i, col);
                if (val == "$0.00")
                {
                    gviewItems.DeleteRow(i);
                    i--;
                }
            }
        }

        private void repositoryItemTextEdit_SteamProfile_EditValueChanged(object sender, EventArgs e)
        {
            CSGL_Trade.Properties.Settings.Default.SteamProfileID =
                bar_txtProfileID.EditValue.ToString();
        }

        private void SetMyItemsPrices(object sender, EventArgs e)
        {

            SteamInventory steamInventory = new CSGL_Trade.SteamInventory();
            var dtMyInv = new DataTable();

            Invoke((MethodInvoker)delegate
            {
                gviewSteamItems.ShowLoadingPanel();
                dtMyInv = (DataTable)gridControl2.DataSource;
            });

            for (var i = 0; i < dtMyInv.Rows.Count; i++)
            {
                Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        var itemName = dtMyInv.Rows[i][0].ToString();
                        //The below commented item will check againt the CSGL
                        //grid and pull value from that

                        //var drPrice = GetMyItemPriceFromCsglGridView(itemName);

                        SteamMarketHistory steamMarketHistory = steamInventory.GetMarketHistory(itemName);

                        double drPrice = (double)steamMarketHistory.History[0].Price / 100;

                        //Console.WriteLine("Found {0} @ {1}", itemName, drPrice);

                        gviewSteamItems.SetRowCellValue(i, gviewSteamItems.Columns[1], drPrice);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                });
                gviewSteamItems.HideLoadingPanel();
                bgwGetPricesForMyItems.CancelAsync();
            }
        }
        public string GetMyItemPriceFromCsglGridView(string itemName)
        {
            var dtCsgl = (DataTable)gridControl1.DataSource;

            foreach (DataRow dr in dtCsgl.Rows)
            {
                if ((string)dr[0] == itemName)
                {
                    return (string)dr[1];
                }
            }
            return null;
        }

        private void gviewSteamItems_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            decimal currencyValue;

            if (e.Column.FieldName == "Worth")
            {
                try
                {
                    if (Decimal.TryParse(e.Value.ToString(), out currencyValue))
                    {
                        e.DisplayText = string.Format("{0:c}", currencyValue);
                        e.Column.SortMode = ColumnSortMode.DisplayText;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
}

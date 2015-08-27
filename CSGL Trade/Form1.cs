using CSGL_Trade.Properties;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// ReSharper disable LocalizableElement

namespace CSGL_Trade
{
    public partial class Form1 : XtraForm
    {
        private readonly CSGL _csgl = new CSGL();
        private readonly SteamInventory _steamInventory = new SteamInventory();

        private readonly string[] itemWears =
        {
            "Field-Tested", "Well-Worn", "Battle-Scarred", "Factory New",
            "Minimal Wear"
        };

        public Form1()
        {
            InitializeComponent();
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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
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

            bgwGetItemSchema.DoWork += BgwLoadNewItemSchema; //BgwLoadItemSchema;

            bgwGetItemSchema.RunWorkerCompleted += RemoveLoadingScreensAndZeroItems;

            bgwGetPricesForMyItems.DoWork += SetMyItemsPrices;

            bgwGetSteamItems.DoWork += BgwLoadSteamInventory;

            bgwGetItemSchema.RunWorkerAsync();

            bgwGetSteamItems.RunWorkerAsync();
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

        private void BgwLoadNewItemSchema(object sender, EventArgs e)
        {
            var CSGOIS = new CSGOItems();
            CSGOIS = CSGOIS.LoadNewInstance();

            //Calculating maximum for the progress bar.
            var totalItems = CSGOIS.Count;
            Invoke((MethodInvoker)delegate
            {
                repositoryItemProgressBar1.Maximum = totalItems;
            });

            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Worth");

            var loopTotal = 0;
            for (var i = 0; i < CSGOIS.Count; i++)
            {
                for (var n = 0; n < itemWears.Length; n++)
                {
                    var dr = dt.NewRow();

                    var itemNameWithWear =
                        CSGOIS.Results.Collection1[i].Weapon.Text + string.Format(" ({0})", itemWears[n]);

                    var SMH = new SteamMarketHistory();

                    //Console.WriteLine("Getting Price For {0}", itemNameWithWear);

                    SMH = _steamInventory.GetMarketHistory(itemNameWithWear);

                    dr[0] = itemNameWithWear;

                    try
                    {
                        dr[1] = (double)SMH.History[0].Price / 100;
                        //Console.WriteLine("{0} = {1}", itemNameWithWear, (double)SMH.History[0].Price / 100);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Failed Getting Price With Wear...");
                        dr[1] = "N/A (Not Found)";
                    }

                    dt.Rows.Add(dr);

                    loopTotal += 1;
                    Invoke((MethodInvoker)delegate
                    {
                        barProgressBar.EditValue = (double)loopTotal / totalItems * 100;
                    });
                }
            }
            Threading.SetControlPropertyThreadSafe(gridControl1,
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
            foreach (var item in steamItems)
            {
                var dr = dt.NewRow();
                dr[0] = item;
                dt.Rows.Add(dr);
            }

            Threading.SetControlPropertyThreadSafe(
                gridControl2,
                "DataSource",
                dt);
        }

        private void ClearGridView(GridControl gridControl)
        {
            var dt = new DataTable();
            gridControl.DataSource = dt;
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gviewItems.SelectedRowsCount != 0)
            {
                var row = gviewItems.GetSelectedRows()[0];
                Console.WriteLine(gviewItems.GetRowCellDisplayText(row, gviewItems.Columns[1]));
            }
        }

        private void gviewItems_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            decimal currencyValue;

            if (e.Column.FieldName == "Worth")
            {
                try
                {
                    if (decimal.TryParse(e.Value.ToString(), out currencyValue))
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

        private void gviewSteamItems_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Worth")
            {
                try
                {
                    decimal currencyValue;
                    if (decimal.TryParse(e.Value.ToString(), out currencyValue))
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

        private void RemoveLoadingScreensAndZeroItems(object sender, RunWorkerCompletedEventArgs e)
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
                var val = gviewItems.GetRowCellDisplayText(i, col);
                if (val == "$0.00")
                {
                    gviewItems.DeleteRow(i);
                    i--;
                }
            }
        }

        private void repositoryItemTextEdit_SteamProfile_EditValueChanged(object sender, EventArgs e)
        {
            Settings.Default.SteamProfileID =
                bar_txtProfileID.EditValue.ToString();
        }

        private void SetMyItemsPrices(object sender, EventArgs e)
        {
            var steamInventory = new SteamInventory();
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

                        var steamMarketHistory = steamInventory.GetMarketHistory(itemName);

                        var drPrice = (double)steamMarketHistory.History[0].Price / 100;

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

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gviewSteamItems_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveItemList()
        {
            WriteLine("Beginning saving...");

            var dt = (DataTable)gridControl1.DataSource;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int n = 0; n < dt.Columns.Count; n++)
                {
                    builder.Append(dt.Rows[i][n]);
                    if (n != dt.Columns.Count - 1)
                    {
                        builder.Append(",");
                    }
                }
                builder.AppendLine("");
            }
            var path = @"data\items.txt";
            if (!System.IO.File.Exists(path)) { System.IO.File.Create(path); }

            var sw = new System.IO.StreamWriter(path);
            sw.Write(builder.ToString());
            sw.Close();
            WriteLine("Saving complete.");

        }

        private void WriteLine(string msg)
        {
#if DEBUG
            Console.WriteLine(msg);
#endif
        }

        private void SaveItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveItemList();
        }
        private void LoadItems()
        {
            try
            {
                ClearGridView(gridControl1);
                var path = @"data\items.txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show("No save data!\r\nPlease reload items.");
                }

                var dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Worth");

                var sr = new StreamReader(File.OpenRead(path));

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');
                        var newRow = dt.NewRow();
                        newRow[0] = values[0];
                        newRow[1] = values[1];
                        dt.Rows.Add(newRow);
                    }
                }
                sr.Close();
                sr.Dispose();
                gridControl1.DataSource = dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadItemsFromFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadItems();
        }

        private void ReloadSteamItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            gviewSteamItems.ShowLoadingPanel();

            bgwGetPricesForMyItems.DoWork +=
                SetMyItemsPrices;

            bgwGetPricesForMyItems.RunWorkerCompleted += delegate { gviewSteamItems.HideLoadingPanel(); };

            bgwGetSteamItems.DoWork +=
                BgwLoadSteamInventory;

            bgwGetSteamItems.RunWorkerCompleted += delegate
            {
                RemoveZeroItems();
                bgwGetPricesForMyItems.RunWorkerAsync();
            };

            bgwGetSteamItems.RunWorkerAsync();
        }

        private void FindMatchedTradingItems()
        {
            if (gviewSteamItems.SelectedRowsCount != 0)
            {
                var col = gviewSteamItems.Columns[1];
                var selectedRow = (int)gviewSteamItems.GetSelectedRows()[0];

                var itemPrice = (string)gviewSteamItems.GetRowCellValue(selectedRow, col);

                WriteLine(itemPrice.ToString(CultureInfo.InvariantCulture));

                var dtAllItems = (DataTable)gridControl1.DataSource;

                var tradeForItems = from i in dtAllItems.AsEnumerable()
                                    where (i.Field<string>("Worth") != "N/A (Not Found)") &&
                                    (Convert.ToDouble(i.Field<string>("Worth")) <= Convert.ToDouble(itemPrice) + 1.00)
                                    && (Convert.ToDouble(i.Field<string>("Worth")) >= Convert.ToDouble(itemPrice))
                                    select i.ItemArray;
                var dtNew = new DataTable();

                dtNew.Columns.Add("Name");

                dtNew.Columns.Add("Worth");

                foreach (var row in tradeForItems)
                {
                    dtNew.Rows.Add(row);
                }

                gridControl3.DataSource = dtNew;
            }
        }

        private void gviewSteamItems_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            FindMatchedTradingItems();
        }
    }
}
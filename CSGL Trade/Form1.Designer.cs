namespace CSGL_Trade
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bgwGetItemSchema = new System.ComponentModel.BackgroundWorker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gviewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupCSGLItems = new DevExpress.XtraEditors.GroupControl();
            this.groupSteamItems = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gviewSteamItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bgwGetSteamItems = new System.ComponentModel.BackgroundWorker();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bar_txtProfileID = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit_SteamProfile = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barProgressBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bgwGetPricesForMyItems = new System.ComponentModel.BackgroundWorker();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gviewTradeFor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCSGLItems)).BeginInit();
            this.groupCSGLItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSteamItems)).BeginInit();
            this.groupSteamItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewSteamItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_SteamProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewTradeFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwGetItemSchema
            // 
            this.bgwGetItemSchema.WorkerReportsProgress = true;
            this.bgwGetItemSchema.WorkerSupportsCancellation = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 22);
            this.gridControl1.MainView = this.gviewItems;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(608, 337);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gviewItems});
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseClick);
            // 
            // gviewItems
            // 
            this.gviewItems.GridControl = this.gridControl1;
            this.gviewItems.Name = "gviewItems";
            this.gviewItems.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gviewItems.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gviewItems.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gviewItems_CustomColumnDisplayText);
            // 
            // groupCSGLItems
            // 
            this.groupCSGLItems.Controls.Add(this.gridControl1);
            this.groupCSGLItems.Location = new System.Drawing.Point(12, 30);
            this.groupCSGLItems.Name = "groupCSGLItems";
            this.groupCSGLItems.Size = new System.Drawing.Size(612, 361);
            this.groupCSGLItems.TabIndex = 2;
            this.groupCSGLItems.Text = "CSGL Items";
            // 
            // groupSteamItems
            // 
            this.groupSteamItems.Controls.Add(this.gridControl2);
            this.groupSteamItems.Location = new System.Drawing.Point(630, 30);
            this.groupSteamItems.Name = "groupSteamItems";
            this.groupSteamItems.Size = new System.Drawing.Size(647, 361);
            this.groupSteamItems.TabIndex = 3;
            this.groupSteamItems.Text = "Steam Items";
            // 
            // gridControl2
            // 
            this.gridControl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 22);
            this.gridControl2.MainView = this.gviewSteamItems;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(643, 337);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gviewSteamItems});
            this.gridControl2.Click += new System.EventHandler(this.gridControl2_Click);
            // 
            // gviewSteamItems
            // 
            this.gviewSteamItems.GridControl = this.gridControl2;
            this.gviewSteamItems.Name = "gviewSteamItems";
            this.gviewSteamItems.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gviewSteamItems.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gviewSteamItems.OptionsBehavior.Editable = false;
            this.gviewSteamItems.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gviewSteamItems.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gviewSteamItems_RowCellClick);
            this.gviewSteamItems.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gviewSteamItems_CustomColumnDisplayText);
            this.gviewSteamItems.Click += new System.EventHandler(this.gviewSteamItems_Click);
            // 
            // bgwGetSteamItems
            // 
            this.bgwGetSteamItems.WorkerReportsProgress = true;
            this.bgwGetSteamItems.WorkerSupportsCancellation = true;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Sharp Plus";
            this.defaultLookAndFeel1.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.bar_txtProfileID,
            this.barButtonItem1,
            this.barProgressBar,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barSubItem2,
            this.barButtonItem5});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit_SteamProfile,
            this.repositoryItemProgressBar1});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Reload";
            this.barSubItem2.Id = 7;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Reload Items";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Reload Steam Items";
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ReloadSteamItems_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Load Items From File";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LoadItemsFromFile_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Save Items";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveItems_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Settings";
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_txtProfileID, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bar_txtProfileID
            // 
            this.bar_txtProfileID.Caption = "Steam Profile ID";
            this.bar_txtProfileID.Edit = this.repositoryItemTextEdit_SteamProfile;
            this.bar_txtProfileID.Id = 1;
            this.bar_txtProfileID.Name = "bar_txtProfileID";
            this.bar_txtProfileID.Width = 136;
            // 
            // repositoryItemTextEdit_SteamProfile
            // 
            this.repositoryItemTextEdit_SteamProfile.AutoHeight = false;
            this.repositoryItemTextEdit_SteamProfile.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit_SteamProfile.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit_SteamProfile.Mask.BeepOnError = true;
            this.repositoryItemTextEdit_SteamProfile.Mask.EditMask = "\\d*";
            this.repositoryItemTextEdit_SteamProfile.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit_SteamProfile.Name = "repositoryItemTextEdit_SteamProfile";
            this.repositoryItemTextEdit_SteamProfile.NullText = "Please Enter Your Profile ID Here.";
            this.repositoryItemTextEdit_SteamProfile.NullValuePrompt = "Please Enter Your Profile ID Here.";
            this.repositoryItemTextEdit_SteamProfile.EditValueChanged += new System.EventHandler(this.repositoryItemTextEdit_SteamProfile_EditValueChanged);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barProgressBar)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barProgressBar
            // 
            this.barProgressBar.CanOpenEdit = false;
            this.barProgressBar.Caption = "barEditItem1";
            this.barProgressBar.Edit = this.repositoryItemProgressBar1;
            this.barProgressBar.Id = 3;
            this.barProgressBar.Name = "barProgressBar";
            this.barProgressBar.Width = 250;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ShowTitle = true;
            this.repositoryItemProgressBar1.Step = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1287, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 623);
            this.barDockControlBottom.Size = new System.Drawing.Size(1287, 19);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 599);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1287, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 599);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Load Items From File";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // bgwGetPricesForMyItems
            // 
            this.bgwGetPricesForMyItems.WorkerReportsProgress = true;
            this.bgwGetPricesForMyItems.WorkerSupportsCancellation = true;
            // 
            // gridControl3
            // 
            this.gridControl3.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(2, 22);
            this.gridControl3.MainView = this.gviewTradeFor;
            this.gridControl3.MenuManager = this.barManager1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(1261, 200);
            this.gridControl3.TabIndex = 2;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gviewTradeFor});
            // 
            // gviewTradeFor
            // 
            this.gviewTradeFor.GridControl = this.gridControl3;
            this.gviewTradeFor.Name = "gviewTradeFor";
            this.gviewTradeFor.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl3);
            this.groupControl1.Location = new System.Drawing.Point(12, 395);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1265, 224);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Items To Trade For";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 642);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupSteamItems);
            this.Controls.Add(this.groupCSGLItems);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCSGLItems)).EndInit();
            this.groupCSGLItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupSteamItems)).EndInit();
            this.groupSteamItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewSteamItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_SteamProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewTradeFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwGetItemSchema;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewItems;
        private DevExpress.XtraEditors.GroupControl groupCSGLItems;
        private DevExpress.XtraEditors.GroupControl groupSteamItems;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewSteamItems;
        private System.ComponentModel.BackgroundWorker bgwGetSteamItems;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarEditItem bar_txtProfileID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit_SteamProfile;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.ComponentModel.BackgroundWorker bgwGetPricesForMyItems;
        private DevExpress.XtraBars.BarEditItem barProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewTradeFor;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;

    }
}


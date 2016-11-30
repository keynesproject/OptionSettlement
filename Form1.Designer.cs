namespace OptionSettlement
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInform = new System.Windows.Forms.DataGridView();
            this.DgvSStockSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSStockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSOptionSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSOptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSOptionPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSOptionBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSOptionSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSOptionVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSSettlement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSPreBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSPreSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSBuySpread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSSellSpread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTestDDE = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTestLoadCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.temiTestStrSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.temiTestTime = new System.Windows.Forms.ToolStripMenuItem();
            this.temiTestMessagebox = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerStatusTime = new System.Windows.Forms.Timer(this.components);
            this.TimerSettlementStock = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIndex = new System.Windows.Forms.TabPage();
            this.dgvInformIndex = new System.Windows.Forms.DataGridView();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.TimerSettlementIndex = new System.Windows.Forms.Timer(this.components);
            this.DgvIStockSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIStockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIOptionSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIOptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIOptionPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIOptionBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIOptionSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIOptionVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvISettlement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIPreBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIPreSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvIBuySpread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvISellSpread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInform)).BeginInit();
            this.msMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformIndex)).BeginInit();
            this.tabOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInform
            // 
            this.dgvInform.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInform.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInform.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInform.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvSStockSymbol,
            this.DgvSStockName,
            this.DgvSStockPrice,
            this.DgvSOptionSymbol,
            this.DgvSOptionName,
            this.DgvSOptionPrice,
            this.DgvSOptionBuy,
            this.DgvSOptionSell,
            this.DgvSOptionVolume,
            this.DgvSSettlement,
            this.DgvSPreBuy,
            this.DgvSPreSell,
            this.DgvSBuySpread,
            this.DgvSSellSpread});
            this.dgvInform.Location = new System.Drawing.Point(7, 3);
            this.dgvInform.Name = "dgvInform";
            this.dgvInform.RowHeadersVisible = false;
            this.dgvInform.RowTemplate.Height = 24;
            this.dgvInform.Size = new System.Drawing.Size(1007, 505);
            this.dgvInform.TabIndex = 1;
            // 
            // DgvSStockSymbol
            // 
            this.DgvSStockSymbol.HeaderText = "股票代號";
            this.DgvSStockSymbol.MaxInputLength = 10;
            this.DgvSStockSymbol.Name = "DgvSStockSymbol";
            this.DgvSStockSymbol.ReadOnly = true;
            this.DgvSStockSymbol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSStockName
            // 
            this.DgvSStockName.HeaderText = "股票名稱";
            this.DgvSStockName.MaxInputLength = 10;
            this.DgvSStockName.Name = "DgvSStockName";
            this.DgvSStockName.ReadOnly = true;
            this.DgvSStockName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSStockPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSStockPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSStockPrice.HeaderText = "股票成交價";
            this.DgvSStockPrice.MaxInputLength = 10;
            this.DgvSStockPrice.Name = "DgvSStockPrice";
            this.DgvSStockPrice.ReadOnly = true;
            this.DgvSStockPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSOptionSymbol
            // 
            this.DgvSOptionSymbol.HeaderText = "期貨代號";
            this.DgvSOptionSymbol.MaxInputLength = 10;
            this.DgvSOptionSymbol.Name = "DgvSOptionSymbol";
            this.DgvSOptionSymbol.ReadOnly = true;
            this.DgvSOptionSymbol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSOptionName
            // 
            this.DgvSOptionName.HeaderText = "期貨名稱";
            this.DgvSOptionName.MaxInputLength = 10;
            this.DgvSOptionName.Name = "DgvSOptionName";
            this.DgvSOptionName.ReadOnly = true;
            // 
            // DgvSOptionPrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSOptionPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvSOptionPrice.HeaderText = "期貨成交價";
            this.DgvSOptionPrice.MaxInputLength = 10;
            this.DgvSOptionPrice.Name = "DgvSOptionPrice";
            this.DgvSOptionPrice.ReadOnly = true;
            this.DgvSOptionPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSOptionBuy
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSOptionBuy.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvSOptionBuy.HeaderText = "期貨買價";
            this.DgvSOptionBuy.MaxInputLength = 10;
            this.DgvSOptionBuy.Name = "DgvSOptionBuy";
            this.DgvSOptionBuy.ReadOnly = true;
            this.DgvSOptionBuy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSOptionSell
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSOptionSell.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvSOptionSell.HeaderText = "期貨賣價";
            this.DgvSOptionSell.MaxInputLength = 10;
            this.DgvSOptionSell.Name = "DgvSOptionSell";
            this.DgvSOptionSell.ReadOnly = true;
            this.DgvSOptionSell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSOptionVolume
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSOptionVolume.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvSOptionVolume.HeaderText = "期貨成交量";
            this.DgvSOptionVolume.MaxInputLength = 10;
            this.DgvSOptionVolume.Name = "DgvSOptionVolume";
            this.DgvSOptionVolume.ReadOnly = true;
            // 
            // DgvSSettlement
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSSettlement.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvSSettlement.HeaderText = "預估結算價";
            this.DgvSSettlement.MaxInputLength = 10;
            this.DgvSSettlement.Name = "DgvSSettlement";
            this.DgvSSettlement.ReadOnly = true;
            this.DgvSSettlement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSPreBuy
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSPreBuy.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvSPreBuy.HeaderText = "掛買";
            this.DgvSPreBuy.MaxInputLength = 10;
            this.DgvSPreBuy.Name = "DgvSPreBuy";
            this.DgvSPreBuy.ReadOnly = true;
            // 
            // DgvSPreSell
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSPreSell.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvSPreSell.HeaderText = "掛賣";
            this.DgvSPreSell.MaxInputLength = 10;
            this.DgvSPreSell.Name = "DgvSPreSell";
            this.DgvSPreSell.ReadOnly = true;
            // 
            // DgvSBuySpread
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSBuySpread.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvSBuySpread.HeaderText = "買進期貨";
            this.DgvSBuySpread.MaxInputLength = 10;
            this.DgvSBuySpread.Name = "DgvSBuySpread";
            this.DgvSBuySpread.ReadOnly = true;
            this.DgvSBuySpread.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvSSellSpread
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSSellSpread.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvSSellSpread.HeaderText = "賣出期貨";
            this.DgvSSellSpread.MaxInputLength = 10;
            this.DgvSSellSpread.Name = "DgvSSellSpread";
            this.DgvSSellSpread.ReadOnly = true;
            this.DgvSSellSpread.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiTest,
            this.tsmiHelp});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1049, 24);
            this.msMenu.TabIndex = 3;
            this.msMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileOutput,
            this.toolStripSeparator1,
            this.tsmiFileExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(44, 20);
            this.tsmiFile.Text = "檔案";
            // 
            // tsmiFileOutput
            // 
            this.tsmiFileOutput.Name = "tsmiFileOutput";
            this.tsmiFileOutput.Size = new System.Drawing.Size(124, 22);
            this.tsmiFileOutput.Text = "輸出結果";
            this.tsmiFileOutput.Click += new System.EventHandler(this.tsmiFileOutput_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiFileExit
            // 
            this.tsmiFileExit.Name = "tsmiFileExit";
            this.tsmiFileExit.Size = new System.Drawing.Size(124, 22);
            this.tsmiFileExit.Text = "結束";
            this.tsmiFileExit.Click += new System.EventHandler(this.tsmiFileExit_Click);
            // 
            // tsmiTest
            // 
            this.tsmiTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTestDDE,
            this.tsmiTestLoadCSV,
            this.temiTestStrSplit,
            this.temiTestTime,
            this.temiTestMessagebox});
            this.tsmiTest.Name = "tsmiTest";
            this.tsmiTest.Size = new System.Drawing.Size(44, 20);
            this.tsmiTest.Text = "測試";
            // 
            // tsmiTestDDE
            // 
            this.tsmiTestDDE.Name = "tsmiTestDDE";
            this.tsmiTestDDE.Size = new System.Drawing.Size(149, 22);
            this.tsmiTestDDE.Text = "DDE指定數值";
            this.tsmiTestDDE.Click += new System.EventHandler(this.tsmiTestDDE_Click);
            // 
            // tsmiTestLoadCSV
            // 
            this.tsmiTestLoadCSV.Name = "tsmiTestLoadCSV";
            this.tsmiTestLoadCSV.Size = new System.Drawing.Size(149, 22);
            this.tsmiTestLoadCSV.Text = "讀取CSV";
            this.tsmiTestLoadCSV.Click += new System.EventHandler(this.tsmiTestLoadCSV_Click);
            // 
            // temiTestStrSplit
            // 
            this.temiTestStrSplit.Name = "temiTestStrSplit";
            this.temiTestStrSplit.Size = new System.Drawing.Size(149, 22);
            this.temiTestStrSplit.Text = "字串分割";
            this.temiTestStrSplit.Click += new System.EventHandler(this.temiTestStrSplit_Click);
            // 
            // temiTestTime
            // 
            this.temiTestTime.Name = "temiTestTime";
            this.temiTestTime.Size = new System.Drawing.Size(149, 22);
            this.temiTestTime.Text = "時間測試";
            this.temiTestTime.Click += new System.EventHandler(this.temiTestTime_Click);
            // 
            // temiTestMessagebox
            // 
            this.temiTestMessagebox.Name = "temiTestMessagebox";
            this.temiTestMessagebox.Size = new System.Drawing.Size(149, 22);
            this.temiTestMessagebox.Text = "提示訊息";
            this.temiTestMessagebox.Click += new System.EventHandler(this.temiTestMessagebox_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelpAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "說明";
            // 
            // tsmiHelpAbout
            // 
            this.tsmiHelpAbout.Name = "tsmiHelpAbout";
            this.tsmiHelpAbout.Size = new System.Drawing.Size(100, 22);
            this.tsmiHelpAbout.Text = "關於";
            // 
            // TimerStatusTime
            // 
            this.TimerStatusTime.Enabled = true;
            this.TimerStatusTime.Interval = 1000;
            this.TimerStatusTime.Tick += new System.EventHandler(this.TimerStatusTime_Tick);
            // 
            // TimerSettlementStock
            // 
            this.TimerSettlementStock.Interval = 5000;
            this.TimerSettlementStock.Tick += new System.EventHandler(this.TimerSettlementStock_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIndex);
            this.tabControl1.Controls.Add(this.tabOption);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 540);
            this.tabControl1.TabIndex = 4;
            // 
            // tabIndex
            // 
            this.tabIndex.Controls.Add(this.dgvInformIndex);
            this.tabIndex.Location = new System.Drawing.Point(4, 22);
            this.tabIndex.Name = "tabIndex";
            this.tabIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndex.Size = new System.Drawing.Size(1020, 514);
            this.tabIndex.TabIndex = 1;
            this.tabIndex.Text = "指數結算";
            this.tabIndex.UseVisualStyleBackColor = true;
            // 
            // dgvInformIndex
            // 
            this.dgvInformIndex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInformIndex.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInformIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInformIndex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvIStockSymbol,
            this.DgvIStockName,
            this.DgvIStockPrice,
            this.DgvIOptionSymbol,
            this.DgvIOptionName,
            this.DgvIOptionPrice,
            this.DgvIOptionBuy,
            this.DgvIOptionSell,
            this.DgvIOptionVolume,
            this.DgvISettlement,
            this.DgvIPreBuy,
            this.DgvIPreSell,
            this.DgvIBuySpread,
            this.DgvISellSpread});
            this.dgvInformIndex.Location = new System.Drawing.Point(7, 3);
            this.dgvInformIndex.Name = "dgvInformIndex";
            this.dgvInformIndex.RowHeadersVisible = false;
            this.dgvInformIndex.RowTemplate.Height = 24;
            this.dgvInformIndex.Size = new System.Drawing.Size(1007, 505);
            this.dgvInformIndex.TabIndex = 5;
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.dgvInform);
            this.tabOption.Location = new System.Drawing.Point(4, 22);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabOption.Size = new System.Drawing.Size(1020, 514);
            this.tabOption.TabIndex = 0;
            this.tabOption.Text = "股期結算";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // TimerSettlementIndex
            // 
            this.TimerSettlementIndex.Interval = 5000;
            this.TimerSettlementIndex.Tick += new System.EventHandler(this.TimerSettlementIndex_Tick);
            // 
            // DgvIStockSymbol
            // 
            this.DgvIStockSymbol.HeaderText = "指數代號";
            this.DgvIStockSymbol.MaxInputLength = 10;
            this.DgvIStockSymbol.Name = "DgvIStockSymbol";
            this.DgvIStockSymbol.ReadOnly = true;
            this.DgvIStockSymbol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIStockName
            // 
            this.DgvIStockName.HeaderText = "指數名稱";
            this.DgvIStockName.MaxInputLength = 10;
            this.DgvIStockName.Name = "DgvIStockName";
            this.DgvIStockName.ReadOnly = true;
            this.DgvIStockName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIStockPrice
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIStockPrice.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvIStockPrice.HeaderText = "指數成交價";
            this.DgvIStockPrice.MaxInputLength = 10;
            this.DgvIStockPrice.Name = "DgvIStockPrice";
            this.DgvIStockPrice.ReadOnly = true;
            this.DgvIStockPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIOptionSymbol
            // 
            this.DgvIOptionSymbol.HeaderText = "期指代號";
            this.DgvIOptionSymbol.MaxInputLength = 10;
            this.DgvIOptionSymbol.Name = "DgvIOptionSymbol";
            this.DgvIOptionSymbol.ReadOnly = true;
            this.DgvIOptionSymbol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIOptionName
            // 
            this.DgvIOptionName.HeaderText = "期指名稱";
            this.DgvIOptionName.MaxInputLength = 10;
            this.DgvIOptionName.Name = "DgvIOptionName";
            this.DgvIOptionName.ReadOnly = true;
            // 
            // DgvIOptionPrice
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIOptionPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.DgvIOptionPrice.HeaderText = "期指成交價";
            this.DgvIOptionPrice.MaxInputLength = 10;
            this.DgvIOptionPrice.Name = "DgvIOptionPrice";
            this.DgvIOptionPrice.ReadOnly = true;
            this.DgvIOptionPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIOptionBuy
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIOptionBuy.DefaultCellStyle = dataGridViewCellStyle13;
            this.DgvIOptionBuy.HeaderText = "期指買價";
            this.DgvIOptionBuy.MaxInputLength = 10;
            this.DgvIOptionBuy.Name = "DgvIOptionBuy";
            this.DgvIOptionBuy.ReadOnly = true;
            this.DgvIOptionBuy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIOptionSell
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIOptionSell.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvIOptionSell.HeaderText = "期指賣價";
            this.DgvIOptionSell.MaxInputLength = 10;
            this.DgvIOptionSell.Name = "DgvIOptionSell";
            this.DgvIOptionSell.ReadOnly = true;
            this.DgvIOptionSell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIOptionVolume
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIOptionVolume.DefaultCellStyle = dataGridViewCellStyle15;
            this.DgvIOptionVolume.HeaderText = "期指成交量";
            this.DgvIOptionVolume.MaxInputLength = 10;
            this.DgvIOptionVolume.Name = "DgvIOptionVolume";
            this.DgvIOptionVolume.ReadOnly = true;
            // 
            // DgvISettlement
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvISettlement.DefaultCellStyle = dataGridViewCellStyle16;
            this.DgvISettlement.HeaderText = "預估結算價";
            this.DgvISettlement.MaxInputLength = 10;
            this.DgvISettlement.Name = "DgvISettlement";
            this.DgvISettlement.ReadOnly = true;
            this.DgvISettlement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvIPreBuy
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIPreBuy.DefaultCellStyle = dataGridViewCellStyle17;
            this.DgvIPreBuy.HeaderText = "掛買";
            this.DgvIPreBuy.MaxInputLength = 10;
            this.DgvIPreBuy.Name = "DgvIPreBuy";
            this.DgvIPreBuy.ReadOnly = true;
            // 
            // DgvIPreSell
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIPreSell.DefaultCellStyle = dataGridViewCellStyle18;
            this.DgvIPreSell.HeaderText = "掛賣";
            this.DgvIPreSell.MaxInputLength = 10;
            this.DgvIPreSell.Name = "DgvIPreSell";
            this.DgvIPreSell.ReadOnly = true;
            // 
            // DgvIBuySpread
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvIBuySpread.DefaultCellStyle = dataGridViewCellStyle19;
            this.DgvIBuySpread.HeaderText = "買進期指";
            this.DgvIBuySpread.MaxInputLength = 10;
            this.DgvIBuySpread.Name = "DgvIBuySpread";
            this.DgvIBuySpread.ReadOnly = true;
            this.DgvIBuySpread.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvISellSpread
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvISellSpread.DefaultCellStyle = dataGridViewCellStyle20;
            this.DgvISellSpread.HeaderText = "賣出期指";
            this.DgvISellSpread.MaxInputLength = 10;
            this.DgvISellSpread.Name = "DgvISellSpread";
            this.DgvISellSpread.ReadOnly = true;
            this.DgvISellSpread.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 589);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "期貨結算價計算";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInform)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabIndex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformIndex)).EndInit();
            this.tabOption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvInform;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestDDE;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestLoadCSV;
        private System.Windows.Forms.ToolStripMenuItem temiTestStrSplit;
        private System.Windows.Forms.ToolStripMenuItem temiTestTime;
        private System.Windows.Forms.Timer TimerStatusTime;
        private System.Windows.Forms.Timer TimerSettlementStock;
        private System.Windows.Forms.ToolStripMenuItem temiTestMessagebox;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelpAbout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIndex;
        private System.Windows.Forms.TabPage tabOption;
        private System.Windows.Forms.DataGridView dgvInformIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSStockSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSStockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSOptionSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSOptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSOptionPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSOptionBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSOptionSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSOptionVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSSettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSPreBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSPreSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSBuySpread;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSSellSpread;
        private System.Windows.Forms.Timer TimerSettlementIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIStockSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIStockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIOptionSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIOptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIOptionPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIOptionBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIOptionSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIOptionVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvISettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIPreBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIPreSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvIBuySpread;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvISellSpread;
    }
}


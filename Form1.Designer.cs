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
            this.dgvInform = new System.Windows.Forms.DataGridView();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTestDDE = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTestLoadCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.temiTestStrSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.temiTestTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerStatusTime = new System.Windows.Forms.Timer(this.components);
            this.TimerCheck = new System.Windows.Forms.Timer(this.components);
            this.TimerSettlement = new System.Windows.Forms.Timer(this.components);
            this.DgvStockSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvStockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvOptionSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvOptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvOptionPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvOptionBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvOptionSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSettlement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSpread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInform)).BeginInit();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInform
            // 
            this.dgvInform.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInform.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInform.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInform.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvStockSymbol,
            this.DgvStockName,
            this.DgvStockPrice,
            this.DgvOptionSymbol,
            this.DgvOptionName,
            this.DgvOptionPrice,
            this.DgvOptionBuy,
            this.DgvOptionSell,
            this.DgvSettlement,
            this.DgvSpread});
            this.dgvInform.Location = new System.Drawing.Point(11, 27);
            this.dgvInform.Name = "dgvInform";
            this.dgvInform.RowHeadersVisible = false;
            this.dgvInform.RowTemplate.Height = 24;
            this.dgvInform.Size = new System.Drawing.Size(903, 519);
            this.dgvInform.TabIndex = 1;
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiTest,
            this.tsmiAbout});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(926, 24);
            this.msMenu.TabIndex = 3;
            this.msMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(44, 20);
            this.tsmiFile.Text = "檔案";
            // 
            // tsmiTest
            // 
            this.tsmiTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTestDDE,
            this.tsmiTestLoadCSV,
            this.temiTestStrSplit,
            this.temiTestTime});
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
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(44, 20);
            this.tsmiAbout.Text = "關於";
            // 
            // TimerStatusTime
            // 
            this.TimerStatusTime.Enabled = true;
            this.TimerStatusTime.Interval = 1000;
            this.TimerStatusTime.Tick += new System.EventHandler(this.TimerStatusTime_Tick);
            // 
            // TimerCheck
            // 
            this.TimerCheck.Enabled = true;
            this.TimerCheck.Interval = 500;
            this.TimerCheck.Tick += new System.EventHandler(this.TimerCheck_Tick);
            // 
            // TimerSettlement
            // 
            this.TimerSettlement.Interval = 5000;
            this.TimerSettlement.Tick += new System.EventHandler(this.TimerSettlement_Tick);
            // 
            // DgvStockSymbol
            // 
            this.DgvStockSymbol.HeaderText = "股票代號";
            this.DgvStockSymbol.Name = "DgvStockSymbol";
            this.DgvStockSymbol.ReadOnly = true;
            // 
            // DgvStockName
            // 
            this.DgvStockName.HeaderText = "股票名稱";
            this.DgvStockName.Name = "DgvStockName";
            this.DgvStockName.ReadOnly = true;
            // 
            // DgvStockPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvStockPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvStockPrice.HeaderText = "股票成交價";
            this.DgvStockPrice.Name = "DgvStockPrice";
            this.DgvStockPrice.ReadOnly = true;
            // 
            // DgvOptionSymbol
            // 
            this.DgvOptionSymbol.HeaderText = "期貨代號";
            this.DgvOptionSymbol.Name = "DgvOptionSymbol";
            this.DgvOptionSymbol.ReadOnly = true;
            // 
            // DgvOptionName
            // 
            this.DgvOptionName.HeaderText = "期貨名稱";
            this.DgvOptionName.Name = "DgvOptionName";
            this.DgvOptionName.ReadOnly = true;
            // 
            // DgvOptionPrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvOptionPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvOptionPrice.HeaderText = "期貨成交價";
            this.DgvOptionPrice.Name = "DgvOptionPrice";
            this.DgvOptionPrice.ReadOnly = true;
            // 
            // DgvOptionBuy
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvOptionBuy.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvOptionBuy.HeaderText = "期貨買價";
            this.DgvOptionBuy.Name = "DgvOptionBuy";
            this.DgvOptionBuy.ReadOnly = true;
            // 
            // DgvOptionSell
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvOptionSell.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvOptionSell.HeaderText = "期貨賣價";
            this.DgvOptionSell.Name = "DgvOptionSell";
            this.DgvOptionSell.ReadOnly = true;
            // 
            // DgvSettlement
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSettlement.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvSettlement.HeaderText = "預估結算價";
            this.DgvSettlement.Name = "DgvSettlement";
            this.DgvSettlement.ReadOnly = true;
            // 
            // DgvSpread
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvSpread.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvSpread.HeaderText = "結算價差";
            this.DgvSpread.Name = "DgvSpread";
            this.DgvSpread.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 577);
            this.Controls.Add(this.dgvInform);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "期貨結算價計算";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInform)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvInform;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvStockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvOptionNo;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestDDE;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestLoadCSV;
        private System.Windows.Forms.ToolStripMenuItem temiTestStrSplit;
        private System.Windows.Forms.ToolStripMenuItem temiTestTime;
        private System.Windows.Forms.Timer TimerStatusTime;
        private System.Windows.Forms.Timer TimerCheck;
        private System.Windows.Forms.Timer TimerSettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvStockSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvStockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvOptionSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvOptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvOptionPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvOptionBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvOptionSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvSpread;
    }
}


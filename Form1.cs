using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 股票期或 12:30-13:25 661個  55分鐘+1 
 * 指數期貨  1:00~ 1:25 301個  
 * 每5秒鐘搓合一次
 */

namespace OptionSettlement
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public enum DgvColumnCell
        {
            eSTOCK_SYMBOL = 0,        //股票代號;// 
            eSTOCK_NAME,              //股票名稱;//
            eSTOCK_PRICE,             //股票成交價;//
            eOPTION_SYMBOL,           //期貨代號;//
            eOPTION_NAME,             //期貨名稱;//
            eOPTION_PRICE,            //期貨成交價;//
            eOPTION_BUY,              //期貨買價;//
            eOPTION_SELL,             //期貨賣價;//
            eOPTION_VOLUME,           //期貨成交量;//
            eOPTION_SETTLEMENT,       //預估結算價;//
            eOPTION_PRE_BUY,          //掛買;//
            eOPTION_PRE_SELL,         //掛賣;//
            eOPTION_BUY_SPREAD,       //買進期貨;//
            eOPTION_SELL_SPREAD       //賣出期貨;//
        };

        /// <summary>
        /// 股期結算 data gride view 的欄位名稱
        /// </summary>
        private static readonly string[] DgvCellNameStock =
        {
            "DgvSStockSymbol",
            "DgvSStockName",
            "DgvSStockPrice",
            "DgvSOptionSymbol",
            "DgvSOptionName",
            "DgvSOptionPrice",
            "DgvSOptionBuy",
            "DgvSOptionSell",
            "DgvSOptionVolume",
            "DgvSSettlement",
            "DgvSPreBuy",
            "DgvSPreSell",
            "DgvSBuySpread",
            "DgvSSellSpread"
        };

        /// <summary>
        /// 指數結算 data gride view 的欄位名稱
        /// </summary>
        private static readonly string[] DgvCellNameIndex =
        {
            "DgvIStockSymbol",
            "DgvIStockName",
            "DgvIStockPrice",
            "DgvIOptionSymbol",
            "DgvIOptionName",
            "DgvIOptionPrice",
            "DgvIOptionBuy",
            "DgvIOptionSell",
            "DgvIOptionVolume",
            "DgvISettlement",
            "DgvIPreBuy",
            "DgvIPreSell",
            "DgvIBuySpread",
            "DgvISellSpread"
        };

        /// <summary>
        /// 股期類結算搓合數量
        /// </summary>
        private const int m_nSettlementStockNums = 661;
        //private const int m_nSettlementStockNums = 301;

        /// <summary>
        /// 指數類結算搓合數量
        /// </summary>
        private const int m_nSettlementIndexNums = 301;

        /// <summary>
        /// 股期結算價起算的起始時間
        /// </summary>
        private const string m_strAssignTimeStartStock = "12:30";
        //private const string m_strAssignTimeStartStock = "11:30";

        /// <summary>
        /// 指數期貨結算價起算的起始時間
        /// </summary>
        private const string m_strAssignTimeStartIndex = "13:00";
        //private const string m_strAssignTimeStartIndex = "11:30";

        /// <summary>
        /// 結算價起算的結束時間
        /// </summary>
        private const string m_strAssignTimeEnd = "13:25";
        //private const string m_strAssignTimeEnd = "13:30";

        /// <summary>
        /// 視窗底部狀態列
        /// </summary>
        protected StatusBar m_MainStatusBar = new StatusBar();

        /// <summary>
        /// 視窗底部狀態列資訊 
        /// </summary>
        protected StatusBarPanel m_StatusPanel = new StatusBarPanel();

        /// <summary>
        /// 視窗底部狀態列時間資訊
        /// </summary>
        protected StatusBarPanel m_DatetimePanel = new StatusBarPanel();

        /// <summary>
        /// 
        /// </summary>
        private DDEClient m_DdeClient = new DDEClient();

        /// <summary>
        /// 成對股票期貨商品代號,內容為[股期代號,對應股票代號,]
        /// </summary>
        private Dictionary<string, string> m_dicSymbolStock;

        /// <summary>
        /// 成對指數期貨商品代號,內容為[指數期貨,對應指數代號]
        /// </summary>
        private Dictionary<string, string> m_dicSymbolIndex;

        /// <summary>
        /// 紀錄以 股票或期貨代號 為 KEY, List<DataGridViewRow> 為 Value 的表. 
        /// [ (string)股票或期貨代號, List<DataGridViewRow> ]
        /// </summary>
        private Hashtable m_htProductRowsNo = new Hashtable();
        
        /// <summary>
        /// 紀錄以 股票代號 為 KEY, Settlement物件 為 Value 的表.
        /// [ (string)股票代號, Settlement ]
        /// </summary>
        private Hashtable m_htStockSettlement = new Hashtable();

        /// <summary>
        /// 紀錄以 指數代號 為 KEY, Settlement物件 為 Value 的表.
        /// [ (string)指數代號, Settlement ]
        /// </summary>
        private Hashtable m_htIndexSettlement = new Hashtable();

        public FormMain()
        {
            InitializeComponent();

            CreateStatusBar();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.dgvInform.SortCompare += new DataGridViewSortCompareEventHandler(this.dgvInformSortCompare);
            this.dgvInformIndex.SortCompare += new DataGridViewSortCompareEventHandler(this.dgvInformSortCompare);
        }

        private void dgvInformSortCompare(object sender,DataGridViewSortCompareEventArgs e)
        {
            if (   e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eSTOCK_PRICE]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_PRICE]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_BUY]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_SELL]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_VOLUME]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_SETTLEMENT]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_PRE_BUY]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_PRE_SELL]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_BUY_SPREAD]
                || e.Column.Name == DgvCellNameStock[(int)DgvColumnCell.eOPTION_SELL_SPREAD]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eSTOCK_PRICE]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_PRICE]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_BUY]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_SELL]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_VOLUME]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_SETTLEMENT]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_PRE_BUY]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_PRE_SELL]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_BUY_SPREAD]
                || e.Column.Name == DgvCellNameIndex[(int)DgvColumnCell.eOPTION_SELL_SPREAD])
            {
                if(    e.CellValue1.ToString() == "null" 
                    || e.CellValue2.ToString() == "null" )
                {
                    e.SortResult = 0;
                }
                else
                {
                    if (Convert.ToDouble(e.CellValue1) < Convert.ToDouble(e.CellValue2))
                    {
                        e.SortResult = -1;
                    }
                    else if (Convert.ToDouble(e.CellValue1) == Convert.ToDouble(e.CellValue2))
                    {
                        e.SortResult = 0;
                    }
                    else
                    {
                        e.SortResult = 1;
                    }
                }
            }
            else
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
            }

            e.Handled = true;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            
            SetStatusInformation("資料讀取中.....");

            this.CreateProductDdeData();
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_DdeClient.CloseDdeClient();
        }

        /// <summary>
        /// 建立狀態資訊列,視窗最底下的那個資訊列
        /// </summary>
        private void CreateStatusBar()
        {
            // Set first panel properties and add to StatusBar
            m_StatusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            m_StatusPanel.Text = "Application started. No action yet.";
            m_StatusPanel.ToolTipText = "Last Activity";
            m_StatusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            m_MainStatusBar.Panels.Add(m_StatusPanel);

            // Set second panel properties and add to StatusBar
            m_DatetimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            m_DatetimePanel.ToolTipText = "DateTime: " + System.DateTime.Now.ToString();
            m_DatetimePanel.Text = System.DateTime.Now.ToLongTimeString();
            m_DatetimePanel.AutoSize = StatusBarPanelAutoSize.Contents;
            m_MainStatusBar.Panels.Add(m_DatetimePanel);

            m_MainStatusBar.ShowPanels = true;

            // Add StatusBar to Form controls
            this.Controls.Add(m_MainStatusBar);
        }

        /// <summary>
        /// 設定DataGridView的Cell的字型顏色,
        /// 當 新值 大於 基準值 則設定為紅色
        ///    新值 小於 基準值 則設定為綠色
        ///    新值 等於 基準值 則設定為黑色
        /// </summary>
        /// <param name="BaseValue">基準值</param>
        /// <param name="CurrentValue">新值</param>
        /// <param name="Cell">要更改顏色的Cell</param>
        private void SetFontColor(string BaseValue, string CurrentValue, DataGridViewCell Cell)
        {
            if (string.Compare(BaseValue, "null") == 0 || BaseValue.Length == 0 )
                return;

            if (string.Compare(CurrentValue, "null") == 0 || CurrentValue.Length == 0 )
                return;

            float Base = float.Parse(BaseValue);
            float Current = float.Parse(CurrentValue);
            
            if (Current > Base)
            {
                Cell.Style.ForeColor = Color.Red;
            }
            else if (Current < Base)
            {
                Cell.Style.ForeColor = Color.Green;
            }
            else
            {
                Cell.Style.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 建立DDE商品連結
        /// </summary>
        /// <param name="DicSymbol"></param>
        /// <returns></returns>
        private bool CreateDdeLink( Dictionary<string, string> DicSymbol, bool IsStock )
        {
            //建立DDE連線;//
            if (m_DdeClient.CreateDdeClient("YES", "DQ", DicSymbol) == true)
            {
                this.CreateProductStockDgvData(ref m_DdeClient, DicSymbol, IsStock);
            }
            else
            {
                //顯示DDE連線錯誤訊息;//
                if (MessageBox.Show("無法連結 DDE Server, 請開啟 YesWin !", "無法連線",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                {
                    return CreateDdeLink(DicSymbol, IsStock);
                }
                else
                {
                    Application.Exit();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 建立商品資訊
        /// </summary>
        private void CreateProductDdeData()
        {
            //讀取股期商品CVS資料;//
            DataImport DataImport = new DataImport();           
            m_dicSymbolStock = DataImport.ImportStockCSV("./StockInfo.csv");

            //讀取指數商品CVS代號;//
            m_dicSymbolIndex = DataImport.ImportIndexCSV("./IndexInfo.csv");

            //建立股票期貨類的DDE連線;//
            if (!CreateDdeLink(m_dicSymbolStock, true))
                return;

            //建立指數期貨類的DDE連線;//
            if (!CreateDdeLink(m_dicSymbolIndex, false))
                return;

            DataImport = null;
        }
        
        /// <summary>
        /// DDE Server 有資料更新時會通知的函數
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DdeAdvice(object sender, List<string> args)
        {
            //取得商品代號;//
            string strSymbol = args[(int)DDEClient.ItemField.eSymbol];
            if (m_htProductRowsNo.ContainsKey(strSymbol))
            {
                //取得更新資料所在的列編號;//
                List<DataGridViewRow> Product = (List<DataGridViewRow>)m_htProductRowsNo[strSymbol];
                foreach (DataGridViewRow Rows in (List<DataGridViewRow>)m_htProductRowsNo[strSymbol])
                {
                    if (string.Compare(Rows.Cells[(int)DgvColumnCell.eSTOCK_SYMBOL].Value.ToString(), strSymbol) == 0)
                    {
                        //表示為股期的股票部分更新,只更新列表的股票成交價;//
                        Rows.Cells[(int)DgvColumnCell.eSTOCK_PRICE].Value = args[(int)DDEClient.ItemField.ePrice];

                        //設定字型顏色;//
                        string PreviousPrice = args[(int)DDEClient.ItemField.eReference];
                        SetFontColor(PreviousPrice, args[(int)DDEClient.ItemField.ePrice], Rows.Cells[(int)DgvColumnCell.eSTOCK_PRICE]);                        
                    }
                    else if (string.Compare(Rows.Cells[(int)DgvColumnCell.eOPTION_SYMBOL].Value.ToString(), strSymbol) == 0)
                    {
                        //表示為股期類的資料更新,更新列表的期貨成交價,買價,賣價,成交量;//
                        Rows.Cells[(int)DgvColumnCell.eOPTION_PRICE].Value = args[(int)DDEClient.ItemField.ePrice];
                        Rows.Cells[(int)DgvColumnCell.eOPTION_BUY].Value = args[(int)DDEClient.ItemField.eBidPrice];
                        Rows.Cells[(int)DgvColumnCell.eOPTION_SELL].Value = args[(int)DDEClient.ItemField.eAskPrice];
                        Rows.Cells[(int)DgvColumnCell.eOPTION_VOLUME].Value = args[(int)DDEClient.ItemField.eCumulativeVolume];

                        //設定字型顏色;//
                        string ReferencePrice = args[(int)DDEClient.ItemField.eReference];
                        SetFontColor(ReferencePrice, args[(int)DDEClient.ItemField.ePrice], Rows.Cells[(int)DgvColumnCell.eOPTION_PRICE]);
                        SetFontColor(ReferencePrice, args[(int)DDEClient.ItemField.eBidPrice], Rows.Cells[(int)DgvColumnCell.eOPTION_BUY]);
                        SetFontColor(ReferencePrice, args[(int)DDEClient.ItemField.eAskPrice], Rows.Cells[(int)DgvColumnCell.eOPTION_SELL]);                        
                    }
                }
            }
        }

        /// <summary>
        /// 建立股票期貨商品資料表格
        /// </summary>
        /// <param name="DdeClient"></param>
        /// <param name="DicSymbol">成對商品代號[股票期貨代號,對應股票代號]</param>
        private void CreateProductStockDgvData( ref DDEClient DdeClient, Dictionary<string, string> DicSymbol, bool IsStock )
        {
            //建立商品資料;//
            foreach (KeyValuePair<string, string> Item in DicSymbol)
            {
                //取得股票及期貨資料;//
                List<string> listStockData = m_DdeClient.GetProductData(Item.Value);
                List<string> listOptionData = m_DdeClient.GetProductData(Item.Key);

                //判斷有無取得資料;//
                if (listStockData == null || listOptionData == null)
                    continue;
                
                //DataGridView建立列的資料;//
                string[] arrRowData =
                {
                    listStockData[(int)DDEClient.ItemField.eSymbol],    //股票代號;//
                    listStockData[(int)DDEClient.ItemField.eName],      //股票名稱;//
                    listStockData[(int)DDEClient.ItemField.ePrice],     //股票成交價;//
                    listOptionData[(int)DDEClient.ItemField.eSymbol],   //期貨代號;//
                    listOptionData[(int)DDEClient.ItemField.eName],     //期貨名稱;//
                    listOptionData[(int)DDEClient.ItemField.ePrice],    //期貨成交價;//
                    listOptionData[(int)DDEClient.ItemField.eBidPrice], //期貨買價;//
                    listOptionData[(int)DDEClient.ItemField.eAskPrice], //期貨賣價;//
                    listOptionData[(int)DDEClient.ItemField.eCumulativeVolume], //期貨成交交量;//
                    "null",                                             //預估結算價;//
                    "0",                                                //掛買;//
                    "0",                                                //掛賣;//
                    "0",                                                //賣出期貨買價價差;//
                    "0"                                                 //買進期貨賣價價差;//                    
                };

                //增加一列資料,並取得Row的編號及Row資料;//
                DataGridViewRow Rows;
                if (IsStock)
                {
                    int RowIdX = dgvInform.Rows.Add(arrRowData);
                    Rows = dgvInform.Rows[RowIdX];
                }
                else
                {
                    int RowIdX = dgvInformIndex.Rows.Add(arrRowData);
                    Rows = dgvInformIndex.Rows[RowIdX];
                }

                //判斷此資料是否已經設定過變更不同的增加方式;//
                if ( m_htProductRowsNo.ContainsKey(listStockData[(int)DDEClient.ItemField.eSymbol]) == true )
                {
                    //紀錄商品資料所在的Rows;//
                    ((List<DataGridViewRow>)m_htProductRowsNo[listStockData[(int)DDEClient.ItemField.eSymbol]]).Add(Rows);
                }
                else
                {
                    List<DataGridViewRow> RowLists = new List<DataGridViewRow>();
                    RowLists.Add(Rows);
                    m_htProductRowsNo.Add(listStockData[(int)DDEClient.ItemField.eSymbol], RowLists);
                }

                if (m_htProductRowsNo.ContainsKey(listOptionData[(int)DDEClient.ItemField.eSymbol]) == true)
                {
                    //紀錄商品資料所在的Rows;//
                    ((List<DataGridViewRow>)m_htProductRowsNo[listOptionData[(int)DDEClient.ItemField.eSymbol]]).Add(Rows);                    
                }   
                else
                {
                    List<DataGridViewRow> RowLists = new List<DataGridViewRow>();
                    RowLists.Add(Rows);
                    m_htProductRowsNo.Add(listOptionData[(int)DDEClient.ItemField.eSymbol], RowLists);
                }
                                
                if (IsStock)
                {
                    //新增股票的結算價計算物件;//
                    if (m_htStockSettlement.Contains(listStockData[(int)DDEClient.ItemField.eSymbol]) == false)
                    {
                        Settlement StockSettlement = new Settlement(m_nSettlementStockNums);
                        m_htStockSettlement.Add(listStockData[(int)DDEClient.ItemField.eSymbol], StockSettlement);
                    }
                }
                else
                {
                    //新增指數的結算價計算物件;//
                    if (m_htIndexSettlement.Contains(listStockData[(int)DDEClient.ItemField.eSymbol]) == false)
                    {
                        Settlement StockSettlement = new Settlement(m_nSettlementIndexNums);
                        m_htIndexSettlement.Add(listStockData[(int)DDEClient.ItemField.eSymbol], StockSettlement);
                    }
                }

                string ReferencePrice = listStockData[(int)DDEClient.ItemField.eReference];
                SetFontColor(ReferencePrice, listStockData[(int)DDEClient.ItemField.ePrice], Rows.Cells[(int)DgvColumnCell.eSTOCK_PRICE]);
                ReferencePrice = listOptionData[(int)DDEClient.ItemField.eReference];
                SetFontColor(ReferencePrice, listOptionData[(int)DDEClient.ItemField.ePrice], Rows.Cells[(int)DgvColumnCell.eOPTION_PRICE]);
                SetFontColor(ReferencePrice, listOptionData[(int)DDEClient.ItemField.eBidPrice], Rows.Cells[(int)DgvColumnCell.eOPTION_BUY]);
                SetFontColor(ReferencePrice, listOptionData[(int)DDEClient.ItemField.eAskPrice], Rows.Cells[(int)DgvColumnCell.eOPTION_SELL]);
                
                //設定DDE更新資料的回Call Function;//
                DdeClient.mEventDdeAdvice += DdeAdvice;
            }
        }

        /// <summary>
        /// 設定底部資訊列訊息
        /// </summary>
        /// <param name="strInfo">要顯示的訊息</param>
        private void SetStatusInformation( string strInfo )
        {
            m_StatusPanel.Text = strInfo;
        }

        /// <summary>
        /// 指定要顯示的訊息類型
        /// </summary>
        /// <param name="InformType"></param>
        private void SetStatusInformation( int InformType )
        {
            switch(InformType)
            {
                case 0:
                    SetStatusInformation("未到指定時間: " + m_strAssignTimeStartStock );
                    break;

                case 1:
                    SetStatusInformation("已到指定時間: " + m_strAssignTimeStartStock + ", 開始計算股票期貨結算價!");
                    break;

                case 2:
                    SetStatusInformation("已超過指定時間: " + m_strAssignTimeStartStock);
                    break;

                case 3:
                    SetStatusInformation("已超過結束時間: " + m_strAssignTimeEnd);
                    break;

                case 4:
                    SetStatusInformation("已到指定時間: " + m_strAssignTimeStartIndex + ", 開始計算股票期貨及指數期貨結算價!");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 檢查時間是否在指定的開始時間的5秒之內
        /// </summary>
        /// <param name="strTimeStart">起始時間(24時制),EX:13:00</param>
        /// <param name="strTimeEnd">結束時間(24時制),EX:15:30</param>
        /// <returns>0:表示時間未到, 1:表示已到指定時間, 2:表示超過指定時間5秒, 3:表示超過結束時間, 4:錯誤的數值</returns>
        private int CheckOnTimeLine( string strTimeStart, string strTimeEnd )
        {
            //取得現在時間;//
            DateTime dtTimeNow = new DateTime();
            dtTimeNow = DateTime.Now;

            //設定指定時間區間;//
            DateTime dtTimeAssignStart = new DateTime();
            DateTime dtTimeAssignEnd = new DateTime();
            dtTimeAssignStart = Convert.ToDateTime(strTimeStart);
            dtTimeAssignEnd = Convert.ToDateTime(strTimeEnd);

            //判斷現在時間是否在指定區間之間;//
            int nResult = DateTime.Compare(dtTimeNow, dtTimeAssignStart);

            if (nResult == 0)
            {
                //表示已到指定時間12:30;//
                Console.WriteLine("The same time as {0}", dtTimeAssignStart);
                return 1;
            }
            else if (nResult < 0)
            {
                //表示未到12:30;//
                Console.WriteLine("Now Time {0}, Not to come {1}", dtTimeNow, dtTimeAssignStart);
                return 0;
            }
            else
            {
                //表示經過指定時間12:30,在比較是否在結束時間13:25前;//
                nResult = DateTime.Compare(dtTimeNow, dtTimeAssignEnd);
                if (nResult < 0)
                {
                    //表示現在時間在指定時間之間;//
                    //檢查時間分鐘是否在指定的起始時間
                    if (dtTimeNow.Minute == dtTimeAssignStart.Minute)
                    {
                        //檢視誤差時間是否在5秒之內;//
                        if (dtTimeNow.Second - dtTimeAssignStart.Second <= 5)
                        {
                            //表示時間只經過起始時間5秒內;//
                            return 1;
                        }
                        else
                        {
                            Console.WriteLine("Now Time {0}, Overtime {1} seconds.", dtTimeNow, dtTimeNow.Second);
                            return 2;
                        }
                    }
                    else
                    {
                        //表示現在時間已經大於起始指定時間1分鐘以上;//
                        Console.WriteLine("Now Time {0}, Overtime {1} minutes.", dtTimeNow, dtTimeNow.Minute);
                        return 2;
                    }
                }
                else
                {
                    //表示已超過指定結束時間13:25;//
                    Console.WriteLine("Now Time {0}, Overtime {1}.", dtTimeNow, dtTimeAssignEnd);
                    return 3;
                }
            }

            return 4;
        }

        /// <summary>
        /// 每隔一秒更新一次時間，顯示於視窗右下角的資訊,並檢查時間是否開始計算結算資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerStatusTime_Tick(object sender, EventArgs e)
        {
            //更新時間資訊;//
            m_DatetimePanel.ToolTipText = "DateTime: " + System.DateTime.Now.ToString();
            m_DatetimePanel.Text = System.DateTime.Now.ToLongTimeString();

            //檢查時間是否在12:30-1點25之間;//
            if (TimerSettlementStock.Enabled == false)
            {
                int nCheckTime = CheckOnTimeLine(m_strAssignTimeStartStock, m_strAssignTimeEnd);
                if (nCheckTime == 1)
                {
                    //開啟結算價計算;//
                    TimerSettlementStock.Enabled = true;
                    TimerSettlementStock.Start();

                    this.SetStatusInformation(1);
                }
                else
                {
                    this.SetStatusInformation(nCheckTime);
                }
            }

            //檢查時間是否在13:00-1點25之間;//
            if (TimerSettlementIndex.Enabled == false)
            {
                int nCheckTime = CheckOnTimeLine(m_strAssignTimeStartIndex, m_strAssignTimeEnd);
                if (nCheckTime == 1)
                {
                    //開啟結算價計算;//
                    TimerSettlementIndex.Enabled = true;
                    TimerSettlementIndex.Start();

                    this.SetStatusInformation(4);
                }
                else
                {
                    if(TimerSettlementStock.Enabled == false)
                        this.SetStatusInformation(nCheckTime);
                }                
            }
        }

        /// <summary>
        /// 每隔5秒取得股票成交價,並計算結算價格後,顯示在列表上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSettlementStock_Tick(object sender, EventArgs e)
        {
            //計算股期結算價;//
            CaculateSettlement(m_htStockSettlement);
            
            //計算時間是否超過指定的結束時間;//
            int nCheckTime = this.CheckOnTimeLine( m_strAssignTimeStartStock, m_strAssignTimeEnd );
            if(nCheckTime == 3 )
            {
                //關閉結算計時;//
                TimerSettlementStock.Enabled = false;
            }
        }

        /// <summary>
        /// 每隔5秒取得指數成交價,並計算結算價格後,顯示在列表上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSettlementIndex_Tick(object sender, EventArgs e)
        {            
            //計算指數結算價;//
            CaculateSettlement(m_htIndexSettlement);

            //計算時間是否超過指定的結束時間;//
            int nCheckTime = this.CheckOnTimeLine(m_strAssignTimeStartIndex, m_strAssignTimeEnd);
            if (nCheckTime == 3)
            {
                //關閉結算計時;//
                TimerSettlementIndex.Enabled = false;
            }
        }

        /// <summary>
        /// 計算結算價
        /// </summary>
        /// <param name="htSettlement"></param>
        private void CaculateSettlement(Hashtable htSettlement)
        {
            //取得成交價,並計算結算價格;//
            //m_htProductRowsNo;
            //m_htStockSettlement;
            //m_htIndexSettlement;
            foreach (DictionaryEntry DE in htSettlement)
            {
                string strSymbol = DE.Key.ToString();
                if (m_htProductRowsNo.ContainsKey(strSymbol))
                {
                    //1.取得結算價計算物件;//
                    Settlement StockSettlement = (Settlement)DE.Value;

                    //2.取得列表或指數的成交價;//
                    string strNewStockPrice;
                    List<DataGridViewRow> RowList = (List<DataGridViewRow>)m_htProductRowsNo[strSymbol];
                    strNewStockPrice = RowList[0].Cells[(int)DgvColumnCell.eSTOCK_PRICE].Value.ToString();

                    //3.設定新成交價給 結算物件;//
                    bool IsSetSettlement = true;
                    if (   string.Compare(strNewStockPrice, "null") == 0
                        || StockSettlement.SetNewPrice(Convert.ToSingle(strNewStockPrice)) == false )
                    {
                        IsSetSettlement = false;

                        //設定新數值為-1,表示讀取錯誤數值;//
                        StockSettlement.SetNewPrice(-1);
                    }

                    //4.設定新結算價及計算相關套利價格,並設定回列表;//                    
                    foreach (DataGridViewRow dgvRow in RowList)
                    {
                        //檢查結算價有無設定成功;//
                        if (!IsSetSettlement)
                        {
                            //設定結算價為錯誤數值;//
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_SETTLEMENT].Value = "null";
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_BUY_SPREAD].Value = "null";
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_SELL_SPREAD].Value = "null";
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_PRE_BUY].Value = "null";
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_PRE_SELL].Value = "null";

                            continue;
                        }

                        //將結算價顯示在Row上;//
                        string strNewSettlement = StockSettlement.GetSettlement().ToString("f2");
                        dgvRow.Cells[(int)DgvColumnCell.eOPTION_SETTLEMENT].Value = strNewSettlement;

                        //取得期貨五檔賣價,並計算套利的"買進期貨"及"掛賣";//
                        string strOptionPrice = dgvRow.Cells[(int)DgvColumnCell.eOPTION_SELL].Value.ToString();
                        if (string.Compare(strOptionPrice, "null") != 0 && strOptionPrice.Length > 0)
                        {
                            //買進期貨 公式:預估結算價-期貨賣價  (大於0的弄成紅色);//
                            string strSpread = (Convert.ToSingle(strNewSettlement) - Convert.ToSingle(strOptionPrice)).ToString("f2");
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_BUY_SPREAD].Value = strSpread;
                            this.SetFontColor("0", strSpread, dgvRow.Cells[(int)DgvColumnCell.eOPTION_BUY_SPREAD]);

                            //掛賣 公式:期貨賣價 - 預估結算價 (大於0的弄成紅色);//
                            strSpread = (Convert.ToSingle(strOptionPrice) - Convert.ToSingle(strNewSettlement)).ToString("f2");
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_PRE_SELL].Value = strSpread;
                            this.SetFontColor("0", strSpread, dgvRow.Cells[(int)DgvColumnCell.eOPTION_PRE_SELL]);
                        }

                        //取得期貨五檔買價,並計算套利的"賣出期貨"及"掛買";//
                        strOptionPrice = dgvRow.Cells[(int)DgvColumnCell.eOPTION_BUY].Value.ToString();
                        if (string.Compare(strOptionPrice, "null") != 0 && strOptionPrice.Length > 0)
                        {
                            //賣出期貨 公式:期貨買價-預估成結算價  (大於0弄成紅色);//
                            string strSpread = (Convert.ToSingle(strOptionPrice) - Convert.ToSingle(strNewSettlement)).ToString("f2");
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_SELL_SPREAD].Value = strSpread;
                            this.SetFontColor("0", strSpread, dgvRow.Cells[(int)DgvColumnCell.eOPTION_SELL_SPREAD]);

                            //掛買 公式:預估結算價 - 期貨買價  (大於0的弄成紅色);//
                            strSpread = (Convert.ToSingle(strNewSettlement) - Convert.ToSingle(strOptionPrice)).ToString("f2");
                            dgvRow.Cells[(int)DgvColumnCell.eOPTION_PRE_BUY].Value = strSpread;
                            this.SetFontColor("0", strSpread, dgvRow.Cells[(int)DgvColumnCell.eOPTION_PRE_BUY]);
                        }
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        // 以下為測試
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 股票及期貨資料輸出至檔案(CVS檔)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFileOutput_Click(object sender, EventArgs e)
        {
            //取得現在日期;//
            DateTime dtTimeNow = DateTime.Now;
            string strSaveFileName = dtTimeNow.Year.ToString();
            if( dtTimeNow.Month < 10 )
                strSaveFileName += "0" + dtTimeNow.Month.ToString();
            else
                strSaveFileName += dtTimeNow.Month.ToString();
            if( dtTimeNow.Day < 10 )
                strSaveFileName += "0" + dtTimeNow.Day.ToString();
            else
                strSaveFileName += dtTimeNow.Day.ToString();

            //顯示檔案儲存的對話視窗;//
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "Comma-Separated Values|*.csv";
            SaveDlg.Title = "Save an CSV File";
            SaveDlg.FileName = strSaveFileName;

            System.Windows.Forms.DialogResult eDlgResult;
            eDlgResult = SaveDlg.ShowDialog();

            // 當對話框按下存檔或是OK,及檔案名稱有寫的話;//
            if (eDlgResult == System.Windows.Forms.DialogResult.OK
                && SaveDlg.FileName != "")
            {
                if (SaveDlg.FilterIndex == 1)
                {
                    try
                    {
                        //開啟檔案;//
                        System.IO.StreamWriter SW = new System.IO.StreamWriter(SaveDlg.FileName, false, Encoding.UTF8);
                        
                        //輸出標頭檔;//
                        foreach (DataGridViewColumn dgvColumn in dgvInform.Columns)
                            SW.Write(dgvColumn.HeaderText + ",");
                        SW.WriteLine();

                        //輸出每列資訊;//
                        foreach (DataGridViewRow dgvRow in dgvInform.Rows)
                        {
                            for (int i = 0; i < dgvInform.ColumnCount; i++)
                                SW.Write(dgvRow.Cells[i].Value + ",");
                            SW.WriteLine();
                        }
                        
                        //將緩衝當中的資料寫入到實體檔案中 並將檔案關閉釋放資源;//
                        SW.Flush();
                        SW.Close();

                        SW = null;
                    }
                    catch( Exception E )
                    {
                        MessageBox.Show("其他程式正在使用" + strSaveFileName + ",請先關閉應用程式再重試!", "無法輸出檔案",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

            SaveDlg = null;
        }

        /// <summary>
        /// 結束程式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 測試直接指定指定股票期期貨代號的資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTestDDE_Click(object sender, EventArgs e)
        {          
            Dictionary<string, string> dicMyDic = new Dictionary<string, string>();

            //dicMyDic.Add("SCN1.SIMEX", "OAF1");            
            //dicMyDic.Add("OAF1", "SCN1.SIMEX");

            dicMyDic.Add("YM1.CME", "OAF1");
            dicMyDic.Add("OAF1", "YM1.CME");
            dicMyDic.Add("2106", "FLF1");
            dicMyDic.Add("2915", "DWF1");

            if ( m_DdeClient.CreateDdeClient("YES", "DQ", dicMyDic) == true )
            {
                //建立商品資料;//
                this.CreateProductStockDgvData(ref m_DdeClient, dicMyDic, true);
            }

            dicMyDic = null;
        }

        /// <summary>
        /// 測試讀取檔案,並讀取資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTestLoadCSV_Click(object sender, EventArgs e)
        {
            this.CreateProductDdeData();
        }

        /// <summary>
        /// 字串解析測試
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temiTestStrSplit_Click(object sender, EventArgs e)
        {
            string Str1 = "YM1.CME.Name";

            int a = Str1.LastIndexOf('.');
            
            string Str2 = Str1.Substring(0,a);
        }

        /// <summary>
        /// 測試現在時間是否在指定時間之內
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temiTestTime_Click(object sender, EventArgs e)
        {
            int nCheckTime = CheckOnTimeLine( m_strAssignTimeStartStock, m_strAssignTimeEnd );
        }

        /// <summary>
        /// 測試MessageBox的按鈕類型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temiTestMessagebox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("無法連結 DDE Server, 請開啟 YesWin !", "無法連線",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
            {
                //按下Retry;//
            }
        }
    }
}

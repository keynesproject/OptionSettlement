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
 * 股期 12:30-13:25 661個  55分鐘+1 
 * 期貨  1:00~ 1:25 301個  
 * 每5秒鐘搓合一次
 */

namespace OptionSettlement
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 結算搓合數量
        /// </summary>
        private const int m_nSettlementTimes = 661;

        /// <summary>
        /// 結算價起算的起始時間
        /// </summary>
        private const string m_strAssignTimeStart = "12:30";
        //private const string m_strAssignTimeStart = "23:38";

        /// <summary>
        /// 結算價起算的結束時間
        /// </summary>
        private const string m_strAssignTimeEnd = "13:25";
        //private const string m_strAssignTimeEnd = "23:40";

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
        /// 成對商品代號,內容為[股票代號,對應股期代號]
        /// </summary>
        private Dictionary<string, string> m_dicSymbol;

        /// <summary>
        /// 紀錄以 股票或期貨代號 為 KEY, DataGridViewRow 為 Value 的表. 
        /// [ (string)股票或期貨代號, DataGridViewRow ]
        /// </summary>
        private Hashtable m_htProdoctRowsNo = new Hashtable();
        
        /// <summary>
        /// 紀錄以 股票代號 為 KEY, Settlement物件 為 Value 的表.
        /// [ (string)股票代號, Settlement ]
        /// </summary>
        private Hashtable m_htStockSettlement = new Hashtable();

        public FormMain()
        {
            InitializeComponent();

            CreateStatusBar();
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

        private bool CreateDdeLink( Dictionary<string, string> DicSymbol )
        {
            //建立DDE連線;//
            if (m_DdeClient.CreateDdeClient("YES", "DQ", m_dicSymbol) == true)
            {
                //建立商品資料;//
                this.CreateProductDgvData(ref m_DdeClient, m_dicSymbol);
            }
            else
            {
                //顯示DDE連線錯誤訊息;//
                if (MessageBox.Show("無法連結 DDE Server, 請開啟 YesWin !", "無法連線",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                {
                    return CreateDdeLink(DicSymbol);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void CreateProductDdeData()
        {
            //讀取商品CVS資料;//
            DataImport DataImport = new DataImport();           
            m_dicSymbol = DataImport.ImportCSV("./StockInfo.csv");

            //建立DDE連線;//
            CreateDdeLink(m_dicSymbol);
            
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
            if (m_htProdoctRowsNo.ContainsKey(strSymbol))
            {
                //取得更新資料所在的列編號;//
                DataGridViewRow Rows = (DataGridViewRow)m_htProdoctRowsNo[strSymbol];
                
                if (string.Compare(Rows.Cells["DgvStockSymbol"].Value.ToString(), strSymbol) == 0)
                {
                    //表示股票的資料更新,只更新列表的股票成交價;//
                    Rows.Cells["DgvStockPrice"].Value = args[(int)DDEClient.ItemField.ePrice];

                    //設定字型顏色;//
                    string PreviousPrice = args[(int)DDEClient.ItemField.eReference];
                    SetFontColor(PreviousPrice, args[(int)DDEClient.ItemField.ePrice], Rows.Cells["DgvStockPrice"]);

                    //計算套利價格;//
                    CaculateArbitrage(Rows);                    
                }
                else if (string.Compare(Rows.Cells["DgvOptionSymbol"].Value.ToString(), strSymbol) == 0)
                {
                    //表示期貨的資料更新,更新列表的期貨成交價,買價,賣價;//
                    Rows.Cells["DgvOptionPrice"].Value = args[(int)DDEClient.ItemField.ePrice];
                    Rows.Cells["DgvOptionBuy"].Value = args[(int)DDEClient.ItemField.eBidPrice];
                    Rows.Cells["DgvOptionSell"].Value = args[(int)DDEClient.ItemField.eAskPrice];

                    //設定字型顏色;//
                    string ReferencePrice = args[(int)DDEClient.ItemField.eReference];
                    SetFontColor(ReferencePrice, args[(int)DDEClient.ItemField.ePrice], Rows.Cells["DgvOptionPrice"]);
                    SetFontColor(ReferencePrice, args[(int)DDEClient.ItemField.eBidPrice], Rows.Cells["DgvOptionBuy"]);
                    SetFontColor(ReferencePrice, args[(int)DDEClient.ItemField.eAskPrice], Rows.Cells["DgvOptionSell"]);

                    //計算套利價格;//
                    CaculateArbitrage(Rows);
                }
            }
        }

        /// <summary>
        /// 計算套利價格
        /// </summary>
        /// <param name="dgvRow">有更新資料的Row編號</param>
        private void CaculateArbitrage( DataGridViewRow dgvRow )
        {

        }

        /// <summary>
        /// 建立商品資料表格
        /// </summary>
        /// <param name="DdeClient"></param>
        /// <param name="DicSymbol">成對商品代號[股票代號,對應股期代號]</param>
        private void CreateProductDgvData( ref DDEClient DdeClient, Dictionary<string, string> DicSymbol )
        {
            //建立商品資料;//
            foreach (KeyValuePair<string, string> Item in DicSymbol)
            {
                //取得股票及期貨資料;//
                List<string> listStockData = m_DdeClient.GetProductData(Item.Key);
                List<string> listOptionData = m_DdeClient.GetProductData(Item.Value);

                //判斷有無取得資料;//
                if (listStockData == null || listOptionData == null)
                    continue;

                //判斷此資料是否已經設定過;//
                if (m_htProdoctRowsNo.ContainsKey(listStockData[(int)DDEClient.ItemField.eSymbol]) == true)
                    continue;
                if (m_htProdoctRowsNo.ContainsKey(listOptionData[(int)DDEClient.ItemField.eSymbol]) == true)
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
                    "null",                                             //預估結算價;//
                    "0",                                                //賣出期貨買價價差;//
                    "0"                                                 //買進期貨賣價價差;//
                };

                //增加一列資料,並取得Row的編號及Row資料;//
                int RowIdX = dgvInform.Rows.Add(arrRowData);
                DataGridViewRow Rows = dgvInform.Rows[RowIdX];

                //紀錄商品資料所在的Rows;//
                m_htProdoctRowsNo.Add(listStockData[(int)DDEClient.ItemField.eSymbol], Rows);
                m_htProdoctRowsNo.Add(listOptionData[(int)DDEClient.ItemField.eSymbol], Rows);

                //新增股票的結算價計算物件;//
                Settlement StockSettlement = new Settlement(m_nSettlementTimes);
                m_htStockSettlement.Add(listStockData[(int)DDEClient.ItemField.eSymbol], StockSettlement );

                //設定顯示的字型顏色;//                    
                string ReferencePrice = listStockData[(int)DDEClient.ItemField.eReference];
                SetFontColor(ReferencePrice, listStockData[(int)DDEClient.ItemField.ePrice], Rows.Cells["DgvStockPrice"]);
                ReferencePrice = listOptionData[(int)DDEClient.ItemField.eReference];
                SetFontColor(ReferencePrice, listOptionData[(int)DDEClient.ItemField.ePrice], Rows.Cells["DgvOptionPrice"]);
                SetFontColor(ReferencePrice, listOptionData[(int)DDEClient.ItemField.eBidPrice], Rows.Cells["DgvOptionBuy"]);
                SetFontColor(ReferencePrice, listOptionData[(int)DDEClient.ItemField.eAskPrice], Rows.Cells["DgvOptionSell"]);

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
                    SetStatusInformation("未到指定時間: " + m_strAssignTimeStart );
                    break;

                case 1:
                    SetStatusInformation("已到指定時間: " + m_strAssignTimeStart + ", 開始計算結算價!");
                    break;

                case 2:
                    SetStatusInformation("已超過指定時間: " + m_strAssignTimeStart);
                    break;

                case 3:
                    SetStatusInformation("已超過結束時間: " + m_strAssignTimeEnd);
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
        /// 每隔一秒更新一次時間
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerStatusTime_Tick(object sender, EventArgs e)
        {
            //更新時間資訊;//
            m_DatetimePanel.ToolTipText = "DateTime: " + System.DateTime.Now.ToString();
            m_DatetimePanel.Text = System.DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// 每隔1秒檢查一下現在時間,是否在12:30-1點25之間
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            if (TimerSettlement.Enabled == false)
            {
                int nCheckTime = CheckOnTimeLine(m_strAssignTimeStart, m_strAssignTimeEnd);                
                if (nCheckTime == 1)
                {
                    //開啟結算價計算;//
                    TimerSettlement.Enabled = true;
                    TimerSettlement.Start();
                    
                    TimerCheck.Enabled = false;                                   
                }
                this.SetStatusInformation(nCheckTime);
            }    
        }

        /// <summary>
        /// 每隔5秒取得成交價,並計算結算價格後,顯示在列表上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSettlement_Tick(object sender, EventArgs e)
        {
            //取得成交價,並計算結算價格;//
            //m_htProdoctRowsNo;
            //m_htStockSettlement;
            foreach ( DictionaryEntry DE in m_htStockSettlement )
            {
                string strSymbol = DE.Key.ToString();
                if(m_htProdoctRowsNo.ContainsKey(strSymbol))
                {
                    //取得列資訊;//
                    DataGridViewRow dgvRow = (DataGridViewRow)m_htProdoctRowsNo[strSymbol];
                    
                    //取得列上的股票及期貨成交價;//
                    string strNewStockPrice = dgvRow.Cells["DgvStockPrice"].Value.ToString();                    
                    
                    //設定新的成交價;//
                    Settlement StockSettlement = (Settlement)DE.Value;
                    StockSettlement.SetNewPrice(Convert.ToSingle(strNewStockPrice));

                    //將結算價顯示在Row上;//
                    string strNewSettlement = StockSettlement.GetSettlement().ToString("f2");
                    dgvRow.Cells["DgvSettlement"].Value = strNewSettlement;
                      
                    // 買進期貨  公式 預估結算價-期貨賣價  (大於0的弄成紅色);//
                    string strOptionPrice = dgvRow.Cells["DgvOptionSell"].Value.ToString();
                    if (string.Compare(strOptionPrice, "null") != 0 || strOptionPrice.Length > 0 )
                    {
                        string strSpread = (Convert.ToSingle(strNewSettlement) - Convert.ToSingle(strOptionPrice)).ToString("f2");
                        dgvRow.Cells["DgvBuySpread"].Value = strSpread;
                        this.SetFontColor("0", strSpread, dgvRow.Cells["DgvBuySpread"]);
                    }

                    // 賣出期貨  公式 期貨買價-預估成結算價  (大於0弄成紅色);//
                    strOptionPrice = dgvRow.Cells["DgvOptionBuy"].Value.ToString();
                    if (string.Compare(strOptionPrice, "null") != 0 || strOptionPrice.Length > 0 )
                    {
                        string strSpread = (Convert.ToSingle(strOptionPrice) - Convert.ToSingle(strNewSettlement)).ToString("f2");
                        dgvRow.Cells["DgvSellSpread"].Value = strSpread;
                        this.SetFontColor("0", strSpread, dgvRow.Cells["DgvSellSpread"]);
                    }
                }
            }

            //計算時間是否超過指定的結束時間;//
            int nCheckTime = this.CheckOnTimeLine( m_strAssignTimeStart, m_strAssignTimeEnd );
            if(nCheckTime == 3 )
            {
                //關閉結算計時;//
                TimerSettlement.Enabled = false;

                //開啟時間檢查;//
                TimerCheck.Enabled = true;
            }

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
                this.CreateProductDgvData(ref m_DdeClient, dicMyDic);
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

        private void temiTestTime_Click(object sender, EventArgs e)
        {
            int nCheckTime = CheckOnTimeLine( m_strAssignTimeStart, m_strAssignTimeEnd );
        }

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

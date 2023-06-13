using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SrtMacro_v02.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SrtMacro_v02
{
    /// <summary>
    /// PageSRT.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageSRT : Page
    {
        /// <summary>
        /// 크로스 스레드 해결 
        /// </summary>
        public static RichTextBox Log = new RichTextBox();
        
        /// <summary>
        /// 쓰레드 동작
        /// </summary>
        Thread thread;

        /// <summary>
        /// 메인동작 반복여부
        /// </summary>
        bool isRun = false;

        /// <summary>
        /// Model Class
        /// </summary>
        SrtModels Model = new SrtModels();

        /// <summary>
        /// 로그 RichTextBox Height
        /// </summary>
        const double Logheight = 330;

        public PageSRT()
        {
            InitializeComponent();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualHeight > 711)
            {
                double size = this.ActualHeight - 711;
                size = Logheight + size;
                Console.WriteLine(size);
                Log.Height = size;
            }
            else
            {
                Log.Height = Logheight;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Log = txtLog;
            Log.Height = Logheight;

            comboStartAddress.ItemsSource = Values.AddressList;
            comboStopAddress.ItemsSource = Values.AddressList;

            comboStartTime.ItemsSource = Values.StartList.Keys;
            comboStopTime.ItemsSource = Values.EndList.Keys;

            comboAdult.ItemsSource = Values.AdultList;
            comboChild.ItemsSource = Values.ChildList;

            comboDelay.ItemsSource = Values.DelayTime.Keys;

            try
            {
                if (File.Exists(Values.SetPath))
                {
                    using(StreamReader sr = File.OpenText(Values.SetPath))
                    {
                        string str = sr.ReadToEnd();

                        // 세팅파일 Read 후 UI에 삽입
                        JObject json = JObject.Parse(str);
                        txtId.Text = (string)json["SRT"][0]["ID"];
                        txtPw.Password = (string)json["SRT"][0]["PW"];
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// 세팅 파일 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!String.IsNullOrEmpty(txtId.Text) && !String.IsNullOrEmpty(txtPw.Password))
                {
                    JObject json = new JObject();
                    JArray jarr = new JArray();

                    json.Add("ID", txtId.Text);
                    json.Add("PW", txtPw.Password);
                    jarr.Add(json);

                    JObject result = new JObject();
                    result.Add("SRT", jarr);

                    if (!File.Exists(Values.SetPath)) using (File.Create(Values.SetPath)) { }
                    File.WriteAllText(Values.SetPath, result.ToString());
                
                    MessageBox.Show("저장되었습니다", "알림");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 동작 시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.ID = txtId.Text; // SRT ID
                Model.PW = txtPw.Password; // SRT PW
                Model.DATE = dpTime.SelectedDate.Value.ToString("yyyyMMdd"); // 예매 날짜
                Model.STARTADDRESS = comboStartAddress.Text; // 출발지
                Model.STOPADDRESS = comboStopAddress.Text; // 도착지
                Model.STARTTIME = comboStartTime.Text; // 출발시간
                Model.ENDTIME = $"{dpTime.SelectedDate.Value.ToString("yyyy-MM-dd")} {TimeSpan.Parse(Values.EndList[comboStopTime.Text])}"; // 도착시간
                Model.ADULT = comboAdult.Text; // 어른 수
                Model.CHILD = comboChild.Text; // 아이 수
                Model.DELAY = Values.DelayTime[comboDelay.Text];

                isRun = false;

                thread = new Thread(() =>
                {
                    Work(Model.ID, Model.PW, Model.DATE, Model.STARTADDRESS, Model.STOPADDRESS, Model.STARTTIME, Model.ENDTIME, Model.ADULT, Model.CHILD, Model.DELAY);
                });

                thread.IsBackground = true;
                thread.Start();
            }
            catch(Exception ex)
            {
                Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText(ex.Message + "\r\n");
                    Log.ScrollToEnd();
                }));
            }
        }

        /// <summary>
        /// 메인로직
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_pw"></param>
        /// <param name="_date"></param>
        /// <param name="_startaddress"></param>
        /// <param name="_stopaddress"></param>
        /// <param name="_starttime"></param>
        /// <param name="_endtime"></param>
        /// <param name="_adult"></param>
        /// <param name="_child"></param>
        private void Work(string _id, string _pw,string _date, string _startaddress, string _stopaddress, string _starttime, string _endtime, string _adult, string _child, int _delay)
        {
            try {
                using (IWebDriver driver = new ChromeDriver())
                {
                    driver.Url = "https://etk.srail.kr/main.do"; // srt 메인페이지

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                    var btn = driver.FindElement(By.XPath("//*[@id=\"wrap\"]/div[3]/div[1]/div/a[2]")); // LOGIN 영역선택
                    btn.Click(); // 클릭

                    // 로그인 기능
                    #region
                    var login = driver.FindElement(By.XPath("//*[@id=\"srchDvNm01\"]"));
                    Task.Delay(100).Wait();
                    //Thread.Sleep(100);
                    login.SendKeys(_id); // 아이디 입력

                    var pw = driver.FindElement(By.XPath("//*[@id=\"hmpgPwdCphd01\"]"));
                    Task.Delay(100).Wait();
                    //Thread.Sleep(100);
                    pw.SendKeys(_pw); // 비밀번호 입력

                    btn = driver.FindElement(By.XPath("//*[@id=\"login-form\"]/fieldset/div[1]/div[1]/div[2]/div/div[2]/input"));
                    btn.Click(); // 로그인버튼 클릭
                    #endregion

                    // 열차 정보
                    #region
                    var address = driver.FindElement(By.XPath("//*[@id=\"dptRsStnCd\"]"));
                    address.SendKeys(_startaddress);

                    address = driver.FindElement(By.XPath("//*[@id=\"arvRsStnCd\"]"));
                    address.SendKeys(_stopaddress);

                    // 달력 입력
                    driver.ExecuteJavaScript("this.selectCalendarInfo()");

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    var iFrame = wait.Until(_drv => _drv.FindElement(By.XPath("//*[@id=\"_LAYER_BODY_\"]")));
                    driver.SwitchTo().Frame(iFrame);

                    try
                    {
                        driver.ExecuteJavaScript($"selectDateInfo('{_date}')");
                    }
                    catch
                    {
                        // 출발시간 입력
                        var time = driver.FindElement(By.XPath("//*[@id=\"dptTm\"]"));
                        time.SendKeys($"{_starttime}");

                        // 성인 x명
                        var people = driver.FindElement(By.XPath("//*[@id=\"psgInfoPerPrnb1\"]"));
                        people.SendKeys($"{_adult}");

                        // 어린이 x명
                        var child = driver.FindElement(By.XPath("//*[@id=\"psgInfoPerPrnb5\"]"));
                        child.SendKeys($"{_child}");

                        driver.ExecuteJavaScript("selectScheduleList()");
                    }
                    #endregion

                    // ================================================================
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
                    
                    // 예매 완료될때까지
                    int index = 1;
                    while (!isRun)
                    {
                        index = 1;

                        while (true)
                        {
                            try
                            {
                                wait.Until(_drv => _drv.FindElement(By.TagName("table")));
                                break;
                            }
                            catch 
                            {
                                continue; 
                            }
                        }
                        
                        var table = driver.FindElement(By.TagName("table"));
                        var tbody = table.FindElement(By.TagName("tbody")); // == 12개
                        var trow = tbody.FindElements(By.TagName("tr"));

                        foreach (var item in trow)
                        {
                            

                            var temp = item.FindElements(By.ClassName("time"));
                            DateTime arrive = DateTime.Parse(temp[1].Text);

                            if (arrive.Hour < DateTime.Parse(_endtime).Hour)
                            {
                                var test = item.FindElements(By.XPath($"//*[@id=\"result-form\"]/fieldset/div[6]/table/tbody/tr[{index}]/td[7]"));
                                var ancor = test[0].FindElements(By.TagName("a"));
                                
                                Console.WriteLine($"출발시간 : {temp[0].Text}, 도착시간 : {temp[1].Text}"); // 도착시간    
                                Console.WriteLine(ancor[0].Text);

                                Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                                {
                                    try
                                    {
                                        Log.AppendText($"출발시간 : {temp[0].Text}, 도착시간 : {temp[1].Text}");
                                    }
                                    catch (StaleElementReferenceException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }));

                                index++;
                                if (ancor[0].Text != "매진")
                                {
                                    Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                                    {
                                        try
                                        {
                                            Log.AppendText($"\t<예약완료>\r\n");
                                            Log.ScrollToEnd();
                                        }
                                        catch (StaleElementReferenceException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }));

                                    Console.WriteLine($"출발시간 : {temp[0].Text}, 도착시간 : {temp[1].Text} <예약완료>\r\n");
                                    ancor[0].Click();
                                    
                                }
                                else
                                {
                                    Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                                    {
                                        Log.AppendText($"\t<매진>\r\n");
                                        Log.ScrollToEnd();
                                    }));
                                }
                            }
                            else
                            {
                                Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                                {
                                    Log.AppendText("\t<도착시간 초과>\r\n");
                                    Log.ScrollToEnd();
                                }));
                            }
                        }

                        driver.Navigate().Refresh();
                        
                        Task.Delay(_delay).Wait();

                        // LogClear
                        if (Log.Document.Blocks.Count() > 200)
                        {
                            Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                            {
                                Log.Document.Blocks.Clear();
                            }));
                        }
                      
                    }
                }
            }
            catch(StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
           catch(Exception ex)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText($"{ex}\r\n");
                    Log.ScrollToEnd();
                }));
            }
        }

        /// <summary>
        /// 동작 정지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("매크로를 정지하시겠습니까?", "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    isRun = true;
                }
            }
            catch(Exception ex)
            {
                Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText(ex.Message + "\r\n");
                    Log.ScrollToEnd();
                }));
            }
        }
    }
}

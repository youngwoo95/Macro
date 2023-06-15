using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SrtMacro_v02.Models.KTX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SrtMacro_v02
{
    public partial class pageKTX : Page
    {  
        /// <summary>
       /// 크로스 스레드 해결 
       /// </summary>
        public static RichTextBox Log = new RichTextBox();

        /// <summary>
        /// 로그 RichTextBox Height
        /// </summary>
        const double Logheight = 330;

        /// <summary>
        /// KTX 모델 클래스
        /// </summary>
        KtxModels Models = new KtxModels();

        bool isRun = false;

        Thread thread;

        IWebElement? element;
        
        WebDriverWait wait;

        /// <summary>
        /// 크롬드라이버 옵션
        /// </summary>
        ChromeDriverService driverService;

        /// <summary>
        /// 크롬드라이버 옵션
        /// </summary>
        ChromeOptions options;

        public pageKTX()
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
            comboStopTime.ItemsSource = Values.StartList.Keys;

            comboAdult.ItemsSource = Values.AdultList;
            comboAdult.SelectedIndex = 0;

            comboChildren.ItemsSource = Values.ChildrenList;
            comboChildren.SelectedIndex = 0;

            comboChild.ItemsSource = Values.ChildList;
            comboChild.SelectedIndex = 0;

            comboOld.ItemsSource = Values.OldList;
            comboOld.SelectedIndex = 0;

            comboDelay.ItemsSource = Values.DelayTime.Keys;

            try
            {
                if (File.Exists(Values.SetPath))
                {
                    using (StreamReader sr = File.OpenText(Values.SetPath))
                    {
                        string str = sr.ReadToEnd();

                        // 세팅파일 Read 후 UI에 삽입
                        JObject json = JObject.Parse(str);
                        txtId.Text = (string)json["KTX"][0]["ID"];
                        txtPw.Password = (string)json["KTX"][0]["PW"];
                    }
                }
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText($"{ex}\r\n");
                    Log.ScrollToEnd();
                }));

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
                    result.Add("KTX", jarr);

                    if (!File.Exists(Values.SetPath)) using (File.Create(Values.SetPath)) { }
                    File.WriteAllText(Values.SetPath, result.ToString());

                    MessageBox.Show("저장되었습니다", "알림");
                }

            }catch(Exception ex)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText($"{ex}\r\n");
                    Log.ScrollToEnd();
                }));

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
                Models.ID = txtId.Text;
                Models.PW = txtPw.Password;
                Models.DATE = dpTime.SelectedDate.Value;
                Models.STARTADDRESS = comboStartAddress.Text; // 출발지
                Models.STOPADDRESS = comboStopAddress.Text; // 도착지
                Models.STARTTIME = comboStartTime.Text; // 출발시간
                Models.ENDTIME = Values.StartList[comboStopTime.Text]; // 도착시간
                Models.ADULT = comboAdult.Text; // 어른
                Models.CHILDREN = comboChildren.Text; // 어린이
                Models.CHILD = comboChild.Text; // 유아
                Models.OLD = comboOld.Text; // 노인
                Models.DELAY = Values.DelayTime[comboDelay.Text];

                isRun = false;

                thread = new Thread(() =>
                {
                    Work(Models.ID, Models.PW, Models.DATE, Models.STARTADDRESS, Models.STOPADDRESS, Models.STARTTIME, Models.ENDTIME, Models.ADULT, Models.CHILDREN, Models.CHILD, Models.OLD, Models.DELAY);
                });
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText($"{ex}\r\n");
                    Log.ScrollToEnd();
                }));

                Console.WriteLine(ex.Message);
            }
        }

        
        private void Work(string _id, string _pw, DateTime _date, string _startaddress, string _stopaddress, string _starttime, string _endtime, string _adult, string _children, string _child, string _old, int _delay)
        {
            try
            {
                if (MessageBox.Show("브라우저를 표시하시겠습니까?", "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = false; // 브라우저 표시

                    options = new ChromeOptions();
                    options.AddArgument("ignore-certificate-errors");
                    options.PageLoadStrategy = PageLoadStrategy.Default;
                }
                else
                {
                    driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true; // 표시안함

                    options = new ChromeOptions();
                    options.AddArguments("headless"); // 표시안함
                    options.AddArgument("ignore-certificate-errors");
                    options.PageLoadStrategy = PageLoadStrategy.Default;
                }

                using (IWebDriver driver = new ChromeDriver(driverService,options))
                {
                    driver.Url = "https://www.letskorail.com/index.jsp"; // ktx 메인페이지
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                    element = driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div/ul/li[2]/a")); // Login 영역선택
                    element.Click(); // 버튼 클릭

                    // 로그인 기능
                    element = driver.FindElement(By.XPath("//*[@id=\"radInputFlg1\"]"));
                    element.Click();

                    element = driver.FindElement(By.XPath("//*[@id=\"txtMember\"]"));
                    Task.Delay(100).Wait();
                    element.SendKeys(_id); // 아이디 입력

                    element = driver.FindElement(By.XPath("//*[@id=\"txtPwd\"]"));
                    Task.Delay(100).Wait();
                    element.SendKeys(_pw); // 비밀번호 입력

                    element = driver.FindElement(By.XPath("//*[@id=\"loginDisplay1\"]/ul/li[3]/a/img")); // 로그인 버튼
                    element.Click(); // 로그인 버튼 클릭

                    element = driver.FindElement(By.XPath("//*[@id=\"res_cont_tab01\"]/form/div/fieldset/p/a")); // 승차권예매 버튼
                    element.Click();

                    element = driver.FindElement(By.Id("peop01")); // 어른
                    element.SendKeys(_adult);

                    element = driver.FindElement(By.Id("peop02")); // 어린이
                    element.SendKeys(_children);

                    element = driver.FindElement(By.Id("peop04")); // 유아
                    element.SendKeys(_child);

                    element = driver.FindElement(By.Id("peop03")); // 노인
                    element.SendKeys(_old);

                    element = driver.FindElement(By.XPath("//*[@id=\"selGoTrainRa00\"]")); // 기차타입
                    element.Click();

                    //element = driver.FindElement(By.XPath("//*[@id=\"route01\"]")); // 여정경로
                    //element.Click();

                    element = driver.FindElement(By.Id("start"));
                    element.Clear();
                    element.SendKeys(_startaddress);

                    element = driver.FindElement(By.Id("get"));
                    element.Clear();
                    element.SendKeys(_stopaddress);

                    element = driver.FindElement(By.Id("s_year")); // 년
                    element.SendKeys(_date.Year.ToString());

                    element = driver.FindElement(By.Id("s_month")); // 월
                    element.SendKeys(_date.Month.ToString());

                    element = driver.FindElement(By.Id("s_day")); // 일
                    element.SendKeys(_date.Day.ToString());

                    element = driver.FindElement(By.Id("s_hour")); // 출발일
                    element.SendKeys(_starttime);

                    //element = driver.FindElement(By.XPath("//*[@id=\"route01\"]"));
                    element = driver.FindElement(By.XPath("//*[@id=\"center\"]/div[3]/p/a")); // 조회
                    element.Click();


                    int i = 1;
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));

                    while (!isRun)
                    {
                        i = 1;

                        var table = driver.FindElement(By.Id("tableResult"));
                        var tbody = table.FindElement(By.TagName("tbody"));
                        var trow = tbody.FindElements(By.TagName("tr"));

                        foreach (var item in trow)
                        {
                            while (true)
                            {
                                try
                                {
                                    wait.Until(_drv => _drv.FindElement(By.XPath($"//*[@id=\"tableResult\"]/tbody/tr[{i}]/td[3]")));
                                    break;
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                            
                            var start = item.FindElements(By.XPath($"//*[@id=\"tableResult\"]/tbody/tr[{i}]/td[3]"));
                            var stop = item.FindElements(By.XPath($"//*[@id=\"tableResult\"]/tbody/tr[{i}]/td[4]"));

                            string[] arrstart = start[0].Text.Split("\r\n");
                            string[] arrstop = stop[0].Text.Split("\r\n"); // [1] : 시간

                            Console.WriteLine(arrstart[1].ToString()); // 출발시간
                            Console.WriteLine(arrstop[1].ToString()); // 도착시간


                            if (DateTime.Parse(arrstop[1]).Hour < DateTime.Parse(_endtime).Hour)
                            {
                                var temp = item.FindElements(By.XPath($"//*[@id=\"tableResult\"]/tbody/tr[{i}]/td[6]"));
                                string compare = ((OpenQA.Selenium.WebElement)temp[0]).ComputedAccessibleLabel;
                                Console.WriteLine(compare);
                                
                                if (compare != "좌석매진")
                                {
                                    
                                    Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                                    {
                                        try
                                        {
                                            Log.AppendText($"출발시간 : {arrstart[1].ToString()}, 도착시간 : {arrstop[1].ToString()} 예매완료 \r\n");
                                            Log.ScrollToEnd();
                                        }
                                        catch(StaleElementReferenceException ex)
                                        {
                                            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                                            {
                                                Log.AppendText($"{ex}\r\n");
                                                Log.ScrollToEnd();
                                            }));
                                        }
                                        catch(Exception ex)
                                        {
                                            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                                            {
                                                Log.AppendText($"{ex}\r\n");
                                                Log.ScrollToEnd();
                                            }));
                                        }
                                    }));

                                    element.Click();
                                }
                                else
                                {
                                    Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                                    {
                                        try
                                        {
                                            Log.AppendText($"출발시간 : {arrstart[1].ToString()}, 도착시간 : {arrstop[1].ToString()} 매진 \r\n");
                                            Log.ScrollToEnd();
                                        }
                                        catch(StaleElementReferenceException ex)
                                        {
                                            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                                            {
                                                Log.AppendText($"{ex}\r\n");
                                                Log.ScrollToEnd();
                                            }));
                                        }
                                        catch(Exception ex)
                                        {
                                            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                                            {
                                                Log.AppendText($"{ex}\r\n");
                                                Log.ScrollToEnd();
                                            }));
                                        }
                                    }));
                                }
                                
                            }
                            else
                            {
                                Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                                {
                                    try
                                    {
                                        Log.AppendText($"출발시간 : {arrstart[1].ToString()}, 도착시간 : {arrstop[1].ToString()} 도착시간 초과 \r\n");
                                        Log.ScrollToEnd();
                                    }
                                    catch(StaleElementReferenceException ex)
                                    {
                                        Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                                        {
                                            Log.AppendText($"{ex}\r\n");
                                            Log.ScrollToEnd();
                                        }));

                                        Console.WriteLine(ex.Message);
                                    }
                                    catch(Exception ex)
                                    {
                                        Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                                        {
                                            Log.AppendText($"{ex}\r\n");
                                            Log.ScrollToEnd();
                                        }));

                                        Console.WriteLine(ex.Message);
                                    }
                                }));
                            }
                            i++;
                        }

                        driver.Navigate().Refresh();
                        Task.Delay(_delay).Wait();

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
            catch(Exception ex)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText($"{ex}\r\n");
                    Log.ScrollToEnd();
                }));

                Console.WriteLine(ex.Message);
            }
        }


        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("매크로를 정지하시겠습니까?", "알림", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    isRun = true;
                }
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate ()
                {
                    Log.AppendText(ex.Message + "\r\n");
                    Log.ScrollToEnd();
                }));

                Console.WriteLine(ex.Message);
            }
        }

    }
}

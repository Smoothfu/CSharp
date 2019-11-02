using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DllHelper;
using System.Drawing;
using System.Diagnostics;
using System.Windows;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Reflection;
using System.Threading;
using System.Media;
using System.Windows.Media;

namespace ConsoleApp378
{
    class Program
    {
        static void Main(string[] args)
        {
            MediaPlayerDemo();
            Console.ReadLine(); 
        }

        static MediaPlayer mp3Player = new MediaPlayer();
        static void MediaPlayerDemo()
        {            
            string mp3Path = Directory.GetCurrentDirectory() + @"\MediaResource\XXDDDJ.mp3";
            mp3Player.Open(new Uri(mp3Path));
            Console.WriteLine(" Start:Y;Exit:Q;Amplify:A;Decrease:D;Pause:P;C:Acclerate!");
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                ControlMediaPlayer(line[0]);
            }      
        }

        static void ControlMediaPlayer(char c)
        {
            if (mp3Player != null && mp3Player.HasAudio)
            {
                switch (c)
                {
                    //Start
                    case 'Y':
                        mp3Player.Play();
                        ShowStatus(mp3Player);
                        break;

                    //Exit
                    case 'Q':
                        mp3Player.Stop();
                        ShowStatus(mp3Player);
                        break;

                    //Amplify 
                    case 'A':
                        mp3Player.Volume = mp3Player.Volume + 0.1;
                        ShowStatus(mp3Player);
                        break;

                    //Decrease
                    case 'D':
                        mp3Player.Volume = mp3Player.Volume - 0.1;
                        ShowStatus(mp3Player);
                        break;

                    //Pause
                    case 'P':
                        mp3Player.Pause();
                        ShowStatus(mp3Player);
                        break;

                    //Accelerate
                    case 'C':
                        mp3Player.SpeedRatio += 0.3;
                        ShowStatus(mp3Player);
                        break;
                }
            }
        }

        static void ShowStatus(MediaPlayer mPlayer)
        {
            if(mPlayer!=null)
            {
                string msg = $"Position:{mp3Player.Position},SpeedRatio:{mp3Player.SpeedRatio},IsMuted:{mp3Player.IsMuted}," +
                    $"ScrubbingEnabled:{mp3Player.ScrubbingEnabled},Balance:{mp3Player.Balance},NaturalVideoWidth:{mp3Player.NaturalVideoWidth}"
                    + $"Source:{mp3Player.Source}";
                Console.WriteLine(msg);
            }
        }

        #region 
        static void ValueDemo()
        {
            string a = "hello";
            string b = a;
            
            Console.WriteLine(ReferenceEquals(a, b));
        }

        static void BytesToImg()
        {
            string content = File.ReadAllText("10.txt");
            byte[] imageBytes = Convert.FromBase64String(content);
            MemoryStream ms = new MemoryStream(imageBytes);
            Image image = Image.FromStream(ms, true, true);
        }
        static void WebDriverSeleniumDemo()
        {
            string url = "http://image.baidu.com/search/index?ct=201326592&z=9&tn=baiduimage&word=%E5%88%98%E4%BA%A6%E8%8F%B2&pn=0&ie=utf-8&oe=utf-8&cl=2&lm=-1&fr=&se=&sme=&width=0&height=0";
            WebDriverDemo(url);
        }
        static void WebDriverDemo(string url = "http://www.tieba.com/p/4325046994#!/l/p1")
        {
            ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            driver.Navigate().GoToUrl(url);
            List<IWebElement> lwe = driver.FindElements(By.CssSelector("img")).ToList();

            List<string> imgsList = new List<string>();
            StringBuilder imgBuilder = new StringBuilder();
            foreach(var img in lwe)
            {                 
                string imgUrl = img.GetAttribute("src");
                imgBuilder.AppendLine(imgUrl);
                imgsList.Add(imgUrl);
            }

            File.WriteAllText("lyf.txt", imgBuilder.ToString());
        }
        static List<string> GetImagesInHTMLString()
        {
            string url = "http://tieba.baidu.com/p/4325046994#!/l/p1";
            string htmlString = "";
            WebClient client = new WebClient();
            string source = client.DownloadString(url);
            List<string> images = new List<string>();
            string pattern = @"<(img)\b[^>]*>";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(source);

            for (int i = 0, l = matches.Count; i < l; i++)
            {
                images.Add(matches[i].Value);
            }

            return images;
        }
        static void GetUrls()
        {
            string url = "http://tieba.baidu.com/p/4325046994#!/l/p1";
            WebClient client = new WebClient();
            string source = client.DownloadString(url);
            LogStreamWriter(source);
        }
        static void GetAllImages()
        {
            string url = "http://tieba.baidu.com/p/4325046994#!/l/p1";
            HtmlAgilityPack.HtmlDocument document =new HtmlWeb().Load(url);
            List<string> image_links = new List<string>(); 

            foreach (HtmlNode link in document.DocumentNode.SelectNodes("//a/@href |//img/@src"))
            {
                image_links.Add(link.GetAttributeValue("src", ""));
            }
        }
        static void HtmlAgilityImgsDemo()
        {
            string url = "http://tieba.baidu.com/p/4325046994#!/l/p1";
            var doc = new HtmlWeb().Load(url);
            var urls = doc.DocumentNode.Descendants("img")
                                .Select(e => e.GetAttributeValue("src", null))
                                .Where(s => !String.IsNullOrEmpty(s));
          
        }
        static void GetWebContent()
        {
            string url = "https://cn.bing.com/images/search?q=crystal+liu&FORM=HDRSC2";
            WebClient client = new WebClient();
            Task<string> stringTask= client.DownloadStringTaskAsync(url);
            LogStreamWriter(stringTask.Result);
        }
        static void HtmlAgilityDemo(string url = "https://weibo.com/liuyifeiofficial?sudaref=www.baidu.com&display=0&retcode=6102&is_hot=1")
        {
            StringBuilder imgBuilder = new StringBuilder();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(url);
            foreach(var link in doc.DocumentNode.SelectNodes("//a/@href |//img/@src"))
            {

            }

            LogStreamWriter(imgBuilder.ToString());
        }
        static void LogStreamWriter(string logContent)
        {
            string logFile = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
            using (StreamWriter logWriter = new StreamWriter(logFile, false, Encoding.UTF8))
            {
                logWriter.WriteLine(logContent);
            }
        }
        static void CSharpStopWatchTest()
        {
            string logFile = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(600);
            StringBuilder logBuilder = new StringBuilder();

            using (StreamWriter logWriter = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                while (DateTime.Now < endTime)
                {
                    string msg = $"Time is {DateTime.Now.ToString("yyyyMMddHHmmssfff")}, guid is {Guid.NewGuid()}";
                    logWriter.WriteLine(msg);
                }
            }

            long memoryMsg = Process.GetCurrentProcess().PrivateMemorySize64;
            Console.WriteLine(memoryMsg);
            MessageBox.Show(memoryMsg.ToString());
        }
        static void DirectoryDemo()
        {
            string path = @"D:\C";
            string[] allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            if (allFiles != null && allFiles.Any())
            {
                string fileLog = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
                using (StreamWriter writer = new StreamWriter(fileLog, false, Encoding.UTF8))
                {
                    foreach (var file in allFiles)
                    {
                        writer.WriteLine(file);
                    }
                }
            }

            Console.WriteLine($"Count:{allFiles.Count()}");
        }
        void DllDemo()
        {
            int x = 10, y = 20;
            int result = MathHelper.Add(x, y);
            Console.WriteLine(result);
        }
        static void CSharpCatch()
        {
            string lyfUrl = "https://cn.bing.com/images/search?view=detailV2&ccid=zJUUrtzP&id=FB1117141967C90C09EAF1145DFAA21ACF09B557&thid=OIP.zJUUrtzPaw-amftW0IiWcQHaKY&mediaurl=http%3a%2f%2fbehindthelensonline.net%2fsite%2fwp-content%2fuploads%2f2017%2f11%2fmulan-crystal-liu.jpg&exph=1000&expw=713&q=crystal+liu&simid=607989251696755723&selectedIndex=0&ajaxhist=0";

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(lyfUrl, "image.png");
            }
        }

        #endregion
    }

    struct MyStruct
    {
        public int Age;
        public string Name { get; set; }
        public MyStruct(int age,string name)
        {            
            Age = age;
            Name = name;
        }        
    }

    public struct SecondStruct
    {
        public SecondStruct(int a,int b)
        {

        }
    }
}

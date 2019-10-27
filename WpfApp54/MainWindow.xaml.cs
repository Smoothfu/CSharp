using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;
using Path = System.IO.Path;
using System.Reflection;
using OpenQA.Selenium;
using System.Threading;

namespace WpfApp54
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ImageClass> ImgsList { get; set; }
        static string url = "http://image.baidu.com/search/index?ct=201326592&z=9&tn=baiduimage&word=%E5%88%98%E4%BA%A6%E8%8F%B2&pn=0&ie=utf-8&oe=utf-8&cl=2&lm=-1&fr=&se=&sme=&width=0&height=0";
           
        public MainWindow()
        {
            InitializeComponent();
            WebDriverDemo(url);
            lv.ItemsSource = ImgsList;
            this.DataContext = this;
        }  

        public class ImageClass
        {
            public Uri ImagePath { get; set; }
        }

        void WebDriverDemo(string url = "http://image.baidu.com/search/index?ct=201326592&z=9&tn=baiduimage&word=%E5%88%98%E4%BA%A6%E8%8F%B2&pn=0&ie=utf-8&oe=utf-8&cl=2&lm=-1&fr=&se=&sme=&width=0&height=0")
        {
            ImgsList = new ObservableCollection<ImageClass>();
            ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //string url = "http://www.tieba.com/p/4325046994#!/l/p1";
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(60000);
            List<IWebElement> lwe = driver.FindElements(By.CssSelector("img")).ToList();
           
            StringBuilder imgBuilder = new StringBuilder();
            foreach (var img in lwe)
            {
                string imgUrl = img.GetAttribute("src");
                if(!string.IsNullOrWhiteSpace(imgUrl))
                {
                    imgBuilder.AppendLine(imgUrl);
                    ImgsList.Add(new ImageClass()
                    {
                        ImagePath = new Uri(imgUrl, UriKind.Absolute)
                    });
                }                
            }

            File.WriteAllText("lyf.txt", imgBuilder.ToString());
        }
    }
}

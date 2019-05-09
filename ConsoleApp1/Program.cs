using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; 
using System.Diagnostics;
using System.Windows.Media;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
 
            List<Process> procArr = Process.GetProcesses().OrderBy(x => x.ProcessName).ToList();
            if (procArr != null && procArr.Any())
            {
                foreach (var proc in procArr)
                {
                    Console.WriteLine($"Id:{proc.Id},ProcessName:{proc.ProcessName}");
                }
            }
            bool createdNew;
            var mutex = new Mutex(true, "WpfApp38.exe", out createdNew);
            if(!createdNew)
            {
                MessageBox.Show("The application has started!");
                return;
            }
            Process.Start("WpfApp38.exe");
            Application app = new MainApp();
            Console.WriteLine($"app.GetType().Name:{app.GetType().Name}");
            Window win = new Window();
            win.Title = "This is generated in Console";
            win.Background = new SolidColorBrush(Colors.Yellow);
            app.Run(win);

            
            Console.ReadLine();
        }
    }

    public class MainApp:Application
    {
        public MainApp():base()
        {

        }

        protected override void OnActivated(EventArgs e)
        {
            Console.WriteLine("OnActivated");
            base.OnActivated(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OnExit");            
            Console.WriteLine($"ApplicationExitCode:{e.ApplicationExitCode}");
            this.Shutdown(0);            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Console.WriteLine("OnStartup");
            base.OnStartup(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            Console.WriteLine("OnDeactivated");
            base.OnDeactivated(e);
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            Console.WriteLine("OnSessionEnding");
            base.OnSessionEnding(e);
        }
    }
}

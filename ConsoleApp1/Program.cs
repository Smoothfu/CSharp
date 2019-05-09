using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; 
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Process.Start("WpfApp38.exe");
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

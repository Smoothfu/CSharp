using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp38
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App():base()
        {

        }

        protected override void OnActivated(EventArgs e)
        {
            Console.WriteLine("OnActivated");
            base.OnActivated(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Console.WriteLine("OnExit");
            this.Shutdown();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            Console.WriteLine("OnDeactivated");
            base.OnDeactivated(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Console.WriteLine("OnStartup");
            base.OnStartup(e);
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            Console.WriteLine("OnSessionEnding");
            base.OnSessionEnding(e);
        }
    }
}

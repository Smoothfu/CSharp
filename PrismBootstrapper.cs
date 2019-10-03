using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SalesModule;

namespace WPFPrism
{
    public class PrismBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //return this.Container.TryResolve<Shell>();
            return this.Container.TryResolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(SalesModule.SalesModule));
        }
    }
}

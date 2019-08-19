using ModuleB;
using Prism.Mef;
using Prism.Modularity;
using System.ComponentModel.Composition.Hosting;
using System.Windows;

namespace WpfApp49
{
    public class BootStrapper:MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(BootStrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleA.ModuleA).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleB.ModuleB).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleC.ModuleC).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleD.ModuleD).Assembly));

        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Ioc;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;
using Unity.Builder;
using System.Collections.ObjectModel;

namespace WpfApp46
{
    public class Module1 : IModuleGroupsCatalog
    {
        private IRegionManager iRegionManager;
        public Module1(IRegionManager iregionManager)
        {
            this.iRegionManager = iregionManager;
        }

        public Collection<IModuleCatalogItem> Items => throw new NotImplementedException();

        public void OnInitialized(IContainerProvider containerProvider)
        {
            this.iRegionManager.RegisterViewWithRegion("Module1", typeof(WpfApp46.View.SalesOrderDetail));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }       
    }

    class BootStrap
    {

    }
}

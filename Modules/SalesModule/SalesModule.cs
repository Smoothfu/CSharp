using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModule
{
    public class SalesModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public SalesModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("SalesRegion", typeof(Views.SalesView));
        }
    }
}

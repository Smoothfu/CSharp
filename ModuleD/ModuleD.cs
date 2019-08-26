using Prism.Modularity;
using Prism.Mef.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleD
{
    [ModuleExport("ModuleD", typeof(ModuleD), InitializationMode = InitializationMode.WhenAvailable)]
    public class ModuleD : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public ModuleD(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("RegionD", typeof(View.GridD));
        }
    }
}

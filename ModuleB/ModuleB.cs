using Prism.Modularity;
using Prism.Mef.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB
{
    [ModuleExport("ModuleB",typeof(ModuleB),InitializationMode =InitializationMode.WhenAvailable)]
    public class ModuleB : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public ModuleB(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("RegionB", typeof(View.GridB));
        }
    }
}

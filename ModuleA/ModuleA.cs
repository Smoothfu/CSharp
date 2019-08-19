using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Mef.Modularity;
using System.ComponentModel.Composition;
using Prism.Regions;

namespace ModuleA
{
    [ModuleExport("ModuleA",typeof(ModuleA),InitializationMode=InitializationMode.WhenAvailable)]
    public class ModuleA : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public ModuleA(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("RegionA", typeof(View.GridA));
        }
    }
}

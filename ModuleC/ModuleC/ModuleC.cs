using Prism.Modularity;
using Prism.Mef.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleC
{
    [ModuleExport("ModuleC",typeof(ModuleC),InitializationMode=InitializationMode.WhenAvailable)]
    public class ModuleC : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public ModuleC(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("RegionC", typeof(View.GridC));
        }
    }
}

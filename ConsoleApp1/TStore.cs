using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TStore
    {

        public int TBID { get; set; }
        public string TName { get; set; }
        public string TCT { get; set; }
        public string TTitle { get; set; }
        public string TFN { get; set; }
        public string TMN { get; set; }
        public string TLN { get; set; }

        public override string ToString()
        {
            return string.Format("TBID:{0},TName:{1},TCT:{2},TTitle:{3},TFN:{4},TMN:{5},TLN:{6}\n", TBID, TName, TCT, TTitle, TFN, TMN, TLN);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp208.Model
{    
    public class TProd
    {
        public int TPID { get; set; }
        public short TLID { get; set; }
        public string TShelf { get; set; }
        public byte TBin { get; set; }
        public short TQuantity { get; set; }
        public Guid TRowGuid { get; set; }
        public DateTime TMD { get; set; }

        public override string ToString()
        {
            return string.Format("TPID:{0},TLID:{1},TShelf:{2},TBin:{3},TQuantity{4},TRowGuid:{5},TMD:{6}\n", TPID, TLID, TShelf, TBin,TQuantity, TRowGuid, TMD);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp17
{
    public class ProdInv
    {
        //0,int;
        //1,shortint,
        //2,string,
        //3.byte,
        //4,short,
        //5,System.Guid,

        //6,System.DateTime
        public int PId{get;set;}
        public short LId { get; set; }
        public string Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime MD { get; set; }


        public override string ToString()
        {
            return string.Format("PId:{0},LId:{1},Shelf:{2},Bin:{3},Quantity:{4},RowGuid:{5},MD:{6}\n",
                PId, LId, Shelf, Bin, Quantity, RowGuid, MD);
        }
    }
}

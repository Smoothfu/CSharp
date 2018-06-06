using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1.Model
{
    public class ProductInventory
    {
        public int PID { get;set;}
        public short LID { get; set; }
        public string Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime MD { get; set; }
    }
}

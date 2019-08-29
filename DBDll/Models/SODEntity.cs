using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDll.Models
{
    [Table("SOD2")]
    public class SODEntity
    {
        public int SalesOrderID { get; set; }

        public int SalesOrderDetailID { get; set; }

        public string CarrierTrackingNumber { get; set; }

        public int OrderQty { get; set; }

        public int ProductID { get; set; }

        public int SpecialOfferID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitPriceDiscount { get; set; }

        public decimal LineTotal { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}

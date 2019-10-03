using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModule.Models
{
    public class SalesOrderDetail:BindableBase
    {
        private int salesOrderID;
        public int SalesOrderID
        {
            get
            {
                return salesOrderID;
            }

            set
            {
                if(value!=salesOrderID)
                {
                    salesOrderID = value;
                    OnPropertyChanged("SalesOrderID");
                }
            }
        }

        private int salesOrderDetailID;
        public int SalesOrderDetailID
        {
            get
            {
                return salesOrderDetailID;
            }
            set
            {
                if(value!=salesOrderDetailID)
                {
                    salesOrderDetailID = value;
                    OnPropertyChanged("SalesOrderDetailID");
                }
            }
        }

        private string carrierTrackingNumber;
        public string CarrierTrackingNumber
        {
            get
            {
                return carrierTrackingNumber;
            }
            set
            {
                if(carrierTrackingNumber!=value)
                {
                    carrierTrackingNumber = value;
                    OnPropertyChanged("CarrierTrackingNumber");
                }
            }
        }

        private int orderQty;
        public int OrderQty
        {
            get
            {
                return orderQty;
            }
            set
            {
                if(value!=orderQty)
                {
                    orderQty = value;
                    OnPropertyChanged("OrderQty");
                }
            }
        }

        private int productID;
        public int ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                if(value!=productID)
                {
                    productID = value;
                    OnPropertyChanged("ProductID");
                }
            }
        }

        private int specialOfferID;
        public int SpecialOfferID
        {
            get
            {
                return specialOfferID;
            }
            set
            {
                if(value!=specialOfferID)
                {
                    specialOfferID = value;
                    OnPropertyChanged("SpecialOfferID");
                }
            }
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if(value!=unitPrice)
                {
                    unitPrice = value;
                    OnPropertyChanged("UnitPrice");
                }
            }
        }

        private decimal unitPriceDiscount;
        public decimal UnitPriceDiscount
        {
            get
            {
                return unitPriceDiscount;
            }
            set
            {
                if(value!=unitPriceDiscount)
                {
                    unitPriceDiscount = value;
                    OnPropertyChanged("UnitPriceDiscount");
                }
            }
        }

        private decimal lineTotal;
        public decimal LineTotal
        {
            get
            {
                return lineTotal;
            }
            set
            {
                if(value!=lineTotal)
                {
                    lineTotal = value;
                    OnPropertyChanged("LineTotal");
                }
            }
        }

        private Guid rowGuid;
        public Guid RowGuid
        {
            get
            {
                return rowGuid;
            }
            set
            {
                if(value!=rowGuid)
                {
                    rowGuid = value;
                    OnPropertyChanged("RowGuid");
                }
            }
        }

        private DateTime modifiedDate;
        public DateTime ModifiedDate
        {
            get
            {
                return modifiedDate;
            }
            set
            {
                if (value != modifiedDate)
                {
                    modifiedDate = value;
                    OnPropertyChanged("ModifiedDate");
                }
            }
        }

        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get
            {
                return createdAt;
            }
            set
            {
                if(value!=createdAt)
                {
                    createdAt = value;
                    OnPropertyChanged("CreatedAt");
                }
            }
        }
        
    }
}

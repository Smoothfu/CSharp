using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;


namespace WebApplication14.Controllers
{
    public class SODetailController : ApiController
    {
        private List<SalesOrderDetail> orderList = new List<SalesOrderDetail>();
        private List<SalesOrderDetail> topOrderList = new List<SalesOrderDetail>();
        private List<SalesDetailClass> salesDetailList = new List<SalesDetailClass>();
        public SODetailController()
        {
            using (SODDB db = new SODDB())
            {
                orderList = db.SalesOrderDetails.ToList();
                for(int i=0;i< orderList.Count; i++)
                {
                    salesDetailList.Add(new SalesDetailClass()
                    {
                        SalesOrderDetailID = orderList[i].SalesOrderDetailID
                    });
                }
            }
        }

        //public List<SalesOrderDetail> GetList()
        //{
        //    return topOrderList;
        //}

        public List<SalesDetailClass> GetSalesDetailList()
        {
            return salesDetailList;
        }

        public SalesOrderDetail GetSalesOrderDetail(int salesOrderDetailID)
        {
            try
            {
                var salesOrder = orderList.First(x => x.SalesOrderDetailID == salesOrderDetailID);
                if(salesOrder!=null)
                {
                    return salesOrder;
                }                  
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }
        
        public SalesDetailClass GetSalesDetailClass(int sodDetailId)
        {
            try
            {
                var sodDetail = salesDetailList.First(x => x.SalesOrderDetailID == sodDetailId);
                return sodDetail;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public SalesOrderDetail GetSODByRowGuid(Guid rowGuid)
        {
            var sodRow = orderList.First(x => x.rowguid == rowGuid);
            return sodRow;
        }

        public SalesOrderDetail GetSODDetailByUnitPrice(decimal specifiedUnitPrice)
        {
            try
            {
                var selectedUnitPrice = orderList.First(x => x.UnitPrice == specifiedUnitPrice);
                if(selectedUnitPrice!=null)
                {
                    return selectedUnitPrice;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;   
        }


        public List<SalesOrderDetail> GetSalesOrderDetailListByUnitPrice(decimal filterUnitPrice)
        {
            try
            {
                List<SalesOrderDetail> salesOrderDetailList = new List<SalesOrderDetail>();
                salesOrderDetailList = orderList.Where(x => x.UnitPrice == filterUnitPrice).ToList();
                return salesOrderDetailList;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        //[HttpGet]
        //public SalesOrderDetail GetOrderBySODID(int soiID)
        //{
        //    try
        //    {
        //        var sod = orderList.First(x => x.SalesOrderDetailID == soiID);
        //        if(sod!=null)
        //        {
        //            return sod;
        //        }               
        //    }
        //    catch(Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }

        //    return null;
        //}
    }
}

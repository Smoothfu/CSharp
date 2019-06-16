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
        public SODetailController()
        {
            using (SODDB db = new SODDB())
            {
                orderList = db.SalesOrderDetails.ToList();
                topOrderList = orderList.Take(10).ToList();
            }
        }

        public List<SalesOrderDetail> GetList()
        {
            return topOrderList;
        }

        [HttpGet]
        public SalesOrderDetail GetOrderBySODID(int soiID)
        {
            try
            {
                var sod = orderList.First(x => x.SalesOrderDetailID == soiID);
                if(sod!=null)
                {
                    return sod;
                }               
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }
}

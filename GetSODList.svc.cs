using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService11.Model;
using System.Configuration;

namespace WcfService11
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetSODList" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetSODList.svc or GetSODList.svc.cs at the Solution Explorer and start debugging.
    public class GetSODList : IGetSODList
    {
        public List<SalesOrderDetail> GetSODSList()
        {
            List<SalesOrderDetail> sodList = new List<SalesOrderDetail>();
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                sodList = db.SalesOrderDetails.ToList();
            }
            return sodList;
        }
    }
}

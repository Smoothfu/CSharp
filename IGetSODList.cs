using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService11.Model;

namespace WcfService11
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetSODList" in both code and config file together.
    [ServiceContract]
    public interface IGetSODList
    {
        [OperationContract]
        List<SalesOrderDetail> GetSODSList();
    }
}

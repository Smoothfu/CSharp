using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace MathService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetDataTableFromDB" in both code and config file together.
    [ServiceContract]
    public interface IGetDataTableFromDB
    {
        [OperationContract]
        string GetDataTableFromDBResult();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDBService
    {
        [OperationContract]
        List<DbClass> GetDbClassList();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class DbClass
    {              
        [DataMember]
        public string STableCatalog { get; set; }

        [DataMember]
        public string STableScheme { get; set; }

        [DataMember]
        public string STableName { get; set; }

        [DataMember]
        public string STableType { get; set; }

        public override string ToString()
        {
            return string.Format("STableCatalog:{0},STableScheme:{1},STableName:{2},STableType:{3}\n", STableCatalog, STableScheme, STableName, STableType);
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp46.GetSalesOrderService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GetSalesOrderService.IGetSODDT")]
    public interface IGetSODDT {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetSODDT/GetSalesOrderDetailDT", ReplyAction="http://tempuri.org/IGetSODDT/GetSalesOrderDetailDTResponse")]
        System.Data.DataTable GetSalesOrderDetailDT();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetSODDT/GetSalesOrderDetailDT", ReplyAction="http://tempuri.org/IGetSODDT/GetSalesOrderDetailDTResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetSalesOrderDetailDTAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGetSODDTChannel : WpfApp46.GetSalesOrderService.IGetSODDT, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetSODDTClient : System.ServiceModel.ClientBase<WpfApp46.GetSalesOrderService.IGetSODDT>, WpfApp46.GetSalesOrderService.IGetSODDT {
        
        public GetSODDTClient() {
        }
        
        public GetSODDTClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetSODDTClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetSODDTClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetSODDTClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetSalesOrderDetailDT() {
            return base.Channel.GetSalesOrderDetailDT();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetSalesOrderDetailDTAsync() {
            return base.Channel.GetSalesOrderDetailDTAsync();
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp280.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDateService")]
    public interface IDateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateService/GetDate", ReplyAction="http://tempuri.org/IDateService/GetDateResponse")]
        System.DateTime GetDate();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateService/GetDate", ReplyAction="http://tempuri.org/IDateService/GetDateResponse")]
        System.Threading.Tasks.Task<System.DateTime> GetDateAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDateServiceChannel : ConsoleApp280.ServiceReference1.IDateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DateServiceClient : System.ServiceModel.ClientBase<ConsoleApp280.ServiceReference1.IDateService>, ConsoleApp280.ServiceReference1.IDateService {
        
        public DateServiceClient() {
        }
        
        public DateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.DateTime GetDate() {
            return base.Channel.GetDate();
        }
        
        public System.Threading.Tasks.Task<System.DateTime> GetDateAsync() {
            return base.Channel.GetDateAsync();
        }
    }
}

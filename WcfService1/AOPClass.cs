using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Reflection;
using System.ServiceModel.Channels;

namespace WcfService1
{
    public class AOPClass : IOperationBehavior, IParameterInspector
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
           
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine("******返回操作名称: " + operationName);
            Console.WriteLine("******返回操作编号: " + correlationState.ToString() + "*******");

            for(int i=0;i<outputs.Length;i++)
            {
                Type type = outputs[i].GetType();
                Console.WriteLine("返回操作参数: " + i.ToString() + " 类型为: " + type.ToString());
                Console.WriteLine("返回操作参数: " + i.ToString() + " ToString()为: " + outputs[i].ToString());
                Console.WriteLine("返回操作参数: " + i.ToString() + " 属性: ");

                PropertyInfo[] pis = type.GetProperties();
                foreach(PropertyInfo pi in pis)
                {
                    Console.WriteLine(pi.Name + ":");
                    Console.WriteLine(pi.GetValue(outputs[i], null));
                }
            }

            Type returnType = returnValue.GetType();
            Console.WriteLine("操作返回值: " + " 类型为: " + returnType.ToString());
            Console.WriteLine("操作返回值: " + " ToString() 为:" + returnType.ToString());
            Console.WriteLine("操作返回值: " + " 属性: ");

            if(returnType.ToString()!="System.String")
            {
                PropertyInfo[] pInfos = returnType.GetProperties();
                foreach(PropertyInfo pi in pInfos)
                {
                    Console.WriteLine(pi.Name + ":");
                    Console.WriteLine(pi.GetValue(returnValue, null));
                }
            }

        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(this);
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            Guid newGuid = Guid.NewGuid();
            Console.WriteLine("******调用操作名称: " + operationName + "******");
            Console.WriteLine("******调用操作编号: " + newGuid.ToString() + "******");
            for(int i=0;i<inputs.Length;i++)
            {
                Type t = inputs[i].GetType();
                Console.WriteLine("操作参数: " + i.ToString() + " 类型为: " + t.ToString());
                Console.WriteLine("操作参数: " + i.ToString() + " ToString()为: " + inputs[i].ToString());
                Console.WriteLine("操作参数: " + i.ToString() + " 属性:");

                PropertyInfo[] pis = t.GetProperties();
                foreach(PropertyInfo pi in pis)
                {
                    Console.WriteLine(pi.Name + ": ");
                    Console.WriteLine(pi.GetValue(inputs[i], null));
                }
            }
            return newGuid;
        }

        public void Validate(OperationDescription operationDescription)
        {
            
        }
    }
}
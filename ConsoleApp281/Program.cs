﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Reflection;
using System.ServiceModel.Channels;
using WcfServiceLibrary1;

namespace ConsoleApp281
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfServiceLibrary1.Service1 dateTimeService = new Service1();
            DateTime dt = dateTimeService.GetDateTime();
            MyServiceHost msh = new MyServiceHost(typeof(WcfServiceLibrary1.Service1));
            msh.Open();
            Console.WriteLine("服务已开启，回车关闭服务!");
            Console.ReadLine();
            msh.Close();
        }
    }

    class MyParameterInspector : IOperationBehavior, IParameterInspector
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
           
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine("******返回操作名称: " + operationName + "******");
            Console.WriteLine("******返回操作编号: " + correlationState.ToString() + "******");
            for(int i=0;i<outputs.Length;i++)
            {
                Type type = outputs[i].GetType();
                Console.WriteLine("返回操作参数" + i.ToString() + " 类型为:" + type.ToString());
                Console.WriteLine("返回操作参数" + i.ToString() + "ToString() 为:" + outputs[i].ToString());
                Console.WriteLine("返回操作参数" + i.ToString() + " 属性:");

                PropertyInfo[] pis = type.GetProperties();
                foreach(PropertyInfo pi in pis)
                {
                    Console.WriteLine(pi.Name + ":");
                    Console.WriteLine(pi.GetValue(outputs[i], null));
                }
            }

            Type returnType = returnValue.GetType();
            Console.WriteLine("操作返回值类型为: " + returnType.ToString());
            Console.WriteLine("操作返回值ToString()为: " + returnType.ToString());
            Console.WriteLine("操作返回值属性");

            if(returnType.ToString()!="System.String")
            {
                PropertyInfo[] pInfos = returnType.GetProperties();
                foreach(PropertyInfo pi in pInfos)
                {
                    Console.WriteLine(pi.Name);
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
            for (int i = 0; i < inputs.Length; i++)
            {
                Type type = inputs[i].GetType();
                Console.WriteLine("操作参数" + i.ToString() + " 类型为: " + i.ToString());
                Console.WriteLine("操作参数" + i.ToString() + " ToString()为: " + inputs[i].ToString());
                Console.WriteLine("操作参数" + "属性:");
                PropertyInfo[] pis = type.GetProperties();
                foreach (PropertyInfo pi in pis)
                {
                    Console.WriteLine(pi.Name);
                    Console.WriteLine(pi.GetValue(inputs[i], null));
                }
            }
            return newGuid;
        }

        public void Validate(OperationDescription operationDescription)
        {
             
        }
    }

    public class MyServiceHost:ServiceHost
    {
        public MyServiceHost(Type serviceType,params Uri[] baseAddresses):base(serviceType,baseAddresses)
        {

        }

        //应用配置文件设置
        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();

            //加入参数检查服务
            AddGuidValidation();
        }

        private void AddGuidValidation()
        {
            int endPointsCount = this.Description.Endpoints.Count;
            MyParameterInspector mypi = new MyParameterInspector();
            for(int i=0;i<endPointsCount;i++)
            {
                if(this.Description.Endpoints[i].Contract.Name!="IMetadataExchange")
                {
                    int operationsCount = this.Description.Endpoints[i].Contract.Operations.Count;
                    for(int j=0;j<operationsCount;j++)
                    {
                        this.Description.Endpoints[i].Contract.Operations[j].Behaviors.Add(mypi);
                    }
                }
            }
        }
    }
}

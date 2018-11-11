using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text; 

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DateService : ServiceHost, IDateService
    {
        public DateService(Type serviceType,params Uri[] baseAddresses):base(serviceType,baseAddresses)
        {

        }

        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();

            //加入参数检查服务

            AddGuidValidation();

        }

        //加入参数检查服务
        private void AddGuidValidation()
        {
            int endPointsCount = this.Description.Endpoints.Count;
            AOPClass aopObj = new AOPClass();
            for(int i=0;i<endPointsCount;i++)
            {
                if(this.Description.Endpoints[i].Contract.Name!="IMetadataExchange")
                {
                    int operationCount = this.Description.Endpoints[i].Contract.Operations.Count;
                    for(int j=0;j<operationCount;j++)
                    {
                        this.Description.Endpoints[i].Contract.Operations[j].Behaviors.Add(aopObj);

                    }
                }
            }
        }
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}

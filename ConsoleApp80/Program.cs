using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ConsoleApp80
{
    //发布器类
    public class EventTest
    {
        private int value;
        public delegate void NumManipulationHandler();
        public event NumManipulationHandler ChangeNum;

        protected virtual void OnNumChanged()
        {
            if (null != ChangeNum)
            {
                //事件被触发
                ChangeNum();
                
            }
            else
            {
                Console.WriteLine("event not fired");
            }
        }

        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }

        public void SetValue(int n)
        {
            if(value!=n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }

    //订阅器类
    public class SubscribedEvent
    {
        public void Printf()
        {
            Console.WriteLine("event fire");
        }
    }

    //触发
    class Program
    {
        public static void Main(string[] args)
        {

            //实例化对象，第一次没有触发事件
            EventTest e = new EventTest();
            //实例化对象
            SubscribedEvent v = new SubscribedEvent();
            //注册
            e.ChangeNum += new EventTest.NumManipulationHandler(v.Printf);
            e.SetValue(7);
            e.SetValue(11);
            Console.ReadLine();
        }
    }
}

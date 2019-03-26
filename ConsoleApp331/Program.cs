using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Specialized;

namespace ConsoleApp331
{
    //This delegate must have the same signature as the method it will call asynchronously.
    public delegate string AsyncMethodDel(int callDuration, out int threadId);
    public delegate string GetNowDel(DateTime dt);
   
    
    class Program
    {
        static int requestCounter;
        static ArrayList hostData = new ArrayList();
        static StringCollection hostNames = new StringCollection();
          
        static void Main(string[] args)
        {
            TestThreadPool();
            Console.ReadLine();
        }

        static void TestThreadPool()
        {
            //Queue the task.
            ThreadPool.QueueUserWorkItem(QuqueWorkWaitCallback);
            Console.WriteLine("Main thread does some work,then sleeps");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread exists.");
        }

        static void QuqueWorkWaitCallback(object obj)
        {
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
        }

        static void TestAsyncCallback()
        {
            //Create the delegate that will process the results of the asynchronous request.
            AsyncCallback asyncCallback = new AsyncCallback(ProcessDnsInformation);
            string host;
            do
            {
                Console.WriteLine("Enter the name of a host computer or <Enter> to finish: ");
                host = Console.ReadLine();
                if(host.Length>0)
                {
                    //Increment the request counter in a thread safe 
                    Interlocked.Increment(ref requestCounter);
                    //Start the asynchronous request for DNS information.
                    Dns.BeginGetHostEntry(host, asyncCallback, host);
                }
            } while (host.Length>0);

            while(requestCounter>0)
            {
                UpdateUserInterface();
            }

            //Display the results
            for(int i=0;i<hostNames.Count;i++)
            {
                object data = hostData[i];
                string msg = data as string;
                
                //A SocketException was thrown
                if(!string.IsNullOrEmpty(msg))
                {
                    Console.WriteLine($"Request for {hostNames[i]} returned message {msg}");
                }

                //Get the results
                IPHostEntry hostEntry = (IPHostEntry)data;
                string[] aliases = hostEntry.Aliases;
                IPAddress[] address = hostEntry.AddressList;
                if(aliases.Length>0)
                {
                    Console.WriteLine($"Aliases for {hostNames[i]}");
                    for(int j=0;j<aliases.Length;j++)
                    {
                        Console.WriteLine(aliases[j]);
                    }
                }

                if(address.Length>0)
                {
                    Console.WriteLine($"Addresses for {hostNames[i]}");
                    for(int k=0;k<address.Length;k++)
                    {
                        Console.WriteLine(address[k].ToString());
                    }
                }
            }
        }

        //The following method is called when each asynchronous operation completed.
        static void ProcessDnsInformation(IAsyncResult asyncResult)
        {
            string hostName = (string)asyncResult.AsyncState;
            hostNames.Add(hostName);

            try
            {
                //Get the results
                IPHostEntry host = Dns.EndGetHostEntry(asyncResult);
                hostData.Add(host);
            }
            catch(SocketException ex)
            {
                hostData.Add(ex.Message);
            }
            finally
            {
                //Decrement the request counter in a thread-safe manner.
                Interlocked.Decrement(ref requestCounter);
            }
        }
        static void UpdateUserInterface()
        {
            Console.WriteLine($"{requestCounter} requests remaining");
        }
        static void IAsyncResultAsyncDelegate()
        {
            //Create the delegate.
            GetNowDel getNowCaller = new GetNowDel(GetTimeMethod);
            IAsyncResult asyncResult = getNowCaller.BeginInvoke(DateTime.Now, new AsyncCallback(GetTimeCallback),
                "The call executed on thread {0},with return value {1}");
            Console.WriteLine($"The main thread {Thread.CurrentThread.ManagedThreadId} continues to execute...");
            
            Console.WriteLine("The main thread ends");
        }

        static void GetTimeCallback(IAsyncResult ar)
        {
            //Retrieve the delegate.
            AsyncResult asyncResult = ar as AsyncResult;
            if(asyncResult!=null)
            {
                GetNowDel caller = (GetNowDel)asyncResult.AsyncDelegate;

                //retrieve the format string that was passed as state information.
                string formatString = (string)ar.AsyncState;
                
                string returnValue = caller.EndInvoke(ar);
                Console.WriteLine(formatString, Thread.CurrentThread.ManagedThreadId, returnValue);
            }
        }

        static void TestIAsyncResultIsCompleted()
        {
            //Create the delegate.
            GetNowDel getNowCaller = new GetNowDel(GetTimeMethod);

            //Initiate the asynchronous call.
            IAsyncResult asyncResult = getNowCaller.BeginInvoke(DateTime.Now, new AsyncCallback(GetTimeNowCallBack), "This is the IAsyncResult IsCompleted property");

            //Poll while simulating work.
            while(asyncResult.IsCompleted==false)
            {
                Console.WriteLine($"The asyncResult.IsCompleted==false,now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            }

            //call EndInvoke to retrieve the results
            string returnValue = getNowCaller.EndInvoke(asyncResult);
            Console.WriteLine($"\nThe call execute on thread {Thread.CurrentThread.ManagedThreadId}," +
                $"with return value {returnValue}");
        }
        static void TestWaitHandle()
        {
            //Create the delegate.
            GetNowDel getNowCaller = new GetNowDel(GetTimeMethod);

            //Initiate the asynchronous call.
            IAsyncResult asyncResult = getNowCaller.BeginInvoke(DateTime.Now, new AsyncCallback(GetTimeNowCallBack), "This is the WaitHandle");

            string asyncState = asyncResult.AsyncState.ToString();
            Console.WriteLine($"AsyncState is {asyncState}");

            //Wait for the WaitHandle to become signaled.
            asyncResult.AsyncWaitHandle.WaitOne();

            //Perform additional processing here.
            //call EndInvoke to retrieve the results.
            string returnValue = getNowCaller.EndInvoke(asyncResult);

            //Close the wait handle.

            asyncResult.AsyncWaitHandle.Close();
            Console.WriteLine($"The call executed on thread {Thread.CurrentThread.ManagedThreadId},with return " +
                $"value {returnValue} ");
        }
        static void InvokeGetTimeMethod()
        {
            GetNowDel getNowDel = new GetNowDel(GetTimeMethod);
            IAsyncResult result = getNowDel.BeginInvoke(DateTime.Now, new AsyncCallback(GetTimeNowCallBack),
                "This is the GetTime now async state ");
            string asyncState = result.AsyncState.ToString();
            Console.WriteLine($"The AsyncState is {asyncState}");
            string finalResult = getNowDel.EndInvoke(result);
            Console.WriteLine($"FinalResult is {finalResult}");
        }
        static void GetTimeNowCallBack(IAsyncResult ar)
        {
            Console.WriteLine("This is the GetTimeNowCallBack(IAsyncResult ar) method");
            string asyncState = ar.AsyncState.ToString();
            if(!string.IsNullOrEmpty(asyncState))
            {
                Console.WriteLine(asyncState);
            }
        }
        static void TestEndInvoke()
        {
            //The asynchronous method puts the thread id here.
            int threadId;

            //Create the delegate.
            AsyncMethodDel asyncCaller = new AsyncMethodDel(TestAsyncMethod);

            //Initiate the asynchronous call.
            IAsyncResult asyncResult = asyncCaller.BeginInvoke(3000, out threadId, null, "This is async state");
            string asyncState = asyncResult.AsyncState.ToString();
            Console.WriteLine(asyncState);
            Thread.Sleep(0);
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId} does some work");

            //Call EndInvoke to wait for the asynchronous call to complete,and to retrieve the results
            string returnValue = asyncCaller.EndInvoke(out threadId, asyncResult);
            Console.WriteLine($"The call executed on thread {threadId}, with returned value {returnValue}");
        }
        //The method to be executed asynchronously
        static string TestAsyncMethod(int callDuration,out int threadId)
        {
            Console.WriteLine("Test method begins");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return string.Format($"My call time was {callDuration.ToString()}");
        }

        static string GetTimeMethod(DateTime dt)
        {
            Console.WriteLine("This is GetTimeMethod() method!");             
            return dt.ToString("yyyyMMddHHmmssffff");
        }
    }
}

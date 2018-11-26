using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace ConsoleApp292
{
    interface IMath
    {
        void Add(int x, int y);
        void Subtract(int x, int y);
    }
    class Program:IDisposable,IMath
    {
        public event EventHandler FirstEvent;
        public event EventHandler SecondEvent;
        public string Name { get; set; }
        public int Age { get; set; }
        private string name = "Floomberg";
        public int age = 31;
        protected decimal Asset = 100000000.0m;
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.FirstEvent += Obj_FirstEvent;
            if(obj.FirstEvent!=null)
            {
                Obj_FirstEvent(obj, new EventArgs());
            }
            Type type = typeof(Program);
            FieldInfo[] fis = type.GetFields();
            if(fis!=null && fis.Any())
            {
                Console.WriteLine("FieldInfo:");
                fis.All(x =>
                {
                    Console.WriteLine(x.Name);
                    return true;
                });
                Console.WriteLine("\n\n\n");
            }
            MemberInfo[] mis = type.GetMembers();
            if(mis!=null && mis.Any())
            {
                Console.WriteLine("MemberInfo:");
                mis.All(x =>
                {
                    Console.WriteLine(x.Name);
                    return true;
                });
                Console.WriteLine("\n\n\n");
            }

            MethodInfo[] miss = type.GetMethods();
            if(miss!=null && miss.Any())
            {
                Console.WriteLine("MethodInfo:");
                miss.All(x =>
                {
                    Console.WriteLine(x.Name);
                    return true;
                });
                Console.WriteLine("\n\n\n");
            }

            Type[] types = type.GetInterfaces();
            if(types!=null && types.Any())
            {
                Console.WriteLine("GetInterfaces");
                types.All(x =>
                {
                    Console.WriteLine(x.FullName);
                    return true;
                });
                Console.WriteLine("\n\n\n");
            }

            PropertyInfo[] pis = type.GetProperties();
            if(pis!=null && pis.Any())
            {
                Console.WriteLine("Properties:");
                pis.All(x =>
                {
                    Console.WriteLine(x.Name);
                    return true;
                });
                Console.WriteLine("\n\n\n");
            }

            EventInfo[] eis = type.GetEvents();
            if(eis!=null && eis.Any())
            {
                Console.WriteLine("EventInfo:");
                eis.All(x =>
                {
                    Console.WriteLine(x.Name);
                    return true;
                });
                Console.WriteLine("\n\n\n");
            }
            Console.ReadLine();
        }

        private static void Obj_FirstEvent(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }

        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
            if(num<=0)
            {
                return;
            }

            
            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for (int j=2;j<=Math.Sqrt(i);j++)
                {
                    if(i%j==0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime)
                {
                    primeList.Add(i);
                }
            }

            primeList.ForEach(x =>
            {
                Console.Write(x + "\t");
            });
        }
        static void ArraySample()
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(1, 1000);
            }
            Console.WriteLine("The original array:\n");
            arr.All(x =>
            {
                Console.Write(x + "\t");
                return true;
            });

            Array.Sort(arr);
            Console.WriteLine("\n\n\nThe sorted array:\n");
            arr.All(x =>
            {
                Console.Write(x + "\t");
                return true;
            });
        }
        static void Top10Languages()
        {
            string[] top10Language = new string[] { "Javascript", "Java", "Python", "PHP", "C++", "C#", "TypeScript", "Shell", "C", "Ruby" };

            top10Language.All(x =>
            {
                Console.WriteLine(x);
                return true;
            });
        }
        static void IntTryParse()
        {
            int num;
            string str;
            Console.Write("Enter a number: ");
            str = Console.ReadLine();
            if (int.TryParse(str, out num))
            {
                Console.WriteLine("You entered num is {0}\n", num);
            }
        }
        static void ArrayListCapacityExpandAutomobile()
        {
            ArrayList al = new ArrayList();
            al.Capacity = 3;
            for (int i = 0; i < 10; i++)
            {
                al.Add(i);
            }
            Console.WriteLine(al.Capacity);
        }
        static void StackOrder()
        {
            Stack<int> intStack = new Stack<int>();
            Console.WriteLine("The pushed order:");
            for (int i = 0; i < 10; i++)
            {
                intStack.Push(i);
                Console.Write(i + "\t");
            }

            Console.WriteLine("\n\n\n\n\nThe popped up order:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(intStack.Pop() + "\t");
            }
        }
        static void QueueOrder()
        {
            Queue<int> intQueue = new Queue<int>();

            Console.WriteLine("The enqueue order: ");
            for (int i = 0; i < 10; i++)
            {
                intQueue.Enqueue(i);
                Console.Write(i + "\t");
            }

            Console.WriteLine("\n\n\n\n\nThe dequeue order: ");
            while (intQueue.Count > 0)
            {
                Console.Write(intQueue.Dequeue() + "\t");
            }
        }
        static void SQLADONET()
        {
            string selectSQL = "select * from Production.Product where  ProductID > all(select ProductID from Production.Product where ProductID>500 and ProductID<=800)";
            string connString = ConfigurationManager.AppSettings["conString"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(selectSQL, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.CommandText = selectSQL;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {


                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                string formatMsg = string.Format("{0,-10}:{1,-30}" + "\t",
                                    ds.Tables[0].Columns[j].ColumnName,
                                    ds.Tables[0].Rows[i][j].ToString());
                                Console.Write(formatMsg);
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("\n\n\n\n\nThere are totally {0} rows data in the table", ds.Tables[0].Rows.Count);
                    }
                }
            }
        }
        public void Dispose()
        {
            this.Dispose();
        }

        public void Add(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Subtract(int x, int y)
        {
            throw new NotImplementedException();
        }
    }

    public  sealed  class Singleton
    {
        private Singleton()
        {
        }
        private static Singleton Instance;
        private static string str = "loclObj";
        public static Singleton GetSingleton()
        {
            lock(str)
            {
                if(Instance==null)
                {
                    Instance = new Singleton();
                }
                return Instance;
            }
        }
    }
}

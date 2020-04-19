using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Dynamic;

namespace ConsoleApp419
{
    delegate void StringAction(string str);
    public delegate T Transformer<T>(T arg);
    public delegate void ProgressReporter(int percentComplete);
    delegate int Transformer(int x);
    public interface ITransformer
    {
        int Trans(int x);
    }
    delegate int CubeDel(int x);
    delegate object ObjectRetriever();
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);
    public delegate void EventHandler<TEventArgs>(object source, TEventArgs e) where TEventArgs : EventArgs;
    public delegate void PriceChangedHandler2(object sender, PriceChangedEventArgs e);
    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChangedEvent;
    }
    class Program
    {
        static void Main(string[] args)
        {
            DynamicConvert();
            Console.ReadLine();
        }

        static void DynamicConvert()
        {
            int i = 7;
            dynamic d = i;
            short j = d;
        }

        #region Demo

        static void DynamicReferenceObjectReference()
        {
            object obj = new System.Text.StringBuilder();
            dynamic d = obj;
            d.Append("Hello");
            Console.WriteLine(obj);
        }

        static void DynamicDemo2()
        {
            dynamic x = "Hello";
            Console.WriteLine(x.GetType().Name);
            x = 123;
            Console.WriteLine(x.GetType().Name);
        }

        static dynamic Mean(dynamic x, dynamic y) => (x + y) / 2;


        static void DynamicDemo()
        {
            //The Duck class doesn’t actually have a Quack method.Instead, it uses custom binding to intercept and interpret all method calls.
            dynamic d = new Duck();
            d.Quack();
            d.Waddle();
        }

        static void PropertyChanegdDemo()
        {
            ImplementINotifyPropertyChanged a = new ImplementINotifyPropertyChanged();
            a.CustomerName = "Fred";
            a.PropertyChangedEvent += A_PropertyChangedEvent;

            a.CustomerName = "FLIF";

        }

        private static void A_PropertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            ImplementINotifyPropertyChanged obj = sender as ImplementINotifyPropertyChanged;
            if (obj != null)
            {
                Console.WriteLine(obj.CustomerName);
            }
        }


        static void AttributesDemo([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            Console.WriteLine(memberName);
            Console.WriteLine(filePath);
            Console.WriteLine(lineNumber);
        }

        static void TupleDemo3()
        {
            Tuple<string, int> t = Tuple.Create("Fred", 23);
            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);
        }

        static void TupleEquals()
        {
            var tuple1 = ("One", 1);
            var tuple2 = ("One", 1);
            Console.WriteLine(tuple1.Equals(tuple2));
        }

        static void TupleDeconstructDemo()
        {
            var (name, age, sex) = TupleConstruct();
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(sex);
        }

        static (string, int, char) TupleConstruct() => ("Fred", 32, 'M');

        static void TupleDeconstruct()
        {
            var fred = ("Fred", 32);
            (string name, int age) = fred;
            Console.WriteLine(name);
            Console.WriteLine(age);
        }

        static void ValueTupleDemo()
        {
            ValueTuple<string, int> vt = ValueTuple.Create("Bob", 32);
            (string, int) bob2 = ValueTuple.Create("Bob2", 21);
            Console.WriteLine(vt.Item1);
            Console.WriteLine(vt.Item2);
            Console.WriteLine(bob2.Item1);
            Console.WriteLine(bob2.Item2);
        }

        static void TupleNames()
        {
            var tuple = (Name: "FLIF", Age: 23);
            Console.WriteLine(tuple.Age);
            Console.WriteLine(tuple.Age);
        }

        static void TupleDemo2()
        {
            (string, int) bob = ("Fred", 1);
            Console.WriteLine(bob.Item1);
            Console.WriteLine(bob.Item2);
        }


        static void TupleDemo()
        {
            var bod = ("Fred", 32);
            Console.WriteLine(bod);
            Console.WriteLine($"Item1:{bod.Item1},Item2:{bod.Item2}");
            var joe = bod;
            Console.WriteLine(joe);
        }


        static void AnnoymousTypeDemo()
        {
            var dude = new { Name = "Fred", ID = 32 };
            Console.WriteLine($"Name:{dude.Name},Id:{dude.ID}");
        }
        static void ThisExtensionMethodDemo()
        {
            Console.WriteLine("SMIF".IsCapitalized());
            Console.WriteLine(StringHelper.IsCapitalized("SMFI"));
        }

        static void ArrayIndexOfDemo()
        {
            Array a = Array.CreateInstance(typeof(string), new int[] { 2 }, new int[] { 1 });
            a.SetValue("a", 1);
            a.SetValue("b", 2);
            Console.WriteLine(Array.IndexOf(a, "c"));
        }

        static void UnBoxNullableAs()
        {
            object s = "string";
            int? x = s as int?;
            Console.WriteLine(x.HasValue);
        }
        static void NullableConversions()
        {
            int? x = 5;
            int y = (int)x;
            Console.WriteLine(y);
        }

        static void NullableTypeDemo()
        {
            int? i = null;
            Console.WriteLine($"i==null,{i == null}");
            Console.WriteLine(i.HasValue);
        }

        static void FibEven()
        {
            foreach (int fib in EvenNumbersOnly(Fibs(6)))
            {
                Console.WriteLine(fib);
            }
        }

        static IEnumerable<int> Fibs3(int fibCount)
        {
            for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
            {
                yield return prevFib;
                int newFib = prevFib + curFib;
                prevFib = curFib;
                curFib = newFib;
            }
        }

        static IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
        {
            foreach (int x in sequence)
            {
                if ((x % 2) == 0)
                {
                    yield return x;
                }
            }
        }

        static void YieldBreakDemo()
        {
            IEnumerable<string> source = Foo2(true);
            foreach (var a in source)
            {
                Console.WriteLine(a);
            }
        }

        static IEnumerable<string> Foo2(bool breakEarly)
        {
            yield return "One";
            yield return "Two";
            //if(breakEarly)
            //{
            //    yield break;
            //}
            yield return "three";
        }


        static void YieldDemo()
        {
            IEnumerable<string> source = Foo();
            foreach (string s in source)
            {
                Console.WriteLine(s);
            }
        }

        static IEnumerable<string> Foo()
        {
            yield return "one";
            yield return "two";
            yield return "three";
        }

        static void FibDemo()
        {
            foreach (int fib in Fibs(6))
            {
                Console.WriteLine(fib);
            }
        }


        static IEnumerable<int> Fibs(int fibCount)
        {
            for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
            {
                yield return prevFib;
                int newFib = prevFib + curFib;
                prevFib = curFib;
                curFib = newFib;
            }
        }
        static void DictionaryDemo()
        {
            var dict = new Dictionary<int, string>()
            {
                {5,"Five"},
                {10,"Ten"}
            };

            var dict2 = new Dictionary<int, string>()
            {
                [3] = "three",
                [10] = "ten"
            };

            foreach (var di in dict2)
            {
                Console.WriteLine($"Key:{di.Key},Value:{di.Value}");
            }
        }

        static void GetEnumeratorDemo()
        {
            using (var enumerator = "beer".GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var element = enumerator.Current;
                    Console.WriteLine(element);
                }
            }
        }
        static void WebClientDemo()
        {
            string str = null;
            using (WebClient wc = new WebClient())
            {
                try
                {
                    str = wc.DownloadString("http://www.albahari.com/nutshell/");
                    Console.WriteLine(str);
                }
                catch (WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
                {
                    Console.WriteLine("Timeout");
                }
            }
        }

        static void CaseDemo()
        {
            string str = "This is a test!";
            string convertedString = ProperCase(str);
            Console.WriteLine($"{str}");
        }

        static string ProperCase(string value) =>
            value == null ? throw new ArgumentException("value") : value == "" ? "" :
            char.ToUpper(value[0]) + value.Substring(1);

        static void DisplayDemo()
        {
            try
            {
                DisplayName(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Caught the exception! {ex.Message}");
            }
        }

        static void DisplayName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Console.WriteLine(name);
        }
        static void ReadFile2()
        {
            StreamReader reader = null;
            try
            {
                reader = File.OpenText("a.txt");
                if (reader.EndOfStream)
                {
                    return;
                }
                Console.WriteLine(reader.ReadToEnd());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }
        }

        static void ReadFile()
        {
            using (StreamReader reader2 = new StreamReader("a.txt"))
            {
                string str = reader2.ReadToEnd();
                Console.WriteLine(str);
            }
        }
        static void IndexOutOfRangeExceptionDemo(string[] args)
        {
            try
            {
                byte b = byte.Parse(args[0]);
                Console.WriteLine(b);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Please provide at least one argument");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("That's not a number!");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("You've given me more than a byte!");
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
            {
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.SendFailure)
            {
            }
        }

        static void DivideByZero()
        {
            try
            {
                int y = Calc(0);
                Console.WriteLine(y);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("X cannot be zero!");
            }
            Console.WriteLine("Program completed!");
        }

        static int Calc(int x) => 10 / x;

        public event EventHandler ClickedEvent = delegate { };

        void ClickedDemo()
        {
            ClickedEvent += delegate { Console.WriteLine("Clicked!"); };
        }

        static void TransXDemo()
        {
            Transformer trans = x => x * x * x;
            Console.WriteLine(trans(100));
        }

        static void DelDemo()
        {
            Transformer trans = delegate (int x) { return x * x * x; };
            Console.WriteLine(trans(1000));
        }
        static void ActionDemo()
        {
            Action[] actionArr = new Action[3];
            for (int i = 0; i < 3; i++)
            {
                int temp = i;
                actionArr[i] = () => Console.WriteLine(temp);
            }

            foreach (Action ac in actionArr)
            {
                ac();
            }
        }

        static void Natural2Demo()
        {
            Func<int> nac = Natural2();
            Console.WriteLine(nac());
            Console.WriteLine(nac());
            Console.WriteLine(nac());
            Console.WriteLine(nac());
        }

        static Func<int> Natural2()
        {
            return () => { int seed = 0; return seed++; };
        }
        static void NaturalDemo()
        {
            Func<int> naturalFunc = Natural();
            Console.WriteLine(naturalFunc());
            Console.WriteLine(naturalFunc());
            Console.WriteLine(naturalFunc());
        }

        static Func<int> Natural()
        {
            int seed = 0;
            return () => seed++;
        }

        static void MultiplyDemo()
        {
            int factor = 2;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(100000000));
        }

        static void FuncDemo()
        {
            Program obj = new Program();
            int result = obj.GetLengthFunc("Make every second count", "Cherish the present moment");
            Console.WriteLine(result);
        }
        Func<string, string, int> GetLengthFunc = (s1, s2) => s1.Length + s2.Length;
        Action<int> act = x => Console.WriteLine(x * x * x);

        Func<int, int, int> func = (x, y) => x + y;

        Func<int, int> squareFunc = (x) => x * x;
        Func<int, int> CubeFunc = (x) => x * x * x;

        static void StockDemo()
        {
            Stock3 stk = new Stock3("SMIF");
            stk.Price = 27.10M;
            stk.PriceChangedEvent += StkPriceChangedEvent;
            stk.Price = 31.59M;
        }

        private static void StkPriceChangedEvent(object source, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
            {
                Console.WriteLine("Alert,10% stock price increase!");
            }
        }

        PriceChangedHandler priceChangedEvent;
        public event PriceChangedHandler PriceChangedEvent
        {
            add
            {
                priceChangedEvent += value;
            }
            remove
            {
                priceChangedEvent -= value;
            }
        }

        static string RetrieveString() => "Current";

        static void CubeDemo()
        {
            CubeDel cube = Cube;
            IAsyncResult asyncResult = cube.BeginInvoke(1000, CubeCB, null);
            int result = cube.EndInvoke(asyncResult);
            Console.WriteLine(result);
        }

        private static void CubeCB(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState);
        }

        static void StringActionDemo()
        {
            StringAction sa = new StringAction(ActOnObject);
            IAsyncResult asyncResult = sa.BeginInvoke("Current", Callback, null);
            sa.EndInvoke(asyncResult);
        }

        private static void Callback(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState);
        }

        static void ActOnObject(object o) => Console.WriteLine(o);
        static void DelegateInterfaceDemo()
        {
            int[] values = { 100, 200, 300 };
            TransformAll(values, new Cube());
            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }

        static void TransformAll(int[] values, ITransformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t.Trans(values[i]);
            }
        }

        static void Transform<T>(T[] values, Func<T, T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = transformer(values[i]);
            }
        }

        static void Transformer<T>(T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }

        static void DelegateTargetMethod()
        {
            Program x = new Program();
            ProgressReporter pr = x.InstanceProgress;
            pr(99);
            Console.WriteLine(pr.Target == x);
            Console.WriteLine(pr.Method);
        }

        void InstanceProgress(int percentComplete) => Console.WriteLine(percentComplete);

        static void WriteProgressToConsole(int percentComplete) =>
            Console.WriteLine(percentComplete);

        static void WriteProgressToFile(int percentComplete) => System.IO.File.WriteAllText("progresst.txt", percentComplete.ToString());

        static void HardWork(ProgressReporter pr)
        {
            for (int i = 0; i < 10; i++)
            {
                pr(i * 10);
                System.Threading.Thread.Sleep(100);
            }
        }

        static int Square(int x)
        {
            return x * x;
        }

        static int Cube(int x) => x * x * x;

        static int SquareX(int x) => x * x;

        static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }

        #endregion
    }

    #region History

    public class Duck : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine(binder.Name + " method was called!");
            result = null;
            return true;
        }
    }

    public class ImplementINotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChangedEvent;
        void OnPropertyChanged([CallerMemberName] string propName=null)
        {
            PropertyChangedEvent?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        string customerName;
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                if(value==customerName)
                {
                    return;
                }
                customerName = value;
                OnPropertyChanged();
            }
        }
    }

    public class PropertyChangedEventArgs:EventArgs
    {
        public PropertyChangedEventArgs(string propName) { }
        public virtual string PropName { get; }
    }
    public static class StringHelper
    {
        public static bool IsCapitalized(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            return char.IsUpper(str[0]);
        }
    }
    public class Stock2
    {
        public event EventHandler<PriceChangedEventArgs> PriceChangedEvent;
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            var tempEvent = PriceChangedEvent;
            if(tempEvent != null)
            {
                tempEvent(this, e);
            }
            PriceChangedEvent?.Invoke(this, e);
        }
    }

    public class Square : ITransformer
    {
        public int Trans(int x) => x * x;        
    }

    public class Cube : ITransformer
    {
        public int Trans(int x) => x * x * x;        
    }

    public class Stock
    {
        string symbol;
        decimal price;
        public Stock(string symbolValue)
        {
            symbol = symbolValue;
        }

        public event PriceChangedHandler PriceChangedEvent;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                if(PriceChangedEvent!=null)
                {
                    PriceChangedEvent(oldPrice, price);
                }
            }
        }         
    }

    public class PriceChangedEventArgs:System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;
        public PriceChangedEventArgs(decimal lastPriceValue,decimal newPriceValue)
        {
            LastPrice = lastPriceValue;
            NewPrice = newPriceValue;
        }
    }

    public class PriceChangedEventArgs3 : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs3(decimal lastPriceValue, decimal newPriceValue)
        {
            LastPrice = lastPriceValue;
            NewPrice = newPriceValue;
        }
    }

    public class Stock3
    {
        string symbol;
        decimal price;
        public Stock3(string symbolValue)
        {
            symbol = symbolValue;
        }

        public event EventHandler<PriceChangedEventArgs> PriceChangedEvent;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChangedEvent?.Invoke(this, e);
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }

    public class Stock4
    {
        string symbol;
        decimal price;
        public Stock4(string symbolValue)
        {
            symbol = symbolValue;
        }
        public event EventHandler PriceChangedEvent;
        protected virtual void OnPriceChanged(EventArgs e)
        {
            PriceChangedEvent?.Invoke(this, e);
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price == value)
                {
                    return;
                }
                price = value;
                OnPriceChanged(EventArgs.Empty);
            }
        }
    }

    public interface IFoo
    {
        event EventHandler Ev;
    }

    class Foo : IFoo
    {
        private event EventHandler ev;
        public event EventHandler Ev
        {
            add
            {
                ev += value;
            }
            remove
            {
                ev -= value;
            }
        }


    }

    public class Foo2
    {
        public static event EventHandler<EventArgs> StaticEvent;
        public virtual event EventHandler<EventArgs> VirtualEvent;
    }
    #endregion 
   
}

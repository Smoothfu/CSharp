using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace ConsoleApp328
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedListClass sortedList=new SortedListClass();
            Console.ReadLine();
        }


        static void KeyValuePairExample()
        {
            KeyValuePair<int, string>[] kvpArr = new  KeyValuePair<int, string>[10000];
            for(int i=0;i<10000;i++)
            {
                kvpArr[i] = new KeyValuePair<int, string>(i, "Fred" + i);
            }

            if(kvpArr!=null && kvpArr.Any())
            {
                foreach(KeyValuePair<int,string> kvp in kvpArr)
                {
                    Console.WriteLine($"Key:{kvp.Key},Value:{kvp.Value}");
                }
            }
        }
        static void CustomizeAttributes()
        {
            var attrs = Attribute.GetCustomAttributes(typeof(DerivedDerivedClass), true);
            if(attrs!=null && attrs.Any())
            {
                foreach(var att in attrs)
                {
                    var animal = att as AnimalAttribute;
                    Console.WriteLine($"Id {animal.Id},Name {animal.Name}");
                }
            }
        }
    }

    [System.AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    public class AnimalAttribute:Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Animal(Id =1,Name ="Fred1")]
    public class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine($"This is {typeof(BaseClass).Name}");
        }
    }

    [Animal(Id =2,Name ="Fred2")]
    public class DerivedClass:BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine($"This is {typeof(DerivedClass).Name}");
        }
    }

    [Animal(Id=3,Name ="Fred3")]
    [Animal(Id =4,Name ="Fred4")]
    [Animal(Id =5,Name ="Fred5")]
    public class DerivedDerivedClass:DerivedClass
    {
        public DerivedDerivedClass()
        {
            Console.WriteLine($"This is {typeof(DerivedDerivedClass).Name}");
        }
    }

    public class KeyValueDic:DictionaryBase
    {
        public KeyValueDic()
        {
            for(int i=0;i<10;i++)
            {
                Add(Guid.NewGuid(), i);
            }

            foreach(DictionaryEntry kv in base.InnerHashtable)
            {
                Console.WriteLine($"Key={kv.Key},value={kv.Value}");
            }
        }

        public void Add(Guid keyGuid,int i)
        {
            base.InnerHashtable.Add(keyGuid, i);
        }

        public string Item(Guid keyGuid)
        {
            return base.InnerHashtable[keyGuid].ToString();
        }

        public void Remove(Guid keyGuid)
        {
            base.InnerHashtable.Remove(keyGuid);
        }
    }

    public class KVDic:DictionaryBase
    {
        public KVDic()
        {
            for(int i=0;i<100000;i++)
            {
                Add(i, "Fred" + i);
            }
            foreach(DictionaryEntry de in base.InnerHashtable)
            {
                Console.WriteLine($"Key {de.Key}, Value {de.Value}");
            }
        }
        public void Add(int i,string name)
        {
            base.InnerHashtable.Add(i, name);
        }

        public string Item(int index)
        {
            return base.InnerHashtable[index].ToString();
        }

        public void Remove(int index)
        {
            base.InnerHashtable.Remove(index);
        }
    }

    public class SortedListClass
    {
        public SortedListClass()
        {
            SortedList<int, string> intStringList = new SortedList<int, string>();
            for(int i=0;i<10000;i++)
            {
                intStringList.Add(i, "Fred" + i);
            }

            foreach(var de in intStringList)
            {
                Console.WriteLine($"Key={de.Key},Value={de.Value}");
            }
        }
    }
}

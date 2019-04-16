using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp340
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassTest();
            StructTest();
            Console.ReadLine();
        } 

        static void ClassTest()
        {
            Console.WriteLine("Class Test:");
            Student stuA = new Student(1,"Fred1");
            Student stuB = stuA;
            Console.WriteLine($"stuA:{stuA.GetHashCode()},stuA.Id:{stuA.Id},stuA.Name:{stuA.Name}");
            Console.WriteLine($"stuB:{stuB.GetHashCode()},stuB.Id:{stuB.Id},stuB.Name:{stuB.Name}");
            stuA.Id = 3;
            stuA.Name = "Fred2";
            Console.WriteLine($"stuA:{stuA.GetHashCode()},stuA.Id:{stuA.Id},stuA.Name:{stuA.Name}");
            Console.WriteLine($"stuB:{stuB.GetHashCode()},stuB.Id:{stuB.Id},stuB.Name:{stuB.Name}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void StructTest()
        {
            Console.WriteLine("Struct Test:");
            StudentStruct stuA = new StudentStruct(1, "Fred1");
            StudentStruct stuB = stuA;
            Console.WriteLine($"stuA:{stuA.GetHashCode()},stuA.Id:{stuA.Id},stuA.Name:{stuA.Name}");
            Console.WriteLine($"stuB:{stuB.GetHashCode()},stuB.Id:{stuB.Id},stuB.Name:{stuB.Name}");
            stuA.Id = 2;
            stuA.Name = "Fred2";
            Console.WriteLine($"stuA:{stuA.GetHashCode()},stuA.Id:{stuA.Id},stuA.Name:{stuA.Name}");
            Console.WriteLine($"stuB:{stuB.GetHashCode()},stuB.Id:{stuB.Id},stuB.Name:{stuB.Name}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void StringPoolStay()
        {
            string strA = "这是美丽的春天，希望的春天，生机勃勃的春天；这是美丽的春天，希望的春天，生机勃勃的春天";
            string strB = strA;
            int aHashcode = strA.GetHashCode();
            Console.WriteLine($"strA:{strA},aHashcode:{aHashcode}");
            int bHashCode = strB.GetHashCode();
            Console.WriteLine($"strB:{strB},bHashCode:{bHashCode}");
            if (aHashcode == bHashCode)
            {
                Console.WriteLine("Equal");
            }
            strA = "Hello world,Everything depends on myself";
            aHashcode = strA.GetHashCode();
            Console.WriteLine($"strA:{strA},aHashcode:{aHashcode}");
            Console.WriteLine($"strB:{strB},bHashCode:{bHashCode}");
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Student(int id,string name)
        {
            Id = id;
            Name = name;
        }
        
    }

    struct StudentStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentStruct(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp80
{
    class Student
    {
        private string code = "N.A";
        private string name = "not known";
        private int age = 0;

        //声明类型为string的Code属性
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        //声明类型为string的Name属性
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        //声明类型为int的Age属性
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public override string ToString()
        {
            return "Code= " + code + ",Name= " + name + ",Age= " + age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个新的Student对象
            Student stu = new Student();
            //设置stu的code,name和age
            stu.Code = "0001";
            stu.Name = "Fred";
            stu.Age = 30;

            Console.WriteLine("Student Info:{0}", stu);

            //增加年龄
            stu.Age += 1;
            Console.WriteLine("Student Info:{0}", stu);
            Console.ReadLine();
            
           
            Console.ReadLine();
        }
    }
}

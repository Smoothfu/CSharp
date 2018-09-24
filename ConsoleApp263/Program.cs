using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp263
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>();
            for(int i=0;i<10;i++)
            {
                stuList.Add(new Student()
                {
                    StuId = i,
                    StuName = "Fred" + i,
                    StuAge = 31 + i,
                    StuScore = 100 + i
                });
            }

            for(int i=0;i<stuList.FirstOrDefault().GetType().GetProperties().Count();i++)
            {
                Console.WriteLine(stuList.FirstOrDefault().GetType().GetProperties()[i].Name);
            }
            Console.ReadLine();
        }
    }

    public class Student : INotifyPropertyChanged
    {
        private int stuId;
        public int StuId
        {
            get
            {
                return stuId;
            }
            set
            {
                stuId = value;
                NotifyPropertyChanged("StuId");
            }
        }

        private string stuName;
        public string StuName
        {
            get
            {
                return stuName;
            }
            set
            {
                stuName = value;
                NotifyPropertyChanged("StuName");
            }
        }


        private int stuAge;
        public int StuAge
        {
            get
            {
                return stuAge;
            }
            set
            {
                stuAge = value;
                NotifyPropertyChanged("StuAge");
            }
        }

        private int stuScore;
        public int StuScore
        {
            get
            {
                return stuScore;
            }
            set
            {
                stuScore = value;
                NotifyPropertyChanged("StuScore");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace CarLibrary
{
    public  class Car
    {
        public string CarName { get; set; }
        public double CurrentSpeed { get; set; }
        public double MaxSpeed { get; set; }
        public Car(string carName,double curSpeed)
        {
            CarName = carName;
            CurrentSpeed = curSpeed;
        }

        public Car(string carName,double curSpeed,double maxSpeed):this(carName,curSpeed)
        {
            MaxSpeed = maxSpeed;
        }

        public Car()
        {

        }
        public override string ToString()
        {
            return string.Format("{0}'s speed is :{1}\n", CarName, CurrentSpeed);
        }

        public virtual void Turbust()
        {
            Console.WriteLine("The car is turbust!\n");
        }
    }

    public class SuperCar : Car
    {
        public SuperCar(string carName, double curSpeed, double maxSpeed) : base(carName, curSpeed, maxSpeed)
        {
        }

        public override void Turbust()
        {
            Console.WriteLine("{0}'s speed is too fast!\n", CarName);
        }
    }

    public class MiniVan : Car
    {
        public MiniVan(string carName, double curSpeed, double maxSpeed) : base(carName, curSpeed, maxSpeed)
        {
        }

        public override void Turbust()
        {
            Console.WriteLine("{0}'s speed is too low!\n", CarName);
        }
    }
}

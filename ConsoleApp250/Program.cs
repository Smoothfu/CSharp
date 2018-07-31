using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace ConsoleApp250
{
    class Program
    {
        static void Main(string[] args)
        {
            //Manually work with IEnumerator.
            Garage carLot = new Garage();
            IEnumerator enumerator = carLot.GetEnumerator();
            enumerator.MoveNext();
            Car myCar = (Car)enumerator.Current;
            Console.WriteLine("Name:{0},Id:{1}\n", myCar.Name, myCar.Id);
           
            Console.ReadLine();
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Car(string carName,int carId)
        {
            Name = carName;
            Id = carId; 
        }
    }

    public class Garage : IEnumerable
    {
        //System.Array already implements IEnumerator!
        private Car[] carArray = new Car[5];
        public Garage()
        {
            carArray[0] = new Car("G650", 1);
            carArray[1] = new Car("GL550", 2);
            carArray[2] = new Car("Crusider", 3);
            carArray[3] = new Car("X6", 4);
            carArray[4] = new Car("S600", 5);
        }
        public IEnumerator GetEnumerator()
        {
            //return the array objects IEnumerator
            return carArray.GetEnumerator();
        }
    }
}

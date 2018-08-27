using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp255
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int result = Divide(10, 0);

            }

            //TargetSite actually returns a MethodBase object.
            catch(Exception ex)
            {
                Console.WriteLine("\n***Error!****");               
               
            }

            Console.WriteLine("\n*****Out of exception logic*****\n");
            Console.ReadLine();
        }

        static int Divide(int x,int y)
        {
            int result;
            try
            {
                result = x / y;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n***Error!****");
                Console.WriteLine("Member name:{0}\n", ex.TargetSite);
                Console.WriteLine("Class defining member:{0}\n", ex.TargetSite.DeclaringType);
                Console.WriteLine("Memeber type:{0}\n", ex.TargetSite.MemberType);
                Console.WriteLine("Message:{0}\n", ex.Message);
                Console.WriteLine("Source:{0}\n", ex.Source);
                Console.WriteLine("HelpLink:{0}\n", ex.HelpLink);
            }
            finally
            {
                result = 10;
            }
            return result;
        }
    }

    class Radio
    {
        public void TurnOn(bool on)
        {
            if(on)
            {
                Console.WriteLine("Jamming");
            }
            else
            {
                Console.WriteLine("Quite time...");
            }
        }
    }

    class Car
    {
        //Constant for maxium speed.
        public const int MaxSpeed = 100;

        //Car properties
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        //Is the car still operational?
        private bool carIsDead;

        //A car has-a radio.
        private Radio theMusicBox = new Radio();

        //Constructors.
        public Car()
        {

        }

        public Car(string name,int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            //Delegate request to inner object.
            theMusicBox.TurnOn(state);
        }

        //See if Car has overheated.
        public void Acclerate(int delta)
        {
            if(carIsDead)
            {
                Console.WriteLine("{0} is out of order...", PetName);
            }
            else
            {
                CurrentSpeed += delta;

                if(CurrentSpeed>MaxSpeed)
                {
                    Console.WriteLine("{0} has overheated!", PetName);
                    CurrentSpeed = 0;
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("=>CurrentSpeed={0}\n", CurrentSpeed);
                }
            }
        }
    }
}

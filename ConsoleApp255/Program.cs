using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp255
{
    class Program
    {
        static void Main(string[] args)
        {

            Car mc = new Car("PRADO", 50);
            for(int i=0;i<10;i++)
            {
                mc.Acclerate(10);
                mc.CrankTunes(true);
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
            try
            {
                if (carIsDead)
                {
                    Console.WriteLine("{0} is out of order...", PetName);
                }
                else
                {
                    CurrentSpeed += delta;

                    if (CurrentSpeed > MaxSpeed)
                    {
                        Console.WriteLine("{0} has overheated!", PetName);
                        CurrentSpeed = 0;
                        //We need to call the HelpLink property,thus we need to create a local variable before throwing the exception object.
                        CarIsDeadException ex = new CarIsDeadException(string.Format("{0} has overheadted!\n", PetName),"You have a lead foot",DateTime.Now);
                        ex.HelpLink = "http://www.CarsRUs.com";

                        throw ex;
                    }
                    else
                    {
                        Console.WriteLine("=>CurrentSpeed={0}\n", CurrentSpeed);
                    }
                }
            }

            catch(Exception ex)
            {

                Console.WriteLine("\n***Error!****");
                Console.WriteLine("Member name:{0}\n", ex.TargetSite);
                Console.WriteLine("Class defining member:{0}\n", ex.TargetSite.DeclaringType);
                Console.WriteLine("Memeber type:{0}\n", ex.TargetSite.MemberType);
                Console.WriteLine("Message:{0}\n", ex.Message);
                Console.WriteLine("Source:{0}\n", ex.Source);
                Console.WriteLine("HelpLink:{0}\n", ex.HelpLink);


                Console.WriteLine("n->Custom Data:\n");

                foreach(DictionaryEntry de in ex.Data)
                {
                    Console.WriteLine("->{0}:{1}", de.Key, de.Value);
                }
            }
           
        }
    }

    public class CarIsDeadException:ApplicationException
    {
        private string messageDetails = string.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException()
        {

        }

        public CarIsDeadException(string message,string cause,DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        //Override the Exception.Message property.
        public override string Message
        {
            get
            {
                return string.Format("Car Error Message:{0}\n", messageDetails);
            }
        }
    }
}

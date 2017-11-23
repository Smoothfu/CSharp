using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Now list any assembly -or module-level attributes.
//Enforce CLS compliance for all public types in this assembly.

[assembly:CLSCompliant(true)]

//Now,your namespaces and types

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Value of VehicleDescriptionAttribute*****\n");
            ReflectOnAttributesUsingEarlyBinding();
            Console.ReadLine();
        }

        private static void ReflectOnAttributesUsingEarlyBinding()
        {
            //Get a Type representing the Winnebago.
            Type type = typeof(Winnebago);

            //Get all attributes on the Winnebago.
            object[] customAtts = type.GetCustomAttributes(true);

            //Print the description
            foreach(VehicleDescriptionAttribute v in customAtts)
            {
                Console.WriteLine("->{0}\n", v.Description);
            }
        }
    }

    //This class can be saved to disk.
    [Serializable]
    public class Motorcycle
    {
        //However,this field will not be persisted.
        [NonSerialized]
        float weightOfCurrentPassengers;
        //These fields are still serializable.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }

    [Serializable,Obsolete("Use another vehicle!")]
    public class HorseAndBuggy
    {

    }

    [Serializable]
    [Obsolete("Use another vehicle!")]
    public class Horse
    {

    }

    ////Assign description using a "named property"
    //[Serializable]
    //[VehicleDescription(Description="My rocking Harley")]
    //public class Motorcycle2
    //{
    //}

    [Serializable]
    [Obsolete("Use another vehicle!")]
    [VehicleDescription("The old gray mare,she ain't what she used to be..")]
    public class HorseAndBuggy2
    {

    }

    [VehicleDescription("A very long,slow,but feature-rich auto")]
    public class Winnebago
    {
        [VehicleDescription("My rocking CD player")]
        public void PlayMusic(bool On)
        {

        }
    }
}

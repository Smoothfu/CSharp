using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLibrary
{

    //Represents the state of the engine.
    public enum EngineState
    {
        engineAlive,engineDead
    }

    //The abstract base class in the hierarchy.

    public abstract class Car
    {
        public string CarName { get; set; }
        public double CurrentSpeed { get; set; }
        public double MaxSpeed { get; set; }

        protected EngineState engineState = EngineState.engineAlive;
        public EngineState EngineState
        {
            get
            {
                return engineState;
            }
        }

        public abstract void TurboBoost();

        public Car()
        {

        }

        public Car(string carName,double maxSp,double currSp)
        {
            CarName = carName;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
    }

    public class SportsCar : Car
    {
        public SportsCar()
        {

        }

        public SportsCar(string carName, double maxSp, double currSp) : base(carName, maxSp, currSp)
        {


        }
        public override void TurboBoost()
        {
            MessageBox.Show("Ramming Speed!", "Faster is forbidden!");
        }
    }

    public class MiniVan : Car
    {
        public MiniVan()
        {

        }

        public MiniVan(string carName,double maxSp,double currSp):base(carName,maxSp,currSp)
        {

        }
        public override void TurboBoost()
        {
            //MiniVans have poor turbo capabilities!
            engineState = EngineState.engineDead;
            MessageBox.Show("Eek!", "You have a good rest!");
        }
    }

    public class Class1
    {
    }
}

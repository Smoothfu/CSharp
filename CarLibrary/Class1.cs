using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{

    //Represents the state of engine.
    public enum EngineState
    {
        engineAlive,engineDead
    }

    //The abstract base class in the hierarchy.
    public abstract class Car
    {
        public string CarName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState egnState = EngineState.engineAlive;

        public EngineState EngineStates
        {
            get
            {
                return egnState;
            }
        }

        public abstract void TurboBoost();


        public Car()
        {

        }

        public Car(string carName,int maxSp,int currSp)
        {
            CarName = carName;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
    }
}

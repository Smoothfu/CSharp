using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarLibrary;


namespace ConsoleApp77
{
    public class SportCar : Car
    {
        public SportCar()
        {

        }

        public SportCar(string carName,int maxSp,int currsp):base(carName,maxSp,currsp)
        {

        }
        public override void TurboBoost()
        {
            MessageBox.Show("Ramming Speed!", "Faster is better");
        }
    }

    public class MinVan : Car
    {
        public MinVan()
        {

        }

        public MinVan(string carName,int maxSp,int currSp):base(carName,maxSp,currSp)
        {

        }
        public override void TurboBoost()
        {
            //Minivans have poor turbo capabilities.

            egnState = EngineState.engineDead;
            MessageBox.Show("Eek!", "Your engine block exploded!");
        }
    }
}

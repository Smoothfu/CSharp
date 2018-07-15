using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp244
{
    class Program
    {
        static void Main(string[] args)
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;

            //The BinaryWriter persists state data in a binary format.
            //You would need to import System.Runtime.Serialization.Formatters.Binary 
            //to gain access to BinaryFormatter.

            BinaryFormatter binFormat = new BinaryFormatter();

            //Store object in a local file.
            using (Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }

                Console.ReadLine();
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {

            //Specify what is done when a file is renamed.
            Console.WriteLine("File:{0} renamed to {1}\n", e.OldFullPath, e.FullPath);
        }

      

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            //Specify what is done when a file is changed,created,or deleted.
            Console.WriteLine("File:{0}{1}!", e.FullPath, e.ChangeType);
        }

     
    }

    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }

    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondCar : Car
    {
        public bool canFly;
        public bool canSubMerge;
    }
}

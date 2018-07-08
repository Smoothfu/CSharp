using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ConsoleApp242
{
    class Program
    {
        static void Main(string[] args)
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;

            //The BinaryFormatter persists state data in a binary format.
            //You would need to import System.Runtime.Serialization.Formatters.Binary to gain access to BinaryFormatter.
            BinaryFormatter binFormat = new BinaryFormatter();

            //Store object in a local file.
            using (Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("The managedthreadIs in AddMethod is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }
    }

    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }
}

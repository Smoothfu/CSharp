using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp232
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationMethod();
            Console.ReadLine();
        }

        static void EncodingDefaultGetStringGetBytes()
        {
            Console.WriteLine("*****Fun with FileStreams*****\n");

            //Obtain a FileStream object.
            using (FileStream fs = File.Open(@".\myMsg.data", FileMode.Create))
            {
                //Encode a string as array of bytes.
                string msg = "The world is wonderful!";
                byte[] arrBytes = Encoding.Default.GetBytes(msg);

                //write byte[] to file.
                fs.Write(arrBytes, 0, arrBytes.Length);

                //Reset internal position of stream.
                fs.Position = 0;

                //Read the types from file and display to console.
                Console.WriteLine("\nYour message as an array of bytes: \n");
                byte[] bytesFromFile = new byte[arrBytes.Length];
                for (int i = 0; i < arrBytes.Length; i++)
                {
                    bytesFromFile[i] = (byte)fs.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }

                //Display decoded messages.
                Console.WriteLine("\n\nDecoded Message:\n");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
        }

        static void StreamWriterReader()
        {
            Console.WriteLine("*****Fun with StreamWriter/StreamReader*****\n");

            //Get a StreamWriter and write string data.
            using (StreamWriter writer = File.CreateText(@".\reminders.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Father's Day this year...");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + " ");
                }

                //Insert a new line.
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("Created file and wrote some thoughts...");

        }

        static void StreamReaderFileOpenText()
        {
            //Now read data from file.
            Console.WriteLine("Here are your thoughts:\n");
            using (StreamReader sr = File.OpenText(@".\reminders.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }

        static void StringWriterMethod()
        {
            Console.WriteLine("*****Fun with StringBuilder/StringReader*****\n");

            //Create a StringWriter and emit character data  to memory
            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine("Don't forget Mother's Day this year...");

                //Get a copy of the contents stored in a string and dump to console.
                Console.WriteLine("Contents of StringWriter:\n{0}", writer);
            }
        }

        static void StringWriterStringBuilder()
        {
            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                Console.WriteLine("Contents of StringWriter:\n{0}", writer);

                //Get the internal StringBuilder
                StringBuilder sBuilder = writer.GetStringBuilder();
                sBuilder.Insert(0, "Hey!!");
                Console.WriteLine("->{0}\n", sBuilder.ToString());
                sBuilder.Remove(0, "Hey!!".Length);
                Console.WriteLine("-> {0}", sBuilder.ToString());
            }
        }

        static void StringWriterStringReader()
        {
            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                Console.WriteLine("Contents of StringWriter:\n{0}", writer);

                //Read data from the StringWriter.
                using (StringReader reader = new StringReader(writer.ToString()))
                {
                    string input = null;
                    while ((input = reader.ReadLine())!=null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }
        }

        static void BinaryReaderMethod()
        {
            Console.WriteLine("*****Fun with Binary Writers/Readers *****\n");

            //Open a binary writer for a file.
            FileInfo fi = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(fi.OpenWrite()))
            {
                //Print out the type of BaseStream
                Console.WriteLine("Base stream is :{0}\n", bw.BaseStream);

                //Create some data to save in the file.
                double d = 12345.67;
                int anInt = 34567;
                string aString = "A,B,C";

                //Write the data.
                bw.Write(d);
                bw.Write(anInt);
                bw.Write(aString);
            }

            Console.WriteLine("Done!");

        }

        static void BinaryWriterReader()
        {
            Console.WriteLine("*****Fun with Binary Writers/Readers*****\n");

            //Open a binary writer for a file.
            FileInfo fi = new FileInfo("BinFile.data");
            using (BinaryWriter bw = new BinaryWriter(fi.OpenWrite()))
            {
                //Print out the type of BaseStream.
                //System.IO.FileStream in this case.
                Console.WriteLine("Base stream is :{0}\n", bw.BaseStream);

                //Create some data to save in the file.
                double aDouble = 12345.67;
                int anInt = 34567;
                string aString = "A,B,C";

                //Write the data.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }

            Console.WriteLine("Done!");
        }

        static void BinaryReaderWriterMethod()
        {
            FileInfo fi = new FileInfo("BinFile.dat");

            //Read the binary data from the stream.
            using (BinaryReader br = new BinaryReader(fi.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }

            Console.ReadLine();
        }

        static void FileSystemWatcherMethod()
        {
            Console.WriteLine("****The Amazing File Watcher App*****\n");
            //Establish the path to the directory to watch.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\Users\Fred\Downloads";

                string[] allFiles = Directory.GetFiles(watcher.Path.ToString(),"*.txt",SearchOption.AllDirectories);

                if (allFiles != null && allFiles.Any())
                {
                    Console.WriteLine("There are {0} files in the specified path", allFiles.Count());
                    Parallel.ForEach(allFiles, x =>
                    {
                        Console.WriteLine(x);
                    });
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            //Only watch text files.
            watcher.Filter = "*.txt";

            //Add event handlers
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;

            //Begin watching the directory.
            watcher.EnableRaisingEvents = true;

            //Wait for the user to quit the program.
            Console.WriteLine(@"Press 'q' to quit app.");
            while(Console.Read()!='q')
            {
                ;
            }
        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            //Specify what is done when a file is renamed.
            Console.WriteLine("File :{0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File:{0}", e.FullPath);
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File:{0}\n", e.FullPath);
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //Specify what is done when a file is changed,created,or deleted.
            Console.WriteLine("File:{0},{1}!", e.FullPath, e.ChangeType);
        }

        private static void SerializationMethod()
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;

            //The BinaryFormatter persists state data in a binary format.
            //You would need to import System.Runtime.Serialization.Formatters.Binary to gain access to BinaryFormatter

            BinaryFormatter binFormat = new BinaryFormatter();

            //Store object in a local file.
            using (Stream stream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(stream, userData);
            }
        }
    }

    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }
}

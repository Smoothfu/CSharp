using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace ConsoleApp232
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriterStringReader();
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
    }
}

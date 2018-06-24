﻿using System;
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
            StreamWriterReader();
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
                for(int i=0;i<10;i++)
                {
                    writer.Write(i + " ");
                }

                //Insert a new line.
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("Created file and wrote some thoughts...");
            
        }
    }
}

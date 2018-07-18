using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace ConsoleApp246
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of XmlTextReader and call Read method to read the file.
            string fullXmlPath = @" D:\C\ConsoleApp246\ConsoleApp246\XMLFile1.xml";
            XmlTextReader xmlReader = new XmlTextReader(fullXmlPath);
            xmlReader.Read();

            //If the node has value.
            while(xmlReader.Read())
            {
                //Move to first element.
                xmlReader.MoveToElement();
                Console.WriteLine("XmlTextReader properties test:\n");
                Console.WriteLine("=====================");
                Console.WriteLine(xmlReader.Name);
                Console.WriteLine(xmlReader.BaseURI);
                Console.WriteLine(xmlReader.LocalName);
                Console.WriteLine(xmlReader.AttributeCount.ToString());
                Console.WriteLine(xmlReader.Depth.ToString());
                Console.WriteLine(xmlReader.LineNumber.ToString());
                Console.WriteLine(xmlReader.NodeType.ToString());
                Console.WriteLine(xmlReader.Value.ToString());

            }

            Console.ReadLine();

        }
    }
}

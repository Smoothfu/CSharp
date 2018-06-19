using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp227
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drawing test.Please input command");
            do
            {
                string input = Console.ReadLine().Trim();
                DrawAction(input);
            }
            while (!string.IsNullOrEmpty(Console.ReadLine()));                     

            Console.ReadLine();            
        }


        static void DrawAction(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            string firstChar = str.Trim().FirstOrDefault().ToString().ToUpperInvariant();
            
            switch(firstChar)
            {
                case "C":
                    DrawRectangle(str);
                    break;
                case "L":
                    DrawLine(str);
                    break;
                case "R":
                    DrawRectangleWithTwoPoints(str);
                    break;
                case "B":
                    FillLineWithColorCircle(str);
                    Console.WriteLine();
                    break;
                case "Q":
                    System.Environment.Exit(0);
                    break;
                default:
                    MessageBox.Show("Please enter valid character");
                    return;
            }
        }

        public static void DrawRectangle(string input)
        {
            string[] stringArr = input.Split(new char[] { ' ' });

            int width,height;
            if(int.TryParse(stringArr[1],out width) &&(int.TryParse(stringArr[2],out height)))
            {
                string s = "";
                for (int i = 0; i < width; i++)
                {
                    s += "-";
                }
                s += "\n";
                for (int j = 0; j < height; j++)
                {
                    string tempSpan = "";
                    for (int span = 0; span < width - 2; span++)
                    {
                        tempSpan += " ";
                    }
                    s += "|" + tempSpan + "|" + "\n";
                }

                for (int i = 0; i < width; i++)
                {
                    s += "-";
                }
                Console.WriteLine(s);
            }           
        }

        public static void DrawLine(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return;
            }
            string[] lineArr = input.Split(new char[] { ' ' });
            int x1, y1, x2, y2;
            string s = "";
            if ((int.TryParse(lineArr[1], out x1)) && (int.TryParse(lineArr[2], out y1)) && (int.TryParse(lineArr[3], out x2)) && (int.TryParse(lineArr[4],out y2)))
            {
                for(int i=0;i<x1;i++)
                {
                    s += "";
                }

                for(int j=0;j<y1;j++)
                {
                    s += "\n";
                }

                for (int i = 0; i < x1 - 1; i++)
                {
                    s += " ";
                }

                for (int k=0;k<Math.Abs(x2-x1);k++)
                {                   
                    s += "x";
                }
                s += "\n";

                for(int m=0;m<Math.Abs(y2-y1);m++)
                {
                    for (int i = 0; i <x2-2; i++)
                    {
                        s += " ";
                    }

                    s += "x"+"\n";
                }

                Console.WriteLine(s);
            }
        }

        static void DrawRectangleWithTwoPoints(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return;
            }

            string[] rectArr = input.Split(new Char[] { ' ' });
            string r = "";
            int x1, y1, x2, y2;
            if((int.TryParse(rectArr[1],out x1))&&(int.TryParse(rectArr[2],out y1))&&(int.TryParse(rectArr[3],out x2)) &&(int.TryParse(rectArr[4],out y2)))
            {
                for (int i = 0; i < y1; i++)
                {
                    r += "\n";
                }
                for (int i=0;i<x1-1;i++)
                {
                    r += " ";
                }
               
               for(int j=0;j<Math.Abs(x2-x1+1);j++)
                {                    
                    r += "x";
                }
                r += "\n";

                for(int i=0;i<Math.Abs(y2-y1);i++)
                {
                    for (int l = 0; l < x1-1; l++)
                    {
                        r += " ";
                    }

                    r += "x";
                    for (int j = 0; j < Math.Abs(x2-x1-1); j++)
                    {
                        r += " ";
                    }
                    r += "x"+"\n";
                }

                for (int j = 0; j < x1 - 1; j++)
                {
                    r += " ";
                }
                for (int i=0;i<Math.Abs(x2-x1+1);i++)
                {                    
                    r += "x";
                }

                Console.WriteLine(r);                
            }
        }

        static void FillLineWithColorCircle(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return;
            }
            string[] colorArr = input.Split(new char[] { ' '});
            int x, y;
            string str = "";
            if((int.TryParse(colorArr[1],out x))&&(int.TryParse(colorArr[1], out y)))
            {               

                for(int j=0;j<y;j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        str += "o";
                    }
                    str += "\n";
                }
                Console.WriteLine(str);                
            }
        }       
       
    }
}

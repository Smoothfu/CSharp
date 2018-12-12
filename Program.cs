using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp307
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilderExample();
            Console.ReadLine();
        }

        static void SplitString()
        {
            string str = "Now is the time";
            int pos;
            string word;
            ArrayList words = new ArrayList();
            pos = str.IndexOf(" ");
            while (pos > 0)
            {
                word = str.Substring(0, pos);
                words.Add(word);
                str = str.Substring(pos + 1, str.Length - (pos + 1));
                pos = str.IndexOf(" ");
                if (pos == -1)
                {
                    word = str.Substring(0, str.Length);
                    words.Add(word);
                }
            }

            if (words.Count > 0)
            {
                foreach (string w in words)
                {
                    Console.Write(w + "\t");
                }
            }
        }

        static ArrayList SplitWords(string str)
        {
            string[] ws = new string[str.Length - 1];
            ArrayList words = new ArrayList();
            int pos;
            string word;
             
            while(str.IndexOf(" ") > 0)
            {
                pos = str.IndexOf(" ");
                word = str.Substring(0, pos);
                words.Add(word);
                str = str.Substring(pos + 1, str.Length - (pos + 1));
                if(pos==-1)
                {
                    word = str.Substring(0, str.Length);
                    words.Add(word);
                }
            }
            return words;
        }

        static void StringSplit()
        {
            string data = "Mike,McMillan,3000 W. Scenic,North Little Rock,AR,72118";
            string[] sdata;
            char[] delimiter = new char[] { ',' };
            sdata = data.Split(delimiter, data.Length);
            foreach (string word in sdata)
            {
                Console.Write(word + " ");
            }
                
        }

        static void StringSplitSeparator()
        {
            string data = "Mike,McMillan,3000 W. Scenic,North Little Rock, AR,72118";
            string[] strData;
            char[] delimiters = new char[] { ',' };
            strData = data.Split(delimiters, data.Length);
            foreach(string str in strData)
            {
                Console.Write(str + "\t");
            }

            string strJoin;
            strJoin = string.Join(",", strData);
            Console.WriteLine("\n" + strJoin);
        }

        static void StringCompare()
        {
            string str1 = "foobar";
            string str2 = "foobar";
            Console.WriteLine(str1.CompareTo(str2));
            Console.WriteLine(string.Compare(str1, str2));
            str2 = "foofoo";
            Console.WriteLine(string.Compare(str1, str2));
            Console.WriteLine(str1.CompareTo(str2));
            str2 = "fooaar";
            Console.WriteLine(string.Compare(str1, str2));
            Console.WriteLine(str1.CompareTo(str2));

        }

        static void StringEndsWith()
        {
            string[] arr = new string[] {"cat","dog","bird","eggs","bones"};
            var pluralAnimals = from a in arr
                                         where a.EndsWith('s')
                                         select a;
            if (pluralAnimals != null && pluralAnimals.Any())
            {
                Console.WriteLine(string.Join("\t", pluralAnimals));                
            }            
        }

        static void StringStartsWith()
        {
            string[] words = new string[] { "triangle", "diagonal", "trimester", "bifocal", "triglycerides" };
            ArrayList triWords = new ArrayList();
            foreach(string word in words)
            {
                if(word.StartsWith("tri"))
                {
                    triWords.Add(word);
                }
            }

            if(triWords!=null && triWords.Count>0)
            {
                foreach(string str in triWords)
                {
                    Console.WriteLine(str);
                }
            }
        }

        static void StringInsert()
        {
            string str = "Hello,Welcome to my class";
            string name = "Floomberg ";
            int pos = str.IndexOf(",");
            str = str.Insert(pos + 1, name);
            Console.WriteLine(str);
            str = str.Remove(pos + 1, name.Length);
            Console.WriteLine(str);
        }

        static void StringReplace()
        {
            string[] words = new string[] { "Receive", "Deceive", "Receipt" };
            Console.WriteLine("Initial word:" + string.Join("\t", words));
            Console.WriteLine("\nThe replace result:");
            for(int i=0;i<=words.GetUpperBound(0);i++)
            {
                words[i] = words[i].Replace("cei", "cie");
                Console.Write(words[i]+"\t");
            }
        }

        static void StringPad()
        {
            string str = "Hello";
            Console.WriteLine(str.PadLeft(20));
            Console.WriteLine(str.Length);
            Console.Write(str.PadRight(20));
            Console.ReadKey();
        }

        static void AlignData()
        {
            string[,] names = new string[,]
            {{"1504", "Mary", "Ella", "Steve", "Bob"},
            {"1133", "Elizabeth", "Alex", "David", "Joe"},
            {"2624", "Joel", "Chris", "Craig", "Bill"}};

            Console.WriteLine("\n\n\n\n\n");
            for(int i=0;i<=names.GetUpperBound(0);i++)
            {
                for(int j=0;j<names.GetUpperBound(1);j++)
                {
                    Console.Write(names[i, j].PadRight(10) + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        static void StringContcatenate()
        {
            string str1 = "Hello";
            string s2 = "world!";
            string s3 = "";
            s3 = string.Concat(str1, "\t", s2,"wonderful");
            Console.WriteLine(s3);

            string[] arr = { "I", " am ", " a", " programmer", " focused ", " on ", " C# " };
            Console.WriteLine(string.Concat(arr));
        }

        static void StringToUpperToLower()
        {
            string str = "hello world";
            str = str.ToUpper();
            Console.WriteLine("ToUpper: " + str);
            str = str.ToLowerInvariant();
            Console.WriteLine(str);            
        }

        static void StringTrim()
        {
            string[] names = { " David", " Raymond", "Mike ", "Bernica " };
            Console.WriteLine("\n");
            ShowNames(names);
            Console.WriteLine("\n\n\n\n\n");
            TrimVals(names);
            Console.WriteLine("\n\n\n\n\n");
            ShowNames(names);
        }

        static void ShowNames(string[] arr)
        {
            if(arr==null && !arr.Any())
            {
                return;
            }

            Console.WriteLine(string.Join("\t", arr));
        }

        static void TrimVals(string[] arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }

            char[] charArr = new char[] { ' ' };
            for(int i=0;i<arr.Length;i++)
            {
                arr[i] = arr[i].Trim(charArr[0]);
                arr[i] = arr[i].TrimEnd(charArr[0]);
            }
        }

        static void StringTrimComments()
        {
            string[] htmlComments = {"<!-- Start Page Number Function -->",
                                     "<!-- Get user name and password -->",
                                     "<!-- End Title page -->",
                                     "<!-- End script -->"};
            char[] commentChars = { '<', '!', '-', '>' };

            for(int i=0;i<htmlComments.Length;i++)
            {
                htmlComments[i] = htmlComments[i].Trim(commentChars);
                htmlComments[i] = htmlComments[i].TrimEnd(commentChars);
            }

            Console.WriteLine(string.Join("\n", htmlComments));
        }

        static void StringBuilderExample()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.EnsureCapacity(20);
            string msg = "This world it is,every thing";
            StringBuilder strBuilder = new StringBuilder(msg);
            Console.WriteLine("Stringbuilder default capacity: " + stringBuilder.Capacity);
            Console.WriteLine("The raw msg length: " + msg.Length);
            Console.WriteLine("strBuilder customized capacity more than 16: " + strBuilder.Capacity);
        }
    }
}

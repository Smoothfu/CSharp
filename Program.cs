using System;
using System.Collections;

namespace ConsoleApp307
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCompare();
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
    }
}

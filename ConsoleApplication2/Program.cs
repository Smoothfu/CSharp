using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNetVersionDemo();
            Console.ReadLine();
        }

        static void GetNetVersionDemo()
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach(var versionKeyName in ndpKey.GetSubKeyNames())
                {
                    //Skip .NET Framework 4.5 version information.
                    if(versionKeyName=="v4")
                    {
                        continue;
                    }

                    if(versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);

                        //Get the .NET Framework version value.
                        var name = (string)versionKey.GetValue("Version", "");

                        //Get the service pack number.
                        var sp = versionKey.GetValue("SP", "").ToString();

                        //Get the installation flag,or an empty string if there is none.
                        var install = versionKey.GetValue("Install", "").ToString();

                        if(string.IsNullOrEmpty(install))
                        {
                            Console.WriteLine($"{versionKeyName} {name}");
                        }
                        else
                        {
                            if(!string.IsNullOrEmpty(sp) && install=="1")
                            {
                                Console.WriteLine($"{versionKeyName} {name} SP{sp}");
                            }
                        }

                        if(!string.IsNullOrEmpty(name))
                        {
                            continue;
                        }

                        foreach(var subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if(!string.IsNullOrEmpty(name))
                            {
                                sp = subKey.GetValue("SP", "").ToString();
                            }

                            install = subKey.GetValue("Install", "").ToString();
                            if(string.IsNullOrEmpty(install))
                            {
                                Console.WriteLine($"{versionKeyName} {name}");
                            }
                            else
                            {
                                if((!string.IsNullOrEmpty(sp)) && install=="1")
                                {
                                    Console.WriteLine($"{subKeyName} {name}  SP{sp}");
                                }
                                else
                                    if(install=="1")
                                {
                                    Console.WriteLine($"{subKeyName} {name}");
                                }
                            }
                        }
                    }
                }
            }
        }
        static void GetDotNetFrameworkVersion()
        {
            const string subKey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full";
            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subKey))
            {
                if(ndpKey!=null && ndpKey.GetValue("Release")!=null)
                {
                    var objResult = ndpKey.GetValue("Release");
                    var versionResult = CheckFor45PlusVersion((int)objResult);
                    Console.WriteLine($".NET Framework Version:{versionResult}");
                }
                else
                {
                    Console.WriteLine(".NET Framework Version 4.5 or later is not detected!");
                }
            }
        }

        //Convert the Main.Minor.Build.Revision
        static string CheckFor45PlusVersion(int releaseKey)
        {             
            if(releaseKey>=528040)
            {
               return "4.8 or later";
            }

            if(releaseKey>=461808)
            {
                return "4.7.2";
            }

            if(releaseKey>=461308)
            {
                return "4.7.1";
            }

            if (releaseKey >= 460798)
            {
                return "4.7";
            }

            if(releaseKey>=394802)
            {
                return "4.6.2";
            }

            if(releaseKey>=394254)
            {
                return "4.6.1";
            }

            if(releaseKey>=393295)
            {
                return "4.6";
            }

            if(releaseKey>=393295)
            {
                return "4.5.2";
            }

            if(releaseKey>=378675)
            {
                return "4.5.1";
            }

            if(releaseKey>=378389)
            {
                return "4.5";
            }

            return "No 4.5 or later version detected!";
        }

        static void MaximizeConsoleWindow()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        static void ConsoleWindowDemo()
        {
            Type type = typeof(Console);
            PropertyInfo[] pis = type.GetProperties();
            if (pis != null && pis.Any())
            {
                Parallel.ForEach(pis, x =>
                {
                    Console.WriteLine($"Name:{x.Name},Value:{x.GetValue(x)}");
                });
            }           
        }

        static void ShowEnvironmentInfoDemo()
        {
            try
            {
                Type type = typeof(Environment);
                PropertyInfo[] pis = type.GetProperties();
                if (pis != null && pis.Any())
                {
                    Parallel.ForEach(pis, x =>
                    {
                        Console.WriteLine($"Name:{x.Name},value:{x.GetValue(x)}");
                    });
                }
            }
            catch
            {

            }
            
        }
    }
}

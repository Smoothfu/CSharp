using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleApp139
{
    class Program
    {
        static DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        static DirectoryInfo subDir=dir.CreateSubdirectory(@"Sub\Sub\Sub\Sub\SubFile\");
        static string filePath = subDir.FullName;
        static void Main(string[] args)
        {
            //Create files

            NewFileInfoMethod();

            //Delete files
            DialogResult dlg = MessageBox.Show("Are you sure to delete all files?", "Delete", MessageBoxButtons.YesNoCancel);

            if (dlg == DialogResult.Yes)
            {
                DeleteAllFiles();
            }

            Console.ReadLine();

        }

        static void NewFileInfoMethod()
        {
            
            DateTime dtStart = DateTime.Now;
            DateTime dtEnd = dtStart.AddSeconds(10);
            while (DateTime.Now.Subtract(dtEnd).TotalSeconds < 0)
            {
                FileInfo fi = new FileInfo(filePath + @"\"+DateTime.Now.ToString("yyyyMMddhhmmssfff")+".txt");
                using (StreamWriter sw = fi.AppendText())
                {
                    string inputStr = "The world is fair and wonderful.cherish the present moment,make every second count,make a difference." + DateTime.Now.ToString("yyyyMMdd:hhmmssfff");

                    sw.WriteLine(inputStr + Environment.NewLine);
                }                             
            }
        }

        static void DeleteAllFiles()
        {
            string[] allFiles = Directory.GetFiles(filePath);
            if(allFiles==null || !allFiles.Any())
            {
                MessageBox.Show("There is no files at all!");
                return;
            }

            File.SetAttributes(filePath, FileAttributes.Normal);
            foreach(var file in allFiles)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
           
            string[] afterAllFiles = Directory.GetFiles(filePath);
            if(afterAllFiles==null ||!afterAllFiles.Any())
            {
                MessageBox.Show("Deleted successfully!");
            }
        }
    }
}

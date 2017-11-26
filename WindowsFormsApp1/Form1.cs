using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp26;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Allow user to select an assembly to load.
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                if(dlg.FileName.Contains("CommonSnappableTypes"))
                {
                    MessageBox.Show("CommonSnappableTypes has no snap-ins");
                }
                else if(!LoadExternalModule(dlg.FileName))
                {
                    MessageBox.Show("Nothing implements IAppFunctionality!");
                }
            }
        }

        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;
            try
            {
                //Dynamically load the selected assembly.
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }

            //Get all IAppFunctionality-compatible classes in assembly.
            var types = from t in theSnapInAsm.GetTypes()
                        where t.IsClass && (t.GetInterface("IAppFunctionality" )!= null)
                        select t;

            //Now,create the object and call DoIt() method.
            foreach(Type t in  types)
            {
                foundSnapIn = true;
                //use late binding to create the type.
                IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.Name);
                itfApp.DoIt();
                listBox1.Items.Add(t.FullName);

                //Show Company Info.
                DisplayCompanyData(t);
            }
            return foundSnapIn;
        }

        private void DisplayCompanyData(Type t)
        {

            //Get [CompanyInfo] data.
            var compInfo = from ci in t.GetCustomAttributes(false)
                           where
(ci.GetType() == typeof(CompantInfoAttibute))
                           select ci;

            //Show data.
            foreach(CompantInfoAttibute ci in compInfo)
            {
                MessageBox.Show(ci.CompanyUrl, string.Format("More info about {0} can be found at ", ci.CompanyName));
            }
        }
    }
}

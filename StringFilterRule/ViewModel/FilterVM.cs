using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using StringFilterRule.Properties;
using System.Reflection;
using StringFilterRule.Model;
using System.Xml;
using System.Net.Http;

namespace StringFilterRule.ViewModel
{
    class FilterVM : INotifyPropertyChanged
    {
        public FilterVM()
        {
            InitRulesDic();
            SelectTextCmd = new DelegateCommand(SelectTextCmdExecuted, SelectTextCmdCanExecute);
            SelectRuleCmd = new DelegateCommand(SelectRuleCmdExecuted, SelectRuleCmdCanExecute);
        }        

        #region Properties

        private string textFileFullPath;
        public string TextFileFullPath
        {
            get
            {
                return textFileFullPath;
            }
            set
            {
               if(value!=textFileFullPath)
                {
                    textFileFullPath = value;
                    NotifyPropertyChanged("TextFileFullPath");
                }
            }
        }        

        private Dictionary<string,string> rulesDic = new Dictionary<string, string>();
        public Dictionary<string, string> RulesDic
        {
            get
            {
                return rulesDic;
            }
            set
            {
                if(value!=rulesDic)
                {
                    rulesDic = value;
                    NotifyPropertyChanged("RulesDic");
                }
            }
        }        
        #endregion

        #region Commands
        private DelegateCommand selectTextCmd;
        public DelegateCommand SelectTextCmd
        {
            get
            {
                return selectTextCmd;
            }
            set
            {
                selectTextCmd = value;
            }
        }

        private DelegateCommand selectRuleCmd;
        public DelegateCommand SelectRuleCmd
        {
            get
            {
                return selectRuleCmd;
            }
            set
            {
                selectRuleCmd = value;
            }
        }
        #endregion

        #region Methods
        private bool SelectTextCmdCanExecute()
        {
            return true;
        }
        private void SelectTextCmdExecuted()
        {
            System.Windows.Forms.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TextFileFullPath = ofd.FileName;
            }
        }
        private bool SelectRuleCmdCanExecute()
        {
            if(RulesDic!=null && RulesDic.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SelectRuleCmdExecuted()
        {
            
        }

        private void InitRulesDic()
        {
            XmlDocument doc = new XmlDocument(); 
            string filePath = Environment.CurrentDirectory + @"\Properties\Resources.resx";
            doc.Load(filePath);
            List<string> commentList = new List<string>();
            Type resourceType = typeof(Resources);
            PropertyInfo[] pis = resourceType.GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var pi in pis.Where(x => x.PropertyType == typeof(string) && x.Name.StartsWith("R")))
            {
                if (!string.IsNullOrEmpty(pi.Name))
                {
                    string dicValue = Resources.ResourceManager.GetString(pi.Name);
                    string comment= ReadResourceComment(doc, pi.Name);
                    if(!string.IsNullOrEmpty(comment))
                    {
                        commentList.Add(comment);
                    }

                    if (!rulesDic.Any(x => x.Key.Contains(pi.Name)))
                    {
                        rulesDic.Add(pi.Name, dicValue);
                    }
                    else
                    {
                        rulesDic[pi.Name] = dicValue;
                    }
                }
            }
            var temp = commentList;
        }

        public string ReadResourceComment(XmlDocument doc, string FieldName)
        {
            if (doc != null && !string.IsNullOrEmpty(doc.InnerXml))
            {
                return doc.SelectSingleNode("root/data[@name='" + FieldName + "']")["comment"].InnerText;
            }

            return string.Empty;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (propName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}

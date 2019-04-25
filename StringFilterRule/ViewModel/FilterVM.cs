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
using System.Resources;
using System.Collections;

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

        private string textFileFullPath = string.Empty;
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

        private List<RuleModel> rulesList = new List<RuleModel>();
        public List<RuleModel> RulesList
        {
            get
            {
                return rulesList;
            }
            set
            {
                if(value!=rulesList)
                {
                    rulesList = value;
                    NotifyPropertyChanged("RulesList");
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
            if(RulesList != null && RulesList.Any())
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
            Type resourceType = typeof(Resources);
            PropertyInfo[] pis = resourceType.GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var pi in pis.Where(x => x.PropertyType == typeof(string) && x.Name.StartsWith("R")))
            {
                if (!string.IsNullOrEmpty(pi.Name))
                {
                    string ruleValue = Resources.ResourceManager.GetString(pi.Name);
                    string ruleComment = ReadResourceComment(doc, pi.Name);                                   

                     if(!rulesList.Any(x=>x.RuleKey.Contains(pi.Name)))
                    {
                        rulesList.Add(new RuleModel()
                        {
                            RuleKey = pi.Name,
                            RuleValue = ruleValue,
                            RuleComment = ruleComment
                        });

                        var temp = RulesList;
                    }
                    else
                    {
                        var selectedItem = RulesList.Where(x => x.RuleKey == pi.Name).FirstOrDefault();
                        if(selectedItem!=null)
                        {
                            var selectedIndex = RulesList.IndexOf(selectedItem);
                            RulesList.RemoveAt(selectedIndex);
                            var updatedItem = new RuleModel()
                            {
                                RuleKey = pi.Name,
                                RuleValue = ruleValue,
                                RuleComment = ruleComment
                            };
                            RulesList.Insert(selectedIndex, updatedItem);
                        }                        
                    }
                }
            } 
        }

        public string ReadResourceComment(XmlDocument doc, string FieldName)
        {
            if (doc != null && !string.IsNullOrEmpty(doc.InnerXml))
            {
                string nodeComment= doc.SelectSingleNode("root/data[@name='" + FieldName + "']")["comment"].InnerText;
                return nodeComment;
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

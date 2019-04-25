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
using FilterFunctionDll;
using System.IO;

namespace StringFilterRule.ViewModel
{
    class FilterVM : INotifyPropertyChanged
    {
        static string FilterResultFileFullName = Directory.GetCurrentDirectory() + "\\" +
            DateTime.Now.ToString("yyyyMMdd") + "FilterResult.txt";
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

        private RuleModel selectedRuleModel;
        public RuleModel SelectedRuleModel
        {
            get
            {
                if(selectedRuleModel==null)
                {
                    selectedRuleModel = new RuleModel();
                }
                return selectedRuleModel;
            }
            set
            {
                if(value!=selectedRuleModel)
                {
                    selectedRuleModel = value;
                    NotifyPropertyChanged("SelectedRuleModel");
                }
            }
        }

        private FilterAction filterActionInstance;
        public FilterAction FilterActionInstance
        {
            get
            {
                //Implement IOC by getter
                if(filterActionInstance==null)
                {
                    filterActionInstance = InvokeDllClass.GetFilterActionInstance();
                }
                return filterActionInstance;
            }
            set
            {
                if (value != filterActionInstance)
                {
                    filterActionInstance = value;
                    NotifyPropertyChanged("FilterActionInstance");
                }
            }
        }


        private string originalValue = string.Empty;
        public string OriginalValue
        {
            get
            {
                return originalValue;
            }
            set
            {
                if(value!=originalValue)
                {
                    originalValue = value;
                    NotifyPropertyChanged("OriginalValue");
                }
            }
        }

        private string finalResult = string.Empty;
        public string FinalResult
        {
            get
            {
                return finalResult;
            }
            set
            {
                if(value!=finalResult)
                {
                    finalResult = value;
                    NotifyPropertyChanged("FinalResult");
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
            originalValue = File.ReadAllText(textFileFullPath);
        }
        private bool SelectRuleCmdCanExecute()
        {            
            if (RulesList != null && RulesList.Any())
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
            try
            {
                if (SelectedRuleModel != null)
                {
                    string actionName = SelectedRuleModel.RuleKey;
                    string filterValue = selectedRuleModel.RuleValue;
                    switch (actionName)
                    {
                        case "R1":
                            FilterActionInstance.BeginsWithFilterValue(OriginalValue, filterValue);
                            break;
                        case "R2":
                            filterActionInstance.EndsWithFilterValue(originalValue, filterValue);
                            break;
                        case "R3":
                            filterActionInstance.ContainsFilterValue(originalValue, filterValue); break;
                        case "R4":
                            string endsFilterValue = RulesList.Where(x => x.RuleKey == actionName).FirstOrDefault().RuleValue;
                            filterActionInstance.BeginsOrEndsWithFilterValue(originalValue, filterValue, endsFilterValue);
                            break;
                        case "R5":
                            filterActionInstance.NotContainsFilterValue(originalValue, filterValue);
                            break;
                        case "R6":
                            string beginsFilterString= RulesList.Where(x => x.RuleKey == "R1").FirstOrDefault().RuleValue;
                            string endsFilterString = RulesList.Where(x => x.RuleKey == "R2").FirstOrDefault().RuleValue;
                            string containsFilterString = RulesList.Where(x => x.RuleKey == "R3").FirstOrDefault().RuleValue;
                            filterActionInstance.BeginsWithOrEndsWithNotContainsFilterValue(originalValue, beginsFilterString,
                                endsFilterString, containsFilterString);
                            break;
                        default:
                            break;
                    }

                    FinalResult = FilterActionInstance.FilterResult;
                    LogMessage(FinalResult);
                }
            }
            catch(Exception ex)
            {
                LogMessage(ex.StackTrace);
            }
        }        

        void LogMessage(string writeMsg)
        {
            using (StreamWriter filterWriter = new StreamWriter(FilterResultFileFullName, true))
            {
                filterWriter.WriteLine(writeMsg);
                filterWriter.WriteLine($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}" + Environment.NewLine);
            }
        }

        private void InitRulesDic()
        {
            try
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

                        if (!rulesList.Any(x => x.RuleKey.Contains(pi.Name)))
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
                            if (selectedItem != null)
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
            catch (Exception ex)
            {
                LogMessage(ex.StackTrace);
            }
        }

        public string ReadResourceComment(XmlDocument doc, string FieldName)
        {
            try
            {
                if (doc != null && !string.IsNullOrEmpty(doc.InnerXml))
                {
                    string nodeComment = doc.SelectSingleNode("root/data[@name='" + FieldName + "']")["comment"].InnerText;
                    return nodeComment;
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.StackTrace);
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

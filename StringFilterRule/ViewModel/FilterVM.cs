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

        private List<KeyValuePair<string,string>> rulesDic = new List<KeyValuePair<string, string>>();
        public List<KeyValuePair<string, string>> RulesDic
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
            Type resourceType = typeof(Resources);
            PropertyInfo[] pis = resourceType.GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var pi in pis.Where(x => x.PropertyType == typeof(string) && x.Name.EndsWith("Value")))
            {
                if(!string.IsNullOrEmpty(pi.Name))
                {
                    string dicValue = Resources.ResourceManager.GetString(pi.Name);
                    if (!rulesDic.Any(x=>x.Key.Contains(pi.Name)))
                    {
                        rulesDic.Add(new KeyValuePair<string, string>(pi.Name, dicValue));
                    }
                    else
                    {
                        rulesDic[pi.Name] = dicValue;
                    }
                }               
            }
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

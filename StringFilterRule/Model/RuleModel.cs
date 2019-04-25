using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFilterRule.Model
{
    class RuleModel : INotifyPropertyChanged
    {
        private string ruleKey = string.Empty;
        public string RuleKey
        {
            get
            {
                return ruleKey;
            }
            set
            {
                if(value!=ruleKey)
                {
                    ruleKey = value;
                    NotifyPropertyChanged("RuleKey");
                }
            }
        }

        private string ruleValue = string.Empty;
        public string RuleValue
        {
            get
            {
                return ruleValue;
            }
            set
            {
                if(ruleValue!=value)
                {
                    ruleValue = value;
                    NotifyPropertyChanged("RuleValue");
                }
            }
        }

        private string ruleComment = string.Empty;
        public string RuleComment
        {
            get
            {
                return ruleComment;
            }
            set
            {
                if(value!=ruleComment)
                {
                    ruleComment = value;
                    NotifyPropertyChanged("RuleComment");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterFunctionDll
{
    class FilterDelegate:INotifyPropertyChanged
    {
        delegate bool FilterDel(string[] filterActionNames, string[] filterConditions);
        public FilterDelegate()
        {

        }

        public bool StartsWithFilterValue(string originalValue,string filterValue)
        {
            if(!string.IsNullOrEmpty(originalValue) && !string.IsNullOrEmpty(filterValue))
            {
                if(originalValue.StartsWith(filterValue))
                {
                    filterResult = originalValue;
                    return true;
                }
            }
            filterResult = string.Empty;
            return false;
        }

        public bool EndsWithFilterValue(string originalValue, string filterValue)
        {
            if (!string.IsNullOrEmpty(originalValue) && !string.IsNullOrEmpty(filterValue))
            {
                if (originalValue.EndsWith(filterValue))
                {
                    filterResult = originalValue;
                    return true;
                }
            }
            filterResult = string.Empty;
            return false;
        }

        public bool ContainsFilterValue(string originalValue,string filterValue)
        {
            if(!string.IsNullOrEmpty(originalValue) && !string.IsNullOrEmpty(filterValue))
            {
                if(originalValue.Contains(filterValue))
                {
                    filterResult = originalValue;
                    return true;
                }
            }
            filterResult = string.Empty;
            return false;
        }

        public bool BeginsOrEndsWithFilterValue(string originalValue,
            string startsWithFilterValue,string endsWithFilterValue)
        {
            return StartsWithFilterValue(originalValue, startsWithFilterValue)
                || EndsWithFilterValue(originalValue, endsWithFilterValue);
        }

        public bool NotContainsFilterValue(string originalValue, string filterValue)
        {
            return !ContainsFilterValue(originalValue, filterValue);
        }

        public bool BeginsWithOrEndsWithNotContainsFilterValue(string originalValue,
            string beginsWithFilterValue,string endsWithFilterValue,string containsFilterValue)
        {
            return BeginsOrEndsWithFilterValue(originalValue, beginsWithFilterValue, endsWithFilterValue)
                && NotContainsFilterValue(originalValue, containsFilterValue);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string filterResult = string.Empty;
        public string FilterResult
        {
            get
            {
                return filterResult;
            }
            set
            {
                if(value!=filterResult)
                {
                    filterResult = value;
                    NotifyPropertyChanged("FilterResult");
                }
            }
        }
    }
}

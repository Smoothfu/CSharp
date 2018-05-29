using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    public class PersonDG : BaseNotifyPropertyChanged
    {

        public PersonDG()
        {
           
        }

        //private string _BusinessEntityID;
        //public string BusinessEntityID
        //{
        //    get
        //    {
        //        return _BusinessEntityID;
        //    }
        //    set
        //    {
        //        _BusinessEntityID = value;
        //        NotifyPropertyChanged("BusinessEntityID");
        //    }
        //}

        //private string _PersonType;
        //public string PersonType
        //{
        //    get
        //    {
        //        return _PersonType;
        //    }
        //    set
        //    {
        //        _PersonType = value;
        //        NotifyPropertyChanged("PersonType");
        //    }
        //}
        //public string NameStyle { get; set; }
        //public string Title { get; set; }
        //public string FirstName { get; set; }
        //public string MiddleName { get; set; }
        //public string LastName { get; set; }
        //public string Suffix { get; set; }
        //public string EmailPromotion { get; set; }
        //public string AdditionalContactInfo { get; set; }
        //public string Demographics { get; set; }
        //public string RowGuid { get; set; }
        //public string ModifiedDate { get; set; }
        private string _BusinessEntityID;
        public string BusinessEntityID
        {
            get
            {
                return _BusinessEntityID;
            }
            set
            {
                _BusinessEntityID = value;
                NotifyPropertyChanged("BusinessEntityID");
            }
        }

        private string _PersonType;
        public string PersonType
        {
            get
            {
                return _PersonType;
            }
            set
            {
                _PersonType = value;
                NotifyPropertyChanged("PersonType");
            }                          
        }

        private string _NameStyle;
        public string NameStyle
        {
            get
            {
                return _NameStyle;
            }
            set
            {
                _NameStyle = value;
                NotifyPropertyChanged("NameStyle");
            }
        }

        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                NotifyPropertyChanged("FirstName");
            }               
        }

        private string _MiddleName;
        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                _MiddleName = value;
                NotifyPropertyChanged("MiddleName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        private string _Suffix;
        public string Suffix
        {
            get
            {
                return _Suffix;
            }
            set
            {
                _Suffix = value;
                NotifyPropertyChanged("Suffix");
            }
        }

        private string _EmailPromotion;
        public string EmailPromotion
        {
            get
            {
                return _EmailPromotion;
            }
            set
            {
                _EmailPromotion = value;
                NotifyPropertyChanged("EmailPromotion");
            }
        }

        private string _AdditionalContactInfo;
        public string AdditionalContactInfo
        {
            get
            {
                return _AdditionalContactInfo;
            }
            set
            {
                _AdditionalContactInfo = value;
                NotifyPropertyChanged("AdditionalContactInfo");
            }
        }

        private string _Demographics;
        public string Demographics
        {
            get
            {
                return _Demographics;
            }
            set
            {
                _Demographics = value;
                NotifyPropertyChanged("Demographics");
            }
        }

        private string _RowGuid;
        public string RowGuid
        {
            get
            {
                return _RowGuid;
            }
            set
            {
                _RowGuid = value;
                NotifyPropertyChanged("RowGuid");
            }
        }

        private string _ModifiedDate;
        public string ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
                NotifyPropertyChanged("ModifiedDate");
            }
        }

    }
}

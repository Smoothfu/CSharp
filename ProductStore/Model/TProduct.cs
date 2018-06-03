using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProductStore.Model
{
    public class TProduct : ProductChangeNotify
    {
        private int _TPID;
        public int TPID
        {
            get
            {
                return _TPID;
            }
            set
            {
                _TPID = value;
                NotifyPropertyChanged("TPID");
            }
        }

        private string _TName;
        public string TName
        {
            get
            {
                return _TName;
            }
            set
            {
                _TName = value;
                NotifyPropertyChanged("TName");
            }
        }

        private string _TPNO;
        public string TPNO
        {
            get
            {
                return _TPNO;
            }
            set
            {
                _TPNO = value;
                NotifyPropertyChanged("TPNO");
            }
        }

        private string _TMF;
        public string TMF
        {
            get
            {
                return _TMF;
            }
            set
            {
                _TMF = value;
                NotifyPropertyChanged("TMF");
            }
        }

        private string _TFGF;
        public string TFGF
        {
            get
            {
                return _TFGF;
            }
            set
            {
                _TFGF = value;
                NotifyPropertyChanged("TFGF");
            }
        }

        private string _TColor;
        public string TColor
        {
            get
            {
                return _TColor;
            }
            set
            {
                _TColor = value;
                NotifyPropertyChanged("TColor");
            }
        }

        private string _TSSL;
        public string TSSL
        {
            get
            {
                return _TSSL;
            }
            set
            {
                _TSSL = value;
                NotifyPropertyChanged("TSSL");
            }
        }

        private string _TROP;
        public string TROP
        {
            get
            {
                return _TROP;
            }
            set
            {
                _TROP = value;
                NotifyPropertyChanged("TROP");
            }
        }

        private string _TSC;
        public string TSC
        {
            get
            {
                return _TSC;
            }
            set
            {
                _TSC = value;
                NotifyPropertyChanged("TSC");
            }
        }

        private string _TLP;
        public string TLP
        {
            get
            {
                return _TLP;
            }
            set
            {
                _TLP = value;
                NotifyPropertyChanged("TLP");
            }
        }       
    }
}

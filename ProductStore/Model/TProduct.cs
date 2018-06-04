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
        private Int32 _TPID;
        public Int32 TPID
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

        private bool _TMF;
        public bool TMF
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

        private bool _TFGF;
        public bool TFGF
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

        private Int16 _TSSL;
        public Int16 TSSL
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

        private Int16 _TROP;
        public Int16 TROP
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

        private decimal _TSC;
        public decimal TSC
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

        private decimal _TLP;
        public decimal TLP
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

        private string _TSize;
        public string TSize
        {
            get
            {
                return _TSize;
            }
            set
            {
                _TSize = value;
                NotifyPropertyChanged("TSize");
            }
        }

        private string _TSUMC;
        public string TSUMC
        {
            get
            {
                return _TSUMC;
            }
            set
            {
                _TSUMC = value;
                NotifyPropertyChanged("TSUMC");
            }
        }

        private string _TWUMC;
        public string TWUMC
        {
            get
            {
                return _TWUMC;
            }
            set
            {
                _TWUMC = value;
                NotifyPropertyChanged("TWUMC");
            }
        }

        private decimal _TWeight;
        public decimal TWeight
        {
            get
            {
                return _TWeight;
            }
            set
            {
                _TWeight = value;
                NotifyPropertyChanged("TWeight");
            }
        }

        private Int32 _TDTM;
        public Int32 TDTM
        {
            get
            {
                return _TDTM;
            }
            set
            {
                _TDTM = value;
                NotifyPropertyChanged("TDTM");
            }
        }

        private string _TPL;
        public string TPL
        {
            get
            {
                return _TPL;
            }
            set
            {
                _TPL = value;
                NotifyPropertyChanged("TPL");
            }
        }

        private string _TClass;
        public string TClass
        {
            get
            {
                return _TClass;
            }
            set
            {
                _TClass = value;
                NotifyPropertyChanged("TClass");
            }
        }

        public string _TStyle;
        public string TStyle
        {
            get
            {
                return _TStyle;
            }
            set
            {
                _TStyle = value;
                NotifyPropertyChanged("TStyle");
            }
        }

        private Int32 _TPSID;
        public Int32 TPSID
        {
            get
            {
                return _TPSID;
            }
            set
            {
                _TPSID = value;
                NotifyPropertyChanged("TPSID");
            }
        }

        private Int32 _TPMID;
        public Int32 TPMID
        {
            get
            {
                return _TPMID;
            }
            set
            {
                _TPMID = value;
                NotifyPropertyChanged("TPMID");
            }
        }

        private DateTime _TSSD;
        public DateTime TSSD
        {
            get
            {
                return _TSSD;
            }
            set
            {
                _TSSD = value;
                NotifyPropertyChanged("TSSD");
            }
        }

        private DateTime? _TSED;
        public DateTime? TSED
        {
            get
            {
                return _TSED;
            }
            set
            {
                _TSED = value;
                NotifyPropertyChanged("TSED");
            }
        }

        private DateTime? _TDD;
        public DateTime? TDD
        {
            get
            {
                return _TDD;
            }
            set
            {
                _TDD = value;
                NotifyPropertyChanged("TDD");
            }
        }

        private Guid _TRG;
        public Guid TRG
        {
            get
            {
                return _TRG;
            }
            set
            {
                _TRG = value;
                NotifyPropertyChanged("TRG");
            }
        }

        private DateTime _TMD;
        public DateTime TMD
        {
            get
            {
                return _TMD;
            }
            set
            {
                _TMD = value;
                NotifyPropertyChanged("TMD");
            }
        }

    }
}

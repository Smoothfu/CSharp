using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Model;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism;
using Prism.Commands;
using ProductStore.ServiceReference1;

namespace ProductStore.ViewModel
{
    public class ProductVM : ProductChangeNotify
    {
        public ProductVM()
        {

        }

        #region properties

        private List<TProduct> _TProductList = new List<TProduct>();
        public List<TProduct> TProductList
        {
            get
            {
                return _TProductList;
            }
            set
            {
                _TProductList = value;
                NotifyPropertyChanged("TProductList");
            }
        }

        private ObservableCollection<TProduct> _ProductCollection;
        public ObservableCollection<TProduct> ProductCollection
        {
            get
            {
                return _ProductCollection;
            }
            set
            {
                _ProductCollection = value;
                NotifyPropertyChanged("ProductCollection");
            }
        }

        private int _ProductID;
        public int ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
                NotifyPropertyChanged("ProductID");
            }
        }

        #endregion

        #region Commands

        private ICommand _ShowProductCommand;
        public ICommand ShowProductCommand
        {
            get
            {
                if(_ShowProductCommand==null)
                {
                    _ShowProductCommand = new DelegateCommand(ShowProductCommandExecuted, ShowProductCommandCanExecute);
                }
                return _ShowProductCommand;
            }
             
        }

        private void ShowProductCommandExecuted()
        {
            List<SProduct> sProdList = new List<SProduct>();              
            try
            {
                ServiceReference1.Service1Client sClient = new Service1Client();
                sProdList = sClient.GetSProductByPID(ProductID).ToList();
                if(sProdList!=null && sProdList.Any())
                {
                    ProductCollection = new ObservableCollection<TProduct>(ConvertFromServerProduct(sProdList));
                }
                 
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }            
        }

        private bool ShowProductCommandCanExecute()
        {
            return true;
        }

        #endregion

        #region methods
        static List<TProduct> ConvertFromServerProduct(List<SProduct> productList)
        {
            List<TProduct> TProdList = new List<TProduct>();

            if (productList != null && productList.Any())
            {
                productList.ForEach(x =>
                {
                    TProdList.Add(new TProduct()
                    {
                        TPID = x.SPID,
                        TName = x.SName,
                        TPNO = x.SPNO,
                        TMF = x.SMF,
                        TFGF = x.SFGF,
                        TColor = x.SColor,
                        TSSL = x.SSSL,
                        TROP = x.SROP,
                        TSC = x.SSC,
                        TLP = x.SLP,
                        TSize=x.SSize,
                        TSUMC=x.SSUMC,
                        TWUMC=x.SWUMC,
                        TWeight=x.SWeight,
                        TDTM=x.SDTM,
                        TPL=x.SPL,
                        TClass=x.SClass,
                        TStyle=x.SStyle,
                        TPSID=x.SPSID,
                        TPMID=x.SPMID,
                        TSSD=x.SSSD,
                        TSED=x.SSED,
                        TDD=x.SDD,
                        TRG=x.SRG,
                        TMD=x.SMD
                    });
                });
            }
            return TProdList;
        }

        #endregion
    }
   
}

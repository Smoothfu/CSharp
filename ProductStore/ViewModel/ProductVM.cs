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
using ProductWCFService;

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
            try
            {
                ProductWCFService.Service1 obj = new Service1();
                ProductWCFService.Service1 productService = new Service1();
                List<Product> serverProductList = productService.GetProductByPId(ProductID);
                ProductCollection = new ObservableCollection<TProduct>(ConvertFromServerProduct(serverProductList));
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
        static List<TProduct> ConvertFromServerProduct(List<Product> productList)
        {
            List<TProduct> TProdList = new List<TProduct>();

            if (productList != null && productList.Any())
            {
                productList.ForEach(x =>
                {
                    TProdList.Add(new TProduct()
                    {
                        TPID = x.PID,
                        TName = x.Name,
                        TPNO = x.PNO,
                        TMF = x.MF,
                        TFGF = x.FGF,
                        TColor = x.Color,
                        TSSL = x.SSL,
                        TROP = x.ROP,
                        TSC = x.SC,
                        TLP = x.LP
                    });
                });
            }
            return TProdList;
        }

        #endregion
    }
   
}

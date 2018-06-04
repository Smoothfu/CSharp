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
using System.Collections.Specialized;
using System.Windows.Controls;

namespace ProductStore.ViewModel
{
    public class ProductVM : ProductChangeNotify
    {
        static ServiceReference1.Service1Client sClient = new Service1Client();
        static List<SProduct> serverProductList = new List<SProduct>();
        static List<TProduct> terminalProductList = new List<TProduct>();
        static SProduct sp = new SProduct();
        public ProductVM()
        {
            ProductCollection.CollectionChanged += ProductCollection_CollectionChanged;
        }

        public void ProductCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }

        public void SelectedProductChanged(object sender, DataGridCellEditEndingEventArgs e)
        {
            var changedProduct = ((System.Windows.Controls.DataGrid)(sender)).CurrentItem as TProduct;
            if (changedProduct != null)
            {
                var changedIndex = ProductCollection.IndexOf(changedProduct);
                if (changedIndex > -1)
                {
                    ProductCollection.RemoveAt(changedIndex);
                    var sendToServerSingleProd =ConvertToServerSingleProduct(changedProduct);
                    var returnedTProd=ConvertFromServerSingleProduct(sClient.UpdateSelectedProduct(sendToServerSingleProd).FirstOrDefault());
                    ProductCollection.Insert(changedIndex, returnedTProd);
                }
            }
        }
        private void ProductionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {

            }

            if (e.Action == NotifyCollectionChangedAction.Move)
            {

            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {

            }

            if (e.Action == NotifyCollectionChangedAction.Replace)
            {

            }

            if (e.Action == NotifyCollectionChangedAction.Reset)
            {

            }

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

        private ObservableCollection<TProduct> _ProductCollection = new ObservableCollection<TProduct>();
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

        private TProduct _SelectedProduct;
        public TProduct SelectedProduct
        {
            get
            {
                return _SelectedProduct;
            }
            set
            {
                _SelectedProduct = value;
                NotifyPropertyChanged("SelectedProduct");
            }
        }

        private TProduct _ChangedProductItem = new TProduct();
        public TProduct ChangedProductItem
        {
            get
            {
                return _ChangedProductItem;
            }
            set
            {
                _ChangedProductItem = value;
                NotifyPropertyChanged("ChangedProductItem");
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
                if (_ShowProductCommand == null)
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

                sProdList = sClient.GetSProductByPID(ProductID).ToList();
                if (sProdList != null && sProdList.Any())
                {
                    ProductCollection.Clear();
                    ProductCollection = new ObservableCollection<TProduct>(ConvertFromServerProduct(sProdList));
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private bool ShowProductCommandCanExecute()
        {
            return true;
        }

        private ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new DelegateCommand(SaveCommandExecuted, SaveCommandCanExecute);
                }
                return _SaveCommand;
            }
        }

        private bool SaveCommandCanExecute()
        {
            return true;
        }

        private void SaveCommandExecuted()
        {
            serverProductList = ConvertToServerProduct(ProductCollection.ToList());

            serverProductList = sClient.SaveProducts(serverProductList.ToArray()).ToList();

            terminalProductList = ConvertFromServerProduct(serverProductList);
            ProductCollection = new ObservableCollection<TProduct>(terminalProductList);
        }

        #endregion

        #region methods
        public static List<TProduct> ConvertFromServerProduct(List<SProduct> productList)
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
                        TSize = x.SSize,
                        TSUMC = x.SSUMC,
                        TWUMC = x.SWUMC,
                        TWeight = x.SWeight,
                        TDTM = x.SDTM,
                        TPL = x.SPL,
                        TClass = x.SClass,
                        TStyle = x.SStyle,
                        TPSID = x.SPSID,
                        TPMID = x.SPMID,
                        TSSD = x.SSSD,
                        TSED = x.SSED,
                        TDD = x.SDD,
                        TRG = x.SRG,
                        TMD = x.SMD
                    });
                });
            }
            return TProdList;
        }

        public static List<SProduct> ConvertToServerProduct(List<TProduct> tProductList)
        {
            serverProductList.Clear();
            if (tProductList != null && tProductList.Any())
            {
                tProductList.ForEach(x =>
                {
                    sp = new SProduct()
                    {
                        SPID = x.TPID,
                        SName = x.TName,
                        SPNO = x.TPNO,
                        SMF = x.TMF,
                        SFGF = x.TFGF,
                        SColor = x.TColor,
                        SSSL = x.TSSL,
                        SROP = x.TROP,
                        SSC = x.TSC,
                        SLP = x.TLP,
                        SSize = x.TSize,
                        SSUMC = x.TSUMC,
                        SWUMC = x.TWUMC,
                        SWeight = x.TWeight,
                        SDTM = x.TDTM,
                        SPL = x.TPL,
                        SClass = x.TClass,
                        SStyle = x.TStyle,
                        SPSID = x.TPSID,
                        SPMID = x.TPMID,
                        SSSD = x.TSSD,
                        SSED = x.TSED,
                        SDD = x.TDD,
                        SRG = x.TRG,
                        SMD = x.TMD
                    };
                    serverProductList.Add(sp);
                });
            }
            return serverProductList;
        }

        public static TProduct ConvertFromServerSingleProduct(SProduct sProd)
        {
            if (sProd == null)
            {
                return null;
            }

            TProduct tProd = new TProduct()
            {
                TPID = sProd.SPID,
                TName = sProd.SName,
                TPNO = sProd.SPNO,
                TMF = sProd.SMF,
                TFGF = sProd.SFGF,
                TColor = sProd.SColor,
                TSSL = sProd.SSSL,
                TROP = sProd.SROP,
                TSC = sProd.SSC,
                TLP = sProd.SLP,
                TSize = sProd.SSize,
                TSUMC = sProd.SSUMC,
                TWUMC = sProd.SWUMC,
                TWeight = sProd.SWeight,
                TDTM = sProd.SDTM,
                TPL = sProd.SPL,
                TClass = sProd.SClass,
                TStyle = sProd.SStyle,
                TPSID = sProd.SPSID,
                TPMID = sProd.SPMID,
                TSSD = sProd.SSSD,
                TSED = sProd.SSED,
                TDD = sProd.SDD,
                TRG = sProd.SRG,
                TMD = sProd.SMD
            };
            return tProd;
        }

        public static SProduct ConvertToServerSingleProduct(TProduct tProd)
        {
            if (tProd == null)
            {
                return null;
            }

            SProduct sProd = new SProduct()
            {
                SPID = tProd.TPID,
                SName = tProd.TName,
                SPNO = tProd.TPNO,
                SMF = tProd.TMF,
                SFGF = tProd.TFGF,
                SColor = tProd.TColor,
                SSSL = tProd.TSSL,
                SROP = tProd.TROP,
                SSC = tProd.TSC,
                SLP = tProd.TLP,
                SSize = tProd.TSize,
                SSUMC = tProd.TSUMC,
                SWUMC = tProd.TWUMC,
                SWeight = tProd.TWeight,
                SDTM = tProd.TDTM,
                SPL = tProd.TPL,
                SClass = tProd.TClass,
                SStyle = tProd.TStyle,
                SPSID = tProd.TPSID,
                SPMID = tProd.TPMID,
                SSSD = tProd.TSSD,
                SSED = tProd.TSED,
                SDD = tProd.TDD,
                SRG = tProd.TRG,
                SMD = tProd.TMD
            };
            return sProd;
        }

        #endregion
    }
   
}

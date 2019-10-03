using Microsoft.Practices.Prism.Mvvm;
using SalesModule.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands; 
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using Infrastructure;
using System.Windows;
using SalesModule.Views;

namespace SalesModule.ViewModel
{
    public class SalesViewModel : BindableBase
    {
        //pack://application:,,,/SalesModule;component/views/salesview.xaml
        private static SalesViewModel SalesViewModelInstance;
        private SalesViewModel()
        {
            InitCollections();
            InitCommands();
            InitData();
        }

        private void InitCollections()
        {
            SalesOrderDetailCollection = new ObservableCollection<SalesOrderDetail>();
            SelectedOrdersCollection = new ObservableCollection<SalesOrderDetail>();
        }
        private void InitCommands()
        {
            ExitCmd = new DelegateCommand(ExitCmdExecuted, ExitCmdCanExecute);
            RefreshCmd = new DelegateCommand(RefreshCmdExecuted, RefreshCmdCanExecute);
            AddCmd = new DelegateCommand(AddCmdExecuted, AddCmdCanExecute);
            EditCmd = new DelegateCommand(EditCmdExecuted, EditCmdCanExecute);
            DeleteCmd = new DelegateCommand(DeleteCmdExecuted, DeleteCmdCanExecute);
            SubmitCmd = new DelegateCommand(SubmitCmdExecuted, SubmitCmdCanExecute);
            CancelCmd = new DelegateCommand(CancelCmdExecuted, CancelCmdCanExecute);
        }

        private bool CancelCmdCanExecute()
        {
            return true;
        }

        private void CancelCmdExecuted()
        {
            CloseAction();
        }

        private bool SubmitCmdCanExecute()
        {
            return true;
        }

        private void SubmitCmdExecuted()
        {

        }

        private bool ExitCmdCanExecute()
        {
            return true;
        }

        private void ExitCmdExecuted()
        {
            //MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to exit the application", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            //if(messageBoxResult==MessageBoxResult.Yes)
            //{
            Application.Current.Shutdown();
            //}
        }

        private bool DeleteCmdCanExecute()
        {
            return true;
        }

        private void DeleteCmdExecuted()
        {
            SalesOrderDetail toDeleteOrder = SelectedOrder;
            if(toDeleteOrder!=null)
            {
                int toDeleteIndex = SalesOrderDetailCollection.IndexOf(toDeleteOrder);
                if(toDeleteIndex>=0)
                {
                    MessageBoxResult deleteMBR = MessageBox.Show("Are you sure to delete this order?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                    if(deleteMBR==MessageBoxResult.Yes)
                    {
                        SalesOrderDetailCollection.RemoveAt(toDeleteIndex);
                    }
                }
            }
        }

        private bool EditCmdCanExecute()
        {
            return true;
        }

        private void EditCmdExecuted()
        {
            IsNewWindow = false;
            NewEditWindowTitle = "Edit Window";
            EditItemsVisibility = Visibility.Visible;
            if (SelectedOrder!=null)
            {
                SalesOrderID = SelectedOrder.SalesOrderID;
                SalesOrderDetailID = SelectedOrder.SalesOrderDetailID;
                CarrierTrackingNumber = SelectedOrder.CarrierTrackingNumber;
                OrderQty = SelectedOrder.OrderQty;
                ProductID = SelectedOrder.ProductID;
                SpecialOfferID = SelectedOrder.SpecialOfferID;
                UnitPrice = SelectedOrder.UnitPrice;
                UnitPriceDiscount = SelectedOrder.UnitPriceDiscount;
                LineTotal = SelectedOrder.LineTotal;
                RowGuid = SelectedOrder.RowGuid;
                ModifiedDate = SelectedOrder.ModifiedDate;
            }

            AddEditView editWindow = new AddEditView();
            editWindow.Show();            
        }

        private bool AddCmdCanExecute()
        {
            return true;
        }

        private void AddCmdExecuted()
        {
            NewEditWindowTitle = "New Window";
            IsNewWindow = true;

            AddEditView addWindow = new AddEditView();
            addWindow.Show();
        }

        public static SalesViewModel GetSalesViewModelInstance()
        {
            object objLock = new object();
            lock (objLock)
            {
                if (SalesViewModelInstance == null)
                {
                    SalesViewModelInstance = new SalesViewModel();
                }
            }
            return SalesViewModelInstance;
        }

        private bool RefreshCmdCanExecute()
        {
            return true;
        }

        private void RefreshCmdExecuted()
        {
            InitData();
        }

        void InitData()
        {
            SalesOrderDetailCollection = new ObservableCollection<SalesOrderDetail>();
            string selectSQL = "select top(100) * from sales.SalesOrderDetail;";
            DataTable dt = new DataTable();
            dt = DBHelper.ExecuteSelectSQL(selectSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SalesOrderDetail sod = new SalesOrderDetail();
                int intSODID;
                if (Int32.TryParse(dt.Rows[i][0]?.ToString(), out intSODID))
                {
                    sod.SalesOrderID = intSODID;
                }

                int intSODDetailID;
                if (Int32.TryParse(dt.Rows[i][1]?.ToString(), out intSODDetailID))
                {
                    sod.SalesOrderDetailID = intSODDetailID;
                }

                sod.CarrierTrackingNumber = dt.Rows[i][2]?.ToString();

                int intOrderQty;
                if (Int32.TryParse(dt.Rows[i][3]?.ToString(), out intOrderQty))
                {
                    sod.OrderQty = intOrderQty;
                }

                int intProductId;
                if (Int32.TryParse(dt.Rows[i][4]?.ToString(), out intProductId))
                {
                    sod.ProductID = intProductId;
                }

                int intSpecialOfferId;
                if (Int32.TryParse(dt.Rows[i][5]?.ToString(), out intSpecialOfferId))
                {
                    sod.SpecialOfferID = intSpecialOfferId;
                }

                decimal decimalUnitPrice;
                if (decimal.TryParse(dt.Rows[i][6]?.ToString(), out decimalUnitPrice))
                {
                    sod.UnitPrice = decimalUnitPrice;
                }

                decimal decimalUnitPriceDiscount;
                if (decimal.TryParse(dt.Rows[i][7]?.ToString(), out decimalUnitPriceDiscount))
                {
                    sod.UnitPriceDiscount = decimalUnitPriceDiscount;
                }

                decimal decimalLineTotal;
                if (decimal.TryParse(dt.Rows[i][8]?.ToString(), out decimalLineTotal))
                {
                    sod.LineTotal = decimalLineTotal;
                }

                Guid guidRowGuid;
                if (Guid.TryParse(dt.Rows[i][9]?.ToString(), out guidRowGuid))
                {
                    sod.RowGuid = guidRowGuid;
                }

                DateTime dateModifiedDate;
                if (DateTime.TryParse(dt.Rows[i][10].ToString(), out dateModifiedDate))
                {
                    sod.ModifiedDate = dateModifiedDate;
                }
                SalesOrderDetailCollection.Add(sod);
            }
        }

        static DataTable SelectExecute(string selectSQL)
        {
            string connString = @"Server=FRED\MSSQLSERVER01;Initial Catalog=AdventureWorks2017;Integrated Security=SSPI;";
            SqlConnection _dbConnection = new SqlConnection(connString);
            DataTable dt = new DataTable();
            using (_dbConnection)
            {
                if (_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }

                using (SqlCommand selectCmd = new SqlCommand(selectSQL, _dbConnection))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
                    {
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dt = ds.Tables[0];
                    }
                }
            }
            return dt;
        }

        #region Commands

        public DelegateCommand ExitCmd { get; private set; }

        public DelegateCommand RefreshCmd { get; private set; }

        public DelegateCommand AddCmd { get; private set; }

        public DelegateCommand EditCmd { get; private set; }

        public DelegateCommand DeleteCmd { get; private set; }

        public DelegateCommand SubmitCmd { get; private set; }

        public DelegateCommand CancelCmd { get; private set; }

        #endregion

        #region Properties

        private ObservableCollection<SalesOrderDetail> salesOrderDetailCollection;
        public ObservableCollection<SalesOrderDetail> SalesOrderDetailCollection
        {
            get
            {
                return salesOrderDetailCollection;
            }
            set
            {
                if (value != salesOrderDetailCollection)
                {
                    salesOrderDetailCollection = value;
                    OnPropertyChanged("SalesOrderDetailCollection");
                }
            }
        }

        private SalesOrderDetail selectedOrder;
        public SalesOrderDetail SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                if (value != selectedOrder)
                {
                    selectedOrder = value;
                    OnPropertyChanged("SelectedOrder");
                    if (selectedOrder != null)
                    {
                        SelectedOrdersCollection.Add(SelectedOrder);
                        IsBtnEnabled = true;
                    }
                }
            }
        }

        private ObservableCollection<SalesOrderDetail> selectedOrdersCollection;
        public ObservableCollection<SalesOrderDetail> SelectedOrdersCollection
        {
            get
            {
                return selectedOrdersCollection;
            }
            set
            {
                if (value != selectedOrdersCollection)
                {
                    selectedOrdersCollection = value;
                    OnPropertyChanged("SelectedOrdersCollection");
                }
            }
        }

        private string newEditWindowTitle;
        public string NewEditWindowTitle
        {
            get
            {
                return newEditWindowTitle;
            }
            set
            {
                if (value != newEditWindowTitle)
                {
                    newEditWindowTitle = value;
                    OnPropertyChanged("NewEditWindowTitle");
                }
            }
        }

        private Visibility editItemsVisibility = Visibility.Hidden;
        public Visibility EditItemsVisibility
        {
            get
            {
                return editItemsVisibility;
            }
            set
            {
                if (value != editItemsVisibility)
                {
                    editItemsVisibility = value;
                    OnPropertyChanged("EditItemsVisibility");
                }
            }
        }

        private bool isNewWindow;
        public bool IsNewWindow
        {
            get
            {
                return isNewWindow;
            }
            set
            {
                if (value != isNewWindow)
                {
                    isNewWindow = value;
                    OnPropertyChanged("IsNewWindow");
                    if (!isNewWindow)
                    {
                        EditItemsVisibility = Visibility.Visible;
                    }
                }
            }
        }

        public Action CloseAction { get; set; }

        private bool isBtnEnabled;
        public bool IsBtnEnabled
        {
            get
            {
                return isBtnEnabled;
            }
            set
            {
                if(value!=isBtnEnabled)
                {
                    isBtnEnabled = value;
                    OnPropertyChanged("IsBtnEnabled");
                }
            }
        }

        #region Edit Window

        private int salesOrderID;
        public int SalesOrderID
        {
            get
            {
                return salesOrderID;
            }

            set
            {
                if (value != salesOrderID)
                {
                    salesOrderID = value;
                    OnPropertyChanged("SalesOrderID");
                }
            }
        }

        private int salesOrderDetailID;
        public int SalesOrderDetailID
        {
            get
            {
                return salesOrderDetailID;
            }
            set
            {
                if (value != salesOrderDetailID)
                {
                    salesOrderDetailID = value;
                    OnPropertyChanged("SalesOrderDetailID");
                }
            }
        }

        private string carrierTrackingNumber;
        public string CarrierTrackingNumber
        {
            get
            {
                return carrierTrackingNumber;
            }
            set
            {
                if (carrierTrackingNumber != value)
                {
                    carrierTrackingNumber = value;
                    OnPropertyChanged("CarrierTrackingNumber");
                }
            }
        }

        private int? orderQty;
        public int? OrderQty
        {
            get
            {
                return orderQty;
            }
            set
            {
                if (value != orderQty)
                {
                    orderQty = value;
                    OnPropertyChanged("OrderQty");
                }
            }
        }

        private int? productID;
        public int? ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                if (value != productID)
                {
                    productID = value;
                    OnPropertyChanged("ProductID");
                }
            }
        }

        private int? specialOfferID;
        public int? SpecialOfferID
        {
            get
            {
                return specialOfferID;
            }
            set
            {
                if (value != specialOfferID)
                {
                    specialOfferID = value;
                    OnPropertyChanged("SpecialOfferID");
                }
            }
        }

        private decimal? unitPrice;
        public decimal? UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value != unitPrice)
                {
                    unitPrice = value;
                    OnPropertyChanged("UnitPrice");
                }
            }
        }

        private decimal? unitPriceDiscount;
        public decimal? UnitPriceDiscount
        {
            get
            {
                return unitPriceDiscount;
            }
            set
            {
                if (value != unitPriceDiscount)
                {
                    unitPriceDiscount = value;
                    OnPropertyChanged("UnitPriceDiscount");
                }
            }
        }

        private decimal? lineTotal;
        public decimal? LineTotal
        {
            get
            {
                return lineTotal;
            }
            set
            {
                if (value != lineTotal)
                {
                    lineTotal = value;
                    OnPropertyChanged("LineTotal");
                }
            }
        }

        private Guid rowGuid;
        public Guid RowGuid
        {
            get
            {
                return rowGuid;
            }
            set
            {
                if (value != rowGuid)
                {
                    rowGuid = value;
                    OnPropertyChanged("RowGuid");
                }
            }
        }

        private DateTime modifiedDate;
        public DateTime ModifiedDate
        {
            get
            {
                return modifiedDate;
            }
            set
            {
                if (value != modifiedDate)
                {
                    modifiedDate = value;
                    OnPropertyChanged("ModifiedDate");
                }
            }
        }

        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get
            {
                return createdAt;
            }
            set
            {
                if (value != createdAt)
                {
                    createdAt = value;
                    OnPropertyChanged("CreatedAt");
                }
            }
        }

        #endregion

        #endregion
    }
}

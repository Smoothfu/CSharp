using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;
using Prism.Mvvm;
using Prism.Commands;
using WpfApp44.GetDBTableService;
using System.Windows.Input;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace WpfApp44.ViewModel
{
    class DGViewModel:INotifyPropertyChanged
    {
        public DGViewModel()
        {
            DGLoadItemsSource();                        
        }

        public void DGLoadItemsSource()
        {             
            DGDataTable = new DataTable("Client MVVM ViewModel DataTable");
            DGDataTable = ServiceInstance.GetDBDataTables(); 
            DGDefaultDataView = DGDataTable.DefaultView;
        }

        #region properties
        private object objLock = new object();
        private GetDBTablesClient serviceInstance;
        public GetDBTablesClient ServiceInstance
        {
            get
            {
                lock(objLock)
                {
                    if (serviceInstance == null)
                    {
                        serviceInstance = new GetDBTablesClient();
                    }
                }                
                return serviceInstance;
            }
            set
            {
                if(value!=serviceInstance)
                {
                    serviceInstance = value;
                    NotifyPropertyChanged("ServiceInstance");
                }
            }
        }

        private DataRowView selectedDataRowView;
        public DataRowView SelectedDataRowView
        {
            get
            {
                return selectedDataRowView;
            }
            set
            {
                if (value != selectedDataRowView)
                {
                    selectedDataRowView = value;
                    NotifyPropertyChanged("SelectedDataRowView");
                }
            }
        }

        private DataView dGDefaultDataView;
        public DataView DGDefaultDataView
        {
            get
            {
                if(dGDefaultDataView==null)
                {
                    dGDefaultDataView = new DataView();
                }
                return dGDefaultDataView;
            }
            set
            {
                if (value != dGDefaultDataView)
                {
                    dGDefaultDataView = value;
                    NotifyPropertyChanged("DGDefaultDataView");
                }
            }
        }
        private DataTable dGDataTable;
        public DataTable DGDataTable
        {
            get
            {
                return dGDataTable;
            }
            set
            {
                if (value != dGDataTable)
                {
                    dGDataTable = value;
                    NotifyPropertyChanged("DGDataTable");
                }
            }
        }

        #endregion     

        #region Commands      

        private DelegateCommand reloadCmd;
        public DelegateCommand ReloadCmd
        {
            get
            {
                if(reloadCmd==null)
                {
                    reloadCmd = new DelegateCommand(ReloadCmdExecuted, ReloadCmdCanExecute);
                }
                return reloadCmd;
            }
            set
            {
                if(value!=reloadCmd)
                {
                    reloadCmd = value;
                    NotifyPropertyChanged("ReloadCmd");
                }
            }
        }

        private bool ReloadCmdCanExecute()
        {
            return true;
        }

        private void ReloadCmdExecuted()
        {
            DGDataTable.Clear();
            DGLoadItemsSource();
        }

        private ICommand clearCmd;
        public ICommand ClearCmd
        {
            get
            {
                if(clearCmd==null)
                {
                    clearCmd = new DelegateCommand(ClearCmdExecuted, ClearCmdCanExecute);
                }
                return clearCmd;
            }
            set
            {
                if(value!=clearCmd)
                {
                    clearCmd = value;
                    NotifyPropertyChanged("ClearCmd");
                }
            }
        }

        private bool ClearCmdCanExecute()
        {
            return true;
        }

        private void ClearCmdExecuted()
        {
            DGDataTable.Clear();
        }

        private DelegateCommand<object> selectedItemChangedCmd;
        public DelegateCommand<object> SelectedItemChangedCmd
        {
            get
            {
                if(selectedItemChangedCmd==null)
                {
                    selectedItemChangedCmd = new DelegateCommand<object>(SelectedItemChangedCmdExecuted, SelectedItemChangedCmdCanExecute);
                }
                return selectedItemChangedCmd;
            }
            set
            {
                if (value!=selectedItemChangedCmd)
                {
                    selectedItemChangedCmd = value;
                    NotifyPropertyChanged("SelectedItemChangedCmd");
                }
            }
        }

        private bool SelectedItemChangedCmdCanExecute(object arg)
        {
            var selectedDGDataRowView = arg as DataRowView;
            if(selectedDGDataRowView != null)
            {
                return true;
            }
            return false;
        }

        private void SelectedItemChangedCmdExecuted(object obj)
        {
            SelectedDataRowView.Row.Delete();
            DGDataTable.AcceptChanges();
        }

        private DelegateCommand addCmd;
        public DelegateCommand AddCmd
        {
            get
            {
                if (addCmd == null)
                {
                    addCmd = new DelegateCommand(AddCmdExecuted, AddCmdCanExecute);
                }
                return addCmd;
            }
            set
            {
                if (value != addCmd)
                {
                    addCmd = value;
                    NotifyPropertyChanged("AddCmd");
                }
            }
        }

        private bool AddCmdCanExecute()
        {
            return true;
        }
        private void AddCmdExecuted()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private DelegateCommand<object> deleteCmd;
        public DelegateCommand<object> DeleteCmd
        {
            get
            {
                if (deleteCmd==null)
                {
                    deleteCmd = new DelegateCommand<object>(DeleteCmdExecuted, DeleteCmdCanExecute);
                }
                return deleteCmd;
            }
            set
            {
                if(deleteCmd!=value)
                {
                    deleteCmd = value;
                    NotifyPropertyChanged("DeleteCmd");
                }
            }
        }

        private bool DeleteCmdCanExecute(object arg)
        {
            return true;
        }

        private void DeleteCmdExecuted(object obj)
        {
            var selectedDGItem = obj as DataRowView;
            if(selectedDGItem!=null)
            {
                SelectedDataRowView.Row.Delete();
                DGDataTable.AcceptChanges();
            }
        }

        private DelegateCommand<object> exportCmd;
        public DelegateCommand<object> ExportCmd
        {
            get
            {
                if(exportCmd==null)
                {
                    exportCmd = new DelegateCommand<object>(ExportCmdExecuted, ExportCmdCanExecute);
                }
                return exportCmd;
            }
        }

        private bool ExportCmdCanExecute(object arg)
        {
            return true;
        }

        private void ExportCmdExecuted(object obj)
        {
            ExportDataTable(DGDataTable);           
        }

        static void ExportDataTable(DataTable dt)
        {
            string exportedExcelFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xlsx";
            if(dt!=null && dt.Rows.Count>0)
            {
                XSSFWorkbook workBook = new XSSFWorkbook();
                ISheet firstSheet = workBook.CreateSheet("First Sheet");
                IRow headerRow = firstSheet.CreateRow(0);
               
                for(int i=0;i<dt.Columns.Count;i++)
                {                    
                    ICell headerCell = headerRow.CreateCell(i);
                    headerCell.SetCellValue(dt.Columns[i].ColumnName?.ToString());                     
                }                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow dataRow = firstSheet.CreateRow(i + 1);
                    for(int j=0;j<dt.Columns.Count;j++)
                    {
                        ICell dataCell = dataRow.CreateCell(j);                        
                        dataCell.SetCellValue(dt.Rows[i][j]?.ToString());                        
                    }
                }
                for(int i=0;i<dt.Columns.Count;i++)
                {
                    firstSheet.AutoSizeColumn(i);
                }                

                using (FileStream excelStream = File.Create(exportedExcelFullName))
                {
                    workBook.Write(excelStream);
                } 
                System.Windows.Application.Current.Shutdown();
            }           
        }

        #endregion
    }
}

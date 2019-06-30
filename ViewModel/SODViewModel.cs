using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp46.Common;
using System.IO;
using System.Windows.Forms;
using WpfApp46.View;
using System.Windows.Threading;
using System.Threading;

namespace WpfApp46.ViewModel
{
    public class SODViewModel : INotifyPropertyChanged
    {
       static GetSalesOrderService.GetSODDTClient client = new GetSalesOrderService.GetSODDTClient();
        
        #region methods

        public SODViewModel()
        {
            InitSODDT();
        }

        void InitSODDT()
        {
            if(SODDT.Rows.Count==0)
            {
                GetSalesOrderService.GetSODDTClient client = new GetSalesOrderService.GetSODDTClient();
                SODDT = client.GetSalesOrderDetailDT();
            }
            ColumnsCount = SODDT.Columns.Count;
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); 
            }
        }

        #region Property

        private string exportdExcelFileName;
        public string ExportedExcelFileName
        {
            get
            {
                exportdExcelFileName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xlsx";
                return exportdExcelFileName;                              
            }
            set
            {
                if(value!=exportdExcelFileName)
                {
                    exportdExcelFileName = value;
                    NotifyPropertyChanged("ExportedExcelFileName");
                }
            }
        }
        private int columnsCount;
        public int ColumnsCount
        {
            get
            {
                return columnsCount;
            }
            set
            {
                if(value!=columnsCount)
                {
                    columnsCount = value;
                    NotifyPropertyChanged("ColumnsCount");
                }
            }
        }
        private EditWindow editWin;
        public EditWindow EditWin
        {
            get
            {
                lock(client)
                {
                    if (editWin == null)
                    {
                        editWin = new EditWindow();
                    }
                }              
                return editWin;
            }
            set
            {
                if(value!=editWin)
                {
                    editWin = value;
                    NotifyPropertyChanged("EditWin");
                }
            }
        }
        private DataRow newUpdatedDataRow;
        public DataRow NewUpdatedDataRow
        {
            get
            {
                if(newUpdatedDataRow==null)
                {
                    newUpdatedDataRow = SODDT.NewRow();
                }
                return newUpdatedDataRow;
            }
            set
            {
                if(value!=newUpdatedDataRow)
                {
                    newUpdatedDataRow = value;
                    NotifyPropertyChanged("NewUpdatedDataRow");
                }

            }
        }
        private int selectedSODIndex;
        public int SelectedSODIndex
        {
            get
            {
                return selectedSODIndex;
            }
            set
            {
                if(value!=selectedSODIndex)
                {
                    selectedSODIndex = value;
                    NotifyPropertyChanged("SelectedSODIndex");
                }
            }
        }

        private DataRowView initialDataRowView;
        public DataRowView InitialDataRowView
        {
            get
            {
                return initialDataRowView;
            }
            set
            {
                if(value!=initialDataRowView)
                {
                    initialDataRowView = value;
                    NotifyPropertyChanged("InitialDataRowView");
                }
            }
        }

        private DataTable sODDT;
        public DataTable SODDT
        {
            get
            {
               if(sODDT==null)
                {
                    sODDT = new DataTable("Datagrid ItemsSource");
                }
               return sODDT;
            }
            set
            {
                if(value!=sODDT)
                {
                    sODDT = value;
                    NotifyPropertyChanged("SODDT");
                }
            }
        }

        public DataRowView UpdatedSOD { get; set; }

        private DataRowView selectedSOD;
        public DataRowView SelectedSOD
        {
            get
            {                 
                return selectedSOD;
            }
            set
            {
                if(value!=selectedSOD)
                {
                    selectedSOD = value;
                    NotifyPropertyChanged("SelectedSOD");
                }
            }
        }
        private ICommand clearCmd;
        public ICommand ClearCmd
        {
            get
            {
                if(clearCmd==null)
                {
                    clearCmd = new DelCmd(ClearCmdExecute, ClearCmdCanExecute);
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

        private bool ClearCmdCanExecute(object obj)
        {
            if (SODDT != null && SODDT.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void ClearCmdExecute(object obj)
        {
            SODDT.Clear();
        }


        private ICommand reloadCmd;
        public ICommand ReloadCmd
        {
            get
            {
                if(reloadCmd==null)
                {
                    reloadCmd = new DelCmd(ReloadCmdExecuted, ReloadCmdCanExecute);
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

        private bool ReloadCmdCanExecute(object obj)
        {
            if(SODDT.Rows.Count==0)
            {
                return true;
            }
            return false;
        }

        private void ReloadCmdExecuted(object obj)
        {
            InitSODDT();
        }

        private ICommand exportCmd;
        public ICommand ExportCmd
        {
            get
            {
                if(exportCmd==null)
                {
                    exportCmd = new DelCmd(ExportCmdExecuted, ExportCmdCanExecute);
                }
                return exportCmd;
            }
            set
            {
                if(value!=exportCmd)
                {
                    exportCmd = value;
                    NotifyPropertyChanged("ExportCmd");
                }
            }
        }

        private bool ExportCmdCanExecute(object obj)
        {
            if(SODDT!=null && SODDT.Rows.Count>0)
            {
                return true;
            }
            return false;
        }

        private void ExportCmdExecuted(object obj)
        {            
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;            
            bgWorker.RunWorkerAsync();                                
        }        

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Task exportTask = Task.Run(() =>
             {
                 CommonHelper.ExportDataTable(SODDT, ExportedExcelFileName);                 
                 System.Diagnostics.Debug.WriteLine(SODDT.Rows.Count);
             });
        }

        private ICommand editCmd;
        public ICommand EditCmd
        {
            get
            {
                if(editCmd==null)
                {
                    editCmd = new DelCmd(EditCmdExecuted, EditCmdCanExecute);
                }
                return editCmd;
            }
            set
            {
                if(value!=editCmd)
                {
                    editCmd = value;
                    NotifyPropertyChanged("EditCmd");
                }
            }
        }

        private bool EditCmdCanExecute(object obj)
        {
            if(SelectedSOD!=null)
            {
                return true;
            }
            return false;
        }

        private void EditCmdExecuted(object obj)
        {
            SelectedSODIndex = SODDT.Rows.IndexOf(SelectedSOD.Row);
            InitialDataRowView = SelectedSOD;
            SelectedSODDt.Clear();
            for (int i=0;i<SelectedSOD.Row.ItemArray.Length;i++)
            {
                SelectedSODDt.Columns.Add();
            }

            SelectedSODDt.Rows.Add(SelectedSOD.Row.ItemArray);
            UpdatedSOD = SelectedSOD;            
            EditWin.DataContext = this;
            EditWin.ShowDialog();
        }

        private ICommand loadDataCmd;
        public ICommand LoadDataCmd
        {
            get
            {
                if(loadDataCmd==null)
                {
                    loadDataCmd = new DelCmd(LoadDataCmdExecuted, LoadDataCanExecute);
                }
                return loadDataCmd;
            }
            set
            {
                if(value!=loadDataCmd)
                {
                    loadDataCmd = value;
                    NotifyPropertyChanged("LoadDataCmd");
                }
            }
        }

        private bool LoadDataCanExecute(object obj)
        {
            if(SODDT.Rows.Count==0)
            {
                return true;
            }
            return false;
        }

        private void LoadDataCmdExecuted(object obj)
        {
            InitSODDT();
        }
        
        private DataTable selectedSODDt;
        public DataTable SelectedSODDt
        {
            get
            {
                if (selectedSODDt == null)
                {
                    selectedSODDt = new DataTable("Data Table in Edit window");
                }
                return selectedSODDt;
            }
            set
            {
                if(value!= selectedSODDt)
                {
                    selectedSODDt = value;
                    NotifyPropertyChanged("SelectedSODDt");
                }
            }
        }

        private ICommand saveCmd;
        public ICommand SaveCmd
        {
            get
            {
                if(saveCmd==null)
                {
                    saveCmd = new DelCmd(SaveCmdExecuted, SaveCmdCanExecute);
                }
                return saveCmd;
            }
        }

        private bool SaveCmdCanExecute(object obj)
        {          
            return true;
        }

        private void SaveCmdExecuted(object obj)
        {
          Task updatesTask= Task.Run(() =>
            {
                if (SelectedSODIndex != -1)
                {                    
                    var tempDataRow = SelectedSOD.Row;
                    DataRow newDataRow = SODDT.NewRow();
                    newDataRow.ItemArray = tempDataRow.ItemArray.Take(ColumnsCount).ToArray();
                    SODDT.Rows.InsertAt(newDataRow, SelectedSODIndex);
                    SODDT.Rows.RemoveAt(SelectedSODIndex + 1);
                    SelectedSOD.Row.ItemArray = new object[ColumnsCount];
                }
            });

            updatesTask.Wait();
            SODDT.AcceptChanges();
            editWin.Closed += EditWin_Closed;
            EditWin.Close();           
        }

        private void EditWin_Closed(object sender, EventArgs e)
        {
            EditWin.Close();
            EditWin = null;
        }

        void UpdateDataTable()
        {
            var selectedDataRow = UpdatedSOD.Row;
            var selectedIndex = SODDT.Rows.IndexOf(selectedDataRow);
            if (selectedIndex != -1)
            {
                DataRow newAddedRow = SelectedSOD.Row;
                SODDT.ImportRow(SelectedSOD.Row);
            }
        }


        private ICommand cancelCmd;
        public ICommand CancelCmd
        {
            get
            {
                if(cancelCmd==null)
                {
                    cancelCmd = new DelCmd(CancelCmdExecuted, CancelCmdCanExecute);
                }
                return cancelCmd;
            }
            set
            {
                if(value!=cancelCmd)
                {
                    cancelCmd = value;
                    NotifyPropertyChanged("CancelCmd");
                }
            }
        }

        private bool CancelCmdCanExecute(object obj)
        {
            return true;
        }

        private void CancelCmdExecuted(object obj)
        {
            EditWin.Close();
        }
        #endregion
    }
}

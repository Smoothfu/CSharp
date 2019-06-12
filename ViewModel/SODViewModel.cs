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

namespace WpfApp46.ViewModel
{
    public class SODViewModel : INotifyPropertyChanged
    {
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
            string excelFileName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xlsx";
            Task exportTask = Task.Run(() =>
              {
                  CommonHelper.ExportDataTable(SODDT, excelFileName);
              });

            exportTask.Wait();
            if(exportTask.IsCompleted)
            {
                MessageBox.Show($"The exported file has been saved as {excelFileName}");
            }
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
            SelectedSODDt.Clear();
            for (int i=0;i<SelectedSOD.Row.ItemArray.Length;i++)
            {
                SelectedSODDt.Columns.Add();
            }
            
            SelectedSODDt.Rows.Add(SelectedSOD.Row.ItemArray);
            TempDt = SelectedSODDt;
            EditWindow editWin = new EditWindow();
            editWin.DataContext = this;
            editWin.ShowDialog();
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

        public DataTable tempDt;
        public DataTable TempDt
        {
            get
            {
                if(tempDt==null)
                {
                    tempDt = new DataTable("Temp DataTable");
                }
                return tempDt;
            }
            set
            {
                if(value!=tempDt)
                {
                    tempDt = value;
                    NotifyPropertyChanged("TempDt");
                }
            }
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
            var temp = SelectedSODDt;
            var temp2 = TempDt;
        }
        
        #endregion
    }
}

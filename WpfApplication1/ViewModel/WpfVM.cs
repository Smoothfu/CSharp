using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WpfApplication1.Model;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows; 
using System.IO;
using Newtonsoft.Json;

namespace WpfApplication1.ViewModel
{
    public class WpfVM : INotifyPropertyChanged
    {
        private WpfVM()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        private static WpfVM Wpfvm;
        private static readonly object objLock = new object();
        public static WpfVM GetWpfVM()
        {
            lock(objLock)
            {
                if(Wpfvm == null)
                {
                    Wpfvm = new WpfVM();
                }
                return Wpfvm;
            }
        }

        private static CancellationTokenSource cts=new CancellationTokenSource();

        #region Commands
        private DelegateCommand ClickCmdValue;
        public DelegateCommand ClickCmd
        {
            get
            {
                if(ClickCmdValue==null)
                {
                    ClickCmdValue = new DelegateCommand(ClickCmdExecuted);
                }
                return ClickCmdValue;
            }
        }

        private string ContentValue;
        public string Content
        {
            get
            {
                return ContentValue;
            }
            set
            {
                if(value!=ContentValue)
                {
                    ContentValue = value;
                    OnPropertyChanged("Content");
                }
            }
        }


        private bool IsCancelledValue=false;
        public bool IsCancelled
        {
            get
            {
                return IsCancelledValue;
            }
            set
            {
                if(value!=IsCancelledValue)
                {
                    IsCancelledValue = value;
                    OnPropertyChanged("IsCancelled");
                }
            }
        }
        private void ClickCmdExecuted(object obj)
        {
            ContentOb = new ObservableCollection<string>();
            Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    Content = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    App.Current.Dispatcher.BeginInvoke((Action)delegate
                    {
                        ContentOb.Add(Content);
                    });
                    System.Diagnostics.Debug.WriteLine(Content);
                }
            },cts.Token);                      
        }

        private DelegateCommand CancelCmdValue;
        public DelegateCommand CancelCmd
        {
            get
            {
                if(CancelCmdValue==null)
                {
                    CancelCmdValue = new DelegateCommand(CancelCmdValueExecuted);
                }
                return CancelCmdValue;
            }
        }

        private void CancelCmdValueExecuted(object obj)
        {
            cts.Cancel();
            IsCancelled = true;
            System.Diagnostics.Debug.WriteLine("Cancelled!");
            string msJsonSerializerString = JsonConvert.SerializeObject(ContentOb,Formatting.Indented);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
            using(StreamWriter streamWriter=new StreamWriter(fileName,true,Encoding.UTF8))
            {
                streamWriter.WriteLine(msJsonSerializerString);
            }
        }
        #endregion

        #region Properties
        private ObservableCollection<string> ContentObValue;
        public ObservableCollection<string> ContentOb
        {
            get
            {                 
                return ContentObValue;
            }
            set
            {
                if(value!=ContentObValue)
                {
                    ContentObValue = value;
                    OnPropertyChanged("ContentOb");
                }
            }
        }
        #endregion
    }
}

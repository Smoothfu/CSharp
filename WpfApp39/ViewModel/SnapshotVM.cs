using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO; 


namespace WpfApp39.ViewModel
{
   public class SnapshotVM : INotifyPropertyChanged
    {
        public SnapshotVM()
        {
            SnapShotCmd = new DelegateCommand(SnapShotCmdExecuted, SnapShotCmdCanExecute);
        }

        private bool SnapShotCmdCanExecute()
        {
            return true;
        }

        private void SnapShotCmdExecuted()
        { 
            Rectangle bounds = Screen.GetBounds(System.Drawing.Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                }

                string screenShotsFullName = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";

                bitmap.Save(screenShotsFullName, ImageFormat.Jpeg);                               
            }            
        }
       
        public DelegateCommand SnapShotCmd
        {
            get;set;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}

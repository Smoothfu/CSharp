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
using System.Windows.Input;
using WpfApp39.Resources;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WpfApp39.Model;

namespace WpfApp39.ViewModel
{
   public class SnapshotVM : INotifyPropertyChanged
    {
        public SnapshotVM()
        {
            SnapShotCmd = new DelegateCommand(SnapShotCmdExecuted, SnapShotCmdCanExecute);
            GetsDataCmd = new DelegateCommand(GetsDataCmdExecuted, GetsDataCmdCanExecute);
            salesList = new List<SalesOrderDetail>();
        }

        private bool GetsDataCmdCanExecute()
        {
            return true;
        }

        private void GetsDataCmdExecuted()
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connString;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string selectSQL = "select SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber," +
                    "OrderQty,ProductID," +
                    "SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal," +
                    "rowguid,ModifiedDate from sales.SalesOrderDetail";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSQL, conn);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SalesList.Add(new SalesOrderDetail()
                    {
                        SalesOrderID = (int)ds.Tables[0].Rows[i][0],
                        SalesOrderDetailID = (int)ds.Tables[0].Rows[i][1],
                        ModifiedDate = (DateTime)ds.Tables[0].Rows[i][10]
                    });
                }

                var tempList = SalesList;
            }
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

        public DelegateCommand GetsDataCmd
        { get; set; }

        private List<SalesOrderDetail> salesList=new List<SalesOrderDetail>();
        public List<SalesOrderDetail> SalesList
        {
            get
            {
                return salesList;
            }
            set
            {
               
                    salesList = value;
                    NotifyPropertyChanged("SalesList");
               
            }
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

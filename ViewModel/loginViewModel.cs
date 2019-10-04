using Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFPrism.ViewModel
{
    public class LoginViewModel:BindableBase
    {
        public LoginViewModel()
        {
            InitCmds();
        }

        #region Methods
        private void InitCmds()
        {
            LoginCmd = new DelegateCommand<object>(LoginCmdExecuted, LoginCmdCanExecute);
            CancelCmd = new DelegateCommand(CancelCmdExecuted, CancelCmdCanExecute);
        }

        private bool CancelCmdCanExecute()
        {
            return true;
        }

        private void CancelCmdExecuted()
        {
            MessageBoxResult mbr = MessageBox.Show("Are you sure to quit login?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (mbr == MessageBoxResult.Yes)
            {
                CloseAction();
            }
        }

        private bool LoginCmdCanExecute(object arg)
        {
            return true;
        }

        private void LoginCmdExecuted(object obj)
        {
            var pwdBox = obj as PasswordBox;
            if(pwdBox!=null)
            {
                UserPwd = pwdBox.Password;
            }


            if (LoginOn())
            {
                CloseAction();
            }
            else
            {
                MessageBox.Show("UserName or password is not correct!");
                return;
            }
        }

        private bool LoginOn()
        {
            bool isSucceed = false;
            string selectLogin = "select username,userpwd from loginTable where username='" + UserName + "'";
            DataTable pwdDt = DBHelper.ExecuteSelectSQL(selectLogin);
            if(pwdDt!=null && pwdDt.Rows.Count>0)
            {
                string uName = pwdDt.Rows[0][0]?.ToString();
                string uPwd = pwdDt.Rows[0][1]?.ToString();
                if (!string.IsNullOrWhiteSpace(uName) && !string.IsNullOrWhiteSpace(uPwd))
                {
                    string hashPwd = CommonHelper.GetMD5(UserPwd);
                    if (uName.Equals(UserName, StringComparison.Ordinal) && uPwd.Equals(hashPwd, StringComparison.Ordinal))
                    {
                        isSucceed = true;
                    }
                }               
            }
            return isSucceed;
        }

        #endregion

        #region Commands
        public DelegateCommand<object> LoginCmd { get;set; }
        public DelegateCommand CancelCmd { get; set; }
        public Action CloseAction { get; set; }
        #endregion

        #region properties
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if(value!=userName)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        private string userPwd;
        public string UserPwd
        {
            get
            {
                return userPwd;
            }
            set
            {
                if(value!=userPwd)
                {
                    userPwd = value;
                    OnPropertyChanged("UserPwd");
                }
            }
        }

        private bool isRememeberMe;
        public bool IsRememeberMe
        {
            get
            {
                return isRememeberMe;
            }
            set
            {
                if(value!=isRememeberMe)
                {
                    isRememeberMe = value;
                    OnPropertyChanged("IsRememeberMe"); 
                }
            }
        }
        
        #endregion
    }
}

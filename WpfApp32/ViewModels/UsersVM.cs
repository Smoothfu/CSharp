using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp32.Models;

namespace WpfApp32.ViewModels
{
    class UsersVM:INotifyPropertyChanged
    {
        public ObservableCollection<User> usersCollection;
        public ObservableCollection<User> UsersCollection
        {
            get
            {
                return usersCollection;
            }
            set
            {
                if(value!=usersCollection)
                {
                    usersCollection = value;
                    NotifyPropertyChanged("UsersCollection");
                }
            }
        }
        public DelegateCommand ClearCmd { get; set; }
        public UsersVM()
        {
            UsersCollection = new ObservableCollection<User>();
            for (int i = 0; i < 100000;i++)
            {
                UsersCollection.Add(new User()
                {
                    Id = i,
                    Name = "Fred" + i,
                    Gender=i%2==0?"F":"M"
                });
            }
            var temp = UsersCollection;
            ClearCmd = new DelegateCommand(BtnCommandExecuted, BtnCommandCanExecute);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool BtnCommandCanExecute()
        {
            if(UsersCollection!=null && UsersCollection.Any())
            {
                return true;
            }
            return false;
        }

        private void BtnCommandExecuted()
        {
            UsersCollection = null;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;
using WpfApp1.Model;
using System.Windows.Input;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Interactivity;
using System.Windows.Threading;

namespace WpfApp1.ViewModel
{
    public class PersonViewModel : BaseNotifyPropertyChanged
    {
        public PersonViewModel()
        {
            InitData();
        }

        private void InitData()
        {
            _PersonDGList = new List<PersonDG>();

            WcfServiceLibrary1.Service1 obj = new Service1();
            var serverPersonList = obj.GetPersonList();
            if (serverPersonList != null && serverPersonList.Any())
            {
                serverPersonList.ForEach(x =>
                {
                    PersonDGList.Add(ConvertFromServerPerson(x));
                });
            }
        }

        private PersonDG ConvertFromServerPerson(Person serverPerson)
        {
            if (serverPerson == null)
            {
                return null;
            }

            return new PersonDG()
            {
                BusinessEntityID = serverPerson.BusinessEntityID,
                PersonType = serverPerson.PersonType,
                NameStyle = serverPerson.NameStyle,
                Title = serverPerson.Title,
                FirstName = serverPerson.FirstName,
                MiddleName = serverPerson.MiddleName,
                LastName = serverPerson.LastName,
                Suffix = serverPerson.Suffix,
                EmailPromotion = serverPerson.EmailPromotion,
                AdditionalContactInfo = serverPerson.AdditionalContactInfo,
                Demographics = serverPerson.Demographics,
                RowGuid = serverPerson.RowGuid,
                ModifiedDate = serverPerson.ModifiedDate
            };
        }

        private List<PersonDG> _PersonDGList;
        public List<PersonDG> PersonDGList
        {
            get
            {
                return _PersonDGList;
            }
            set
            {
                _PersonDGList = value;
                NotifyPropertyChanged("PersonDGList");
            }
        }

        private PersonDG _SelectedPersonDG = new PersonDG();
        public PersonDG SelectedPersonDG
        {
            get
            {
                return _SelectedPersonDG;
            }
            set
            {
                _SelectedPersonDG = value;
                NotifyPropertyChanged("SelectedPersonDG");
            }
        }

        private ICommand _CellEditCommand;
        public ICommand CellEditCommand
        {
            get
            {
                if (_CellEditCommand == null)
                {
                    _CellEditCommand = new DelegateCommand<object>(CellEditCanExecute, CellEditExecuted);
                }
                return _CellEditCommand;
            }

        }

        private bool CellEditExecuted(object arg)
        {
            if (arg != null)
            {
                return true;
            }
            return false;
        }

        private void CellEditCanExecute(object obj)
        {
            var selectedPerson = obj as PersonDG;
            if (selectedPerson != null)
            {

            }
        }

        private ICommand _QueryCommand;
        public ICommand QueryCommand
        {
            get
            {
                if (_QueryCommand == null)
                {
                    _QueryCommand = new DelegateCommand(QueryCommandCanExecute, QueryCommandExecuted);
                }
                return _QueryCommand;
            }
        }

        private bool QueryCommandExecuted()
        {
            if (SelectedPersonDG != null)
            {
                return true;
            }
            return false;
        }

        private void QueryCommandCanExecute()
        {
            try
            {
                Dispatcher.CurrentDispatcher.Invoke(new Action(() =>
                {
                    int index = PersonDGList.IndexOf(SelectedPersonDG);
                    if(index>-1)
                    {
                        PersonDGList.RemoveAt(index);
                        PersonDGList.Insert(index, SelectedPersonDG);                        
                    }
                    var tempCollection = PersonDGList;
                    PersonDGList = null;
                    PersonDGList = new List<PersonDG>(tempCollection); 
                }),DispatcherPriority.Normal);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("yyyyMMdd-HHmmssfff")+ ex.Message);
            }            
        }
    }
}

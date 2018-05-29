using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class PersonViewModel:BaseNotifyPropertyChanged
    {
        public PersonViewModel()
        { 
            _PersonDGList = new List<PersonDG>();            
            
            WcfServiceLibrary1.Service1 obj = new Service1();
            var serverPersonList = obj.GetPersonList();
            if (serverPersonList != null && serverPersonList.Any())
            {
                serverPersonList.ForEach(x =>
                {
                    var personDGObj = ConvertFromServerPerson(x);
                    PersonDGList.Add(personDGObj);
                });
            }

            var finalResult = PersonDGList;
        }

        private PersonDG ConvertFromServerPerson(Person serverPerson)
        {
            if (serverPerson == null)
            {
                return null;
            }

            var personDGClient = new PersonDG();
            personDGClient.BusinessEntityID = serverPerson.BusinessEntityID;
            personDGClient.PersonType = serverPerson.PersonType;
            personDGClient.NameStyle = serverPerson.NameStyle;
            personDGClient.Title = serverPerson.Title;
            personDGClient.FirstName = serverPerson.FirstName;
            personDGClient.MiddleName = serverPerson.MiddleName;
            personDGClient.LastName = serverPerson.LastName;
            personDGClient.Suffix = serverPerson.Suffix;
            personDGClient.EmailPromotion = serverPerson.EmailPromotion;
            personDGClient.AdditionalContactInfo = serverPerson.AdditionalContactInfo;
            personDGClient.Demographics = serverPerson.Demographics;
            personDGClient.RowGuid = serverPerson.RowGuid;
            personDGClient.ModifiedDate = serverPerson.ModifiedDate;

            return personDGClient;         
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
                if (_PersonDGList != value)
                {
                    NotifyPropertyChanged("PersonDGList");
                }
            }
        }

    }
}

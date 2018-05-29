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
                if (_PersonDGList != value)
                {
                    NotifyPropertyChanged("PersonDGList");
                }
            }
        }

    }
}

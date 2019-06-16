using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class EmployeesController : ApiController
    {
        private static IList<Employee> employeesList = new List<Employee>()
        {
            new Employee()
            {
                Id=1,FirstName="Fred1",LastName="Fu1"
            },
            new Employee()
            {
                Id=2,FirstName="Fred2",LastName="Fu2"
            },
            new Employee
            {
                Id=3,FirstName="Fred3",LastName="Fu3"
            }
        };


        ////Get api/employees
        //public IEnumerable<Employee> Get()
        //{
        //    return employeesList;
        //}

        ////Get api/employees/1
        //public Employee Get(int id)
        //{
        //    return employeesList.First(x => x.Id == id);
        //}

        ////POST api/employees
        //public void Post(Employee emp)
        //{
        //    int maxId = employeesList.Max(x => x.Id);
        //    emp.Id = maxId + 1;
        //    employeesList.Add(emp);
        //}

        ////Put api/employees/1
        //public void Put(int id,Employee emp)
        //{
        //    int index = employeesList.ToList().FindIndex(x => x.Id == id);
        //    employeesList[index] = emp;
        //}

        ////DELETE api/employees/1
        //public void Delete(int id)
        //{
        //    Employee deleteEmp = Get(id);
        //    employeesList.Remove(deleteEmp);
        //}

        //[AcceptVerbs("GET")]
        //public Employee RetrieveEmployeeById(int id)
        //{
        //    return employeesList.First(x => x.Id == id);
        //}


        [HttpGet]
        public Employee RetrieveEmployeeById(int id)
        {
            return employeesList.First(x => x.Id == id);
        }


    }
}

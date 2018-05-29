using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Person> GetPersonList()
        {
            List<Person> personList = new List<Person>();
            //string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                string selectSQL = "select BusinessEntityID,PersonType,NameStyle,Title,FirstName,MiddleName,LastName,Suffix,EmailPromotion,AdditionalContactInfo,Demographics,rowguid,ModifiedDate from AdventureWorks2014.Person.Person";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSQL, conn);
                DataSet ds = new DataSet("AdventureWorks2014.Person.Person");
                sqlDataAdapter.Fill(ds);

                if(ds.Tables[0].Rows.Count>0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        personList.Add(new Person
                        {
                            BusinessEntityID = ds.Tables[0].Rows[i]["BusinessEntityID"].ToString(),
                            PersonType = ds.Tables[0].Rows[i]["PersonType"].ToString(),
                            NameStyle = ds.Tables[0].Rows[i]["NameStyle"].ToString(),
                            Title = ds.Tables[0].Rows[i]["Title"].ToString(),
                            FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString(),
                            MiddleName = ds.Tables[0].Rows[i]["MiddleName"].ToString(),
                            LastName = ds.Tables[0].Rows[i]["LastName"].ToString(),
                            Suffix = ds.Tables[0].Rows[i]["Suffix"].ToString(),
                            EmailPromotion = ds.Tables[0].Rows[i]["EmailPromotion"].ToString(),
                            AdditionalContactInfo = ds.Tables[0].Rows[i]["AdditionalContactInfo"].ToString(),
                            Demographics = ds.Tables[0].Rows[i]["Demographics"].ToString(),
                            RowGuid = ds.Tables[0].Rows[i]["rowguid"].ToString(),
                            ModifiedDate = ds.Tables[0].Rows[i]["ModifiedDate"].ToString()
                        });
                    }
                }
            }
            return personList;
        }
    }
}

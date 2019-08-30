using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;

namespace DBDll.Dll
{
    public class SQLTransactionLevelDemo
    {
        public static void TransShow()
        {
            using (SqlConnection conn = DBCommon.GetSqlConnection())
            {
                using (var trans = conn.BeginTransaction())
                {
                    string sql = "update SOD2 set ModifiedDate=GETDATE() where SalesOrderDetailID%10=0;";
                    int updatedRows=conn.Execute(sql, trans);
                    trans.Commit();
                    if(updatedRows<1)
                    {
                        trans.Rollback();
                    }
                }
            }
        }
    }
}

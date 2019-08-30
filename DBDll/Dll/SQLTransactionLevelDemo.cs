using System;
using System.Data;
using Dapper;

namespace DBDll.Dll
{
    public class SQLTransactionLevelDemo
    {
        public static void TransShow()
        {
            using (IDbConnection conn = DBCommon.GetSqlConnection())
            {
                if(conn.State!=System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "update SOD2 set ModifiedDate=GETUTCDATE() where SalesOrderDetailID%10=0;";
                        int updatedRows = conn.Execute(sql,new { }, trans,commandType:System.Data.CommandType.Text);
                        trans.Commit();                        
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                    }                    
                }
            }
        }
    }
}

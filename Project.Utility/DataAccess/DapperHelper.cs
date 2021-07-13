using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Project.Utility.DataAccess
{
    public class DapperHelper
    {
        const int SQL_TIMEOUT_SEC = 180;

        public static T Query<T>(string connectionString, string commandText, DynamicParameters commandParameters = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault<T>(commandText, commandParameters, commandType: CommandType.StoredProcedure, commandTimeout: SQL_TIMEOUT_SEC);
            }
        }

        public static IEnumerable<T> QueryCollection<T>(string connectionString, string commandText, DynamicParameters commandParameters = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                //return conn.Query<T>(" SELECT [PrejectId], [PrejectName] FROM[Project].[dbo].[ProjectTable] ",
                //    commandParameters, commandType: CommandType.Text, commandTimeout: SQL_TIMEOUT_SEC);
                return conn.Query<T>(commandText, commandParameters, commandType: CommandType.StoredProcedure, commandTimeout: SQL_TIMEOUT_SEC);
            }
        }

        public static int Execute(string connectionString, string commandText, DynamicParameters commandParameters = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute(commandText, commandParameters, commandType: CommandType.StoredProcedure, commandTimeout: SQL_TIMEOUT_SEC);
            }
        }
    }
}

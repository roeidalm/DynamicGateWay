using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace DynamicGateWay.DAL {
    public class DBDal {

        private readonly string _connectionString;
        public DBDal (string connectionString) {
            _connectionString = connectionString;
        }
        public DataTable ExecuteSPAsync (SqlParameter[] paramsData, string SPName) {
            using (SqlConnection connection = new SqlConnection (_connectionString)) {
                try {
                    using (SqlCommand command = new SqlCommand (SPName, connection)) {
                        SqlDataAdapter adapt = new SqlDataAdapter (command);
                        adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapt.SelectCommand.Parameters.AddRange (paramsData);

                        // fill the data table - no need to explicitly call `conn.Open()` - 
                        // the SqlDataAdapter automatically does this (and closes the connection, too)
                        DataTable dt = new DataTable ();
                        adapt.Fill (dt);
                        return dt;
                    }
                } finally {
                    connection.Close ();

                }
            }
        }
    }
}
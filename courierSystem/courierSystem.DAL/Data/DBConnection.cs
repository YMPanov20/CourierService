using Microsoft.Data.SqlClient;
using System;

namespace courierServiceApp.DAL.Data
{
    public class DBConnection
    {
        private static readonly string ConnectionString = @"Server=tcp:courier-system.database.windows.net,1433;Initial Catalog=CourierServiceSystem;Persist Security Info=False;User ID=YMPanov20;Password=Yon10332;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private static SqlConnection _connection;

        public static SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(ConnectionString);
            }

            return _connection;
        }

        public static async Task OpenConnectionAsync(SqlConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening database connection: " + ex.Message);
            }
        }

        public static async Task CloseConnectionAsync(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    await connection.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing database connection: " + ex.Message);
            }
        }
    }

}
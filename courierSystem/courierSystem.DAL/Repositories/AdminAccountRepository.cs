using courierServiceApp.DAL.Data;
using courierSystem.DAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.DAL.Repositories
{
    public class AdminAccountRepository
    {
        private readonly SqlConnection connection;

        // Constructor initializes the connection using the DBConnection class
        public AdminAccountRepository()
        {
            connection = DBConnection.GetConnection();
        }

        // Retrieves an admin account by username asynchronously
        public async Task<AdminAccount> GetAdminAccountByUsernameAsync(string username)
        {
            // Variable to store the retrieved admin account
            AdminAccount adminAccount = null;

            try
            {
                // Open the database connection asynchronously
                await DBConnection.OpenConnectionAsync(connection);

                // Execute SQL command to retrieve admin account by username
                using (SqlCommand command = new SqlCommand("SELECT * FROM AdminAccounts WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    // Execute the SQL command and read the results asynchronously
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Check if there is a record and populate the adminAccount object
                        if (await reader.ReadAsync())
                        {
                            adminAccount = new AdminAccount
                            {
                                UserId = Convert.ToInt32(reader.GetInt32(0)),
                                Username = reader["Username"].ToString(),
                                Password = reader["Pass"].ToString(),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (logging, throwing a custom exception, etc.)
            }
            finally
            {
                // Ensure that the database connection is closed even in case of an exception
                await DBConnection.CloseConnectionAsync(connection);
            }

            // Return the retrieved admin account (null if not found)
            return adminAccount;
        }
    }
}
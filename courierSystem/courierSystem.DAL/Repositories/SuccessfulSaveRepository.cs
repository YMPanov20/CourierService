using courierSystem.DAL.Models;
using courierServiceApp.DAL.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.DAL.Repositories
{
    public class SuccessfulSaveRepository
    {
        private readonly SqlConnection connection;

        // Constructor initializes the connection using the DBConnection class
        public SuccessfulSaveRepository()
        {
            connection = DBConnection.GetConnection();
        }

        // Retrieves the latest tracking ID asynchronously from the Shipments table
        public async Task<string> GetLatestTrackingIdAsync()
        {
            // Variable to store the latest tracking ID
            string latestTrackingId = null;

            try
            {
                // Open the database connection asynchronously
                await DBConnection.OpenConnectionAsync(connection);

                // Execute SQL command to retrieve the top 1 shipment tracking ID from Shipments table
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 S.ShipmentID, S.ShipmentTrackingId FROM Shipments S ORDER BY S.ShipmentID DESC;", connection))
                {
                    // Execute the SQL command and read the results asynchronously
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Check if there is a record and read the tracking ID
                        if (await reader.ReadAsync())
                        {
                            latestTrackingId = reader["ShipmentTrackingId"].ToString();
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

            // Return the latest tracking ID (null if no record found)
            return latestTrackingId;
        }
    }
}
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
    public class ShipmentRepository
    {
        private readonly SqlConnection connection;

        // Constructor initializes the connection using the DBConnection class
        public ShipmentRepository()
        {
            connection = DBConnection.GetConnection();
        }

        // Inserts a shipment record into the Shipments table asynchronously
        public async Task InsertShipmentAsync(Shipments shipment)
        {
            try
            {
                // Open the database connection asynchronously
                await DBConnection.OpenConnectionAsync(connection);

                // Execute SQL command to insert a new shipment into the Shipments table
                using (SqlCommand command = new SqlCommand("INSERT INTO Shipments (ReceiverName, SenderName, ReceiverPhoneNumber, SenderPhoneNumber," +
                    " ShipmentDetails, ShipmentWeight, OfficeID, DestinationOfficeID) VALUES " +
                    "(@ReceiverName, @SenderName, @ReceiverPhoneNumber, @SenderPhoneNumber, @ShipmentDetails, @ShipmentWeight, " +
                    "(SELECT OfficeID FROM Offices WHERE OfficeName = 'Burgas Center 1'), " +
                    "(SELECT OfficeID FROM Offices WHERE OfficeName = @OfficeName));", connection))
                {
                    // Set parameters for the SQL command
                    command.Parameters.AddWithValue("@ReceiverName", shipment.ReceiverName);
                    command.Parameters.AddWithValue("@ReceiverPhoneNumber", shipment.ReceiverPhoneNumber);
                    command.Parameters.AddWithValue("@SenderName", shipment.SenderName);
                    command.Parameters.AddWithValue("@SenderPhoneNumber", shipment.SenderPhoneNumber);
                    command.Parameters.AddWithValue("@ShipmentDetails", shipment.ShipmentDetails);
                    command.Parameters.AddWithValue("@ShipmentWeight", shipment.ShipmentWeight);
                    command.Parameters.AddWithValue("@OfficeName", shipment.OfficeName);

                    // Execute the SQL command to insert the shipment
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (logging, throwing a custom exception, etc.)
                Console.WriteLine("Error inserting shipment: " + ex.Message);
            }
            finally
            {
                // Ensure that the database connection is closed even in case of an exception
                await DBConnection.CloseConnectionAsync(connection);
            }
        }
    }
}
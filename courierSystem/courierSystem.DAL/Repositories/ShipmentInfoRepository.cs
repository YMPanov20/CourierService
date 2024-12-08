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
    public class ShipmentInfoRepository
    {
        private readonly SqlConnection connection;

        // Constructor initializes the connection using the DBConnection class
        public ShipmentInfoRepository()
        {
            connection = DBConnection.GetConnection();
        }

        // Retrieves shipment information by shipment ID asynchronously
        public async Task<ShipmentInfo> GetShipmentInfoByIdAsync(int shipmentId)
        {
            ShipmentInfo shipmentInfo = new ShipmentInfo();

            try
            {
                // Open the database connection asynchronously
                await DBConnection.OpenConnectionAsync(connection);

                // Execute SQL command to retrieve shipment information based on shipment ID
                using (SqlCommand command = new SqlCommand("SELECT S.ShipmentID, S.ReceiverName, S.SenderName, S.ReceiverPhoneNumber, S.SenderPhoneNumber, S.ShipmentDetails, S.ShipmentWeight, S.ShipmentTrackingId, O1.OfficeName AS SourceOfficeName, O2.OfficeName AS DestinationOfficeName FROM Shipments S JOIN Offices O1 ON S.OfficeID = O1.OfficeID JOIN Offices O2 ON S.DestinationOfficeID = O2.OfficeID WHERE S.ShipmentTrackingId = @TrackingId;", connection))
                {
                    command.Parameters.AddWithValue("@TrackingId", shipmentId);

                    // Execute the SQL command and read the results asynchronously
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Check if there is a record and populate the shipmentInfo object
                        if (await reader.ReadAsync())
                        {
                            shipmentInfo = new ShipmentInfo
                            {
                                ShipmentId = Convert.ToInt32(reader["ShipmentID"]),
                                ReceiverName = reader["ReceiverName"].ToString(),
                                SenderName = reader["SenderName"].ToString(),
                                ReceiverPhoneNumber = reader["ReceiverPhoneNumber"].ToString(),
                                SenderPhoneNumber = reader["SenderPhoneNumber"].ToString(),
                                ShipmentDetails = reader["ShipmentDetails"].ToString(),
                                ShipmentWeight = Convert.ToInt32(reader["ShipmentWeight"]),
                                SourceOfficeName = reader["SourceOfficeName"].ToString(),
                                DestinationOfficeName = reader["DestinationOfficeName"].ToString()
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

            // Return the populated shipmentInfo object
            return shipmentInfo;
        }

        // Updates the destination office name for a shipment asynchronously
        public async Task UpdateDestinationOfficeNameAsync(int shipmentTrackingId, string destinationOfficeName)
        {
            try
            {
                // Open the database connection asynchronously
                await DBConnection.OpenConnectionAsync(connection);

                // Execute SQL command to update the destination office name for a shipment
                using (SqlCommand command = new SqlCommand("UPDATE S SET S.DestinationOfficeID = O.OfficeID FROM Shipments S JOIN Offices O ON O.OfficeName = @DestinationOfficeName WHERE S.ShipmentTrackingId = @ShipmentTrackingId", connection))
                {
                    command.Parameters.AddWithValue("@ShipmentTrackingId", shipmentTrackingId);
                    command.Parameters.AddWithValue("@DestinationOfficeName", destinationOfficeName);

                    // Execute the SQL command to update the destination office name
                    await command.ExecuteNonQueryAsync();
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
        }
    }
}
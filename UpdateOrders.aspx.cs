using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class UpdateOrders : System.Web.UI.Page
    {
        // DEPENDENCIES
        string ConnString = @"Data Source=TAHERA\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDb;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;


        int OrderId2;
        int Quantity2;
        string FeedbackLbl;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateOrderBtn_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {

                // Handle potential parsing exceptions
                if (int.TryParse(OrderId2.ToString(), out OrderId2) && int.TryParse(Quantity2.ToString(), out Quantity2))
                {
                    string query = $"UPDATE Orders SET Quantity = @quantity WHERE OrderID = @orderId"; // Corrected table name and query format
                    UpdateOrder(query, OrderId2, Quantity2);
                }
                else
                {
                    FeedbackLbl = "Please enter valid numbers for Order ID and quantity.";
                }
            }
            else
            {
                FeedbackLbl = "Please enter Order ID and quantity.";
            }
        }

        public void UpdateOrder(string query, int orderId, int quantity)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                cmd = new SqlCommand(query, conn);

                // Parameters
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                adapter.UpdateCommand = cmd;

                int countUpdated = adapter.UpdateCommand.ExecuteNonQuery();

                if (countUpdated > 0)
                {
                    FeedbackLbl = $"Successfully updated Order {orderId}";
                }
                else
                {
                    FeedbackLbl = $"Failed to update Order {orderId}";
                }
            }
            catch (SqlException ex)
            {
                FeedbackLbl = $"SQL Error: {ex.Message}";
            }
            catch (Exception e)
            {
                FeedbackLbl = $"Error: {e.Message}";
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean IsValidForm()
        {
            return !string.IsNullOrEmpty(OrderId2.ToString()) && !string.IsNullOrEmpty(Quantity2.ToString());
        }
    }
}
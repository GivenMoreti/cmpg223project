using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class DeleteOrders : System.Web.UI.Page
    {
        int OrderIdTB2;
        string FeedbackLbl;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // DEPENDENCIES
        string ConnString = @"Data Source=TAHERA\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDb;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;

        protected void DeleteOrderBtn_Click(object sender, EventArgs e)
        {
            if (IsValidId())
            {
                int orderId;
                if (int.TryParse(OrderIdTB2.ToString(), out orderId))
                {
                    string query = "Delete from OrdersTable where OrderId=@orderId";
                    DeleteOrder(query, orderId);
                }
                else
                {
                    FeedbackLbl = "Error encountered with Order ID or input field";
                }
            }
            else
            {
                FeedbackLbl = "Order ID field is empty";
            }
        }

        // DELETE ORDER
        public void DeleteOrder(string query, int orderId)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                adapter.DeleteCommand = cmd;

                int countDeleted = adapter.DeleteCommand.ExecuteNonQuery();

                if (countDeleted > 0)
                {
                    FeedbackLbl = $"Successfully deleted Order {orderId}";
                }
                else
                {
                    FeedbackLbl = $"Failed to delete Order {orderId}";
                }
            }
            catch (SqlException ex)
            {
                FeedbackLbl = ex.ToString();
            }
            catch (Exception e)
            {
                FeedbackLbl = e.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        // VALIDATE ORDER ID
        public Boolean IsValidId()
        {
            return !string.IsNullOrEmpty(OrderIdTB2.ToString());
        }
    
    }
}
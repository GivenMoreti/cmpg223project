using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InventoryManagementSystemCMPG223
{
    public partial class CreateOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // DEPENDENCIES
        string ConnString = @"Data Source=TAHERA\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDb;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlCommand cmd;

        protected void CreateOrderBtn_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                int customerId;
                DateTime Calender = OrderDate.SelectedDate;
                DateTime orderDate;
                int quantity;

                if (int.TryParse(CustomerID.Text, out customerId) && 
                    DateTime.TryParse(OrderDate.SelectedDate.ToString(), out orderDate) && int.TryParse(Quantity.Text, out quantity))
                {
                    string query = "Insert into OrdersTable (CustomerID, OrderDate) values (@CustomerId, @OrderDate)";
                    InsertOrder(query, customerId, orderDate,quantity);
                }
                else
                {
                    FeedbackLbl.Text = "Invalid Customer ID or Order Date format. Please enter a number for Customer ID and select a valid date.";
                }
            }
            else
            {
                FeedbackLbl.Text = "Please select a Customer ID and Order Date.";
            }
        }

        // INSERT ORDER
        public void InsertOrder(string query, int customerId, DateTime orderDate, int quantity)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    
                    FeedbackLbl.Text = "Order created successfully!";
                    // Clear form fields (optional)
                    CustomerID.Text = "";
                    orderDate = DateTime.Now;
                }
                else
                {
                    FeedbackLbl.Text = "Failed to create order.";
                }
            }
            catch (SqlException ex)
            {
                FeedbackLbl.Text = $"SQL Error: {ex.Message}";
            }
            catch (Exception e)
            {
                FeedbackLbl.Text = $"Error: {e.Message}";
            }
            finally
            {
                conn.Close();
            }
        }

        // VALIDATE FORM INPUT
        public Boolean IsValidForm()
        {
            return !string.IsNullOrEmpty(CustomerID.Text) && OrderDate.SelectedDate != DateTime.MinValue;
        }
    }
}

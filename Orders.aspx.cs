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
    public partial class Orders : System.Web.UI.Page
    {
        private string _searchTerm; // Member variable to store search term
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOrders();
            }
        }

        string ConnString = @"Data Source=TAHERA\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDb;Integrated Security=True;TrustServerCertificate=True";

        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;

        public void GetOrders(string searchTerm = "")
        {

            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                // Modified query to include search term parameter
                cmd = new SqlCommand("SELECT o.OrderID, c.CustomerName, o.OrderDate, SUM(od.UnitPrice * od.Quantity) AS TotalAmount FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID LEFT JOIN OrderDetails od ON o.OrderID = od.OrderID WHERE (c.CustomerName LIKE '%' + @SearchTerm + '%' OR o.OrderID LIKE '%' + @SearchTerm + '%') GROUP BY o.OrderID, c.CustomerName, o.OrderDate", conn);

                // Add search term parameter
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                OrderGridView2.DataSource = ds.Tables[0];
                OrderGridView2.DataBind();


            }
            catch (SqlException )
            {
                FeedbackLbl2.Text = "An error occurred while retrieving orders. Please try again later.";
            }
            catch (Exception )
            {
                FeedbackLbl2.Text = "An unexpected error occurred.";
            }
            finally
            {
                conn.Close();
            }

        }
        /*protected void SearchBtn_Click(object sender, EventArgs e)
        {
            _searchTerm = SearchItem.Text; // Store search term in member variable
            GetOrders(_searchTerm);
        }*/
    }

}
using iTextSharp.text;
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
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOrderProduct();
            }
        }

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;

        public void GetOrderProduct()
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                cmd = new SqlCommand(@"SELECT OP.OrderId, O.CustomerId, O.OrderDate, P.Id AS ProductId, 
                                            P.ProductName, P.Price, P.ProductDescription, P.ProductSize, OP.Quantity 
                                        FROM  OrderProduct OP 
                                        INNER JOIN  Orders O ON OP.OrderId = O.OrderId 
                                        INNER JOIN Products P ON OP.ProductId = P.Id 
                                        ORDER BY O.OrderDate DESC", conn);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                OrderProductGridView.DataSource = ds;
                OrderProductGridView.DataBind();
            }
            catch (SqlException ex)
            {
                FeedbackLbl.Text = ex.ToString();
            }
            catch (Exception e)
            {
                FeedbackLbl.Text = e.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        // Filter orders by date range
        public void FilterOrders(DateTime startDate, DateTime endDate)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                string query = @"SELECT OP.OrderId, O.CustomerId, O.OrderDate, P.ProductName, P.Price, 
                                    P.ProductDescription, P.ProductSize, OP.Quantity 
                                 FROM OrderProduct OP 
                                 INNER JOIN Orders O ON OP.OrderId = O.OrderId 
                                 INNER JOIN Products P ON OP.ProductId = P.Id 
                                 WHERE O.OrderDate BETWEEN @startDate AND @endDate";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                OrderProductGridView.DataSource = ds;
                OrderProductGridView.DataBind();
            }
            catch (SqlException ex)
            {
                FeedbackLbl.Text = ex.Message;
            }
            catch (Exception e)
            {
                FeedbackLbl.Text = e.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        // Validate selected dates
        public Boolean IsValidDateRange()
        {
            DateTime date1 = Calendar1.SelectedDate;
            DateTime date2 = Calendar2.SelectedDate;

            return date1 <= date2;
        }

        // Search button click handler
        protected void SearchOrders_Click(object sender, EventArgs e)
        {
            if (IsValidDateRange())
            {
                DateTime date1 = Calendar1.SelectedDate;
                DateTime date2 = Calendar2.SelectedDate;
                
                FilterOrders(date1, date2);
                ViewDateLbl.Text = "Viewing orders from " + date1.ToLongDateString() + " to " + date2.ToLongDateString();

            }
            else
            {
                FeedbackLbl.Text = "Invalid date range. Please ensure the start date is earlier than the end date.";
            }
        }
    }
}

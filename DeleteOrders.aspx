<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteOrders.aspx.cs" Inherits="InventoryManagementSystemCMPG223.DeleteOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Orders</title>
     <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="Delete order ">Delete An Order</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                        <asp:TextBox ID="OrderIdTB" runat="server" placeholder="Enter Order ID"></asp:TextBox><br />
                        <asp:Button ID="DeleteOrderBtn" runat="server" Text="Delete Order" OnClick="DeleteOrderBtn_Click" />
                        <br />

                        <asp:Label ID="FeedbackLbl2" runat="server" Text=""></asp:Label><br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>


                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Orders.aspx" runat="server">See Orders</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
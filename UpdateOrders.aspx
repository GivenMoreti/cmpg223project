<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateOrders.aspx.cs" Inherits="InventoryManagementSystemCMPG223.UpdateOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td style="width: 20%;">&nbsp;</td>
                <td id="AddLipstickHeading">Update Order</td>
                <td style="width: 20%;">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 20%;">&nbsp;</td>
                <td class="content">
                     <asp:TextBox ID="OrderId" runat="server" placeholder="Order ID"></asp:TextBox><br />
                     <asp:TextBox ID="Quantity" runat="server" placeholder="Quantity"></asp:TextBox><br />
                    <asp:TextBox ID="ProductId" runat="server" placeholder="item id"></asp:TextBox><br />
                 <asp:Button ID="UpdateOrderBtn" runat="server" Text="Update Order" OnClick="UpdateOrderBtn_Click" /><br />
                    <asp:Label ID="FeedbackLbl1" runat="server" Text=""></asp:Label><br />
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
    </form>
  

</body>
</html>
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateInventory.aspx.cs" Inherits="InventoryManagementSystemCMPG223.CreateInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Inventory</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <div>

     <table style="width: 100%;">
         <tr>
             <td style="width: 20%;">&nbsp;</td>
             
             <td >
                 <h1 id="AddLipstickHeading">Create Inventory Item</h1>    
             </td>

             <td style="width: 20%;">&nbsp;</td>
         </tr>
         <tr>
             <td style="width: 20%;">&nbsp;</td>
             <td class="content">

               
               
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="QuantityInStock" ErrorMessage="*"></asp:RequiredFieldValidator>
                 <asp:TextBox ID="quantityInStock" runat="server" placeholder="Quantity in stock"></asp:TextBox>
                 <br />

                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="SupplierId" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                 <asp:TextBox ID="supplierId" runat="server" placeholder="Supplier Id"></asp:TextBox><br />

                 
                
                 <asp:Button ID="AddInventoryBtn" runat="server" Text="Add Inventory" OnClick="AddInventoryBtn_Click" />
                 <br />
                 <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
             </td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td>&nbsp;</td>
             <td>
                 <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Products.aspx" runat="server">See products</asp:HyperLink>
             </td>
             <td>&nbsp;</td>
         </tr>
     </table>
 </div>
    </form>
</body>
</html>

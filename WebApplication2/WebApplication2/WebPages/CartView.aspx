﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="MobilePhoneRetailer.WebPages.CartView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Button ID="Button9" runat="server" Text="Login" PostBackUrl="~/WebPages/HomePage.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button10" runat="server" Text="Register" PostBackUrl="~/WebPages/Register User.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button11" runat="server" Text="Cart" PostBackUrl="~/WebPages/CartView.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button12" runat="server" Text="View Catalogue" PostBackUrl="~/WebPages/CatalogueView.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button13" runat="server" Text="New Order" PostBackUrl="~/WebPages/Order.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button14" runat="server" Text="View All Orders" PostBackUrl="~/WebPages/OrderView.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button15" runat="server" Text="Add New Product" PostBackUrl="~/WebPages/Product.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button16" runat="server" Text="Add Supplier" PostBackUrl="~/WebPages/Supplier.aspx"  CausesValidation="False"/>
            <asp:Button ID="Button17" runat="server" Text="View Suppliers" PostBackUrl="~/WebPages/SupplierView.aspx"  CausesValidation="False"/>
            <br />
            <br />
            <br />
        <h2>Cart</h2>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            

            <br />
    


        <asp:Label ID="lblTotal" runat="server" ></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button18" runat="server" Text="Empty Cart" OnClick="EmptyCart_Click"/>
        <br />
        
    
    </div>
    </form>
</body>
</html>

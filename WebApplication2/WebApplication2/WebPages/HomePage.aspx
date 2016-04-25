<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication2.WebPages.HomePage" %>

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
    <h2>Login</h2>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
             <p style="margin-left: 120px">
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Login" />
        </p>
             <p style="margin-left: 120px">
            <asp:Label ID="loginSuccess" runat="server"></asp:Label>
                 &nbsp;</p>

    </div>
    </form>
</body>
</html>
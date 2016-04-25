<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register User.aspx.cs" Inherits="MobilePhoneRetailer.WebPages.Register_User" %>

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
    <h2>Register</h2>
        <br />
        <asp:Label ID="Email" runat="server" Text="Email: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="EmailBox" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Password" runat="server" Text="Password: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Name" runat="server" Text="Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Address" runat="server" Text="Address:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="AddressBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="PhoneNum" runat="server" Text="Phone Number: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="PhoneNumBox" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Register" />
    
    </div>
    </form>
</body>
</html>

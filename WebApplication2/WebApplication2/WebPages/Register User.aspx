<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register User.aspx.cs" Inherits="WebApplication2.WebPages.Register_User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Email" runat="server" Text="Email: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Password" runat="server" Text="Password: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Name" runat="server" Text="Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Address" runat="server" Text="Address:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="AddressBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="PhoneNum" runat="server" Text="Phone Number: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="PhoneNumBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" />
    
    </div>
    </form>
</body>
</html>

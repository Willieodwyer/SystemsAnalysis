<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication2.WebPages.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Login page:</h1>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p style="margin-left: 160px">
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Login" />
        </p>
        <p style="margin-left: 160px">
            <asp:Label ID="loginSuccess" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 160px">&nbsp;</p>

    </div>
    </form>
</body>
</html>
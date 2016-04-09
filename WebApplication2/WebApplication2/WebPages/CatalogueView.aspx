<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogueView.aspx.cs" Inherits="WebApplication2.CatalogueView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblSearch" runat="server" Text="Search" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server" Width="170px" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
        <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="WebApplication2.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Type" DataValueField="ProductID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ProductID], [Type] FROM [Products]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="QuantityLabel" runat="server" Text="Quantity"></asp:Label>
        <br />
        <asp:TextBox ID="QuantityBox" runat="server"></asp:TextBox>
        <br />
        <br />
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Stock" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update Stock" />
    
    </div>
    </form>
</body>
</html>

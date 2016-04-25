<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="MobilePhoneRetailer.Business_Layer.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Text="Select the Order category"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Gold</asp:ListItem>
            <asp:ListItem>Silver</asp:ListItem>
            <asp:ListItem Selected="True">Standard</asp:ListItem>
        </asp:RadioButtonList>
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="Select your order number:"></asp:Label>
        <br />
        <asp:DropDownList ID="OrderDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="OrderID" DataValueField="OrderID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ProductID], [Amount], [OrderID] FROM [Order]"></asp:SqlDataSource>
        <br />
        <br />
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Invoice" />
    
    </div>
    </form>
</body>
</html>

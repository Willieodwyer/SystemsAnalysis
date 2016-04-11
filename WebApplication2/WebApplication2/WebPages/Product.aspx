<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WebApplication2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="ManufacturerLabel" runat="server" Text="Manufacturer"></asp:Label>
        <br />
        <asp:TextBox ID="ManufacturerBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="PriceLabel" runat="server" Text="Price"></asp:Label>
        <br />
        <asp:TextBox ID="PriceBox" runat="server"></asp:TextBox>
        <br />
        <br />
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Product" />
        <br />
        <br />
        <asp:DropDownList ID="TypeDropDown" runat="server" DataSourceID="SqlDataSource1" DataTextField="Type" DataValueField="Type">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Type] FROM [Products]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="EditManufacturerLabel" runat="server" Text="Manufacturer"></asp:Label>
        <br />
        <asp:TextBox ID="EditManufacturer" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="EditNameLabel" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="EditName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="EditPriceLabel" runat="server" Text="Edit Price"></asp:Label>
        <br />
        <asp:TextBox ID="EditPrice" runat="server" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Edit Product" />
    
    </div>
    </form>
</body>
</html>

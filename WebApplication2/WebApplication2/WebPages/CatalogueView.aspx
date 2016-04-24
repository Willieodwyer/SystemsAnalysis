<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogueView.aspx.cs" Inherits="WebApplication2.WebPages.CatalogueView" %>

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

        <h2>Catalogue</h2>
        <asp:Label ID="lblSearch" runat="server" Text="Search" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server" Width="170px" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
            <br />
            <br />
        <asp:Label ID="lblEuro" runat="server" Text="Note: All prices in Euro(€)" Font-Bold="true" Font-Size="Medium"></asp:Label>
        <asp:GridView ID="GridView2" runat="server"></asp:GridView>


            <br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1"
                onrowcommand="GridView3_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
                    <asp:TemplateField HeaderText="Add To Cart">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAddToCart" runat="server" CommandName="AddToCart"
                            Text="Add To Cart"/>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Price], [Type], [ProductID] FROM [Products]"></asp:SqlDataSource>


            <asp:Label ID="lblAddToCart" runat="server" ></asp:Label>


    </div>
    </form>
</body>
</html>

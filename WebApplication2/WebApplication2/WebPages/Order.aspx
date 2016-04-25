<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="MobilePhoneRetailer.WebPages.Order1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Order</title>
</head>
<body style="height: 200px">
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

            <h2>Create Order</h2>
            <asp:Label ID="Label1"
                runat="server"
                Width="120px"
                Height="20px">Select Product:</asp:Label>&nbsp;
    <asp:DropDownList ID="lstProducts"
        runat="server"
        Width="256px"
        Height="22px"
        AutoPostBack="True"
        OnSelectedIndexChanged="lstProducts_SelectedIndexChanged">
    </asp:DropDownList>
            <br />
            <br />

            <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" Width="170px" OnTextChanged="txtAddress_TextChanged"> </asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblQuantity" runat="server" Text="Quantity" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" Width="170px" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
            <asp:RangeValidator
                ID="RangeValidator1"
                runat="server"
                ErrorMessage="Must be between 1 and 100"
                ControlToValidate="txtQuantity"
                MaximumValue="100"
                MinimumValue="1"
                Type="Integer">
            </asp:RangeValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please enter a quantity!!" />
            <br />
            <br />

            <asp:Label ID="lblPrice" runat="server" Text="Price" Font-Bold="True" Width="170px" Font-Size="Medium"></asp:Label>
            &nbsp;<asp:TextBox ID="txtPrice" runat="server" Width="170px" Enabled="False"></asp:TextBox><asp:RangeValidator
                ID="RangeValidator2"
                runat="server"
                ErrorMessage="Must be between 1 and 10000"
                ControlToValidate="txtPrice"
                MaximumValue="10000"
                MinimumValue="1"
                Type="Double"></asp:RangeValidator>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnOrder" runat="server" Font-Bold="True" Text="New Order" OnClick="btnOrder_Click" />
            <asp:Button ID="btnAddOrder" runat="server" Font-Bold="True" Text="Add to Order" OnClick="btnAddProduct_Click" Enabled="False" />
            <asp:Button ID="btnViewOrder" runat="server" Font-Bold="True" Text="View Order" OnClick="btnViewOrder_Click" Enabled="False" />
            <br />
            <br />
            <br />
            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            <br />


        </div>
    </form>
</body>
</html>

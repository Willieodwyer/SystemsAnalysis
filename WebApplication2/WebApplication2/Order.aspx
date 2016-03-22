<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebApplication2.Order1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
</head>
<body style="height: 200px">
    <form id="form1" runat="server">
        <div>

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
                MaximumValue="100"
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
            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebApplication2.Order1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
</head>
<body style="height: 200px">
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblProduct" runat="server" Text="Product" Font-Bold="True" Width="170px" Font-Size="Medium"></asp:Label>
            &nbsp;<asp:TextBox ID="txtProduct" runat="server" Width="170px" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtProduct"
                ErrorMessage="Product is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
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
            <br />
            <br />

            <asp:Label ID="lblPrice" runat="server" Text="Price" Font-Bold="True" Width="170px" Font-Size="Medium"></asp:Label>
            &nbsp;<asp:TextBox ID="txtPrice" runat="server" Width="170px">
            </asp:TextBox><asp:RangeValidator
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
        <asp:Button ID="btnOrder" runat="server" Font-Bold="True" Text="ORDER" OnClick="btnOrder_Click" />
            <br />
            <br />
            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>

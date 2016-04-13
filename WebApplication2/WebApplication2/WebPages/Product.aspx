<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WebApplication2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblNotes0" runat="server" Font-Bold="True" Font-Size="Medium" Text="Select a Supplier to edit otherwise enter details for new supplier below." Width="170px"></asp:Label>
            <asp:DropDownList ID="lstProducts"
                runat="server"
                Width="256px"
                Height="22px"
                AutoPostBack="True"
                OnSelectedIndexChanged="lstProducts_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />

            <asp:Label ID="lblPrice" runat="server" Text="Price" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" Width="170px" OnTextChanged="txtPrice_TextChanged"></asp:TextBox>
            <asp:RangeValidator
                ID="RangeValidator2"
                runat="server"
                ErrorMessage="Please enter a price!!"
                ControlToValidate="txtPrice"
                MaximumValue="9999"
                MinimumValue="1"
                Type="Double">
            </asp:RangeValidator>
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtPrice" errormessage="Please enter a Price!" />
            <br />
            <br />
            
            <asp:Label ID="lblType" runat="server" Text="Type" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtType" runat="server" Width="170px" OnTextChanged="txtType_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtType" errormessage="Please enter a Type!" />
            <br />
            <br />

            <asp:Label ID="lblSupplier" runat="server" Text="Supplier" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="txtSupplier" runat="server" Width="170px" OnTextChanged="txtSupplier_TextChanged"></asp:TextBox>
                <asp:RangeValidator
                    ID="RangeValidator1"
                    runat="server"
                    ErrorMessage="Please enter a supplier!!"
                    ControlToValidate="txtSupplier"
                    MaximumValue="9999"
                    MinimumValue="1"
                    Type="Double">
                </asp:RangeValidator>
            <br />
            <br />


            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNewProduct" runat="server" Font-Bold="True" Text="New Product" OnClick="btnNewProduct_Click" />
            <asp:Button ID="btnEditProduct" runat="server" Font-Bold="True" Text="Edit Product" OnClick="btnEditProduct_Click" Enabled="False" />
            <asp:Button ID="btnViewProducts" runat="server" Font-Bold="True" Text="View Products" OnClick="btnViewProducts_Click" Enabled="True" CausesValidation="False" />
            <asp:Button ID="btnDeleteProduct" runat="server" Font-Bold="True" Text="Delete Selected Product" OnClick="btnDeleteProduct_Click" Enabled="false"/>

            <br />
            <br />
            <br />
    </div>
    </form>
</body>
</html>

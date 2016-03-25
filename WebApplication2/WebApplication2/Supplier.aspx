<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNotes0" runat="server" Font-Bold="True" Font-Size="Medium" Text="Select a Supplier to edit otherwise enter details for new supplier below." Width="170px"></asp:Label>
            <asp:DropDownList ID="lstSuppliers"
                runat="server"
                Width="256px"
                Height="22px"
                AutoPostBack="True"
                OnSelectedIndexChanged="lstProducts_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />

            <asp:Label ID="lblName" runat="server" Text="Name" Font-Bold="True" Width="173px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="170px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Please enter a Name!!" />
            <br />
            <br />

            <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="True" Width="170px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" Width="170px" Enabled="True"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Please enter an address!!" />
            <br />
            <br />

            <asp:Label ID="lblPhoneNum" runat="server" Text="PhoneNumber" Font-Bold="True" Width="170px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtPhoneNum" runat="server" Width="170px" Enabled="True"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Please enter a phone number!!" />
            <asp:RangeValidator
                ID="RangeValidator1"
                runat="server"
                ErrorMessage="Please enter a valid phone number!!"
                ControlToValidate="txtPhoneNum"
                MaximumValue="9999999999"
                MinimumValue="0"
                Type="Double">
            </asp:RangeValidator>
            <br />
            <br />
            <asp:Label ID="lblNotes" runat="server" Text="Notes (If any)" Font-Bold="True" Width="170px" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtNotes" runat="server" Width="167px" Enabled="True" Height="88px"></asp:TextBox>





            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNewSupplier" runat="server" Font-Bold="True" Text="New Supplier" OnClick="btnSupplier_Click" />
            <asp:Button ID="btnEditSupplier" runat="server" Font-Bold="True" Text="EditSupplier" OnClick="btnEditSupplier_Click" Enabled="False" />
            <asp:Button ID="btnViewSuppler" runat="server" Font-Bold="True" Text="View Suppliers" OnClick="btnViewSuppliers_Click" Enabled="True" CausesValidation="False" />
            <asp:Button ID="btnDeleteSupplier" runat="server" Font-Bold="True" Text="Delete Selected Supplier" OnClick="btnDeleteSupplier_Click" Enabled="false" CausesValidation="False" />

            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

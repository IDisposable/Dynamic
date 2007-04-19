<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="DynamicSampleWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="TestForm" runat="server">
        <div>
            <label for="FirstName">
                First Name:</label>
            <input id="FirstName" runat="server" type="text" />
            <br />
            <label for="LastName">
                Last Name:</label>
            <input id="LastName" runat="server" type="text" />
            <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastName"
                ErrorMessage="Last Name must be specified"></asp:RequiredFieldValidator><br />
        </div>
        <asp:ValidationSummary ID="Errors" runat="server" />
        <asp:Button ID="Submit" runat="server" Text="Submit" />
    </form>
</body>
</html>

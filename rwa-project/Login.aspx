<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="rwa_project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body style="height: 100vh; display: flex; justify-content: center; align-items: center; flex-direction:column; gap: 1.5em">
    <h1>Welcome to RWA Application Admin</h1>
    <form id="LoginForm" runat="server">
        <div class="form-group">
            <label for="exampleInputEmail1">Username</label>
            <asp:TextBox ID="txtUserName" CssClass="forom-control" runat="server" autocomplete="off"></asp:TextBox>
          </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Password</label>
            <asp:TextBox ID="txtPassword" CssClass="forom-control" TextMode="Password"  runat="server"></asp:TextBox>
        </div>         
        <asp:Button ID="LoginButton" OnClick="LoginButton_Click" runat="server" CssClass="btn btn-primary" Text="Login" UseSubmitBehavior="true" Width="100%"  />
    </form>
    <asp:Panel ID="PanelError" runat="server">
        <div class='alert alert-danger' role='alert'>
              Krivi Username ili Password.
        </div>
    </asp:Panel>
</body>
</html>

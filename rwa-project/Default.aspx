<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="rwa_project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4 text-center">
            <h2>Welcome :)</h2>
            <p>
                Welcome to RWA Application ADMIN Site.
                Use navigation bar to navigate around admin content
            </p>           
        </div>
        <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>        
    </div>

</asp:Content>

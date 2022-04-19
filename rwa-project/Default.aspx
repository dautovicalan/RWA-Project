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
    <div class="d-flex">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>City</th>
                    <th>Adults</th>
                    <th>Children</th>
                    <th>Rooms</th>
                    <th>Pictures</th>
                    <th>Price</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var apartment in Apartments) { %>
                    <tr>
                        <td><%= apartment.Name %></td>
                        <td><%= apartment.CityId %></td>
                        <td><%= apartment.Name %></td>
                        <td><%= apartment.Name %></td>
                        <td><%= apartment.Name %></td>
                        <td><%= apartment.Name %></td>
                        <td><%= apartment.Name %></td>
                        <td><button>Open</button></td>
                    </tr>
                <% } %>
            </tbody>
        </table>      
    </div>

</asp:Content>

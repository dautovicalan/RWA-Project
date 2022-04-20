<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Apartmens.aspx.cs" Inherits="rwa_project.Apartmens" %>
<asp:Content ID="ApartmensPage" ContentPlaceHolderID="MainContent" runat="server">
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
                        <td><a href="https://www.google.com">Open</a></td>
                    </tr>
                <% } %>
            </tbody>
        </table>      
    </div>
</asp:Content>

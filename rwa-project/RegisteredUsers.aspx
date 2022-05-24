<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisteredUsers.aspx.cs" Inherits="rwa_project.RegisterUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex flex-column">
        <h2 class="text-center">Registered Users</h2>
        <table class="table table-striped" id="myTable">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Guid</th>
                    <th>Username</th>
                    <th>Email</th>
                    <th>Address</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var user in ListOfUsers) { %>
                    <tr>
                        <td><%= user.Id %></td>
                        <td><%= user.Guid %></td>
                        <td><%= user.UserName %></td>
                        <td><%= user.Email %></td>
                        <td><%= user.Address %></td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</asp:Content>

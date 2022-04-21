<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Apartmens.aspx.cs" Inherits="rwa_project.Apartmens" %>

<asp:Content ID="ApartmensPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-flex flex-column">
            <div>
                <label for="StatusDropDownList">Status</label>
                <asp:DropDownList ID="StatusDropDownList" runat="server">
                    <asp:ListItem>
                        Occupied
                    </asp:ListItem>
                    <asp:ListItem>
                        Reserved
                    </asp:ListItem>
                    <asp:ListItem>
                        Vacant
                    </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label for="CityDropDownList">City</label>
                <asp:DropDownList ID="CityDropDownList" runat="server">
                    <asp:ListItem>
                        Test
                    </asp:ListItem>
                    <asp:ListItem>
                        Zagreb
                    </asp:ListItem>
                    <asp:ListItem>
                        Idiot
                    </asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <label for="SortByDropDownList">Sort by</label>
            <asp:DropDownList ID="SortByDropDownList" runat="server">
                <asp:ListItem>
                        Osoba
                </asp:ListItem>
                <asp:ListItem>
                        Mjesto
                </asp:ListItem>
                <asp:ListItem>
                        Cijena
                </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="d-flex flex-column">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Id</th>
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
                <% foreach (var apartment in Apartments)
                    { %>
                <tr>
                    <td><%= apartment.Id %></td>
                    <td><%= apartment.Name %></td>
                    <td><%= apartment.CityName %></td>
                    <td><%= apartment.MaxAdults %></td>
                    <td><%= apartment.MaxChildren %></td>
                    <td><%= apartment.TotalRooms %></td>
                    <td><%= apartment.PictureCount %></td>
                    <td><%= apartment.Price %> €</td>
                    <td><a href="https://www.google.com">Open</a></td>
                </tr>
                <% } %>
            </tbody>
        </table>
        <asp:Button ID="AddNewApartment" runat="server" Text="Add" OnClick="AddNewApartment_Click"/>
    </div>
</asp:Content>

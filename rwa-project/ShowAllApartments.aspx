<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowAllApartments.aspx.cs" Inherits="rwa_project.Apartmens" %>

<asp:Content ID="ApartmensPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-flex flex-column">
            <div>
                <label for="StatusDropDownList">Status</label>
                <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="StatusBound" DataTextField="NameEng" DataValueField="Id" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">                                        
                </asp:DropDownList>
                <asp:SqlDataSource ID="StatusBound" runat="server" ConnectionString="<%$ ConnectionStrings:RwaApartmaniConnectionString %>" SelectCommand="GetApartmentStatuses" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
            <div>
                <label for="CityDropDownList">City</label>
                <asp:DropDownList ID="ddlCity" runat="server" DataSourceID="CityBound" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:SqlDataSource ID="CityBound" runat="server" ConnectionString="<%$ ConnectionStrings:RwaApartmaniConnectionString %>" SelectCommand="GetCitys" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </div>
        <div>
            <label for="SortByDropDownList">Sort by<label for="SortByDropDownList">Sort by</label>
            <asp:DropDownList ID="ddlSortType" runat="server">
                <asp:ListItem Value="0">
                        Max person number
                </asp:ListItem>
                <asp:ListItem Value="1">
                        Rooms number
                </asp:ListItem>
                <asp:ListItem Value="2">
                        Price
                </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <label>ASC</label>
            <asp:RadioButton ID="rbAsc" Checked="true" runat="server" GroupName="SortingWay" />
            <label>DESC</label>
            <asp:RadioButton ID="rbDesc" runat="server" GroupName="SortingWay" />
        </div>        
        <asp:Button ID="btnSort" runat="server" Text="Sort" OnClick="btnSort_Click"/>

    </div>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped">
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>City Name</th>
                    <th>Max adults</th>
                    <th>Max Children</th>
                    <th>Total rooms</th>
                    <th>Picture numbers</th>
                    <th>Price</th>
                    <th>Beach distance</th>
                    <th>Status Name</th>
                    <th>Action</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("Id") %></td>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("CityName") %></td>
                <td><%# Eval("MaxAdults") %></td>
                <td><%# Eval("MaxChildren") %></td>
                <td><%# Eval("TotalRooms") %></td>
                <td><%# Eval("PictureCount") %></td>
                <td><%# Eval("Price") %></td>
                <td><%# Eval("BeachDistance") %></td>
                <td><%# Eval("StatusName") %></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Open" CommandName="Open" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="btnAddApartment" runat="server" Text="Add new Apartment" OnClick="btnAddApartment_Click"/>
    <asp:Panel ID="EditApartmentPanel" runat="server" Visible="false">
        <h3>Edit Selected Apartment</h3>
        <asp:Label ID="ApartmentId" runat="server" Text="Label"></asp:Label>
        <div class="form-group">
            <label>Broj soba</label>
            <asp:TextBox ID="txbRoomNumber" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Broj mjesta za odrasle</label>
            <asp:TextBox ID="txbAdultsNumber" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Broj mjesta za djecu</label>
            <asp:TextBox ID="txbChildrenNumber" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Udaljenost od mora</label>
            <asp:TextBox ID="txbBeachDistance" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Status apartmana</label>
            <asp:DropDownList ID="ddlApartmentStatuses" runat="server">

                <asp:ListItem Value="1">Occupied</asp:ListItem>
                <asp:ListItem Value="2">Reserved</asp:ListItem>
                <asp:ListItem Value="3">Vacant</asp:ListItem>

            </asp:DropDownList>
        </div>             
        <asp:Button ID="EditButton" runat="server" Text="Edit Selected Apartment" OnClick="EditButton_Click" />
        <asp:Button ID="DeleteButton" runat="server" Text="Delete Selected Apartment" OnClick="DeleteButton_Click" />
    </asp:Panel>    
    <asp:SqlDataSource ID="SqlApartments" runat="server" ConnectionString="<%$ ConnectionStrings:RwaApartmaniConnectionString %>" SelectCommand="GetApartments" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>

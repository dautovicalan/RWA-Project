<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowAllApartments.aspx.cs" Inherits="rwa_project.Apartmens" %>

<asp:Content ID="ApartmensPage" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* The Modal (background) */
        .modal {
            display: block;
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
        }

    </style>
    <div class="row">
        <div class="d-flex flex-column">
            <div>
                <label for="StatusDropDownList">Status</label>
                <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                     <asp:ListItem Value="99">Nebitno</asp:ListItem>
                    <asp:ListItem Value="1">Zauzeto</asp:ListItem>
                    <asp:ListItem Value="2">Rezervirano</asp:ListItem>
                    <asp:ListItem Value="3">Slobodno</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="StatusBound" runat="server" ConnectionString="<%$ ConnectionStrings:ApartmentDatabase %>" SelectCommand="GetApartmentStatuses" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
            <div>
                <label for="CityDropDownList">City</label>
                <asp:DropDownList ID="ddlCity" runat="server" DataSourceID="CityBound" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:SqlDataSource ID="CityBound" runat="server" ConnectionString="<%$ ConnectionStrings:ApartmentDatabase %>" SelectCommand="GetCitys" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </div>
        <div>
            <label for="SortByDropDownList">Sort by</label>
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
            <table class="table table-striped" id="myTable">
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
            <asp:TextBox ID="txbRoomNumber" runat="server" TextMode="Number" min="0"></asp:TextBox>
            <asp:RangeValidator ControlToValidate="txbRoomNumber" MinimumValue="0" MaximumValue="99" ID="RangeValidator1" runat="server" ErrorMessage="Min number is 0"></asp:RangeValidator>
        </div>
        <div class="form-group">
            <label>Broj mjesta za odrasle</label>
            <asp:TextBox ID="txbAdultsNumber" runat="server" TextMode="Number" min="0"></asp:TextBox>
            <asp:RangeValidator ControlToValidate="txbAdultsNumber" MinimumValue="0" MaximumValue="99" ID="RangeValidator2" runat="server" ErrorMessage="Min number is 0"></asp:RangeValidator>
        </div>
        <div class="form-group">
            <label>Broj mjesta za djecu</label>
            <asp:TextBox ID="txbChildrenNumber" runat="server" TextMode="Number" min="0"></asp:TextBox>
            <asp:RangeValidator ControlToValidate="txbChildrenNumber" MinimumValue="0" MaximumValue="99" ID="RangeValidator3" runat="server" ErrorMessage="Min number is 0"></asp:RangeValidator>
        </div>
        <div class="form-group">
            <label>Udaljenost od mora</label>
            <asp:TextBox ID="txbBeachDistance" runat="server" TextMode="Number" min="0"></asp:TextBox>
            <asp:RangeValidator ControlToValidate="txbBeachDistance" MinimumValue="0" MaximumValue="9999" ID="RangeValidator4" runat="server" ErrorMessage="Min number is 0"></asp:RangeValidator>
        </div>
        <div class="form-group">
            <label>Status apartmana</label>
            <asp:DropDownList ID="ddlApartmentStatuses" runat="server">

                <asp:ListItem Value="1">Occupied</asp:ListItem>
                <asp:ListItem Value="2">Reserved</asp:ListItem>
                <asp:ListItem Value="3">Vacant</asp:ListItem>

            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Current Apartment Tags</label>
            <asp:DropDownList ID="ddlApartmentTags" runat="server"></asp:DropDownList>
            <asp:Button ID="removeTagFromApartmentButton" runat="server" Text="Remove Selected Tag from Apartment tags" OnClick="removeTagFromApartmentButton_Click"/>
            <label>Other available Tags</label>
            <asp:DropDownList ID="ddlAllOtherTags" runat="server"></asp:DropDownList>
            <asp:Button ID="addOtherTagToApartment" runat="server" Text="Add Selected Tag to Apartment tags" OnClick="addOtherTagToApartment_Click"/>
        </div>
        <asp:Button ID="EditButton" runat="server" Text="Edit Selected Apartment" OnClick="EditButton_Click" />
        <asp:Button ID="DeleteButton" runat="server" Text="Delete Selected Apartment" OnClick="DeleteButton_Click" />
        <asp:Repeater ID="imgRepeater" runat="server" OnItemCommand="imgRepeater_ItemCommand">
            <ItemTemplate>
                <div>
                    <asp:Image ID="imgApartment" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[]) Eval("ImageData")) %>' runat="server" Height="100" Width="100" />
                    <asp:Button ID="removeImageButton" CommandArgument='<%# Eval("Id") %>' CommandName="Delete" runat="server" Text="Delete" />
                    <asp:Button ID="setRepImageButton" CommandArgument='<%# Eval("Id") %>' CommandName="SetMain" runat="server" Text="Set as Main" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>    
    <asp:SqlDataSource ID="SqlApartments" runat="server" ConnectionString="<%$ ConnectionStrings:ApartmentDatabase %>" SelectCommand="GetApartments" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:Panel ID="pnlModal" runat="server" Visible="false">
        <div class="modal">
            <div class="modal-content">
                <h1>Are you sure you want to delete this apartment?</h1>
                <div class="form-group">
                    <asp:Button ID="btnDeleteConfirm" runat="server" Text="Yes" OnClick="btnDeleteConfirm_Click"/>
                    <asp:Button ID="btnDeleteCancel" runat="server" Text="No" OnClick="btnDeleteCancel_Click"/>
                </div>
            </div>
        </div>        
    </asp:Panel>
</asp:Content>

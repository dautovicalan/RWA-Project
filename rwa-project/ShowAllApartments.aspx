<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowAllApartments.aspx.cs" Inherits="rwa_project.Apartmens" %>

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
    <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlApartments" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="CityName" HeaderText="CityName" SortExpression="CityName" />
            <asp:BoundField DataField="MaxAdults" HeaderText="MaxAdults" SortExpression="MaxAdults" />
            <asp:BoundField DataField="MaxChildren" HeaderText="MaxChildren" SortExpression="MaxChildren" />
            <asp:BoundField DataField="TotalRooms" HeaderText="TotalRooms" SortExpression="TotalRooms" />
            <asp:BoundField DataField="PictureNumber" HeaderText="PictureNumber" ReadOnly="True" SortExpression="PictureNumber" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="BeachDistance" HeaderText="BeachDistance" SortExpression="BeachDistance" />            
            <asp:BoundField DataField="NameEng" HeaderText="Status" SortExpression="NameEng" />
            <asp:CommandField ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
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

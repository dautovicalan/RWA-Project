<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowAllReservations.aspx.cs" Inherits="rwa_project.ShowAllReservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" CssClass="table table-striped myTable" runat="server" AutoGenerateColumns="False" DataSourceID="Reservations">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="CreatedAt" HeaderText="CreatedAt" SortExpression="CreatedAt" />
            <asp:BoundField DataField="ApartmentId" HeaderText="ApartmentId" InsertVisible="False" ReadOnly="True" SortExpression="ApartmentId" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" SortExpression="UserEmail" />
            <asp:BoundField DataField="UserPhone" HeaderText="UserPhone" SortExpression="UserPhone" />
            <asp:BoundField DataField="UserAddress" HeaderText="UserAddress" SortExpression="UserAddress" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="Reservations" runat="server" ConnectionString="<%$ ConnectionStrings:ApartmentDatabase %>" SelectCommand="GetApartmentReservations" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <div class="form-group">
        <label>Select apartment</label>
        <asp:DropDownList ID="ddlApartments" runat="server" DataSourceID="Apartments" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
        <asp:SqlDataSource ID="Apartments" runat="server" ConnectionString="<%$ ConnectionStrings:ApartmentDatabase %>" SelectCommand="GetApartments" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </div>
    <div class="form-group">
        <label>Enter details</label>
        <asp:TextBox ID="tbDetails" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="tbDetails" runat="server" ErrorMessage="* Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="cbIsNotRegisteredUser" runat="server" OnCheckedChanged="cbIsNotRegisteredUser_CheckedChanged" AutoPostBack="true"/>
        <label for="cbIsNotRegisteredUser">Rezervacija za ne registrirane korisnike</label>
    </div>  
    <asp:Panel ID="pnlRegisteredUsers" runat="server" Visible="true">
            <div class="form-group">
            <label>Registrirani korisnici</label>
            <asp:DropDownList ID="ddlRegisteredUsers" runat="server" DataSourceID="RegisteredUsers" DataTextField="UserName" DataValueField="Id"></asp:DropDownList>
            <asp:SqlDataSource ID="RegisteredUsers" runat="server" ConnectionString="<%$ ConnectionStrings:ApartmentDatabase %>" SelectCommand="GetAspNetUsers" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
        </asp:Panel>                
        <asp:Panel ID="pnlNotRegisteredUser" runat="server" Visible="false">
            <div class="form-group">
                <label>Ime Korisnika</label>
                <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="tbUserName" runat="server" ErrorMessage="* Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Email Korisnika</label>
                <asp:TextBox ID="tbUserEmail" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbUserEmail" runat="server" ErrorMessage="* Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Telefon Korisnika</label>
                <asp:TextBox ID="tbUserPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbUserPhone" runat="server" ErrorMessage="* Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Adresa Korisnika</label>
                <asp:TextBox ID="tbUserAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbUserAddress" runat="server" ErrorMessage="* Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </asp:Panel>
    <asp:Button ID="AddReservationButton" runat="server" Text="Add Reservation" OnClick="AddReservationButton_Click"/>
</asp:Content>

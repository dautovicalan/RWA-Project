﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddApartment.aspx.cs" Inherits="rwa_project.AddApartment" %>

<asp:Content ID="AddApartmentSite" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="OwnersDropDown">Select owner:</label>
        <asp:DropDownList ID="OwnersDropDown" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ControlToValidate="OwnersDropDown" ID="ValidatorTagName" ForeColor="Red" runat="server" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="StatusDropDown">Status:</label>
        <asp:DropDownList ID="StatusDropDown" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ControlToValidate="StatusDropDown" ID="ValidatorTagEnglishName" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="CityDropDown">City:</label>
        <asp:DropDownList ID="CityDropDown" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ControlToValidate="CityDropDown" ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="AddressTextBox">Address:</label>
        <asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="AddressTextBox" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="NameTextBox">Apartment Name:</label>
        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="NameTextBox" ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="NameEngTextBox">Apartment Name (ENG):</label>
        <asp:TextBox ID="NameEngTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="NameEngTextBox" ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="PriceTextBox">Price:</label>
        <asp:TextBox ID="PriceTextBox" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="PriceTextBox" ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="maxAdultsSpinner">Max Adults:</label>        
        <asp:TextBox ID="maxAdultsSpinner" runat="server" type="number" />
        <asp:RequiredFieldValidator ControlToValidate="maxAdultsSpinner" ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="maxChildrenSpinner">Max Children:</label>
        <asp:TextBox ID="maxChildrenSpinner" runat="server" type="number" />
        <asp:RequiredFieldValidator ControlToValidate="maxChildrenSpinner" ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="totalRoomsSpinner">Total rooms:</label>
        <asp:TextBox ID="totalRoomsSpinner" runat="server" type="number" />
        <asp:RequiredFieldValidator ControlToValidate="totalRoomsSpinner" ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="beachDistanceSpinner">Total rooms:</label>
        <asp:TextBox ID="beachDistanceSpinner" runat="server" type="number" />               
        <asp:RequiredFieldValidator ControlToValidate="beachDistanceSpinner" ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <asp:Button ID="SubmitButton" UseSubmitBehavior="true" CssClass="btn btn-primary" runat="server" Text="Add new Apartment" OnClick="SubmitButton_Click" />
</asp:Content>
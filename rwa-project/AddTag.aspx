<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTag.aspx.cs" Inherits="rwa_project.AddTag" %>

<asp:Content ID="AddTagForm" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <label for="TagName">Tag name:</label>
        <asp:TextBox ID="TagName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="TagName" ID="ValidatorTagName" ForeColor="Red" runat="server" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="TagEnglishName">Enter tag english name:</label>
        <asp:TextBox ID="TagEnglishName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="TagEnglishName" ID="ValidatorTagEnglishName" runat="server" ForeColor="Red" ErrorMessage="* Please fill this form"></asp:RequiredFieldValidator>
    </div>
    <asp:Button ID="SubmitButton" UseSubmitBehavior="true" CssClass="btn btn-primary" runat="server" Text="Add new Tag" OnClick="SubmitButton_Click" />
</asp:Content>


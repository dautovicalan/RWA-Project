﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="rwa_project.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex">
        <h2 class="text-center">Tags</h2>
        <asp:BulletedList ID="TagList" runat="server" CssClass="h4">            
        </asp:BulletedList>           
        <asp:Button ID="AddNewTagButton" CssClass="btn btn-primary" runat="server" Text="Add new Tag" OnClick="AddNewTagButton_Click" />
    </div>
</asp:Content>

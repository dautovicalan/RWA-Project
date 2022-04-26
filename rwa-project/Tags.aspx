﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="rwa_project.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex">
        <h2 class="text-center">Tags</h2>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div style="display: flex">
                    <p>
                        <%# Eval("Name") %> <%# Eval("TagAppearance") %>
                    </p>
                    <asp:Button Visible='<%# ShowDeleteButton(Eval("TagAppearance").ToString()) %>' CommandName="Delete" CommandArgument='<%# Eval("id") %>' runat="server" Text="DELETE" UseSubmitBehavior="false"/>
                </div>
            </ItemTemplate>
        </asp:Repeater>               
        <asp:Button ID="AddNewTagButton" CssClass="btn btn-primary" runat="server" Text="Add new Tag" OnClick="AddNewTagButton_Click" />
    </div>
</asp:Content>

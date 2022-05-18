<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="rwa_project.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    <div class="d-flex">
        <h2 class="text-center">Tags</h2>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div style="display: flex">
                    <p>
                        <%# Eval("Name") %> <%# Eval("TagAppearance") %>
                    </p>
                    <asp:Button Visible='<%# ShowDeleteButton(Eval("TagAppearance").ToString()) %>' CommandName="Delete" CommandArgument='<%# Eval("id") %>' runat="server" Text="DELETE" UseSubmitBehavior="false" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button ID="AddNewTagButton" CssClass="btn btn-primary" runat="server" Text="Add new Tag" OnClick="AddNewTagButton_Click" />
    </div>
    <asp:Panel ID="pnlModal" runat="server" Visible="false">
        <div class="modal">
            <div class="modal-content">
                <h1>Are you sure you want to delete this tag?</h1>
                <div class="form-group">
                    <asp:Button ID="btnDeleteConfirm" runat="server" Text="Yes" OnClick="btnDeleteConfirm_Click"/>
                    <asp:Button ID="btnDeleteCancel" runat="server" Text="No" OnClick="btnDeleteCancel_Click"/>
                </div>
            </div>
        </div>        
    </asp:Panel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="rwa_project.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex">
        <h2 class="text-center">Tags</h2>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div style="display: flex">
                    <p>
                        <%# Eval("Name") %> <%# Eval("TagAppearance") %>
                    </p>
                    <asp:Button Visible='<%# ShowDeleteButton(Eval("tagAppearance").ToString()) %>' runat="server" Text="DELETE" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:BulletedList ID="TagList" runat="server" CssClass="h4">            
        </asp:BulletedList>           
        <asp:Button ID="AddNewTagButton" CssClass="btn btn-primary" runat="server" Text="Add new Tag" OnClick="AddNewTagButton_Click" />
    </div>
</asp:Content>

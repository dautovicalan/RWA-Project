<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="rwa_project.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>Ja sam tagovi neki kao</p>
    <div class="d-flex">
        <h2>Tags</h2>
        <ul>
            <% foreach (var singleTag in MyTags) { %>
               <li>
                   <%= singleTag.Name %>
               </li>
              <%  } %>
        </ul>
        <asp:Button ID="AddNewTagButton" CssClass="btn btn-primary" runat="server" Text="Add new Tag" OnClick="AddNewTagButton_Click" />
    </div>
</asp:Content>

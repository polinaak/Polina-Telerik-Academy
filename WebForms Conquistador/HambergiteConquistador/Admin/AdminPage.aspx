<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="HambergiteConquistador.Admin.AdminPage" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Administrator actions</h3>
    <div class="btn-group">
    <button type="button" class="btn btn-primary">Action</button>
    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
    <span class="caret"></span>
    </button>
    <ul class="dropdown-menu" role="menu">
        <li>
            <a href="EditUsers.aspx" >Edit Users</a>
        </li>
        <li>
            <asp:LinkButton runat="server" ID="GetPermissions" OnClick="GetPermissions_Click" Text="GetPermissions" ></asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton runat="server" Text="Edit Questions" OnClick="EditQuestions_Click" ></asp:LinkButton>
        </li>
        <li>
              <asp:LinkButton runat="server" Text="Create Question" OnClick="CreateQuestions_Click" ></asp:LinkButton>
        </li>
        <li>
             <asp:LinkButton runat="server" Text="Approve Questions" OnClick="ApproveQuestions_Click" ></asp:LinkButton>
        </li>
    </ul>
    </div>
   
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAnswers.aspx.cs" Inherits="HambergiteConquistador.Admin.EditAnswers1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h1>Edit Answer</h1>
    <div class="form-inline">
        <asp:Label runat="server" Text="New answer:" CssClass="form-group"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxEdit" CssClass="form-control"></asp:TextBox>
        <asp:Button runat="server" Text="Save changes" OnCommand="EditAnswer_Command" CssClass="btn btn-success"/>
    </div>
</asp:Content>

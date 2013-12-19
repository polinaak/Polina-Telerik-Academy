<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeUserPassword.aspx.cs" Inherits="HambergiteConquistador.Account.ChangeUserPassword" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="TextBoxNewPassword" />
    <asp:Button runat="server" ID="ChangePassword" OnClick="ChangePassword_Click" Text="Change Password" />
</asp:Content>

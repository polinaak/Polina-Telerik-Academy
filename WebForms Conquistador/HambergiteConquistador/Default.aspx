<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HambergiteConquistador._Default" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <h1 runat="server" id="ApplicationGreeting" class="text-primary text-center">Wellcome to Hambergite Conquistador!</h1>

        <p runat="server" id="greeting" class="lead text-center">
        </p>
    </div>

</asp:Content>

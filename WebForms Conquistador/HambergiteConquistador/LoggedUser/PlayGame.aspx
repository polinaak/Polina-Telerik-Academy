<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayGame.aspx.cs" Inherits="HambergiteConquistador.LoggedUser.PlayGame" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<%@ Register Src="~/Controls/MakePictureFromText/MakePictureFromText.ascx" TagPrefix="userControl" TagName="MakePictureFromText" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2> Play Game Page </h2>

    <h3>Bonus: <asp:Literal ID="LiteralBonus" runat="server" Mode="Encode" /></h3>
    <h3>Score: <asp:Literal ID="LiteralScore" runat="server" Mode="Encode" /></h3>

    <asp:UpdatePanel runat="server" ID="UpdatePanelQuestion"></asp:UpdatePanel>
    <h2>Question: <asp:Literal ID="LiteralQuestion" runat="server" Mode="Encode" Visible="false"/></h2>
    
    <userControl:MakePictureFromText runat="server" id="MakePictureFromText" />
    <h2> <asp:Literal ID="LiteralAnswer" runat="server" Mode="Encode" /></h2>

   
    <asp:RadioButtonList ID="RadioButtonListAnswers"  runat="server" 
        CssClass="inline"
        DataTextField ="ContentText" 
        DataValueField="Id"  >

    </asp:RadioButtonList>
        
    <div>
        <asp:Button ID="ButtonSubmit" Text="Submit Answer" runat="server" OnClick="ButtonSubmit_Click" />
        <asp:Button ID="ButtonJoker25" Text="Joker 25%" runat="server" OnClick="ButtonJoker25_Click" />
        <asp:Button ID="ButtonJoker50" Text="Joker 50%" runat="server" OnClick="ButtonJoker50_Click" />
        <asp:Button ID="ButtonNextQuestion" Text="NextQuestion" runat="server" OnClick="ButtonNextQuestion_Click" />
    </div>
    </asp:Content>
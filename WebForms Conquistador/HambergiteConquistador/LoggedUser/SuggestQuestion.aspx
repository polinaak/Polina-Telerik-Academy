<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuggestQuestion.aspx.cs" Inherits="HambergiteConquistador.LoggedUser.SuggestQuestion" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Enter your question followed by 4 possible answers. Exactly one answer should be marked as correct.</h3>
    <div id="input-fields">
        Question: <asp:TextBox runat="server" ID="TextBoxQuestion" /><br />        
        Answer 1: <asp:TextBox runat="server" ID="TextBoxAnswer1" /><br />
        Answer 2: <asp:TextBox runat="server" ID="TextBoxAnswer2" /><br />
        Answer 3: <asp:TextBox runat="server" ID="TextBoxAnswer3" /><br />
        Answer 4: <asp:TextBox runat="server" ID="TextBoxAnswer4" /><br />
    </div>
    <div id="select-correct">
    The correct answer is: 
        <asp:DropDownList runat="server" ID="DropDownCorrectAnswer">
            <asp:ListItem Text="Answer 1" Value="1" />
            <asp:ListItem Text="Answer 2" Value="2" />
            <asp:ListItem Text="Answer 3" Value="3" />
            <asp:ListItem Text="Answer 4" Value="4" />
        </asp:DropDownList>
    </div>
    <asp:Button Text="Submit" runat="server" ID="ButtonSubmit" OnClick="ButtonSubmit_Click" CssClass="btn btn-primary" />
</asp:Content>

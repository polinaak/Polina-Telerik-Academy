<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs" Inherits="HambergiteConquistador.Admin.EditQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <input name="btnBack" title="Previous Page" onclick="location.href = 'javascript:history.go(-1)'" type="button"
    value="Previous Page" class="btn btn-primary"><br />
    <h3>Edit question:</h3>
    <div class="edit-content">
        <asp:TextBox runat="server" ID="TextBoxEdit" Width="100%"></asp:TextBox>
        <ul class="list-group">
            <asp:Repeater runat="server" ItemType="HambergiteConquistador.Models.Answer"
                ID="RepeaterAnswers">
                <ItemTemplate>
                    <li class="list-group-item">
                       <p class="list-group-item-text"><%#: Item.ContentText %><span> (<%#: Item.IsCorrect %>)</span></p>
                       <p><a href="EditAnswers.aspx?answerId=<%# Item.Id %>" class="btn btn-xs">Edit</a>
                       <asp:Button runat="server" Text="Delete" CommandName="Delete" OnCommand="Delete_Command"
                           CommandArgument="<%#: Item.Id %>" OnClientClick="return confirm('Do you want to delete ?');"
                           CssClass="btn btn-xs" /></p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
         </ul>
        <asp:LinkButton runat="server" OnClick="CreateAnswer_Click"><span class="icon-plus-sign"></span> Add answer</asp:LinkButton>
        <label class="checkbox">
            <asp:CheckBox Text="Approved" runat="server" ID="CheckBoxApproved" />
        </label>
        <asp:Button runat="server" Text="Save changes" OnCommand="Save_Command" CssClass="btn btn-success" />
    </div>
</asp:Content>

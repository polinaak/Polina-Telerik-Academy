<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditQuestions.aspx.cs" Inherits="HambergiteConquistador.Admin.EditAnswers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Edit questions</h3>
     <asp:ListView runat="server" ID="ListViewAllQuestions" ItemType="HambergiteConquistador.Models.Question" OnItemDeleting="ListViewAllQuestions_ItemDeleting">
        <LayoutTemplate>
            <table class="table table-bordered">
                <tr id="itemPlaceHolder" runat="server"></tr>
            </table>
             <asp:DataPager runat="server" ID="DataPager" PageSize="6">
                <Fields>
                    <asp:NumericPagerField ButtonCount="10"
                       PreviousPageText="<--"
                       NextPageText="-->" />  
                </Fields>       
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="questionRow" runat="server">
                <td><%#: Item.TextContent %></td>
                <td>
                    <asp:LinkButton runat="server"
                     Text="Edit" 
                     OnCommand="Edit_Command"
                     CommandArgument="<%#: Item.Id %>"
                     CommandName="Edit" >
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton runat="server"
                     Text="Delete"
                     CommandArgument="<%#: Item.Id %>"
                     CommandName="Delete"
                     OnCommand="Delete_Command"
                     OnClientClick="return confirm('Do you want to delete ?');">
                    </asp:LinkButton>
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:ListView>     
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveQuestions.aspx.cs" Inherits="HambergiteConquistador.Admin.ApproveQuestions" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Questions awaiting approval</h3>
    <asp:ListView runat="server" ID="ListViewAllQuestions" ItemType="HambergiteConquistador.Models.Question">
        <LayoutTemplate>
            <table class="table table-bordered">
                <tr id="itemPlaceholder" runat="server"></tr>
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
            <tr class="questions" runat="server">
                <td><%#: Item.TextContent %></td>
                <td>
                    <asp:LinkButton runat="server"
                     Text="Go to approval" 
                     OnCommand="Edit_Command"
                     CommandArgument="<%#: Item.Id %>"
                     CommandName="Edit" CssClass="btn btn-info btn-sm" >
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton runat="server"
                     Text="Delete"
                     CommandArgument="<%#: Item.Id %>"
                     CommandName="Delete"
                     OnCommand="Delete_Command"
                     OnClientClick="return confirm('Do you want to delete ?');"
                     CssClass="btn btn-warning btn-sm" >
                    </asp:LinkButton>
                </td>
            </tr>            
        </ItemTemplate>
    </asp:ListView>     
</asp:Content>

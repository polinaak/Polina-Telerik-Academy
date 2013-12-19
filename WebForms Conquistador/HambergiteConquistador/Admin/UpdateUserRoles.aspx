<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUserRoles.aspx.cs" Inherits="HambergiteConquistador.Admin.UpdateUserRoles" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <p>Current roles:</p>
    
        <asp:GridView runat="server" ID="ListViewUserRole" 
            SelectMethod="ListViewUserRole_GetData" 
            DeleteMethod="ListViewUserRole_DeleteItem" 
            ItemType="HambergiteConquistador.Models.AspNetRole" 
            AllowPaging="true"
            AllowSorting="true" 
            AutoGenerateColumns="false" 
            EnableViewState="false" 
            DataKeyNames="Id" >

            <EmptyDataTemplate>
                <p>User has no roles, yet.</p>
            </EmptyDataTemplate>
            <Columns>
              <asp:BoundField  HeaderText="Role Name" DataField="Name"  SortExpression="Name"/>
                
                <asp:CommandField ShowDeleteButton="true"/>
            </Columns>
        </asp:GridView>
   

    <asp:DropDownList runat="server" ID="DDLRoles" 
        DataValueField="Id" DataTextField="Name" 
        SelectMethod="DDLRoles_GetData" ItemType="HambergiteConquistador.Models.AspNetRole" />
    <asp:Button runat="server" ID="AddRole" OnClick="AddRole_Click" Text="Add Role" 
        CssClass="btn btn-primary" />
</asp:Content>
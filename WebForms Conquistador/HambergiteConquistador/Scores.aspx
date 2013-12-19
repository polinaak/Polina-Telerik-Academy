<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scores.aspx.cs" Inherits="HambergiteConquistador.Scores" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

             <h1 class="text-center"> Scores </h1>

            <asp:GridView ID="GridViewScores" CssClass="text-center container well" runat="server" 
                    AllowPaging="True" 
                    AllowSorting="True" 
                    AutoGenerateColumns="False" 
                    DataKeyNames="ID" 
                    PageSize="10"
                    Width="600px" 
                SelectMethod="GridViewScores_GetData">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                    <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score" />
                  
                </Columns>
            </asp:GridView>

        <div class="text-center">
            <asp:Button 
                ID="ButtonRegister" 
                Text="Start now " 
                runat="server" CssClass="btn btn-large btn-primary" OnClick="ButtonPlayOrRegister_Click" />
        </div>
    </asp:Content>
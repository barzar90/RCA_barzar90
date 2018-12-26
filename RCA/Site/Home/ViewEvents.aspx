<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="ViewEvents.aspx.cs" Inherits="MSHC.Site.Home.ViewEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    
<style type="text/css">
.imgevent{ width:350px; float:left; margin-right:15px}
.eventdiv{ background :#ccc }
</style>
    <div class="container">
      
<div style="eventdiv">
  <h1>Events </h1>
<br><br>  
            <ul class="dropdown" runat="server" id="tabs"></ul>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
 
    </div></div>
</asp:Content>

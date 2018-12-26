<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/MasterPage.Master"
    AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="RCA.Site.Information.events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTitle" runat="server">
    <div class="col pageTitle">
        
        <asp:Label ID="lbl_eventstitle" runat="server"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="lbl_eventscontent" runat="server"></asp:Label>
    
</asp:Content>

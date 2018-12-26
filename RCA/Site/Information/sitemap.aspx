<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="sitemap.aspx.cs" Inherits="RCA.Site.Information.sitemap" %>

<%@ Register src="../../Controls/WebSiteControls/SiteMap.ascx" tagname="SiteMap" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">

  <%--  <asp:Label ID="lbl_sitemap" runat="server"></asp:Label>--%>
    <uc1:SiteMap ID="SiteMap1" runat="server" />

</asp:Content>

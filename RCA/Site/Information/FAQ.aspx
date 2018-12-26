<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/MasterPage.Master"
    AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="RCA.Site.Information.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTitle" runat="server">
    <asp:Label ID="lbl_FAQtitle" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_FAQDetail" runat="server"></asp:Label>
</asp:Content>

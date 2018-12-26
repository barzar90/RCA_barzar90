<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RCA.Account.Login.Login" %>
<%@ Register src="../../Controls/AdminControls/Login.ascx" tagname="Login" tagprefix="uc1" %>
<%@ Register src="../../Controls/AdminControls/Registration.ascx" tagname="Registration" tagprefix="uc2" %>

<asp:Content ID="SitePH" ContentPlaceHolderID="SitePH" runat="server">
    <style>
        .site-sec {
            margin-top:143px !important;
        }
    </style>
     <asp:LinkButton ID="lbtnRegister" runat="server" onclick="lbtnRegister_Click" Text="<%$Resources:General,lblNewUserRegister %>" Visible="false"></asp:LinkButton>
    <uc1:Login ID="ctrlLogin" runat="server" />
    <uc2:Registration ID="ctrlRegistration" runat="server" />
<br />
<asp:HiddenField ID="hdnDisplayReg" runat="server" />
</asp:Content>

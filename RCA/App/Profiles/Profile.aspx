<%@ Page Title="" Language="C#" MasterPageFile=
"~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="RCA.App.Profile" %>
<%@ Register src="~/Controls/AdminControls/UserProfile.ascx" tagname="UserProfile" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    
    
    <uc2:UserProfile ID="ctrlUserProfile" runat="server" />

</asp:Content>

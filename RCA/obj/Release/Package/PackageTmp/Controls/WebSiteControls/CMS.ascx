<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CMS.ascx.cs" Inherits="RCA.Controls.WebSiteControls.CMS" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<%@ Register Src="PlaceHolderControl.ascx" TagName="PlaceHolderControl"
    TagPrefix="uc4" %>
<div class="row">
     <div  id="LeftMenuContent" runat="server" class="col-xs-12 col-sm-4 col-md-4 col-lg-3">
        <div class="quick-links">
            <div id="PContent" runat="server"></div>
        </div>
    </div>
    <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9 brd-left pleft25" id="divContent" runat="server">
        <div class="headingBg">
            <h1>
                <asp:Label ID="lblHeading" runat="server" Text="Label"></asp:Label></h1>
            <uc:BreadCrum ID="BreadCrum" runat="server" />
        </div>
        <asp:HiddenField ID="hdn_keyword" runat="server" />
        <div id="CMSContent" runat="server">
        </div>
        <div class="clear">
        </div>
    </div>
</div>

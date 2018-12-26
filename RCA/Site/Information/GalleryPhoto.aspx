<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" Inherits="RCA.Site.Information.GalleryPhoto" CodeBehind="GalleryPhoto.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="../../Scripts/visuallightbox.js" type="text/javascript"></script>
<script src="../../Scripts/vlbdata1.js" type="text/javascript"></script>
<link href="../../Styles/visuallightbox.css" rel="Stylesheet" type="text/css" />
<link href="../../Styles/vlightbox1.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="CustomForms" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
  <h1><asp:Label ID="lblgaller" runat="server" Text="Photo Gallery">
  </asp:Label></h1>
     <div id="photoalbum">
        <div>
            <asp:DataList ID="DL_EventPhoto" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                        <a class="vlightbox1"  href='<%# DataBinder.Eval(Container.DataItem,"Photo") %>' title=""><img src='<%# DataBinder.Eval(Container.DataItem,"Photo") %>' alt="" />
                            <asp:Label ID="LblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PhotoName") %>'></asp:Label>
                            <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%>
                        </a>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
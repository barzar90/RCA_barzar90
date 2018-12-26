<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="SubAlbum_Gallery.aspx.cs" Inherits="RCA.Site.Information.SubAlbum_Gallery" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="CustomForms" runat="server">
    <%--<div class="pageTitle">
        Photo Album
    </div>
     <div class="contentheadTitle">
        Events
         <asp:Label ID="hdnImageUrl" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <h1>
        <asp:Label ID="lblAlbum" runat="server"></asp:Label></h1>
    <style type="text/css">
        .Timg
        {
            margin: 10px 10px 10px 10px;
            padding: 4px;
            border-top: 1px solid #ddd;
            border-left: 1px solid #ddd;
            border-bottom: 1px solid #c0c0c0;
            border-right: 1px solid #c0c0c0;
            background: #fff;
        }
    </style>
    <script src="../Scripts/vlbdata1.js" type="text/javascript"></script>
    <div style="float: right; display: block">
        <span>
            <asp:LinkButton ID="Lnkhome" runat="server" Text="Home" OnClick="Lnkhome_Click"></asp:LinkButton></span>
    </div>
    <div id="photoalbum_index">
        <asp:ListView ID="LV_Events" runat="server" OnItemDataBound="LV_Events_ItemDataBound">
            <ItemTemplate>
            </ItemTemplate>
            <ItemTemplate>
                <div>
                    <dl>
                        <dt><a href='<%# "../Information/GalleryPhoto.aspx?ID=" + Eval("PhotoID")%>' title=""
                            target="_blank">
                            <asp:Image ID="Image1" runat="server" alt="View Event Photo" ImageUrl='<%# Eval("Photo")%>' /></a></dt>
                        <dt>
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("AlbumName")%>'></asp:Literal>
                            <%--<span>
                                <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span>--%>
                        </dt>
                    </dl>
                    <%--<dl class="team">
                <dt><a href= '<%# "../Information/GalleryPhoto.aspx?ID=" + Eval("AlbumID")%>' title="" target="_blank" > 
            <asp:Image id="Image2"  runat="server" alt="View Event Photo" ImageUrl='<%# Eval("Photo")%>'  /></a></dt>
                 <dt> <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("AlbumName")%>'></asp:Literal></dt>
            </dl>

            <dl class="team">
                <dt><a href= '<%# "../Information/GalleryPhoto.aspx?ID=" + Eval("AlbumID")%>' title="" target="_blank" > 
            <asp:Image id="Image3"  runat="server" alt="View Event Photo" ImageUrl='<%# Eval("Photo")%>'  /></a></dt>
                 <dt> <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("AlbumName")%>'></asp:Literal></dt>
            </dl>--%>
                </div>
            </ItemTemplate>
            <LayoutTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" class="linkMap vAlign">
                    <ul id="itemPlaceholderContainer" runat="server">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>
</asp:Content>


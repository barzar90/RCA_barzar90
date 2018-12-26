<%@ Page Title="Albums - Maharashtra Judicial Academy and Indian Mediation Centre and Training Institute" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="RCA.Site.Information.Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="CustomForms" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <h1> <asp:Label ID="lblAlbum" runat="server"></asp:Label></h1>
    <div id="photoalbum_index">
        <asp:ListView ID="LV_Events" runat="server" OnItemDataBound="LV_Events_ItemDataBound">
            <ItemTemplate>
            </ItemTemplate>
            <ItemTemplate>
                <dl>
                    <dt><a href='<%# "../Information/SubAlbum.aspx?ID=" + Eval("AlbumID")%>' title=""><asp:Image ID="Image1" runat="server" alt="View Event Photo" ImageUrl='<%# Eval("Photo")%>' /></a></dt>
                    <dd>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("AlbumName")%>'></asp:Literal>
                     <%--   <span>
                            <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span>--%>
                    </dd>
                </dl>
            </ItemTemplate>
            <LayoutTemplate>
                <table width="100%" >
                    <ul id="itemPlaceholderContainer" runat="server">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>
</asp:Content>

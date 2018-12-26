 <%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="FrmViewSubAlbum.aspx.cs" Inherits="RCA.Site.Information.FrmViewSubAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
    <style>
.none {display:none;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div  id="LeftMenuContent" runat="server" class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
        <div class="quick-links">
            <div id="PContent" runat="server"></div>
        </div>
    </div>
    <div class="col-xs-12 col-sm-10 col-md-10 col-lg-10 brd-left pleft25">
     <div >
         <h1><asp:Label ID="lblAlbum" runat="server"></asp:Label></h1> 
         <div class='breadcrumbDiv' id="breadcrumb" runat="server">
         </div>        
        <div class="photoalbum_index">
            <asp:ListView ID="LV_Events" OnItemDataBound="ListView_ItemDataBound" runat="server">
                    <ItemTemplate>                  
                     <asp:Label ID="Label1" CssClass="heading-h2 hidden"  runat="server"  Text='<%# Bind("AlbumName") %> '></asp:Label>
                        <dl>
                            <dt>
                            <a href='<%# "../../Site/Information/FrmViewPhoto.aspx?ID=" + Eval("PhotoSubAlbumID")%>'title="">
                            <asp:Image ID="Image1" CssClass="img-1" runat="server" alt="View Event Photo" ImageUrl='<%# Eval("FileName")%>' /></a></dt>
                            <dd><asp:Literal ID="Literal2" runat="server" Text='<%# Eval("SubAlbumName")%>'></asp:Literal></dd>
                        </dl>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server">
                        <li runat="server" id="itemPlaceholder"></li>
                    </ul>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </div>
        </div>
</asp:Content>

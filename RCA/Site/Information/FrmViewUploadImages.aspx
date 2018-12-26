<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Siteplen.Master"
    AutoEventWireup="true" CodeBehind="FrmViewUploadImages.aspx.cs" Inherits="MSHC.Site.Information.FrmViewUploadImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="container">
    <div class="row">
        <h1>
            <asp:Label ID="lblAlbum" runat="server" Text="Press Clip"> </asp:Label></h1></div>
     <%--   <a href="FrmViewSubAlbum.aspx" class="btnBack">Back</a>--%>
        <div id="photoalbum">
            <asp:DataList ID="DL_EventPhoto" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div>
                        <a class="vlightbox1" href='<%# DataBinder.Eval(Container.DataItem,"ImgPath") %>'
                            title="">
                            <asp:Image ID="Image1" runat="server" alt="View Event Photo" ImageUrl='<%# Eval("ImgPath")%>' />
                            <p>
                                <asp:Label ID="LblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label></p>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>

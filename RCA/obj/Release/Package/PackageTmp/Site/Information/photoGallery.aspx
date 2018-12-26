<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" Inherits="RCA.Site.Information.photoGallery" CodeBehind="photoGallery.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

</asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="CustomForms" runat="server">
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="Server">
<h1>Photo Gallery</h1>
    <script src="../../Scripts/vlbdata1.js" type="text/javascript"></script>
    <div id="vlightbox1">
        <div class="col" style="width: 160px; margin: 10px">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <div class="col" style="width: 180px; height: 150px">
                        <a class="vlightbox1" href='<%# DataBinder.Eval(Container.DataItem,"Path") %>' title='<%# DataBinder.Eval(Container.DataItem,"Title") %>'>
                            <img src='<%# DataBinder.Eval(Container.DataItem,"Path") %>' alt="Airoli_01img" width="150px"
                                height="100px" />
                        </a>
                        <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Title") %>' Font-Size="12px"
                            Width="180px"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Local %>"
            SelectCommand="SELECT [ID], Title, '../Upload/galleryImages/'+ Path  as Path FROM [GalleryImage]">
            <%--SelectCommand="SELECT [ID], Title, '../Graphics/Images/photoGallery/'+ Path  as Path FROM [GalleryImage]">--%>
        </asp:SqlDataSource>
    </div>
</asp:Content>

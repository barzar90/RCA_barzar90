<%@ Page Title="" Language="C#" MasterPageFile="~/SITE/Masterpage/MasterPage.master"
    AutoEventWireup="true" CodeBehind="Photos.aspx.cs" Inherits="RCA.Site.Information.Photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTitle" runat="server">
    <div class="pageTitle">
        Photo Album
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td valign="top" cellspacing="5">
                    Album Name:
                    <asp:Label ID="lblAlbumName" runat="server"></asp:Label><br />
                    <asp:Image CssClass="Timg" runat="server" ID="imAlbumPhoto" /><br />
                    No of Pictures:
                    <asp:Label ID="lblNoofPicz" runat="server"></asp:Label>
                    <br />
                    <a href="Albums.aspx">Back to Gallery</a>
                    <br />
                    <asp:LinkButton ID="lbUploadPhotos" runat="server" Visible="false" OnClick="lbUploadPhotos_Click">Upload Photos</asp:LinkButton>
                </td>
                <td>
                    <asp:ListView ID="lvPhotos" runat="server" DataKeyNames="AlbumID" DataSourceID="SqlDataSource1"
                        GroupItemCount="3" OnItemCommand="lvPhotos_ItemCommand" OnSelectedIndexChanged="lvPhotos_SelectedIndexChanged"
                        OnSelectedIndexChanging="lvPhotos_SelectedIndexChanging">
                        <LayoutTemplate>
                            <table id="groupPlaceholderContainer" runat="server" border="0" cellpadding="0" cellspacing="0">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td1" runat="server" align="center" style="background-color: #e8e8e8; color: #333333;">
                                <a href='<%# "PhotoViewer.aspx?PhotoID="+Eval("PhotoID")+"&AlbumID="+ Eval("AlbumID") %>'>
                                    <asp:Image CssClass="Timg" runat="server" ID="imPhoto" ImageUrl='<%# "ThumbNail.ashx?ImURL="+Eval("Photo") %>' />
                                </a>
                                <%--   <a class="vlightbox1" href='<%# DataBinder.Eval(Container.DataItem,"Path") %>' title='<%# DataBinder.Eval(Container.DataItem,"Title") %>'>
                            <img src='<%# DataBinder.Eval(Container.DataItem,"Path") %>' alt="Airoli_01img" width="150px"
                                height="100px" />
                        </a>--%>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:HiddenField ID="hfAlbumID" runat="server" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Local %>"
            SelectCommand="SELECT [PhotoID], [Photo], [PhotoName], [AlbumID] FROM [PhotAlbum] WHERE ([AlbumID] = @AlbumID) ORDER By [PhotoID] ASC"
            OnSelected="SqlDataSource1_Selected">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="1" Name="AlbumID" QueryStringField="AlbumID"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

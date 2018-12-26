<%@ Page Title="" Language="C#" MasterPageFile="~/SITE/Masterpage/MasterPage.master" AutoEventWireup="true" CodeBehind="PressNewsAlbum.aspx.cs" Inherits="RCA.Site.Information.PressNewsAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pageTitle" runat="server">
 <asp:Label ID="lbl_PressNewsAlbum" runat="server" Text="Press News Album"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <asp:ListView ID="lvAlbums" runat="server" GroupItemCount="3"
        InsertItemPosition="LastItem">
        <LayoutTemplate>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr id="groupPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr>
                <td id="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td id="Td3" width="150px" height="150px" align="center" style="background-color: #e8e8e8;
                color: #333333;">
                <asp:HiddenField ID="hfPhotoID" runat="server" Value='<%# Eval("DefaultPhotID") %>' />
                <a href='<%# "PressNewsPhotos.aspx?PressNewsAlbumID="+Eval("PressNewsAlbumID") %>'>
                    <asp:Image CssClass="Timg" runat="server" ID="imPhoto" ImageUrl='<%# "ThumbNail.ashx?ImURL="+Eval("Photo") %>' />
                </a>
                <br />
                <b>
                    <asp:Label ID="lblAlbumName" runat="server" Text='<%# Eval("AlbumName") %>'></asp:Label>
                </b>
            </td>
            <td style="width:20px">&nbsp;</td>
        </ItemTemplate>
        <InsertItemTemplate>
            <%--<td id="Td3" width="150px" height="150px" runat="server" align="center" style="background-color: #e8e8e8;color: #333333;">
                <a href="CreateAlbum.aspx">                    
                    Create New Album
                </a>
                </td>--%>
        </InsertItemTemplate>
    </asp:ListView>
   <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Local %>"
        SelectCommand="SELECT PressNewsAlbum.PressNewsAlbumID, PressNewsAlbum.DefaultPhotID, PressNewsAlbum.AlbumName, PressNewsPhotoAlbum.Photo FROM PressNewsAlbum INNER JOIN PressNewsPhotoAlbum ON PressNewsAlbum.PressNewsAlbumID = PressNewsPhotoAlbum.AlbumID">
    </asp:SqlDataSource>--%>
</asp:Content>

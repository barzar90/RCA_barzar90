<%@ Page Title="" Language="C#" MasterPageFile="~/SITE/Masterpage/MasterPage.master"
    AutoEventWireup="true" CodeBehind="PhotoViewer.aspx.cs" Inherits="RCA.Site.Information.PhotoViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTitle" runat="server">
    <div class="pageTitle">
        Photo Album
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/vlbdata1.js" type="text/javascript"></script>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="linkBlue">
                <a href="Albums.aspx"><< Back to Gallery</a>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ListView ID="lvPhotoViewer" runat="server" GroupItemCount="1">
                    <LayoutTemplate>
                        <table id="groupPlaceholderContainer" runat="server" border="1">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <td id="Td4" align="center" style="background-color: #eeeeee;">
                            <asp:Image runat="server" ID="imPhoto" Height="450px" Width="450px" ImageUrl='<%#Eval("Photo") %>' /></a>
                            <br />
                            
                            <asp:Label ID="DefaultPhotIDLabel" runat="server" Text='<%# Eval("PhotoName") %>' />
                            <%--   <a class="vlightbox1" href='<%# DataBinder.Eval(Container.DataItem,"Path") %>' title='<%# DataBinder.Eval(Container.DataItem,"Title") %>'>
                            <img src='<%# DataBinder.Eval(Container.DataItem,"Path") %>' alt="Airoli_01img" width="150px"
                                height="100px" />
                        </a>--%>
                        </td>
                    </ItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server">
                            </td>
                        </tr>
                    </GroupTemplate>
                </asp:ListView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvPhotoViewer" PageSize="1"
                    OnPreRender="DataPager1_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" PreviousPageText="Previous " NextPageText="Next" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
        <tr>
            <td class="linkBlue">
                <a href="Albums.aspx"><< Back to Gallery</a>
            </td>
        </tr>
    </table>
</asp:Content>

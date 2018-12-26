<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="PressNewsPhotoViewer_Old.aspx.cs" Inherits="MSHC.Site.Information.PressNewsPhotoViewer" %>

    <Html>
    
    <Title>Press News Album</title>
    <head>
    <script src="../Scripts/vlbdata1.js" type="text/javascript"></script>
    <script type="text/javascript">
        javascript: void (document.oncontextmenu = null)
</script>
    </head>
    <body>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="linkBlue">
                <a href="PressNewsAlbum.aspx"><< Back to Press News Gallery</a>
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
                            <asp:Image runat="server" ID="imPhoto" Height="700px" Width="700px" ImageUrl='<%#Eval("Photo") %>' /></a>
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
                <a href="PressNewsAlbum.aspx"><< Back to Press News Gallery</a>
            </td>
        </tr>
    </table>
    </body>
    </html>


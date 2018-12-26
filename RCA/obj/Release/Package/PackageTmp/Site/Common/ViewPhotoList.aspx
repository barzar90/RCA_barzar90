<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"  AutoEventWireup="true" CodeBehind="ViewPhotoList.aspx.cs" Inherits="RCA.Site.Common.ViewPhotoList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h1>
            <asp:Label ID="lblPhotoHeading" runat="server" Text="Photo Gallery"></asp:Label></h1>
        <div class="searchInner searchMarg">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="25%" height="18px">
                        <asp:Label ID="lblArchives" runat="server" Text="Current Or Archives" AssociatedControlID="rblArchives"></asp:Label>
                    </td>
                    <td width="75%" colspan="3" height="18px">
                        <asp:RadioButtonList ID="rblArchives" runat="server" RepeatDirection="Horizontal"
                            Width="40%" AutoPostBack="true" OnSelectedIndexChanged="rblArchives_SelectedIndexChanged">
                            <%--<asp:ListItem Value="1" Selected="True">Current</asp:ListItem>
                            <asp:ListItem Value="2">Archives</asp:ListItem>--%>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </div>
        <div class="innerContView">
            <asp:DataList ID="dlPhotoList" runat="server" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="viewGalList">
                        <a class="vlightbox1" href='<%# "../STD/DisplayFile.ashx?ID=" + Eval("RowID") %>'
                            target="_blank" title='<%# DataBinder.Eval(Container.DataItem, "FileTitleWithDtl")%>'>
                            <%--<a  rel='iframe-750-550'  class='pirobox_gall1' href='<%# "../STD/DisplayFile.ashx?ID=" + Eval("RowID") %>'>        --%>
                            <asp:Image ID="img" runat="server" Width="150px" Height="115px" CssClass="imgBG"
                                ImageUrl='<%# "~/PublicApp/STD/DisplayFile.ashx?ID=" + Eval("RowID") %>' AlternateText='<%# DataBinder.Eval(Container.DataItem, "Title")%>' />
                        </a>
                        <div class="viewGalTitle">
                            <%# DataBinder.Eval(Container.DataItem, "Title")%></div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <asp:HiddenField ID="hdncult" runat="server" />
</asp:Content>

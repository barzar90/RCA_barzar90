<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="RCA.Site.Home.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    
<asp:Repeater ID="RptrWhatsNew" runat="server" OnItemCommand="RptrWhatsNew_ItemCommand">
        <ItemTemplate>
            <li>
                <asp:LinkButton ID="lnkDownload" runat="server" CommandArgument='<%# Eval("RowID") %>'
                    CommandName="DownloadFile"><%# Eval("Title") %></asp:LinkButton>
                <div class="descNews">
                    '<%# Eval("Desc1")%>'</div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

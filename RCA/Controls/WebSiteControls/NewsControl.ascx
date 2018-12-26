<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsControl.ascx.cs" Inherits="RCA.Controls.WebSiteControls.NewsControl" %>
<%--<div class="col-md-3 col-sm-12 col-xs-12">--%>
    <div class="latest-news">
        <div class="news-heading">
            <div class="col-md-8 col-sm-8 col-xs-8">
                <div class="row">
                    <h2>
                        <span class="pull-left">
                            <asp:Label ID="lblNews" runat="server" Visible="true"></asp:Label></span>
                    </h2>
                </div>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-4 text-right controls pull-right">
                <a href="#" id="ticker-previous"><i class="fa fa-chevron-left"></i></a><a id="stop"
                    href="#"><i class="fa fa-pause"></i></a><a id="start" href="#"><i class="fa fa-play">
                    </i></a><a href="#" id="ticker-next"><i class="fa fa-chevron-right"></i></a>
            </div>
        </div>
        <ul class="demo1" id="vertical-ticker">
            <asp:Repeater ID="RptrWhatsNew" runat="server" OnItemCommand="RptrWhatsNew_ItemCommand">
                <ItemTemplate>
                    <li class="news-item">
                        <div class="news-date">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("NewDate") %>'></asp:Literal>
                        </div>
                        <p>
                            <asp:HyperLink ID="hypViewFile" runat="server" Target="_blank" Text='<%# Eval("News") %>'
                                NavigateUrl='<%#  Eval("URL") %>'></asp:HyperLink>
                        </p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="col-md-8 col-sm-8 col-xs-8">
            <div class="row">
                <asp:HyperLink ID="lnkmore" NavigateUrl="~/Site/Home/NewsMore.aspx" CssClass="moreNews"
                    runat="server">
                    <asp:Label ID="lblNewsMore" runat="server" Visible="true"></asp:Label></asp:HyperLink>
            </div>
        </div>
        <span class="clearfix"></span>
    </div>
<%--</div>--%>
<script type="text/javascript">
        $(function () {
            $('#vertical-ticker').totemticker({
                next: '#ticker-next',
                previous: '#ticker-previous',
                stop: '#stop',
                start: '#start',
                mousestop: true
            });
        });
    </script>
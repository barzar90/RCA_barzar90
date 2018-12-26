<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
AutoEventWireup="true" CodeBehind="ViewVideoList.aspx.cs" Inherits="RCA.Site.Information.ViewVideoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery.js"></script>
<script type="text/javascript" src="../../Scripts/jquery.min.js"></script>
<script type="text/javascript" src="../../Scripts/colorbox.js"></script>
<link rel="Stylesheet" href="../../Styles/colorbox.css" />
<script type="text/javascript">
        $(document).ready(function () {
            var url = window.location.href;
            //Examples of how to assign the Colorbox event to elements
            $(".group1").colorbox({ rel: 'group1' });
            $(".group2").colorbox({ rel: 'group2', transition: "fade" });
            $(".group3").colorbox({ rel: 'group3', transition: "none", width: "40%", height: "75%" });
            $(".group4").colorbox({ rel: 'group4', slideshow: true });
            $(".ajax").colorbox();
            $(".youtube").colorbox({ iframe: true, innerWidth: 425, innerHeight: 344 });
            $(".vimeo").colorbox({ iframe: true, innerWidth: 500, innerHeight: 409 });
            $(".iframe").colorbox({ iframe: true, width: "40%", height: "80%" });
            $(".inline").colorbox({ inline: true, width: "40%" });
            $(".callbacks").colorbox({
                rel: 'callbacks',
                onClosed: function () { window.location.href = "ViewVideoList.aspx" }
            });

            $('.non-retina').colorbox({ rel: 'group5', transition: 'none' })
            $('.retina').colorbox({ rel: 'group5', transition: 'none', retinaImage: true, retinaUrl: true });

            $("#cboxContent").find("#cboxNext").attr('href', '#');
            $("#cboxContent").find("#cboxNext").attr('title', 'Next');

            $("#cboxContent").find("#cboxPrevious").attr('href', '#');
            $("#cboxContent").find("#cboxPrevious").attr('title', 'Previous');

            $("#cboxContent").find("#cboxClose").attr('href', '#');
            $("#cboxContent").find("#cboxClose").attr('title', 'Close');

            $("#gallery a").click(function () {
                $('#header').hide();
                $('#leftColumn').hide();
                $('.topContainer2').hide();
                $('#photoContainer').hide();
                $('#footer').hide();
                $('.yellow-Linksblock').hide();
                $('#menuContainer').hide();
                $('#gallery').hide();

            });

            //Example of preserving a JavaScript event for inline calls.
            $("#click").click(function () {
                $('#click').css({ "background-color": "#f00", "color": "#fff", "cursor": "inherit" }).text("Open this window again and this message will still be here.");
                return false;
            });


            $("#cboxClose").click(function () {
                $('#leftColumn').show();
                $('#header').show();
                $('.topContainer2').show();
                $('#photoContainer').show();
                $('#footer').show();
                $('.yellow-Linksblock').show();
                $('#menuContainer').show();
                $('#gallery').show();

            });




        });
</script>
<script type="text/javascript">
    function vidioStop() {
        document.getElementById('Vid').pause();
        document.getElementById('Vid').currentTime = 0;

    }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
<h1>
<asp:Label ID="lblHeading" runat="server" Text="Video Gallery"></asp:Label></h1>
<asp:DataList ID="dlVideoList" Width="100%" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
<ItemTemplate>
<div class="productsList">
<a class="callbacks" href='<%# Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty) + "/Site/Information/ViewVideo.aspx?str=" + DataBinder.Eval(Container.DataItem,"VideoID").ToString() %>'
title='<%# DataBinder.Eval(Container.DataItem, "VideoName")%>'>
</div>
<img src='<%# DataBinder.Eval(Container.DataItem,"VideoImage") %>' alt="" height="180px"
width="200px" /></a>
<div class="viewGalTitle">
<h3>
<%# DataBinder.Eval(Container.DataItem, "VideoName")%></h3>
</div>
</div>
</ItemTemplate>
</asp:DataList>
<asp:HiddenField ID="hdnPageIndex" runat="server" />
</asp:Content>

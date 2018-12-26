<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="ViewVideo.aspx.cs" Inherits="RCA.Site.Common.ViewVideo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<script type="text/javascript" src="../../Scripts/swfobject.js" ></script>
    <script type="text/javascript" language="javascript">
        function vid() {
            var s1 = new SWFObject('player.swf', 'player1', '480', '270', '9');
            s1.addParam('allowfullscreen', 'true');
            s1.addParam('allowscriptaccess', 'always');
            s1.addVariable('file', encodeURIComponent('~/App/STD/GetFile.ashx?ID=173'));
            s1.addVariable('type', 'video');
            s1.write(document.getElementById("video1"));
        }
</script>--%>
</head>
<body>
    <form id="form1" runat="server">
   <%-- <asp:Image ID="Image1" runat="server" />--%>
    <div>
        <asp:Literal ID="ltrVideo" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>

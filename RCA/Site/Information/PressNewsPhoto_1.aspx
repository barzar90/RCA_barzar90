<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PressNewsPhoto_1.aspx.cs"
    Inherits="RCA.Site.Information.PressNewsPhoto_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/visuallightbox.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/vlightbox1.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/vscroller.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/vlbdata1.js" type="text/javascript"></script>
    <script src="../Scripts/visuallightbox.js" type="text/javascript"></script>
    <script src="../Scripts/superfish.js" type="text/javascript"></script>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblphotonewsgallery" runat="server" Text=" Press News Gallery"></asp:Label>
    </div>
    <br />
    <div id="vlightbox1">
        <div class="col" style="width: 160px; margin: 10px">
            <asp:DataList ID="DL_EventPhoto" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="col" style="width: 180px; height: 150px">
                        <a class="vlightbox1" href='<%# DataBinder.Eval(Container.DataItem,"Photo") %>' title="">
                            <img style="border:1px solid #b4ce7d; padding:2px; margin-bottom:5px;" src='<%# DataBinder.Eval(Container.DataItem,"Photo") %>' alt="" width="150px"
                                height="100px" />
                            <asp:Label ID="LblName" CssClass="teamphoto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PhotoName") %>'></asp:Label>
                             <span>
                                <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    </form>
</body>
</html>

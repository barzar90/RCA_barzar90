<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandlerSamples.aspx.cs" Inherits="MOLFrameWork.Handler.STD.HandlerSamples" %>

<%@ Register src="../../Controls/AdminControls/MOLImage.ascx" tagname="MOLImage" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />    
    <script src="../../Scripts/file-upload.js" type="text/javascript"></script>
    <script src="../../Scripts/min.js" type="text/javascript"></script>
    <link href="../../Styles/fileuploader.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form3" runat="server">
    <div>
        <input type="file"  id="abc" name="abc"/>
        <input type="submit" id="kkk" value="submit" />
        <button type="button" id="uiu" onclick="return sampleashx();">test</button>
    </div>
    <div>
        <input type="text"  id="Text1" name="Field1"/>
        <input type="text"  id="Text2" name="Field2"/>
        <input type="text"  id="Text3" name="Field3"/>
        <input type="text"  id="Text4" name="Field4"/>
        <input type="text"  id="Text5" name="Field5"/>
        <button type="button" id="Button2" onclick="return sampleashx();">test</button>
    </div>

    <div style="height: 103px; width: 782px">
        <div style="width: 525px">
            
        </div>
    </div>    
    <uc1:MOLImage ID="MOLImage1" runat="server" />
    </form>
</body>
</html>

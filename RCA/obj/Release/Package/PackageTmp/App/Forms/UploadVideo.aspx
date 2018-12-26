<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="UploadVideo.aspx.cs" Inherits="RCA.App.Forms.UploadVideo" %>

<%@ Register assembly="TextBoxServerControl" namespace="TextBoxServerControl" tagprefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <style type="text/css">
        .style1
        {
            width: 285px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Audio and Video Upload</h1>

<div>
      <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
 </div>

 <table class="t_view">

             <tr>
            <td class="style1" align="right">
                    <asp:Label ID="lblSelectMediaType" runat="server" Text="Select Media Type"></asp:Label>
                </td>
                <td colspan="2" align="left">
                    <asp:DropDownList ID="ddlSelectMEdiaType" runat="server" ValidationGroup="VC" AutoPostBack="true">
                       
                        <asp:ListItem Value="0">Select Media Type</asp:ListItem>
                        <asp:ListItem Value="1">Audio</asp:ListItem>
                        <asp:ListItem Value="2">Video</asp:ListItem>
                    </asp:DropDownList>
                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSelectMEdiaType"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red" InitialValue="0 " 
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>--%>

                </td>
            </tr>
            <tr id="trVideo" runat="server" visible="false">
            <td class="style1" align="right">
                    <asp:Label ID="lblVideoUpload" runat="server" Text="Video Upload"></asp:Label>
                </td>
                <td colspan="2" align="left">
                    <asp:FileUpload ID="FileUpload1" runat="server" ValidationGroup="VC"/>
                    <asp:Label ID="Label1" runat="server" Text="Label" style="color: Red; font-size: x-small; display: inline;"><span style="color: Red">Size Should Be Upto 100MB </span></asp:Label>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red" InitialValue=""
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>--%>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1"  
                      ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" InitialValue="" Font-Size="X-Small"> This is required field</asp:RequiredFieldValidator> --%>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="FileUpload1"
                     ErrorMessage="Only .avi, .mpg, .mpg, .flv, .wmv and .mp4 Video formats are allowed." ForeColor="Red"
                     ValidationExpression="^([0-9a-zA-Z_\-~ :\\])+(.avi|.AVI|.wmv|.WMV|.flv|.FLV|.mpg|.MPG|.mp4|.MP4)$"
                     ValidationGroup="VC" SetFocusOnError="true"></asp:RegularExpressionValidator>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" Display="Dynamic" 
                    SetFocusOnError="True" ErrorMessage="Only .avi, .mpg, .wav, .mid, .wmv, .asf and .mpeg Video formats are allowed." 
                    ControlToValidate="FileUpload1" InitialValue="" Font-Size="X-Small" ValidationGroup="VC"
                    ValidationExpression="/^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.avi|.AVI|.WMV|.wmv|.wav|.WAV|.mpg|.MPG|.mid|.MID|.asf|.ASF|.mpeg|.MPEG)$/"
                    ></asp:RegularExpressionValidator>--%>
               </td>
            </tr>
            
           <!--  -------------------Added on 05062014-------------------------------->
            <tr id="trAudio" runat="server" visible="false">
            <td class="style1" align="right">
                    <asp:Label ID="Label3" runat="server" Text="Audio Upload"></asp:Label>
                </td>
                <td colspan="2" align="left">
                    <asp:FileUpload ID="FileUpload2" runat="server" ValidationGroup="VC"/>
                    <asp:Label ID="Label4" runat="server" Text="Label" style="color: Red; font-size: x-small; display: inline;"><span style="color: Red">Size Should Be Upto 100MB </span></asp:Label>

               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FileUpload2"  
                      ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" InitialValue="" Font-Size="X-Small"> This is required field</asp:RequiredFieldValidator> --%>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" 
                    SetFocusOnError="True"  ErrorMessage="Only mp3 files are allowed!" 
                    ValidationExpression="^.+(.mp3|.MP3)$"
                    ControlToValidate="FileUpload2" InitialValue="" Font-Size="X-Small" ValidationGroup="VC"></asp:RegularExpressionValidator>

              <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" 
                    SetFocusOnError="True" ErrorMessage="Only .mp3, .MP3, .mpeg, .MPEG, .m3u and .M3U audio formats are allowed." 
                    ControlToValidate="FileUpload2" InitialValue="" Font-Size="X-Small" ValidationGroup="VC"
                    ValidationExpression="/^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.mp3|.MP3|.mpeg|.MPEG|.m3u|.M3U)$/"
                    ></asp:RegularExpressionValidator>  --%>  
               </td>
            </tr>
           <!--  -------------------End-------------------------------->
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="lblMediaName" runat="server" Text="Video/Audio name"></asp:Label>
                </td>
                <td align="left">

                <cc1:TextBoxControl ID="txtvideoname" runat="server" DestinationLanguage="ENGLISH" 
                    onclick="this.value = ( this.value == this.defaultValue ) ? '' : this.value;return true;" 
                    onkeypress=" return ValidateCharacter('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_. ', event);" 
                    CDACDestinationLanguage="MARATHI" TargetID="txtvideoname_LL" TypingMode="CDAC"></cc1:TextBoxControl>
                   <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtvideoname"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>--%>
                                         
                </td>
            </tr>
             <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblMediaNameLL" runat="server" Text="Video/Audio name Marathi"></asp:Label>
                </td>
                <td align="left">
                 <cc1:TextBoxControl ID="txtvideoname_LL" runat="server" 
                    DestinationLanguage="ENGLISH" TypingMode="CDAC"></cc1:TextBoxControl>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtvideoname_LL"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
--%>


                   <%-- <asp:TextBox ID="txtvideoname_LL" runat="server" ValidationGroup="VC"></asp:TextBox>--%>
                    
                </td>
            </tr>
<%--            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
 
                </td>
            </tr>--%>
            <tr>
<%--                <td class="style1">
                    &nbsp;</td>--%>
                <td colspan="2" align="center">
                 <asp:Button ID="btnInvoke" CssClass="button" Width="81px" Height="35" runat="server" onclick="btnInvoke_Click" Text="Upload" ValidationGroup="VC"/>
                </td>
            </tr>
            <tr>
             <%--   <td class="style1">
                    &nbsp;</td>--%>
                <td colspan="2" align="center">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

</asp:Content>

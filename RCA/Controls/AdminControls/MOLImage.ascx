<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MOLImage.ascx.cs" Inherits="MSHC.Controls.AdminControls.MOLImage" %>
<asp:Panel ID="pnlImg" runat="server">
    <div>
        <asp:PlaceHolder ID="IMG" runat="server">
        </asp:PlaceHolder>
    </div>
    <label class="file-upload" style="display: none">
        <span class="ImgUpload">
            <input type="button" onclick="DisplayWindow('../../CaptureImage.aspx?RID=0&amp;ID=1&amp;IID=<% Response.Write(ImageText); %>&amp;TID=1&amp;SEC=Sec11&amp;UIT=C1&amp;FID=<% Response.Write(ImageID); %>','Upload Image',400,850); return;"
                value="New" />
            Upload Image</span> <span class="ImgUpload">
                <input type="button" onclick="DisplayWindow('../../CaptureImage.aspx?RID=0&amp;ID=1&amp;IID=<% Response.Write(ImageText); %>&amp;TID=1&amp;SEC=Sec11&amp;UIT=U0&amp;FID=<% Response.Write(ImageID); %>','Upload Image',400,850); return;"
                    value="New" />
                Upload Image</span>
    </label>
    <div class="wrapBtns">
        <img class="camImg" title="Capture Image by Web Camera" alt="Capture Image by Web Camera"
            src="../../Images/webcamera.png" onclick="DisplayWindow('../../CaptureImage.aspx?RID=0&amp;ID=1&amp;IID=<% Response.Write(ImageText); %>&amp;TID=1&amp;SEC=Sec11&amp;TP=C&amp;FID=<% Response.Write(ImageID); %>','Upload Image',370,415); return;"
             />
        <img class="fileImg" title="Upload Image by File" alt="Upload Image by File" src="../../Images/fileImage.png"
            onclick="DisplayWindow('../../CaptureImage.aspx?RID=0&amp;ID=1&amp;IID=<% Response.Write(ImageText); %>&amp;TID=1&amp;SEC=Sec11&amp;TP=U&amp;FID=<% Response.Write(ImageID); %>','Upload Image',370,415); return;"
            />
    </div>
</asp:Panel>
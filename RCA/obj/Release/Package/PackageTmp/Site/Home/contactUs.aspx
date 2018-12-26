<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="contactUs.aspx.cs" Inherits="RCA.Site.Home.contactUs" %>
<%@ Register Src="~/Controls/WebSiteControls/TextCaptcha.ascx" TagName="TextCaptcha" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
.services .container {background:none;}
section { position:relative}
.footerTop { clear:both}
.directions-card { display:none!important; width:1px!important; position:relative; z-index:-100}
.gm-style .directions-card-medium-large { width:1px!important; display:none!important; position:relative; z-index:-100}
</style>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">
    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m8!1m3!1d120557.0163272321!2d72.7448755449219!3d19.22109655630387!3m2!1i1024!2i768!4f13.1!4m7!1i0!3e6!4m0!4m3!3m2!1d19.210722!2d72.90966999999999!5e0!3m2!1sen!2sin!4v1410277939127" class="history-bg" frameborder="0" style="border:0"></iframe>
    <div class="container">
     <h1>Contact Us</h1>
    <script language="javascript" type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function IsAlphabet(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode

            var txt = String.fromCharCode(charCode)

            if (txt.match(/^[a-zA-Z\b ]+$/))

                return true

            return false

        }

        function validate() {

            if (document.getElementById("txtEmail").value == "") {
                alert("Please enter EmailID");
                document.getElementById("txtEmail").focus();
                return false;
            }
          
     

        }
   
        </script>
        <div class="form-horizontal">
            <h2>Send Your Feedback</h2>
            <div class="form-group">
            <asp:Label ID="Label1" AssociatedControlID="txtName" runat="server">Name :</asp:Label>
            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" onkeypress="return IsAlphabet(event);" MaxLength="40"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the information requested." ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
            </div>
    
            <div class="form-group">
            <asp:Label ID="Label5" AssociatedControlID="txtcontact" runat="server">Contact No :</asp:Label>
            <asp:TextBox ID="txtcontact" CssClass="form-control" runat="server" onkeypress="return isNumberKey(event)" MaxLength="12"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter the information requested." ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
            </div>
                
            <div class="form-group">
            <asp:Label ID="Label2" AssociatedControlID="txtEmail" runat="server">Email Id :</asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the information requested." ControlToValidate="txtEmail"></asp:RequiredFieldValidator>&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid emailid" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
            <asp:Label ID="Label3" AssociatedControlID="txtSubject" runat="server">Subject:</asp:Label>
            <asp:TextBox ID="txtSubject" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the information requested." ControlToValidate="txtSubject"></asp:RequiredFieldValidator>&nbsp;
            </div>

            <div class="form-group">
            <asp:Label ID="Label4" AssociatedControlID="txtMessage" runat="server">Feedback :</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" id="txtMessage" rows="5" cols="24" TextMode="MultiLine"  ></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter a message." ControlToValidate="txtMessage"></asp:RequiredFieldValidator>&nbsp;
            </div>

            <div class ="form-group">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <uc1:TextCaptcha ID="TextCaptcha1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>            
            </div>

            <div class="form-group">
            <asp:Button runat="server" ID="btnSend" Text="Send" CssClass="btn margin" OnClick="btnSend_Click"  OnClientClick="javascript:return validate();"   />
            <asp:Button runat="server" ID="btnReset" CssClass="btn" Text="Reset" onclick="btnReset_Click" />
            </div>

            <div class="form-group">
            <asp:Label ID="lblMessage" runat="server" Visible="false"   ></asp:Label>
            </div>
        </div>
        <div class="contact contactafter">
        <h2> Swachh Maharashtra Mission Urban Development </h2>
            <address>
                <p><b>Address:</b> Borivali East, Mumbai, Maharashtra 400066
                <br><b>Phone:</b> 022 2886 0362 / 022-28860389 
                <br><b>Email:</b> sgnpmumbai@gmail.com
                <br><b>Fax:</b> 022 28864567 
                <br><b>Control room:</b>  022 28866449</p>


            </address>
        </div>
        <div class="contact ">
        <h2>Nature Information Center, SGNP</h2>
            <address>
                <p><b>Phone:</b>  022-28847800 (office) / +91- 9969190671 (mob. Mr. Pagare)<br />
                Jagdish Vakale: +91- 9320267527
                <br><b>Email:</b> nicsgnp78@gmail.com</p>


            </address>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" Inherits="MSHC.Site.Information.Complaints" CodeBehind="complaints.aspx.cs" %>

<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/WebSiteControls/TextCaptcha.ascx" TagName="Captcha"
    TagPrefix="UCCaptcha" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script src="../../Scripts/CommonValidations.js" type="text/javascript"></script>--%>
    <%--<span class="pageTitle">Online Grievance </span>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="Server">
<uc:BreadCrum ID="BreadCrum1" runat="server" />
    <h1>
        <asp:Label ID="lblComplaintPageTitle" runat="server"></asp:Label></h1>
    <div>
        <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
    </div>
    <div class="col" style="margin-bottom: 10px">
        <div>
            <div class="formLabel">
                <asp:Label ID="lblFullName" runat="server" Text="Full Name" AssociatedControlID="txtFullName"></asp:Label><span
                    style="color: #f00;">*</span>
            </div>
            <div class="formLabelDescription">
                <cc1:TextBoxControl ID="txtFullName" runat="server" CDACDestinationLanguage="MARATHI"
                    EnableKeyboard="true" MaxLength="50" ToolTip="" TypingMode="CDAC" Width="250px"
                    DestinationLanguage="ENGLISH"></cc1:TextBoxControl>
                <%--    <asp:TextBox ID="txtFullName" MaxLength="50" runat="server" Width="250px" />--%>
                <%--<asp:RequiredFieldValidator ID="reqtFullName" runat="server" ControlToValidate="txtFullName"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC">This Field in blank</asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div>
            <div class="formLabel">
                <asp:Label ID="lblDepartment" runat="server" Text="Department " AssociatedControlID="drpDepartment"></asp:Label><span
                    style="color: #f00;">*</span>
            </div>
            <div class="formLabelDescription">
                <asp:DropDownList ID="drpDepartment" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div class="formLabel">
                <asp:Label ID="lblCountry" runat="server" Text="Country" AssociatedControlID="DrpCountry"></asp:Label>
            </div>
            <div class="formLabelDescription">
                <asp:DropDownList ID="DrpCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DrpCountry_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div class="formLabel">
                <asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="Drpstate"></asp:Label>
            </div>
            <div class="formLabelDescription">
                <asp:DropDownList ID="Drpstate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Drpstate_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div class="formLabel">
                <asp:Label ID="lblDistrict" runat="server" Text="District" AssociatedControlID="Drpdistrict"></asp:Label>
            </div>
            <div class="formLabelDescription">
                <asp:DropDownList ID="Drpdistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Drpdistrict_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div class="formLabel">
                <asp:Label ID="lblTaluka" runat="server" Text="Taluka" AssociatedControlID="DrpTaluka"></asp:Label>
            </div>
            <div class="formLabelDescription">
                <asp:DropDownList ID="DrpTaluka" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div class="formLabel">
                <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No " AssociatedControlID="txtTelephoneNo"></asp:Label><span
                    style="color: #f00;">*</span>
            </div>
            <div class="formLabelDescription">
                <asp:TextBox ID="txtTelephoneNo" MaxLength="10" runat="server" />
            </div>
        </div>
        <div>
            <div class="formLabel">
                <asp:Label ID="lblEmailId" runat="server" Text="Email Id " AssociatedControlID="txtEmailId"></asp:Label><span
                    style="color: #f00;">*</span>
            </div>
            <div class="formLabelDescription">
                <asp:TextBox ID="txtEmailId" MaxLength="50" runat="server" Width="250px" />
            </div>
        </div>
        <div>
            <div style="height: 80px" class="formLabel">
                <asp:Label ID="lblAddress" runat="server" Text="Address" AssociatedControlID="Txtaddress"></asp:Label><span
                    style="color: #f00;">*</span>
            </div>
            <div style="height: 80px" class="formLabelDescription">
                <cc1:TextBoxControl ID="Txtaddress" runat="server" CDACDestinationLanguage="MARATHI"
                    EnableKeyboard="false" ToolTip="" TypingMode="CDAC" DestinationLanguage="ENGLISH"
                    Width="380px" MaxLength="500" Height="65px" Transliteration="ADDRESS"></cc1:TextBoxControl>
                <%-- <asp:TextBox ID="Txtaddress" MaxLength="500" runat="server" Width="380px" TextMode="MultiLine" 
                    Height="65px" />
                --%>
            </div>
        </div>
        <div>
            <div style="height: 80px" class="formLabel">
                <asp:Label ID="lblComplaints" runat="server" Text="Suggetions/Complaints <br/>/Information "
                    AssociatedControlID="txtComplaints"></asp:Label><span style="color: #f00;">*</span>
            </div>
            <div style="height: 80px" class="formLabelDescription">
                <cc1:TextBoxControl ID="txtComplaints" runat="server" CDACDestinationLanguage="MARATHI"
                    EnableKeyboard="false" ToolTip="" TypingMode="CDAC" DestinationLanguage="ENGLISH"
                    Width="380px" MaxLength="500" TextMode="MultiLine" Height="65px"></cc1:TextBoxControl>
                <%-- <asp:TextBox ID="txtComplaints" MaxLength="500" runat="server" Width="380px" TextMode="MultiLine"
                    Height="65px" />--%>
            </div>
        </div>
        <div style="display:none;">
            <div class="formLabel" style="height: 60px;">
                <asp:Label ID="Lblcaptcha" runat="server" Text="Enter Answer"></asp:Label>
            </div>
            <div class="formLabelDescription" style="height: 60px">
                <asp:TextBox ID="TextBox1" MaxLength="10" runat="server" />
               
            </div>
        </div>
        
            <UCCaptcha:Captcha ID="ucCaptcha" runat="server" />

    </div>
    <div class="col">
        <div class="col">
            <asp:Button ID="btnSendComplaint" runat="server" Text="Send Complaint" OnClick="btnSendComplaint_Click"
                ValidationGroup="VC" CssClass="button" />
            <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" CssClass="button" /></div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" Inherits="RCA.Site.Information.feedback" CodeBehind="feedback.aspx.cs" %>

<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/WebSiteControls/TextCaptcha.ascx" TagName="Captcha"
    TagPrefix="UCCaptcha" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="Server">
    <script src="../../Scripts/CommonValidations.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="Server">
    
 
        <h1>
            <asp:Label ID="lbl_Feedback" runat="server"></asp:Label></h1><uc:BreadCrum ID="BreadCrum1" runat="server" />
        <div>
            <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
        </div>
        <div class="well">
        <div class="col-md-6">
        <div class="form-group">
        <asp:Label ID="lblName" runat="server" Text="Applicant's Name" AssociatedControlID="txtName"></asp:Label>
                <span style="color: #f00;">*</span>:
                <cc1:TextBoxControl CssClass="form-control" ID="txtName" runat="server" CDACDestinationLanguage="MARATHI"
                    EnableKeyboard="true" MaxLength="50" ToolTip="" TypingMode="CDAC"
                    DestinationLanguage="ENGLISH" AutoComplete="off" Width="400px"></cc1:TextBoxControl>
        </div>
        </div>
        <div class="clearfix"></div>
        </div>
       <table class="table table-striped table-bordered">
        <tr>
            <td>
                
            </td>
            <td>
            
            </td>
        </tr>
        <tr style="display:none">
            <td>
                <asp:Label ID="lblDepartment" runat="server" Text="Department" AssociatedControlID="drpDepartment"></asp:Label><span
                    style="color: #f00;">*</span>:
            </td>
            <td>
                <asp:DropDownList ID="drpDepartment" runat="server" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display:none">
            <td>
                <asp:Label ID="LblCOuntry" runat="server" AssociatedControlID="DrpCountry" Text="Country"></asp:Label>:
            </td>
            <td>
                <asp:DropDownList ID="DrpCountry" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="DrpCountry_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lblstate" runat="server" AssociatedControlID="Drpstate" Text="State"></asp:Label>:
            </td>
            <td>
                <asp:DropDownList ID="Drpstate" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="Drpstate_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
         <tr style="display:none">
            <td>
                <asp:Label ID="Lbldivision" runat="server" AssociatedControlID="Drpdivision" Text="Division"></asp:Label>:
            </td>
            <td>
                <asp:DropDownList ID="Drpdivision" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="Drpdivision_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblDistrict" runat="server" AssociatedControlID="Drpdistrict" Text="District"></asp:Label>:
            </td>
            <td>
                <asp:DropDownList ID="Drpdistrict" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="Drpdistrict_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblCity" runat="server" AssociatedControlID="DrpCity" Text="City"></asp:Label>:
            </td>
            <td>
                <asp:DropDownList ID="DrpCity" runat="server" AutoPostBack="false" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display:none">
            <td>
                <asp:Label ID="LblTaluka" runat="server" AssociatedControlID="DrpTaluka" Text="Taluka"></asp:Label>:
            </td>
            <td>
                <asp:DropDownList ID="DrpTaluka" runat="server" Width="265px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblMobileNo" runat="server" AssociatedControlID="txtTelephoneNo" Text="Mobile No"></asp:Label><span
                    style="color: #f00;">*</span>:
                <%-- <asp:Label ID="lblContactNoMsg" runat="server" CssClass="span"></asp:Label>--%>
            </td>
            <td>
                <asp:TextBox ID="txtTelephoneNo" MaxLength="10" runat="server" Width="250px" AutoComplete="off" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmailId" runat="server" Text="Applicant's Email Id " AssociatedControlID="txtEmailId"></asp:Label><span
                    style="color: #f00;">*</span>:
            </td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="50"  AutoComplete="off"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblAddress" runat="server" Text="Address" AssociatedControlID="Txtaddress"></asp:Label><span
                    style="color: #f00;">*</span>:
            </td>
            <td>
                <cc1:TextBoxControl ID="Txtaddress" runat="server" CDACDestinationLanguage="MARATHI"
                    EnableKeyboard="false" ToolTip="" TypingMode="CDAC" DestinationLanguage="ENGLISH"
                     MaxLength="500" Height="65px"  Width="400px" Transliteration="ADDRESS" AutoComplete="off"></cc1:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFeedback" runat="server" Text="Feedback" AssociatedControlID="txtFeedback"></asp:Label>
                <span style="color: #f00;">*</span>:
                <asp:Label ID="lblFeedBackMsg" runat="server" CssClass="span"></asp:Label>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtFeedback" runat="server" CDACDestinationLanguage="MARATHI"
                    EnableKeyboard="false" ToolTip="" TypingMode="CDAC" DestinationLanguage="ENGLISH"
                     MaxLength="500" TextMode="MultiLine" Height="65px" Width="400px" AutoComplete="off"></cc1:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTextCapachAns" runat="server" CssClass="span" Text="Enter Answer"
                    AssociatedControlID="ucCaptcha"></asp:Label>
                <span style="color: #f00;">*</span>:
            </td>
            <td>
                <UCCaptcha:Captcha ID="ucCaptcha" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                    CssClass="btn-success btn btn-sm" ValidationGroup="VC" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn-success btn  btn-sm" OnClick="btnReset_Click1" />
            </td>
        </tr>
    </table>
    
</asp:Content>

<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="RCA.Site.Common.Feedback" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/TextCaptcha.ascx" TagName="Captcha"
    TagPrefix="UCCaptcha" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .formLabel {
            width: 260px !important;
            height: 85px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">
    <div class="headingBg">
        <h1>
            <%--<i class="fa fa-inr"></i>--%>
            <asp:Label ID="lblFeedbackHeading" runat="server" Text="Feedback"></asp:Label></h1>
        <uc:BreadCrum ID="BreadCrum" runat="server" />

    </div>


    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
        <div class="searchMarg">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Save" ShowMessageBox="true" CssClass="failureNotification" />
        </div>
        <div class="searchInner searchMarg">
            <asp:Label ID="lblMandatory" runat="server" CssClass="errorMsg" Text="* denotes mandatory fields" Height="18px"></asp:Label>

            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="t_view">
                <tr>
                    <td class="lblText" height="40px" valign="top" width="25%">
                        <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td valign="top" width="75%">
                        <asp:TextBox ID="txtName" runat="server" Width="250px" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Please Enter Name" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="lblText" height="40px" valign="top" width="25%">
                        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td valign="top" width="75%">
                        <asp:TextBox ID="txtEmail" runat="server" ToolTip="" Width="250px" MaxLength="254"></asp:TextBox>

                        <asp:FilteredTextBoxExtender ID="fteEmail" runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers"
                            ValidChars="_@." TargetControlID="txtEmail">
                        </asp:FilteredTextBoxExtender>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email-id"
                            ValidationGroup="Save" Display="None" ControlToValidate="txtEmail" ForeColor="Red"
                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" SetFocusOnError="true"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="lblText" height="40px" valign="top" width="25%">
                        <asp:Label ID="lblMobile" AssociatedControlID="txtMobile" runat="server" Text="Mobile"></asp:Label>
                    </td>
                    <td valign="top" width="75%">
                        <asp:TextBox ID="txtMobile" runat="server" ToolTip="" Width="250px" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Mobile Number must be 10-digit number" ControlToValidate="txtMobile"
                            Display="None" ValidationGroup="Save" SetFocusOnError="true" ForeColor="Red" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                        <asp:FilteredTextBoxExtender ID="fteEngPhone" runat="server" FilterType="Numbers,Custom"
                            ValidChars="/- ," TargetControlID="txtMobile">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td class="lblText" height="40px" valign="top" width="25%">
                        <asp:Label ID="lblSub" AssociatedControlID="TxtSubject" runat="server" Text="Subject"></asp:Label>
                    </td>
                    <td valign="top" width="75%">

                        <asp:TextBox ID="TxtSubject" runat="server" ToolTip="" Width="250px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="TxtSubject"
                            ErrorMessage="Please Enter Subject" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="lblText" height="95px" valign="top" width="26%">
                        <asp:Label ID="lblFeedback" AssociatedControlID="txtFeedback" runat="server" Text="Feedback"></asp:Label>
                    </td>
                    <td valign="top" width="74%">
                        <asp:TextBox ID="txtFeedback" runat="server" Width="250px" TextMode="MultiLine" Rows="4" ToolTip=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFeedback" runat="server" ErrorMessage="Please Enter Feedback"
                            ControlToValidate="txtFeedback" Display="None" ValidationGroup="Save" ForeColor="Red"
                            CssClass="errorMsg" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="100%" height="40px">
                        <UCCaptcha:Captcha ID="ucCaptcha" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="25px" align="center" valign="top" width="100%">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" ValidationGroup="Save"
                            OnClick="btnSubmit_Click" />&nbsp;
                        <asp:Button ID="btnReset" runat="server" CssClass="button" Text="Reset" OnClick="btnReset_Click" />
                    </td>
                </tr>

            </table>
        </div>
    </asp:Panel>


</asp:Content>

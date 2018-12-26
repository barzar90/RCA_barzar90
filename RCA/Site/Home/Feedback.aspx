<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="MSHC.Site.Home.Feedback" %>
<%@ Register Src="~/Controls/WebSiteControls/TextCaptcha.ascx" TagName="Custom" TagPrefix="TextCapcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
      <div>
        <table>
            <tr>
                <td align="center" width="60%">
                    <table width="100%">
                        <tr>
                            <td colspan="2">                                
                                <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                                <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Email Id"></asp:Label>
                                <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Contact No."></asp:Label>
                                <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactNo" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Division"></asp:Label>
                                <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDivision" runat="server" Width="160px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="District"></asp:Label>
                                <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDistrict" runat="server" Width="160px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged1">
                                </asp:DropDownList>
                                <asp:Button ID="Button1" runat="server" Text="Get District" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Taluka"></asp:Label>
                                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTaluka" runat="server" Width="160px">
                                </asp:DropDownList>
                                <asp:Button ID="Button2" runat="server" Text="Get Taluka" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Society Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSocietyName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Feedback"></asp:Label>
                                <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" 
                                    Height="231px" Width="536px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <TextCapcha:custom id="uctextcapcha" runat="server" />
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

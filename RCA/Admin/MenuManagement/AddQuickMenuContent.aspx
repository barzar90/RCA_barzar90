<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="AddQuickMenuContent.aspx.cs" Inherits="MSHC.Admin.MenuManagement.AddQuickMenuContent" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
     <h1><asp:Label ID="lbltitle" runat="server" Text="Add Quick Menu Content"></asp:Label></h1>
        <table width="100%" class="t_view">
            <tr>
                <td nowrap="nowrap" width="200px">
                    <asp:Label ID="lblPgTitle" runat="server" Text="Page Title"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPageTitle" CssClass="textEntry" runat="server" Width="450px"></asp:TextBox>&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RFV_txtPageTitle" runat="server" ErrorMessage="Please Give the Title"
                        Display="Dynamic" ForeColor="Red" ControlToValidate="txtPageTitle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" width="200px">
                    <asp:Label ID="lblpagetitle_LL" runat="server" Text="Local Language Page Title"></asp:Label>
                </td>
                <td>
                    <asp:TextBoxControl ID="txtpageTitle_LL" runat="server" CssClass="textEntry" Width="450px">
                    </asp:TextBoxControl>
                    <asp:RequiredFieldValidator ID="RFV_txtpageTitle_LL" runat="server" ErrorMessage="Please Give Local Language Page Title"
                        Display="Dynamic" ForeColor="Red" ControlToValidate="txtpageTitle_LL"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" width="200px">
                    <asp:Label ID="lblSDescription" runat="server" Text="Short Description"></asp:Label>
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="FCKeditor1"  ForcePasteAsPlainText="true" FormatSource="true"  ToolbarSet="Basic"  runat="server" Height="300px" Width="730px">
                    </FCKeditorV2:FCKeditor>
                       </td>
            </tr>
            <tr>
                <td nowrap="nowrap" width="200px">
                    <asp:Label ID="lblSDescription_LL" runat="server" Text="Local Language Short Description"></asp:Label>
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="FCKeditor2"  ForcePasteAsPlainText="true" FormatSource="true"  ToolbarSet="Basic"  runat="server" Height="300px" Width="730px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" width="200px">
                    <asp:Label ID="lblLDescription" runat="server" Text="Long Description"></asp:Label>
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="FCKeditor3"  ForcePasteAsPlainText="true" FormatSource="true"  ToolbarSet="Basic"  runat="server" Height="300px" Width="730px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" width="200px">
                    <asp:Label ID="lblLongDescription_LL" runat="server" Text="Local Language Long Description"></asp:Label>
                </td>
                <td>
                    <FCKeditorV2:FCKeditor ID="FCKeditor4"  ForcePasteAsPlainText="true" FormatSource="true"  ToolbarSet="Basic"  runat="server" Height="300px" Width="730px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" width="200px">
                    <asp:Label ID="lblsequence" runat="server" Text="Sequence No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSequenceNo" runat="server" CssClass="textEntry" Width="99px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FTBESequence" runat="server" FilterType="Numbers"
                        ValidChars="0123654789" TargetControlID="txtSequenceNo">
                    </asp:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RFV_txtSequenceNo" runat="server" ErrorMessage="Please specify the Sequence Number"
                        Display="Dynamic" ForeColor="Red" ControlToValidate="txtSequenceNo"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
            <td>
                Is Active?
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" />
            </td>
            </tr>
            <tr>
            <td>
                Is Approve?
            </td>
            <td>
                <asp:CheckBox ID="chkIsApprove" runat="server" />
            </td>
            </tr>
            <tr>
                <td nowrap="nowrap" width="200px">
                </td>
                <td>
                    <asp:Button ID="btn_Save" runat="server" CssClass="button" Text="Save" Width="68px" OnClick="btn_Save_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btn_Cancel" runat="server" CssClass="button" Text="Cancel" Width="68px" CausesValidation="false" OnClick="btn_Cancel_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>

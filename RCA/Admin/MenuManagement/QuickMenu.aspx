<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="QuickMenu.aspx.cs" Inherits="MSHC.Admin.MenuManagement.QuickMenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <h1>Quick Menu</h1>
        <table class="t_view">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Select 
                    Quick Menu"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="drpQuickMenu" Width="340" DataTextField="QuickMenuName" DataValueField="QuickMenuID"
                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpMenu_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="drpSubQuickMenu" Width="340" DataTextField="QuickMenuName" DataValueField="QuickMenuID"
                        Visible="false" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Quick Menu </td>
                <td>
                    <asp:TextBox ID="txtMenuName" CssClass="textEntry" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtMenuName"
                        runat="server" ErrorMessage="Please enter menu name."></asp:RequiredFieldValidator>
                </td>
                <td>
                    In Local Language <span style="color: Red;">*</span>
                </td>
                <td>
                    <asp:TextBoxControl ID="txtMenuName_LL" runat="server" DestinationLanguage="MARATHI"
                        CssClass="textEntry"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtMenuName_LL"
                        runat="server" ErrorMessage="Please enter local language menu name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Menu Type
                </td>
                <td>
                    <asp:DropDownList ID="drpMenuType" Width="340" DataTextField="MenuType" DataValueField="RowID"
                        runat="server" AutoPostBack="True" 
                        onselectedindexchanged="drpMenuType_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ForeColor="Red" ControlToValidate="drpMenuType"
                        runat="server" ErrorMessage="Please select menu type."></asp:RequiredFieldValidator>
                </td>
                <td>
                    Value
                </td>
                <td>
                    <asp:TextBox ID="txtMTValue" CssClass="textEntry" runat="server" 
                        MaxLength="450" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="txtMTValue"
                        runat="server" ErrorMessage="please enter manu type value."></asp:RequiredFieldValidator>
                </td>
            </tr>


            <tr>
                <td>
                    Page Title <span style="color: Red;">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPageTitle" CssClass="textEntry" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" ControlToValidate="txtPageTitle"
                        runat="server" ErrorMessage="Please enter Page Title."></asp:RequiredFieldValidator>
                </td>
                <td>
                    Local Language Page Title <span style="color: Red;">*</span>
                </td>
                <td>
                    <asp:TextBoxControl ID="txtPageTitle_LL" runat="server" DestinationLanguage="MARATHI"
                        CssClass="textEntry"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" ControlToValidate="txtPageTitle_LL"
                        runat="server" ErrorMessage="Please enter local language Page Title."></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>
                    Page Heading <span style="color: Red;">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPageHead" CssClass="textEntry" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" ControlToValidate="txtPageHead"
                        runat="server" ErrorMessage="Please enter Page Head."></asp:RequiredFieldValidator>
                </td>
                <td>
                    Local Language Page Heading <span style="color: Red;">*</span>
                </td>
                <td>
                    <asp:TextBoxControl ID="txtPageHead_LL" runat="server" DestinationLanguage="MARATHI"
                        CssClass="textEntry"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" ControlToValidate="txtPageHead_LL"
                        runat="server" ErrorMessage="Please enter local language Page Head."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Meta Description
                </td>
                <td>
                    <asp:TextBox ID="txtMDesc" TextMode="MultiLine" CssClass="textEntry" Rows="6" Columns="40"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    In Local Language</td>
                <td>
                    <asp:TextBoxControl ID="txtMDesc_LL" runat="server" TextMode="MultiLine" Width="320"
                        Rows="6" Columns="40" DestinationLanguage="MARATHI" CssClass="textEntry"></asp:TextBoxControl>
                </td>
            </tr>
            <tr>
                <td>
                    Meta Keywords
                </td>
                <td>
                    <asp:TextBox ID="txtMKeywords" TextMode="MultiLine" Rows="6" Columns="40" runat="server"></asp:TextBox>
                </td>
                <td>
                    In Local Language
                </td>
                <td>
                    <asp:TextBoxControl ID="txtMKeyWords_LL" runat="server" Width="320" TextMode="MultiLine"
                        Rows="6" Columns="40" DestinationLanguage="MARATHI" CssClass="textEntry"></asp:TextBoxControl>
                </td>
            </tr>
            <tr>
                <td>
                   Quick Menu Image
                
                </td>
                <td>
                    <asp:FileUpload ID="fileMenu" runat="server" />
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    Sequence No <span style="color: Red;">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtSequence" CssClass="textEntry" runat="server" Width="99px"></asp:TextBox>
                    <br />
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtSequence" ValidChars="0123654789" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtSequence"
                        runat="server" ErrorMessage="Please enter sequence number."></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                        runat="server" ValidationExpression="[0-9]*\.?[0-9]*" Display="Dynamic" ControlToValidate="txtSequence"
                        ErrorMessage="Please enter only number"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Is New Flag ?
                </td>
                <td>
                    <asp:CheckBox ID="chkIsNew" runat="server" />
                </td>
                <td>
                    Is Active ?
                </td>
                <td>
                   <asp:CheckBox ID="chkActive" runat="server" />
                </td>
            </tr>
            <tr>
              <td>
                Is need to open in Tab?
              </td>
              <td>
                <asp:CheckBox ID="chkNewTab"  runat="server" />
              </td>
               <td> Is use in Mobile version?</td>
              <td><asp:CheckBox ID="chkmobileversion"  runat="server" /></td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Width="68px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClientClick="javascript:history.go(-1);" Width="68px" />
                </td>
            </tr>
        </table>
</asp:Content>

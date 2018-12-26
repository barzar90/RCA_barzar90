<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="ViewCR.aspx.cs" Inherits="RCA.Site.Common.ViewCR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function mycheckDate(sender, args) {
            var mydate = new Date();
            if (sender._selectedDate >= new Date()) {
                alert("You cannot select a day next than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date 
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
        function checktoDate() {
            var fromdate = document.getElementById('<%=txtFromDate.ClientID %>').value;
            var todate = document.getElementById('<%=txtToDate.ClientID %>').value;

            var fromdateval = new Date(fromdate);
            var todateval = new Date(todate);

            if (fromdateval > todateval) {
                alert("From Date cannot be greater than To Date");
                document.getElementById('<%=txtToDate.ClientID %>').focus();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h1>
            <asp:Label ID="lblCRHeading" runat="server" Text="Circular Resolutions"></asp:Label>
        </h1>
        <div class="searchInner searchMarg">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="25%" valign="middle" height="40px">
                        <asp:Label ID="lblFromDate" runat="server" Text="From Date" AssociatedControlID="txtFromDate"></asp:Label>
                    </td>
                    <td width="30%" valign="middle">
                        <asp:TextBox ID="txtFromDate" runat="server" Width="180px" CssClass="calIcon" onChange="return checktoDate();"
                            onKeyPress="javascript: return false;" onPaste="javascript: return false;"></asp:TextBox>
                        <asp:CalendarExtender ID="calFromDate" runat="server" TargetControlID="txtFromDate"
                            Format="dd MMM, yyyy" PopupButtonID="txtFromDate" OnClientDateSelectionChanged="mycheckDate">
                        </asp:CalendarExtender>
                    </td>
                    <td width="20%" valign="middle">
                        <asp:Label ID="lblToDate" runat="server" Text="To Date" AssociatedControlID="txtToDate"></asp:Label>
                    </td>
                    <td width="25%" valign="middle">
                        <asp:TextBox ID="txtToDate" runat="server" Width="180px" CssClass="calIcon" onChange="return checktoDate();"
                            onKeyPress="javascript: return false;" onPaste="javascript: return false;"></asp:TextBox>
                        <asp:CalendarExtender ID="calToDate" runat="server" TargetControlID="txtToDate" Format="dd MMM, yyyy"
                            PopupButtonID="txtToDate" OnClientDateSelectionChanged="mycheckDate">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td width="25%" valign="middle" height="40px">
                        <asp:Label ID="lblBranchDesk" runat="server" Text="Desk" AssociatedControlID="ddlDesk"></asp:Label>
                    </td>
                    <td width="30%" valign="middle">
                        <asp:DropDownList ID="ddlDesk" runat="server" Width="200px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td width="20%" valign="middle">
                        <asp:Label ID="lblKeywords" runat="server" Text="Keyword" AssociatedControlID="txtKeyword"></asp:Label>
                    </td>
                    <td width="25%" valign="middle">
                        <cc1:TextBoxControl ID="txtKeyword" runat="server" EnableKeyboard="false" ToolTip=""
                            Text="" TypingMode="CDAC" TargetID="" Transliteration="NAME" Width="200px"></cc1:TextBoxControl>
                    </td>
                </tr>
                <tr>
                    <td width="25%" height="18px">
                        <asp:Label ID="lblArchives" runat="server" Text="Current Or Archives" AssociatedControlID="rblArchives"></asp:Label>
                    </td>
                    <td width="75%" colspan="3" height="18px">
                        <asp:RadioButtonList ID="rblArchives" runat="server" RepeatDirection="Horizontal"
                            Width="40%" AutoPostBack="true">
                            <%--<asp:ListItem Value="1" Selected="True">Current</asp:ListItem>
                            <asp:ListItem Value="2">Archives</asp:ListItem>--%>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="4" align="center" valign="bottom" height="30px">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="85px" OnClick="btnSearch_Click"
                            CssClass="btnBG" />
                        &nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" Width="85px" OnClick="btnReset_Click"
                            CssClass="btnBG" />
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="NoRecords" align="center" class="innerCont" style="text-align: center;">
            <asp:Label ID="lblNoRecord" CssClass="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="grdCRList" runat="server" AllowPaging="true" PageSize="10" Width="100%"
                CssClass="tableClass" CellPadding="2" CellSpacing="2" GridLines="None" AutoGenerateColumns="false"
                HeaderStyle-BackColor="Green" OnPageIndexChanging="grdCRList_PageIndexChanging"
                OnRowCommand="grdCRList_RowCommand" OnDataBound="grdCRList_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RowID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdRowID" runat="server" Text='<%# Eval("ROWID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Desk" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdDesk" runat="server" Text='<%# Eval("DeskName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" HeaderStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdTitle" runat="server" Text='<%# Eval("FileTitle") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" HeaderStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdTitle_LL" runat="server" Text='<%# Eval("FileTitle_LL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdDescription" runat="server" Text='<%# Eval("FileDtl") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdDescription_LL" runat="server" Text='<%# Eval("FileDtl_LL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdIssueDate" runat="server" Text='<%# Eval("Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Circular No" HeaderStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="lblgrdCRNo" runat="server" Text='<%# Eval("No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View/Download" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ROWID") %>'
                                CommandName="ViewFile">
                                <asp:Image ID="image1" runat="server" ImageUrl="~/Images/download.png" />
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#E2E2E2" ForeColor="#000099" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <PagerStyle CssClass="grdFooter" />
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
    <asp:HiddenField ID="hdncult" runat="server" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="SearchGR.aspx.cs" Inherits="MSHC.Site.Information.SearchGR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %> 
     <%@ Register assembly="TextBoxServerControl" namespace="TextBoxServerControl" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <uc:BreadCrum ID="BreadCrum" runat="server" />
    <h1>
        <asp:Label ID="lbl_GRHeading" runat="server"></asp:Label></h1>
    <%-- <h1>Government Resolutions / Circular / Laws And Acts</h1>--%>
    <div class="gr">
        <asp:Label ID="lblFromDate" runat="server" AssociatedControlID="txtFromDate" Text="From Date :"> </asp:Label>
        <asp:TextBox ID="txtFromDate" runat="server"> </asp:TextBox>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate">
        </asp:CalendarExtender>
        <asp:Label ID="lblToDate" runat="server" AssociatedControlID="txtToDate" Text="To Date :"> </asp:Label>
        <asp:TextBox ID="txtToDate" runat="server"> </asp:TextBox>
        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate">
        </asp:CalendarExtender>
        <asp:Label ID="lblDocType" runat="server" AssociatedControlID="ddlDocumentType" Text="Doc Type :"> </asp:Label>
        <asp:DropDownList ID="ddlDocumentType" runat="server">
        </asp:DropDownList>
        <%-- <asp:Label ID="Label6" runat="server" AssociatedControlID="ddlCategory" Text="Category :"> </asp:Label>
           
        <asp:DropDownList ID="ddlCategory" runat="server">
        </asp:DropDownList>--%>
        <asp:Label ID="lblGRNumber" runat="server" AssociatedControlID="txtGRNumber" Text="GR No. :"> </asp:Label>
        <asp:TextBox ID="txtGRNumber" runat="server"> </asp:TextBox>
        <asp:Label ID="lblIssuedBy" runat="server" AssociatedControlID="txtIssuedBy" Text="IssuedBy :"> </asp:Label>
        <asp:TextBox ID="txtIssuedBy" runat="server"> </asp:TextBox>
        <asp:Label ID="lblKeywordSearch" runat="server" AssociatedControlID="TextBox5" Text="Keyword Search :"> </asp:Label>
        <%--<asp:TextBox ID="TextBox5" runat="server"> </asp:TextBox>--%>
         <cc1:TextBoxControl ID="TextBox5" runat="server" 
            CDACDestinationLanguage="MARATHI" EnableKeyboard="false" MaxLength="50" 
            ToolTip="" TypingMode="CDAC" Width="250px" DestinationLanguage="ENGLISH" AssociatedControlID="TextBox5" Text="Keyword Search :"></cc1:TextBoxControl>

        <div class="btn">
            <asp:Button ID="btnSearchGR" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Clear" OnClick="btnClear_Click" /></div>
    </div>
    <br class="clear" />
    <asp:GridView ID="GridView1" CssClass="t_default" runat="server" AutoGenerateColumns="False"
        CellPadding="3" GridLines="Vertical" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"
        OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataKeyNames="RowID" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
        <Columns>
            <asp:TemplateField HeaderText="SR No" SortExpression="SRNo" HeaderStyle-CssClass="gridHeader"
                ItemStyle-CssClass="gridRow">
                <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SRNo") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("SRNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category" SortExpression="CategoryTypeName" HeaderStyle-CssClass="gridHeader"
                ItemStyle-CssClass="gridRow">
                <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SRNo") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("CategoryType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name" HeaderStyle-CssClass="gridHeader"
                ItemStyle-CssClass="gridRow">
                <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SRNo") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lblDocument" runat="server" Text='<%# Bind("FileTitle") %>'></asp:Label>
                </ItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDocument" runat="server" Text='<%# Bind("FileDtl") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" SortExpression="CreatedDate" HeaderStyle-CssClass="gridHeader"
                ItemStyle-CssClass="gridRow">
                <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GR No." SortExpression="GRNumber" HeaderStyle-CssClass="gridHeader"
                ItemStyle-CssClass="gridRow">
                <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SRNo") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lblGRNumber" runat="server" Text='<%# Bind("No") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size (KB)" SortExpression="Size" HeaderStyle-CssClass="gridHeader"
                ItemStyle-CssClass="gridRow">
               
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FileSize") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="gridHeader"></HeaderStyle>
                <ItemStyle CssClass="gridRow"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="View" SortExpression="ViewName" HeaderStyle-CssClass="gridHeader"
                ItemStyle-CssClass="gridRow">
               
                <ItemTemplate>
                    <asp:ImageButton ID="linkView" runat="server" CommandName="View" CommandArgument='<%#Eval("RowID") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle />
        <HeaderStyle />
        <PagerStyle HorizontalAlign="Center" CssClass="pager" />
        <RowStyle />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <EmptyDataTemplate>
            Record Not Found
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>


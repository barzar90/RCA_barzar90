<%@ Page Title="" Language="C#" MasterPageFile="~/SITE/Masterpage/MasterPage.master"
    AutoEventWireup="true" CodeBehind="SiteSearch.aspx.cs" Inherits="RCA.Site.Information.SiteSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTitle" runat="server">
    <script language="JavaScript">
<!-- Hide from older browsers...


//Check the form before submitting
    function CheckForm() 
    {

	//Check for a word to search
	if (document.frmSiteSearch.search.value==""){
		alert("Please enter at least one keyword to search");
		document.frmSiteSearch.search.focus();
		return false;
	}
	
	return true
}
// -->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearchResults" runat="server" Visible="False">
        <table cellspacing="1" cellpadding="1" width="98%" align="center" class="SearchStatus"
            border="0">
            <tr>
                <td height="18">
                    Searched the site for
                    <asp:Label ID="lblSearchWords" runat="server" Font-Bold="True"></asp:Label>.&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblFilesFound" runat="server" Font-Bold="True">Label</asp:Label>&nbsp;Files
                    found
                </td>
            </tr>
        </table>
        <br>
        <asp:DataGrid ID="dgrdPages" CssClass="Grid" HorizontalAlign="Center" 
            Width="98%" BorderWidth="1px" ShowHeader="False" DataKeyField="PageId" AutoGenerateColumns="False"
            AllowSorting="True" HeaderStyle-CssClass="GridHeader" FooterStyle-CssClass="GridFooter"
            SelectedItemStyle-CssClass="GridSelectedItem" AlternatingItemStyle-CssClass="GridAlternatingItem"
            ItemStyle-CssClass="GridItem" CellPadding="4" runat="Server" 
            AllowPaging="True" PagerStyle-Mode="NumericPages" 
            OnPageIndexChanged="dgrdPages_PageIndexChanged" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" ForeColor="Black" 
            GridLines="Horizontal">
            <SelectedItemStyle CssClass="GridSelectedItem" BackColor="#CC3333" 
                Font-Bold="True" ForeColor="White"></SelectedItemStyle>
            <AlternatingItemStyle CssClass="GridAlternatingItem"></AlternatingItemStyle>
            <ItemStyle CssClass="GridItem"></ItemStyle>
            <HeaderStyle CssClass="GridHeader" BackColor="#333333" Font-Bold="True" 
                ForeColor="White"></HeaderStyle>
            <FooterStyle CssClass="GridFooter" BackColor="#CCCC99" ForeColor="Black"></FooterStyle>
            <Columns>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <%# DisplayTitle(DataBinder.Eval(Container.DataItem, "Title").ToString(),DataBinder.Eval(Container.DataItem, "Path").ToString()) %>
                        <br>
                        <%# DataBinder.Eval(Container.DataItem, "Description") %>
                        <br>
                        <span class="Path">
                            <%# String.Format("{0} - {1}kb", DisplayPath((DataBinder.Eval(Container.DataItem, "Path").ToString())),DataBinder.Eval(Container.DataItem, "Size").ToString()) %>
                        </span>
                        <br>
                        <br>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle CssClass="GridPager" BackColor="White" ForeColor="Black" 
                HorizontalAlign="Right"></PagerStyle>
        </asp:DataGrid>
        <table cellspacing="1" cellpadding="1" width="98%" align="center" class="SearchStatus"
            border="0">
            <tr>
                <td width="47%" height="18">
                    &nbsp;Searched
                    <asp:Label ID="lblTotalFiles" runat="server" Font-Bold="True"></asp:Label>&nbsp;documents
                    in total.
                </td>
                <td align="right" width="53%" height="18">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

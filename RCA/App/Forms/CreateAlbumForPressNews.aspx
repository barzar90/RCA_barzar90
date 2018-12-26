<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="CreateAlbumForPressNews.aspx.cs" Inherits="RCA.FORMS.CreateAlbumForPressNews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/PagerControl.ascx" TagName="PagerControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/CommonValidations.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        
        <span>Create Press Album</span>
         <div class="clearfix"></div>
        </h1>
    <table class="table table-bordered table-striped">
        <tr>
            <td>
                Album Name <span style='color: red;'>*</span>
            </td>
            <td>
                <asp:TextBox ID="txtAlbumName" runat="server" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAlbumName" runat="server" Text="*" ForeColor="Red"
                    ValidationGroup="CA" ControlToValidate="txtAlbumName">
                </asp:RequiredFieldValidator>
                <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create"
                    CssClass="btn btn-sm btn-success" ValidationGroup="CA" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdCreateAlbum" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" Width="100%"
        CellPadding="3" GridLines="Vertical" AllowPaging="True" OnRowCancelingEdit="grdCreateAlbum_RowCancelingEdit"
        OnRowCommand="grdCreateAlbum_RowCommand" OnRowEditing="grdCreateAlbum_RowEditing"
        OnRowUpdating="grdCreateAlbum_RowUpdating" OnRowDataBound="grdCreateAlbum_RowDataBound1">
        <Columns>
            <asp:BoundField DataField="Sr No" HeaderText="SrNo" />
            <asp:TemplateField HeaderText="Sr No" SortExpression="AutoID" Visible="true">
                <ItemTemplate>
                    <asp:Label ID="LblSrNo" runat="server" Text='<%#(Container.DataItemIndex +1 )%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sr. No." SortExpression="SRNo" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblAlbumID" runat="server" Text='<%# Bind("PressNewsAlbumID") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="10px"></ControlStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Album" SortExpression="Album">
                <EditItemTemplate>
                    <asp:TextBox ID="txtgrdAlbum" Width="800px" runat="server" Text='<%# Bind("AlbumName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgrAlbum" runat="server" Text='<%# Bind("AlbumName") %>'></asp:Label>
                    <span>
                        <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../img/gif_new.gif' />" : "")%></span></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IsNew" Visible="false">
                <ItemTemplate>
                    <asp:CheckBox ID="Chkstatus" AutoPostBack="true" key='<%# Eval("PressNewsAlbumID") %>'
                        OnCheckedChanged="chkbox_OnCheckedChanged" runat="server" />
                    <asp:Label ID="lblIsnew" Visible="false" runat="server" Text='<%# Eval("IsNew") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <span onclick="return confirm('Are you sure to Delete?')">
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="delete1"
                            CommandArgument='<%# Eval("PressNewsAlbumID") %>' Text="Delete"></asp:LinkButton>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
        </Columns>
        <PagerSettings FirstPageText="Prev" LastPageText="Last" Mode="NextPreviousFirstLast"
            NextPageText="Next" />
        <PagerStyle BackColor="#666666" HorizontalAlign="Center" CssClass="pager" />
    </asp:GridView>
    <uc1:PagerControl ID="pgCtr1" runat="server" PageSize="10" PageMode="LinkButton" />
</asp:Content>

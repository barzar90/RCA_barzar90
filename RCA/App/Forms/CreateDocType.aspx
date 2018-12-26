<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master"
    AutoEventWireup="true" CodeBehind="CreateDocType.aspx.cs" Inherits="MSHC.App.Forms.CreateDocType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <h1>
        <span>Create Document Type</span>
        <a href="UploadAllPdf.aspx" class="btn btn-sm btn-danger pull-right">Back </a>
        <div class="clearfix"></div>
    </h1>
    <asp:HiddenField ID="HdValue" runat="server" Value="0" />
   
   
    <table class="table table-bordered table-striped">
        <tr id="tr0" runat="server">
            <td>
                <asp:Label ID="lbl_DocType" runat="server" Text="Enumeration Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DDLEnumeration" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLEnumeration_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDLEnumeration"
                    ErrorMessage="Please  Select " ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DoctypNm" runat="server" Text="Document Type : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_DocTypNm" class="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DoctypNmLL" runat="server" Text="Document Type LL : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_DocTypNmLL" class="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblOrder" runat="server" Text="Sequence No: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_SeqNo" class="form-control" runat="server"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_SeqNo"
                    ValidChars="0123654789" FilterType="Numbers">
                </asp:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_IsActive" runat="server" Text="Is Active : "></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chk_IsActive" runat="server" Text="IsActive" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-sm btn-success" Text="Save" OnClick="btn_Save_Click" />
                <asp:Button ID="btn_Cancel" runat="server" CssClass="btn btn-sm btn-warning" Text="Cancel" PostBackUrl="~/App/Forms/UploadAllPdf.aspx" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdupload" CssClass="t_view" runat="server" AutoGenerateColumns="False"
                    AllowPaging="true" CellPadding="3" GridLines="Vertical" Width="100%" OnRowCommand="grdupload_RowCommand"
                    OnRowEditing="grdupload_RowEditing" OnPageIndexChanging="grdupload_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enumeration ValueID">
                            <ItemTemplate>
                                <asp:Label ID="lblEnumID" runat="server" Text='<%# Bind("EnumerationValueID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enumeration Value">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("EnumerationValue") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enumeration Marathi">
                            <ItemTemplate>
                                <asp:Label ID="lblNameLL" runat="server" Text='<%# Bind("EnumerationValue_LL") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sequence No">
                            <ItemTemplate>
                                <asp:Label ID="lblseqNo" runat="server" Text='<%# Bind("SortOrder") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IsActive">
                            <ItemTemplate>
                                <asp:Label ID="lblIsActive" runat="server" Text='<%# Bind("IsActive") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" Visible="true">
                            <ItemTemplate>
                                <%--<span onclick="return confirm('Are you sure to Delete?')">--%>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="edit"
                                    CommandArgument='<%# Eval("EnumerationValueID") %>' Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="5%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

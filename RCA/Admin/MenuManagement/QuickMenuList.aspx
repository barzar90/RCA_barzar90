<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="QuickMenuList.aspx.cs" Inherits="MSHC.Admin.MenuManagement.QuickMenuList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    
<h1><asp:Label ID="ldlQuickmenuname" runat="server" Text="Quick-Menu List of"></asp:Label> <span class="span"><%=QuickMenuName%></span></h1>

    <table class="t_view">
        <tr>
            <td>
                <div class="admintab">
                    <asp:Button ID="btnAddQuickMenu" CssClass="button" runat="server" Text="Add Quick Menu" OnClick="btnAddQuickMenu_Click" />
                    <asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back to Menu" PostBackUrl="~/Admin/MenuManagement/MenuList.aspx" />
                    <div class="clear"></div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView Width="100%" ID="grdQuickMenuList" AllowPaging="True" GridLines="None"
                     AutoGenerateColumns="False" EmptyDataText="There is no data to display" runat="server" OnRowCommand="grdQuickMenuList_RowCommand" OnRowDeleting="grdQuickMenuList_delete">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                                <%#  Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Quick-Menu Name" DataField="QuickMenuName" />
                        <asp:BoundField HeaderText="Meta Description" DataField="MetaDescription" />
                        <asp:BoundField HeaderText="Meta Keywords" DataField="MetaKeywords" />
                        <asp:BoundField HeaderText="Sequence No" DataField="SequenceNo" />
                        <asp:TemplateField HeaderText="Is New">
                            <ItemTemplate>
                                <%#  (Convert.ToBoolean(Eval("IsNewFlag"))==true)?"Yes":"No" %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <%#  (Convert.ToBoolean(Eval("Active"))==true)?"Yes":"No" %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <a href='QuickMenu.aspx?shvid=<%#Eval("QuickMenuID") %>&action=edit&pid=<%#Eval("ParentID") %>&MenuID=<%# Eval("MenuID") %>'>
                                    <img style="display: inline; width: 20px;" src="../../Images/edit_menu.png" alt="Edit Menu"
                                        title="Edit Menu" /></a>&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkDelete" OnClientClick="javascript:return confirm('Are you sure do you to delete');"
                                    CommandArgument='<%#Eval("QuickMenuID") %>' runat="server" CommandName="Delete"><img style="display:inline; width:20px;" src="../../Images/delete_menu.png" alt="Delete Menu" title="Delete Menu" /></asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp; <a href='AddQuickMenuContent.aspx?shvid=<%#Eval("QuickMenuID") %>&MenuID=<%#Eval("MenuID") %>'>
                                    <img style="display: inline; width: 20px;"  src="../../Images/add_content.png"
                                        alt="Add Quick-Menu Content" title="Add Quick-Menu Content" />
                                </a>&nbsp;&nbsp;&nbsp <a href='QuickMenuContentList.aspx?shvid=<%#Eval("QuickMenuID") %>&MenuID=<%#Eval("MenuID") %>'>
                                    <img style="display: inline; width: 20px;" src="../../Images/view_content.png"
                                        alt="View Quick-Menu Content List" title="View Quick-Menu Content List" /></a>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

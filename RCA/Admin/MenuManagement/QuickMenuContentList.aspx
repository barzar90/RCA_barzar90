<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="QuickMenuContentList.aspx.cs" Inherits="MSHC.Admin.MenuManagement.QuickMenuContentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <h1><asp:Label runat="server" ID="lblheading" Text="Quick-Menu Content List of"></asp:Label><span class="span"><%=QuickMenuName %></span></h1>
    <table class="t_view">
        <tr>
            <td>
                <div class="admintab">
                    <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back to Quick Menu" OnClick="btnBack_Click"/>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView Width="100%" ID="grdQuickMenuContentList" AllowPaging="True" GridLines="None" AutoGenerateColumns="False" EmptyDataText="There is no data to display" runat="server" OnRowCommand="grdQuickMenuContentList_RowCommand"
                    OnRowDeleting="grdQuickMenuContentList_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Page Title" DataField="PageTitle" />
                        <asp:BoundField HeaderText="ShortDescription" DataField="ShortDescription" HeaderStyle-Width="30%" />
                        <asp:BoundField HeaderText="Long Description" DataField="LongDescription" />
                        <asp:BoundField HeaderText="Sequence No" DataField="SequenceNo" />
                         <asp:TemplateField HeaderText="IsApprove">
                            <ItemTemplate>
                                
                                <%#Convert.ToBoolean(Eval("IsApprove")) == true ? "Yes" : "No"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                
                                <%#Convert.ToBoolean(Eval("Active")) == true ? "Yes" : "No"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <a href='AddQuickMenuContent.aspx?status=Edit&SendContentID=<%#Eval("QuickContentID") %>&shvid=<%#Eval("QuickMenuId") %>'>
                                    <img style="display: inline; width: 20px;" src="../../Images/edit_menu.png" alt="Edit Menu"
                                        title="Edit Content" /></a>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkDelete" OnClientClick="javascript:return confirm('Are you sure do want to delete');"
                                    CommandArgument='<%#Eval("QuickContentID") %>' runat="server" CommandName="Delete"><img style="display:inline; width:20px;" src="../../Images/delete_menu.png" alt="Delete Content" title="Delete Content" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="MarqueeDataActiveOrNot.aspx.cs" Inherits="MSHC.App.Forms.MarqueeDataActiveOrNot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>
        Latest Updates Active/Inactive</h1>
    <table class="table table-bordered table-striped" width="100%">
        <tr>
            <td align="center">
                <asp:GridView ID="grdupload" CssClass="mGrid table table-bordered table-striped"
                    runat="server" AutoGenerateColumns="False" AllowPaging="true" CellPadding="3"
                    GridLines="Vertical" Width="100%" PageSize="5" OnPageIndexChanging="grdupload_PageIndexChanging"  OnRowEditing="grdupload_RowEditing"
                    OnRowUpdating="grdupload_RowUpdating" OnRowCancelingEdit="grdupload_RowCancelingEdit" DataKeyNames="DocumentID">
                    <Columns>
                        <asp:TemplateField HeaderText="SR No" SortExpression="SRNo" ControlStyle-CssClass="align-center">
                            <ItemTemplate>
                                <asp:Label ID="lblSN" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DocumentPath_LL" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblDocumentPath_LL" runat="server" Text='<%# Bind("DocumentPath_LL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Document Path" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblDocumentPath" runat="server" Text='<%# Bind("DocumentPath") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subject" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblsubject" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="विषय" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblsubLL" runat="server" Text='<%# Bind("Subject_LL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <%-- <%#Convert.ToBoolean(Eval("Flag")) == true ? "Yes" : "No"%>--%>
                                <asp:HiddenField ID="HD_DocumentID" Value='<%#Eval("DocumentID")%>' runat="server" />
                                <asp:HiddenField ID="HD_TYPE" Value='<%#Eval("typeD")%>' runat="server" />
                                <asp:CheckBox ID="ChkView" runat="server" OnCheckedChanged="ChkView_CheckedChanged" AutoPostBack="true" Checked='<%#Eval("IsActive") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                               <asp:CheckBox ID="ChkView" runat="server" Checked='<%#Eval("IsActive") %>'/>
                                 <asp:HiddenField ID="HD_TYPE" Value='<%#Eval("typeD")%>' runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkView" runat="server" AutoPostBack="true" Checked="true" OnCheckedChanged="ChkView_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderStyle-CssClass="gridHeader" HeaderStyle-Width="100px" HeaderText="Option">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate" runat="server" Style="margin-right: 2px; margin-left: 2px;"
                                                Width="40px" CommandName="Update" Height="15px" Text="Update" CommandArgument='<%#Eval("DocumentID") %>'></asp:LinkButton>
                                            <asp:LinkButton ID="Btnupdatecancel" runat="server" Width="40px" CommandName="Cancel"
                                                Height="15px" Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" Width="100px" CommandArgument='<% #Eval("DocumentID")%>'
                                                CommandName="Edit"  Height="16px" Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridHeader" />
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

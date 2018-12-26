<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="UpdatedCaseList.aspx.cs" Inherits="RCA.Admin.MenuManagement.UpdatedCaseList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <div class="row">
            <div class="text-left col-md-6">
                <h1>
                    <span>Case Details</span>
                </h1>
            </div>
            <div class="col-md-6 text-right">
                <%--       <asp:LinkButton CssClass="btn btn-sm btn-danger pull-right" ID="linkBack" Text="Back"
                    CausesValsidation="true" runat="server"  OnClick="linkBack_click" />--%>

                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-danger pull-right" OnClick="btnBack_Click" />
                <%--   onclick="linkBack_Click"--%>
            </div>
        </div>
    <asp:GridView CssClass="table table-bordered table-striped" ID="grdUpdatedCaseList" AllowPaging="True"
        AutoGenerateColumns="False" EmptyDataText="There is no data to display" runat="server"
        OnRowCommand="grdUpdatedCaseList_RowCommand" OnRowDeleting="grdUpdatedCaseList_delete" OnPageIndexChanging="grdUpdatedCaseList_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Sr No">
                <ItemTemplate>
                    <%#  Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Case No" DataField="CaseNo" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Case Status" DataField="CaseStatus" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField HeaderText="LastHearing Date" DataField="LastHearingDate" DataFormatString="{0:MMMM d, yyyy}" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField HeaderText="NextHearing Date" DataField="NextHearingDate" DataFormatString="{0:MMMM d, yyyy}" ItemStyle-HorizontalAlign="Left"/>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='<%# GetSiteURL()%>/Admin/MenuManagement/CaseEntryForm.aspx?ID=<%# Eval("ID") %>&action=editupatedcase'>
                        <span class="glyphicon glyphicon-edit" title="Edit Menu"></span></a>
                    <asp:LinkButton ID="lnkDelete" OnClientClick="javascript:return confirm('Are you sure do you to delete');"
                        CommandArgument='<%# Eval("ID")+","+Eval("CaseNo") %>' runat="server" CommandName="Delete">
                                        <span class="glyphicon glyphicon-trash" title="Delete Menu"></span>
                    </asp:LinkButton>
                   <%-- <a class="hidden" href='QuickMenu.aspx?MenuID=<%# Eval("MenuID") %>'><span class="glyphicon glyphicon-link"
                        title="Add Quick Link"></span></a><a class="hidden" href='<%# GetSiteURL()%>/Admin/MenuManagement/QuickMenuList.aspx?MenuID=<%#Eval("MenuID") %>'>
                            <span class="glyphicon glyphicon-list-alt" title="View Quick Links"></span>
                    </a><a href='<%# GetSiteURL()%>/Admin/MenuManagement/AddMenuContent.aspx?MenuID=<%#Eval("MenuID") %>'>
                        <span class="glyphicon glyphicon-plus" title="Add menu Content"></span></a><a href='<%# GetSiteURL()%>/Admin/MenuManagement/MenuContentList.aspx?MenuID=<%#Eval("MenuID")%>'>
                            <span class="glyphicon glyphicon-list" title="View menu Content"></span>
                    </a>--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="pager-d" />
    </asp:GridView>
</asp:Content>

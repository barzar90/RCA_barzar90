<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="CaseList.aspx.cs" Inherits="RCA.Admin.MenuManagement.CaseList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
     <%if (Session["UserRole"] != null && Session["UserRole"].ToString().ToLower() != "cmscityuser")
        { %>
     <div class="admintab">
         <asp:Button ID="btnCaseEntry" runat="server" CssClass="btn btn-primary btn-sm"
            Text="Case Entry"  OnClick="btnCaseEntry_Click" />   
        <%--<a id="A3" class="btn btn-success btn-sm" runat="server" target="_blank" href="~/Site/Upload/Pdf/UserManual.pdf">
            CMS User Manual</a>--%>
        <div class="clear"></div>
    </div>
    <%} %>

    <asp:GridView CssClass="table table-bordered table-striped" ID="grdCaseList" AllowPaging="True"
        AutoGenerateColumns="False" EmptyDataText="There is no data to display" runat="server"
        OnRowCommand="grdCaseList_RowCommand" OnRowDeleting="grdCaseList_delete" OnPageIndexChanging="grdCaseList_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Sr No">
                <ItemTemplate>
                    <%#  Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Case No" DataField="CaseNo" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Division" DataField="DivisionName" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="District" DataField="DistrictName" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Applicant" DataField="ApplicantName" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Opponent" DataField="OpponentName" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField HeaderText="Case Status" DataField="CaseStatus" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField HeaderText="LastHearing Date" DataField="LastHearingDate" DataFormatString="{0:MMMM d, yyyy}" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField HeaderText="NextHearing Date" DataField="NextHearingDate" DataFormatString="{0:MMMM d, yyyy}" ItemStyle-HorizontalAlign="Left"/>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='<%# GetSiteURL()%>/Admin/MenuManagement/CaseEntryForm.aspx?ID=<%# Eval("ID") %>&action=edit'>
                        <span class="glyphicon glyphicon-edit" title="Edit Menu"></span></a>
                    <asp:LinkButton ID="lnkDelete" OnClientClick="javascript:return confirm('Are you sure do you to delete');"
                        CommandArgument='<%# Eval("ID")+","+Eval("CaseNo") %>' runat="server" CommandName="Delete">
                                        <span class="glyphicon glyphicon-trash" title="Delete Menu"></span>
                    </asp:LinkButton>
                    <%--<a class="hidden" href='QuickMenu.aspx?MenuID=<%# Eval("MenuID") %>'><span class="glyphicon glyphicon-link"
                        title="Add Quick Link"></span></a><a class="hidden" href='<%# GetSiteURL()%>/Admin/MenuManagement/QuickMenuList.aspx?MenuID=<%#Eval("MenuID") %>'>
                            <span class="glyphicon glyphicon-list-alt" title="View Quick Links"></span>
                    </a><a href='<%# GetSiteURL()%>/Admin/MenuManagement/AddMenuContent.aspx?MenuID=<%#Eval("MenuID") %>'>
                        <span class="glyphicon glyphicon-plus" title="Add menu Content"></span></a>--%>
                       <a href='<%# GetSiteURL()%>/Admin/MenuManagement/UpdatedCaseList.aspx?CaseNo=<%#Eval("CaseNo")%>&action=view'>
                            <span class="glyphicon glyphicon-list" title="View menu Content"></span>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="pager-d" />
    </asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="ViewArchivePdfList.aspx.cs" Inherits="RCA.Site.Common.ViewArchivePdfList" %>

<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Controls/WebSiteControls/UCBreadCrum.ascx" TagName="UCBreadCrum"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/CommonValidations.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <table width="100%">
        <tr>
            <td>
                <h1>
                    <asp:Label ID="LblDynamicotherpdf" runat="server"></asp:Label><asp:Label ID="lbl_archive"
                        runat="server"></asp:Label></h1>
            </td>
            <td align="right" >
                <asp:Button ID="btn_ViewPdfArchiveListBack" runat="server" Text="Back" 
                    CssClass="btn btn-primary" onclick="btn_ViewPdfArchiveListBack_Click" />
            </td>
        </tr>
    </table>
    <uc2:UCBreadCrum ID="UCBreadCrum1" runat="server" />
    <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
    <div class="clearfix">
    </div>
    <div class="well">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                <asp:Label ID="lblFromDate" runat="server" Text="From Date" AssociatedControlID="txtFromDate"></asp:Label>
            </div>
            <div class="col-md-3 col-sm-3">
                <div class="input-group">
                    <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                    </div>
                    <asp:TextBox CssClass="form-control" ID="txtFromDate" runat="server" onkeydown="return isBS(event);"
                        autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="calFromDate" runat="server" TargetControlID="txtFromDate"
                        Format="dd/MM/yyyy" PopupButtonID="txtFromDate">
                    </asp:CalendarExtender>
                </div>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Label ID="lblToDate" runat="server" Text="To Date" AssociatedControlID="txtToDate" />
            </div>
            <div class="col-md-3 col-sm-3">
                <div class="input-group">
                    <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                    </div>
                    <asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" onkeydown="return isBS(event);"
                        autocomplete="off" />
                    <asp:CalendarExtender ID="calToDate" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"
                        PopupButtonID="txtToDate">
                    </asp:CalendarExtender>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 col-sm-3">
                <asp:Label ID="lblDocumentType" runat="server" Visible="true" Text="Category" AssociatedControlID="DDlCategory" />
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:DropDownList CssClass="form-control" ID="DDlCategory" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="DDlCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Label ID="lblKeywordsearch" runat="server" Visible="true" Text="Keyword Search"
                    AssociatedControlID="TxtDocNM" />
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:TextBox CssClass="form-control" ID="TxtDocNM" runat="server" Visible="true"
                    onkeypress=" return ValidateCharacter('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ', event);"
                    autocomplete="off" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 col-sm-3 hidden-xs">
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                    ValidationGroup="GR" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblmsg" runat="server" CssClass="alert alert-info col-md-12" Text="No Data Found !!!!!!"
        Visible="false"></asp:Label>
    <div class="table-responsive">
        <asp:GridView ID="grdupload" CssClass="table table-bordered table-striped" runat="server"
            AutoGenerateColumns="False" GridLines="Vertical" Width="100%" PageSize="10" AllowPaging="true" OnPageIndexChanging="grdupload_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="क्रमांक" HeaderStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblSN" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="दस्तएवज क्रमांक" SortExpression="DocumentNO" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblDOCNo" runat="server" Text='<%# Bind("DocumentNO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="विषय" SortExpression="subject">
                    <ItemTemplate>
                        <asp:Label ID="lblsub" runat="server" Text='<%# Bind("subject") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="प्रवर्ग">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%#  Bind("Enumerationvalue") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="दिनांक" SortExpression="CreatedDate">
                    <ItemTemplate>
                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="आकार (MB)">
                    <ItemTemplate>
                        <asp:Label ID="lblsize" runat="server" Text='<%#  Bind("Size") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="डाऊनलोड" SortExpression="SRNo">
                    <ItemTemplate>
                        <a class='align-center' href='<%# "../../Site/Upload/Pdf/" + Convert.ToString(Eval("DocumentPath"))%>'
                            target="_blank">
                            <img id="img1" src="../../Images/pdf.png" alt="Click here to Download PDF" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

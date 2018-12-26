<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="ViewDocuments.aspx.cs" Inherits="MOLFrameWork.Site.Common.ViewDocuments" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Controls/WebSiteControls/UCBreadCrum.ascx" TagName="UCBreadCrum"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
<h1>
        <asp:Label ID="LblDynamicotherpdf" runat="server"></asp:Label></h1>
    <uc2:UCBreadCrum ID="UCBreadCrum1" runat="server" />
    <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
    <div class="clearfix"></div>
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
                <asp:TextBox CssClass="form-control" ID="txtFromDate" runat="server" onkeydown="return isBS(event);"></asp:TextBox>
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
                <asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" onkeydown="return isBS(event);" />
                <asp:CalendarExtender ID="calToDate" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"
                    PopupButtonID="txtToDate">
                </asp:CalendarExtender>
                </div>
            </div>
        </div>
        <div class="row">
            <%--<div class="col-md-3 col-sm-3">
                <asp:Label ID="lblDocumentType" runat="server" Visible="true" Text="Category" AssociatedControlID="DDlCategory" />
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:DropDownList CssClass="form-control" ID="DDlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDlCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </div>--%>
            <div class="col-md-3 col-sm-3">
                <asp:Label ID="lblKeywordsearch" runat="server" Visible="true" Text="Keyword Search"
                    AssociatedControlID="TxtDocNM" />
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:TextBox CssClass="form-control" ID="TxtDocNM" runat="server" Visible="true" onkeypress=" return ValidateCharacter('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ', event);" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 col-sm-3 hidden-xs">
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" ValidationGroup="GR"
                    OnClick="btnSearch_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger" OnClick="btnClear_Click" />
            </div>
        </div>
    </div>
      <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
      <ContentTemplate>
    <asp:Label ID="lblmsg" runat="server" CssClass="alert alert-info col-md-12" Text="No Data Found !!!!!!"
        Visible="false"></asp:Label>
    <div class="table-responsive">
        <asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
    <div style="float:left;width:50%;height:100px;">
        <div class="col-md-3 col-sm-3 col-xs-3">
            <img class="img-responsive" src="../../Site/Upload/Images/<%# Eval("DocumentImage") %>"
        alt='' />
        </div>
        <div class='latestNewsContent col-md-9 col-sm-3 col-xs-9'>
            <div class="heading">
                <%# Eval("Title") %></div>
            <div><%# Eval("CreatedDate") %></div>
            <div class="description">
                <%# Eval("Description") %>               
                <a class='readmore' ID="hypViewFile" runat="server" Target='_blank' href='<%#  "../../Site/Upload/Pdf/" + Eval("DocumentPath") %>'><img src="../../Images/pdf.png"></a><br><%# Eval("Size") %>MB
            </div>
        </div>
        </div>
  </ItemTemplate>
</asp:Repeater>
    </div>

    <div style="margin-top: 20px;">
                    <table style="width: 600px;">
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbFirst" runat="server" 
				OnClick="lbFirst_Click">First</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbPrevious" runat="server" 
				OnClick="lbPrevious_Click">Previous</asp:LinkButton>
                            </td>
                            <td>
                                <asp:DataList ID="rptPaging" runat="server"
                                    OnItemCommand="rptPaging_ItemCommand"
                                    OnItemDataBound="rptPaging_ItemDataBound" 
					RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbPaging" runat="server"
                                            CommandArgument='<%# Eval("PageIndex") %>' 
						CommandName="newPage"
                                            Text='<%# Eval("PageText") %> ' Width="20px">
						</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbNext" runat="server" 
				OnClick="lbNext_Click">Next</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbLast" runat="server" 
				OnClick="lbLast_Click">Last</asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>

                </div>


    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

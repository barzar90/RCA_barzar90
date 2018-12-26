<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="CaseTracking.aspx.cs" Inherits="RCA.Site.Home.CaseTracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">

<div class="table-responsive">
      <h1><asp:Label ID="lblCaseTrack" runat="server" Text="Label"></asp:Label></h1>
<br />
<div class="clear"></div>
<ul class="list-group">
  <li class="list-group-item">
      <div class="col-md-8 col-sm-8">
         <asp:Label ID="lblCaseNo" Text="Enter A Case No To Search : " runat="server" AssociatedControlID="txtCaseNo"></asp:Label>
      <asp:TextBox ID="txtCaseNo" CssClass="form-control" runat="server">
        </asp:TextBox>
     </div>

      <div class="col-md-4 col-sm-4  mtop20">
         <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-warning" />

        &nbsp;&nbsp;

        <asp:Button ID="btnReset" runat="server" Text="Reset"  class="btn btn-success" OnClick="btnReset_Click" />
          </div>
      <div class="clear"></div>
          </li>
    <div class="clear"></div>
</ul>
    <asp:UpdatePanel ID="upNews" runat="server">
        <ContentTemplate>
    <asp:GridView CssClass="table table-bordered table-striped" ID="grdCaseList" AllowPaging="True"
        AutoGenerateColumns="False" EmptyDataText="There is no data to display" runat="server"
        OnPageIndexChanging="grdCaseList_PageIndexChanging">
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
            
        </Columns>
        <PagerStyle CssClass="pager-d" />
    </asp:GridView>
    </ContentTemplate>
        </asp:UpdatePanel>
</div>
</asp:Content>

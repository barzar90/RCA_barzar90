<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitorCount.ascx.cs" Inherits="RCA.Controls.WebSiteControls.VisitorCount" %>
<div class="visitorCount">
<div class="lastReviewed">

    <asp:Label ID="lblTotalVisitHeading" runat="server" Text=""></asp:Label>
  <span class="color-cyan">  <asp:Label ID="lblCounter" runat="server" Text=""></asp:Label></span>
    <br />
    <asp:Label ID="lblTodayVisitHeading" runat="server" Text=""></asp:Label>
   <span class="color-cyan"> <asp:Label ID="lbltodayCount" runat="server" Text=""></asp:Label></span>    <br />

   <span><asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>01/07/2018</span>
    <div class="clear"></div>
</div>
</div>
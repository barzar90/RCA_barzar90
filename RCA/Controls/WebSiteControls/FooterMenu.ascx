<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterMenu.ascx.cs" Inherits="RCA.Controls.WebSiteControls.FooterMenu" %>
<%@ Register Src="~/Controls/WebSiteControls/LastReviewedDate.ascx" TagName="LastReviewedDate"
    TagPrefix="uc1" %>
<%@ Register Src="PlaceHolderControl.ascx" TagName="PlaceHolderControl" TagPrefix="uc4" %>
<footer>
    <div class="container">
        <div class="row">
            <div class="col-md-5 col-xs-12 mtop10">
                <div id="Footermenu1" runat="server">
                </div>
                <asp:Label ID="lbl_copyright" runat="server" Text="Label"></asp:Label>
               <%-- <uc1:LastReviewedDate ID="LastReviewedDate1" runat="server" />--%>
               
            </div>
            </div>

            <div class="col-md-2 col-xs-12">
                <ul class="pull-right logo-list">  
                    <%--<li><a href="#" ID="developedBy">Developed By:</a></li>--%>
                    <%--<li> <a href="#" ID="developedBy"> Developed By: <asp:Label ID="lbl_developedby" runat="server" Text="Label"></asp:Label>  </a> </li>--%>
                    <li><asp:Label ID="lbl_developedby" runat="server" Text="Developed By:"></asp:Label></li>
                    <li> <a class="maintan ExternalLinkClick" href="https://www.mahait.org" target="_blank">
                        <img src="../../Images/MahaIT_Trans.png" alt="">
                    </a></li>
                    
                </ul>
            </div>

            <div class="col-md-5 col-xs-12 mtop20">
                <ul class="pull-right logo-list">  
                    <li>
                        <asp:Label ID="lblTotalVisitHeading" runat="server" Text=""></asp:Label>
                        <span class="color-cyan">  <asp:Label ID="lblCounter" runat="server" Text=""></asp:Label></span>
                    </li>
                    <li>
                         <asp:Label ID="lblTodayVisitHeading" runat="server" Text=""></asp:Label>
                        <span class="color-cyan"> <asp:Label ID="lbltodayCount" runat="server" Text=""></asp:Label></span> 
                    </li>
                    
                </ul>
               <%-- <div class="visitorCount">
                <div class="lastReviewed">

                    <asp:Label ID="lblTotalVisitHeading" runat="server" Text=""></asp:Label>
                  <span class="color-cyan">  <asp:Label ID="lblCounter" runat="server" Text=""></asp:Label></span>
                    
                    <asp:Label ID="lblTodayVisitHeading" runat="server" Text=""></asp:Label>
                   <span class="color-cyan"> <asp:Label ID="lbltodayCount" runat="server" Text=""></asp:Label></span>   

                   <span><asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>01/07/2018</span>
                    <div class="clear"></div>
                </div>
                </div>--%>
            </div>
        </div>
    </div>
</footer>
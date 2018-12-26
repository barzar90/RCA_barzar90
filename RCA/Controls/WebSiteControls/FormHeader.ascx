<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormHeader.ascx.cs" Inherits="RCA.Controls.WebSiteControls.FormHeader" %>
<%@ Register Src="SetCulture.ascx" TagName="SetCulture" TagPrefix="uc1" %>
<%@ Register src="Menu1.ascx" tagname="Menu1" tagprefix="uc2" %>
<header class="topHeaderSection">
<div id="topLinks" class="topLinks" runat="server">
            <div id="defaultMenu" class="container">
               
                        <!-- topLinks -->
                        <ul class="other_links">
                            <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                                <AnonymousTemplate>
                                    <li>
                                        <asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_Click"></asp:Button></li>
                                </AnonymousTemplate>
                                <LoggedInTemplate>
                                    <li class="username">Welcome <span style="font-weight: bolder">
                                        <% Response.Write(HttpContext.Current.Profile.GetPropertyValue("firstName") == "" ? HttpContext.Current.Profile.UserName : HttpContext.Current.Profile.GetPropertyValue("firstName") + " " + HttpContext.Current.Profile.GetPropertyValue("lastName")); %>
                                    </span>! </li>
                                    <li>
                                            <%--  <asp:Button ID="btnlogout" runat="server" Text="Log Out" CssClass="btnResizer" OnClick="btnlogout_Click"></asp:Button>--%>
                                        <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                                            OnLoggedOut="HeadLoginStatus_LoggedOut" />
                                        
                                    </li>
                                    <li>
                                      <asp:LinkButton ID="lnk_changepassword" runat="server" OnClick="lnk_changepassword_Click">LinkButton</asp:LinkButton>
                                        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/App/Profiles/ChangePassword.aspx"></asp:HyperLink>--%></li>
                                    <%-- <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/App/Profiles/Profile.aspx"></asp:HyperLink></li>--%>
                                </LoggedInTemplate>
                            </asp:LoginView>
                            <li>
                                <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" CssClass="btnResizer" /></li>
                            <li>
                                <asp:Button ID="btnContactUs" runat="server" OnClick="btnContactUs_Click" CssClass="btnResizer" /></li>
                            <uc1:SetCulture ID="SetCulture1" runat="server" />
                        </ul>
                        <div class="searchBox">
                            <input type="text" name="search" id="searchTxtBox" value="Search here" class="searchBG"
                                onclick="this.value = ( this.value == this.defaultValue ) ? '' : this.value;return true;" />
                            <asp:Button ID="Search_btn" runat="server" class="searchBTN" />
                            <div class="clear">
                            </div>
                        </div>
                        
                        <!-- topLinks End -->
                   <div class="clear">
            </div>
            </div>
          
        </div>
    <div class="header">
        
     
           <div class="header-top">
           <div class="container">
               <div class="row">
                 <div class="col-md-2 text-center">
                      <a href="https://housing.maharashtra.gov.in" target="_blank" class="mahalogo">
                    <img id="HajLogo_alt" runat="server" src="../../Images/Logo-Maharashtra.Png"
                        alt="Maharashtra Rent Control Act (Housing Department)" /></a>
                  </div>
                <div class="col-md-8 text-center header-textheading">
                    <asp:Label ID="lbl_headTitle" runat="server" CssClass="heading wow animated fadeInUp" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2 text-center">
                     <a href="http://india.gov.in/" target="_blank" class="cenlogo">
                    <img id="NationalEmblem_alt" runat="server" src="../../Images/enbI.Png" alt="Government of Maharashtra" /></a>
                </div>

                <div class="clear">
                </div>
               
            </div>
            <%--<div class="row">
                 <div class="col-md-12">
                <a href="https://www.maharashtra.gov.in" target="_blank" class="mahalogo">
                    <img id="MaharashtraLogo_alt" runat="server" src="../../Images/maharashtralogo.png"
                        alt="Government of Maharashtra" /></a>
                <asp:Label ID="lbl_headTitle" runat="server" CssClass="heading wow animated fadeInUp" Text="Label"></asp:Label>
                <a href="http://india.gov.in/" target="_blank" class="cenlogo">
                    <img id="NationalEmblem_alt" runat="server" src="../../Images/emblem.jpg" alt="Government of Maharashtra" /></a>
                <a class="btnDisplay" href="#" name="Navigation">
                    <asp:Label ID="lbl_navigation" runat="server" Text="Label"></asp:Label></a>
                    </div>
                <div class="clear">
                </div>
               
            </div>--%>
        </div>
            </div>
            <uc2:Menu1 ID="Menu11" runat="server" />
     
        
        <div>
            <asp:Label runat="server" ID="lblTitle" Text="" />
        </div>
    </div>
</header>
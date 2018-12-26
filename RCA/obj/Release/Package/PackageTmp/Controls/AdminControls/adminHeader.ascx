﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adminHeader.ascx.cs" Inherits="RCA.Controls.AdminControls.adminHeader" %>
<%@ Register Src="~/Controls/WebSiteControls/HeaderMenu.ascx" TagName="HeaderMenu"
    TagPrefix="uc1" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>
<%@ Register Src="../WebSiteControls/SetCulture.ascx" TagName="SetCulture" TagPrefix="uc2" %>
<%@ Register Src="../WebSiteControls/Menu1.ascx" TagName="Menu1" TagPrefix="uc3" %>
<header class="topHeaderSection">
    <div id="topLinks" class="topLinks" runat="server">
        <div id="defaultMenu" class=" container">
            <!-- topLinks -->
            <ul class="other_links">
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        <li>
                            <asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_Click" CssClass="btnResizer">
                            </asp:Button>
                        </li>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <li class="username">Welcome <span style="font-weight: bolder">
                            <% Response.Write(HttpContext.Current.Profile.GetPropertyValue("firstName") == "" ? HttpContext.Current.Profile.UserName : HttpContext.Current.Profile.GetPropertyValue("firstName") + " " + HttpContext.Current.Profile.GetPropertyValue("lastName")); %>
                        </span>! </li>
                        <li>
                            <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                                LogoutPageUrl="~/" />
                           
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/App/Profiles/ChangePassword.aspx"></asp:HyperLink>
                        </li>
                    </LoggedInTemplate>
                </asp:LoginView>
                <li>
                    <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" CssClass="btnResizer">
                    </asp:Button>
                </li>
                <li>
                    <asp:Button ID="btnContactUs" runat="server" OnClick="btnContactUs_Click" CssClass="btnResizer">
                    </asp:Button>
                </li>
                <uc2:SetCulture ID="SetCulture1" runat="server" />
            </ul>
            <div class="searchBox ">
                <input type="text" name="search" id="searchTxtBox" value="Search here" class="searchBG"
                    onclick="this.value = ( this.value == this.defaultValue ) ? '' : this.value;return true;" />
                <button name="searchBTN" type="submit" class="searchBTN">
                </button>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="header">
        <div class="header-top">
            <div class="container">
                <%--<div class="row">
                    <div class="col-md-12">
                        <a href="https://www.maharashtra.gov.in" target="_blank" class="mahalogo">
                            <img id="MaharashtraLogo_alt" runat="server" src="../../Images/maharashtralogo.png"
                                alt="Government of Maharashtra" /></a>
                        <asp:Label ID="lbl_headTitle" runat="server" CssClass="heading wow animated fadeInUp"
                            Text="Label"></asp:Label>
                        <a href="http://india.gov.in/" target="_blank" class="cenlogo">
                            <img id="NationalEmblem_alt" runat="server" src="../../Images/emblem.jpg" alt="Government of Maharashtra" /></a>
                        <a class="btnDisplay" href="#" name="Navigation">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a>
                    </div>
                    <div class="clear">
                    </div>
                </div>--%>
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
            </div>
        </div>
        <a class="btnDisplay" href="#" name="Navigation">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></a>
        <uc3:Menu1 ID="Menu11" runat="server" />
    </div>
    
</header>
<a class="btnDisplay" href="#" name="Navigation">
        <asp:Label ID="lbl_navigation" runat="server" Text="Label"></asp:Label></a>
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" Inherits="RCA.Site.Information.contactUs" CodeBehind="contactUs.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
<iframe src="https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d120561.34507720581!2d72.98333419326161!3d19.215194987989396!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sin!4v1396604946771" class="history-bg" frameborder="0" style="border:0"></iframe>
<div class="container"> 
    <h1>Contact us</h1> 
    <div class="contact">
        <address>
        <h2> Swachh Maharashtra Mission Urban Development </h2>
        <p><b>Address:</b> Borivali East, Mumbai, Maharashtra 400066
        <br /><b>Email:</b> sgnpmumbai@gmail.com
        <br /><b>Phone:</b> 022 2886 0362 / 022 28860389, 
        <br /><b>Fax:</b> 022 28864567
        <br /><b>Control room:</b> 022 28866449
</p>
        </address>
    </div>
    <div class="form-horizontal">
    <h2>Send Your Comments</h2>
    <form action="#">
        <div class="form-group">
            <input type="email" class="form-control" placeholder="Your Name..." maxlength="40">
        </div>
        <div class="form-group">
            <input type="email" class="form-control" placeholder="Your Email..." maxlength="40">
        </div>
        <div class="form-group">
            <textarea class="form-control" style="height: 130px;" placeholder="Write down your message..."></textarea>
        </div>
        <button type="submit" class="btn btn-orange pull-right">SEND</button>
        <div class="clear"></div>
    </form></div>
</div>
</asp:Content>

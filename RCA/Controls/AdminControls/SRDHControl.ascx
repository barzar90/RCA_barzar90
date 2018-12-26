<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SRDHControl.ascx.cs" Inherits="RCA.Controls.AdminControls.SRDHControl" %>
<div>
    <asp:Label ID="Label1" runat="server" Text="UID Number"></asp:Label>
    <asp:TextBox ID="txtUID" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" />
</div>
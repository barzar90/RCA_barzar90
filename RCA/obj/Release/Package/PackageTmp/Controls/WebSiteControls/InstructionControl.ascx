<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstructionControl.ascx.cs" Inherits="RCA.Controls.WebSiteControls.InstructionControl" %>
<asp:HyperLink ID="lnkmore" NavigateUrl="~/Site/Home/InstructionMore.aspx" CssClass="view-more"
    runat="server">
    <i class="fa fa-plus"></i>
    <asp:Label ID="lblInstructionMore" runat="server" CssClass="more" Visible="false"
        Text="Instructions"></asp:Label></asp:HyperLink>
<ul class="demo2">
    <asp:Repeater ID="RptrInstruction" runat="server" OnItemCommand="RptrInstruction_ItemCommand">
        <ItemTemplate>
            <li class="news-item">
                <asp:HyperLink ID="hypViewFile" runat="server" Target="_blank" Text='<%# Eval("Instruction") %>'
                    NavigateUrl='<%#  Eval("URL") %>'></asp:HyperLink>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
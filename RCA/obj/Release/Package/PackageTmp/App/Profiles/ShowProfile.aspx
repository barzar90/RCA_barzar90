<%@ Page Title="" Language="C#" MasterPageFile=
"~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="ShowProfile.aspx.cs" Inherits="RCA.App.Profiles.ShowProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <asp:Panel ID="pnlInfo" runat="server" Visible="False">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblFullName" runat="server" Text="Full name unknown" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text="Phone number unknown" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBirthDate" runat="server" Text="Birthdate unknown" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="UploadPhotoGallery.aspx.cs" Inherits="RCA.FORMS.UploadPhotoGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Upload Gallery </h1>
    <table width="100%" class="t_view">
        <tr>
            <td class="label">
                <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label><span
                    style="color: #f00;">*</span>
            </td>
            <td class="labelDescription">
                <asp:TextBox ID="txtTitle" runat="server" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="lblFileName" runat="server" Text="Path"></asp:Label><span
                    style="color: #f00;">*</span>
            </td>
            <td class="labelDescription">
                <asp:FileUpload runat="server" ID="FileUpload1" />
            </td>
        </tr>
        <tr>
            <td align="Left" colspan="2">
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" CssClass="button" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"
                    OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>

            <asp:ListView ID="LV" runat="server" ItemPlaceholderID="itemPlaceholderContainer"
                OnItemEditing="LV_ItemEditing1" OnItemUpdating="LV_ItemUpdating" DataKeyNames="ID"
                OnItemCanceling="LV_ItemCanceling1" OnItemDeleting="LV_ItemDeleting" OnPagePropertiesChanging="LV_PagePropertiesChanging"
                OnSelectedIndexChanged="LV_SelectedIndexChanged">
                <LayoutTemplate>
                    <table runat="server" class="t_view">
                        <tr runat="server">
                            <td runat="server" colspan="4">
                                <table id="itemPlaceholderContainer" runat="server"  width="100%">
                                    <tr runat="server">
                                        <th runat="server">
                                            Title
                                        </th>
                                        <th runat="server">
                                            Photo
                                        </th>
                                        <th id="Th1" runat="server">
                                            Action
                                        </th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server">
                                <asp:DataPager ID="DataPager1" runat="server">
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <EditItemTemplate>
                    <tr class="edititem">
                        <td class="pdflabel">
                            Title:<asp:TextBox ID="txtTitle" runat="server" Width="300px" Text='<%# Bind("Title") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" SetFocusOnError="true" ControlToValidate="txtTitle" ValidationGroup="Upload" ForeColor="Red">Required.
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="pdflabelDescription">
                            Path:<asp:FileUpload ID="EditFileUpload" runat="server" />
                        </td>
                        <td class="pdflabelDescription">
                           
                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="Upload" CausesValidation="true"/>
                            
                            <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <ItemTemplate>
                    <tr class="edititem">
                        <td class="pdflabel">
                            Title:<asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' />
                        </td>
                        <td class="pdflabelDescription">
                         <%--   <asp:Image ID="image1" runat="server" ImageUrl='<%# "~/SITE/Graphics/Images/photoGallery/" + Eval("Path") %>'
                                Width="100px" />--%>
                                 <asp:Image ID="image1" runat="server" ImageUrl='<%# "../../Site/Upload/galleryImages/" + Eval("Path") %>'
                                     Width="100px" />
                        </td>
                        <td class="pdflabelDescription">
                        <span onclick="return confirm('Are you sure to Delete?')">
                            <asp:Button ID="DeleteButton" runat="server" CssClass="button" CommandName="Delete" Text="Delete" />
                         </span>
                            <asp:Button ID="EditButton" runat="server" CssClass="button" CommandName="Edit" Text="Edit" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div style="text-align: center; font-weight: bold;">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="LV" PageSize="2">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="5" />
                    </Fields>
                </asp:DataPager>
            </div>
            <br />
            <table class="t_view" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lbl1" runat="server" Font-Bold="True" Font-Size="11px" ForeColor="#ffffff"></asp:Label>
                    </td>
                </tr>
            </table>

</asp:Content>

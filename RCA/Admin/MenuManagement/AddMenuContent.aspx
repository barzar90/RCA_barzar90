<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="AddMenuContent.aspx.cs" Inherits="RCA.Admin.MenuManagement.AddMenuContent" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
    <script src="ckeditor/jquery.1.9.1.js" type="text/javascript"></script>
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="ckeditor/adapters/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('.mckeditor').ckeditor();
            $('.mckeditor').ckeditor().on('getData.ckeditor', function (event, editor, data) {
                $.ajax({
                    type: "POST",
                    url: "../../WebServices/validateHtml.asmx/ValidateHTML",
                    data: "{'editorContent' : '" + data.dataValue + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == false) {
                            $('#' + editor.name + '').val('');
                        }
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <h1>
        Add Menu Content
    </h1>
    <table width="100%" class="table table-striped table-bordered">
        <tr>
            <td nowrap="nowrap" width="200px">
                <asp:Label ID="lblPageTitle" runat="server" Text="Page Title"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPageTitle" CssClass="textEntry" runat="server" Width="450px"
                    Text="" ValidationGroup="save"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvPageTitle" ForeColor="Red" ControlToValidate="txtPageTitle"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter Page Title."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regPageTitle" ForeColor="Red" runat="server" ControlToValidate="txtPageTitle" ValidationExpression="^[0-9A-Za-z ]+$" 
                        ErrorMessage="Please Do Not Enter Special Characters" ValidationGroup="save"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
                Local Language Page Title
            </td>
            <td>
                <asp:TextBoxControl ID="txtPageTitle_LL" runat="server" Width="450px" DestinationLanguage="MARATHI"
                    Text="" CssClass="textEntry"></asp:TextBoxControl>
                <%--<asp:RequiredFieldValidator ID="rfvPageTitle_LL" ForeColor="Red" ControlToValidate="txtPageTitle_LL"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter Page Title in Marathi."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regPageTitle_LL" ForeColor="Red" runat="server" ControlToValidate="txtPageTitle_LL" ValidationExpression="^[0-9A-Za-z ]+$" 
                        ErrorMessage="Please Do Not Enter Special Characters" ValidationGroup="save"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
                Short Description
            </td>
            <td>
                <asp:TextBox ID="txtEditor2" CssClass="mckeditor" ClientIDMode="Static" TextMode="MultiLine"
                    runat="server" Height="30px" Width="153px" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px" style="height: 47px">
                Local Language Short Description
            </td>
            <td style="width: 100%; height: 47px;" align="center">
                <asp:TextBox ID="txtEditor1" CssClass="mckeditor" ClientIDMode="Static" TextMode="MultiLine"
                    runat="server" Height="26px" Width="140px" Text=""></asp:TextBox>
            </td>
        </tr>
        

        <tr>
            <td nowrap="nowrap" width="200px">
                Long Description
            </td>
            <td width="750px">
                <asp:TextBox ID="txtEditor3" CssClass="mckeditor" ClientIDMode="Static" TextMode="MultiLine"
                    runat="server" Height="37px" Width="154px" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
                Local Language Long Description
            </td>
            <td>
                <asp:TextBox ID="txtEditor4" CssClass="mckeditor" ClientIDMode="Static" TextMode="MultiLine"
                    runat="server" Height="52px" Width="155px" Text=""></asp:TextBox>
            </td>
        </tr>
        

        <tr>
            <td nowrap="nowrap" width="200px">
                Sequence No&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtSequenceNo" runat="server" CssClass="textEntry" Width="98px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtSequenceNo"
                    ValidChars="0123654789" FilterType="Numbers">
                </asp:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                Is Active?
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Is Approve?
            </td>
            <td>
                <asp:CheckBox ID="chkIsApprove" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Select File Type to Upload :
            </td>
            <td>
                <asp:FileUpload ID="UploadFile" runat="server" class="multi" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Images Path &nbsp;:&nbsp;&nbsp;  ../../Site/Upload/Images/fileName.(extention)<br/> Pdf Path&nbsp;:&nbsp;&nbsp; ../../Site/Upload/Pdf/fileName.(extention) <br/> Video Path&nbsp;:&nbsp;&nbsp; ../../Site/Upload/Video/fileName.(extention)"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="labelM">
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>&nbsp;&nbsp;
                <br />
                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btn_Save" class="btn btn-sm btn-success" runat="server" Text="Save" Width="68px"
                    OnClick="btn_Save_Click" ValidationGroup="save" CausesValidation="true" />&nbsp;&nbsp;
                <asp:Button ID="btn_Cancel" class="btn btn-sm btn-warning" runat="server" Text="Cancel" Width="68px"
                    CausesValidation="false" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="pressRelease.aspx.cs" Inherits="MSHC.Site.Information.pressRelease" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/PagerControl.ascx" TagName="PagerControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="col pageTitle">
        Press News
    </div>

     <script language="JavaScript" type="text/javascript">


         var isShift = false;
         function keyUP(keyCode) {

             if (keyCode == 16)
                 isShift = false;
         }
         function isAlphaNum(keyCode) {
             if (keyCode == 16)
                 isShift = true;
             return ((keyCode >= 65 && keyCode <= 90) || ((keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 189 || keyCode == 191 || keyCode == 109 || keyCode == 111 || (keyCode >= 48 && keyCode <= 57) || (keyCode >= 96 && keyCode <= 105)) && isShift == false))
         }
         function isNumberKey1(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode;
             if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }

         function isBS(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode || 8)

                 return false;

             return true;


         }
         function IsAlphabet(evt) {

             var charCode = (evt.which) ? evt.which : event.keyCode

             var txt = String.fromCharCode(charCode)

             if (txt.match(/^[a-zA-Z\b ]+$/))

                 return true

             return false

         }
         function checkDate(sender, args) {


             if (sender._selectedDate > new Date()) {
                 alert("You Can Not Select Date Greater Than Todays Date!");
                 sender._selectedDate = new Date();
                 //sender._selectedDate = "";
                 // set the date back to the current date 
                 sender._textbox.set_Value(sender._selectedDate.format(sender._format))
             }
         }
         function IsNumeric(sText, obj) {
             var ValidChars = "0123456789";
             var IsNumber = true;
             var Char;
             var sVAL
             Char = sText.charAt(0);
             if (Char == "." && obj.value.indexOf('.') > -1)
                 IsNumber = false;
             else {
                 if (ValidChars.indexOf(Char) == -1) {
                     IsNumber = false;
                     alert("Enter Only Nimeric Value");
                 }
             }
             return IsNumber;
         }

         function checkname() {
             var keyCode = window.event.keyCode;
             if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                 window.event.returnValue = false;
                 alert("Enter only letters");
             }
         }


         function Checkfiles() {
             var fup = document.getElementById('FileUpload1');
             var fileName = fup.value;
             var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
             if (ext == "gif" || ext == "GIF" || ext == "PNG" || ext == "png" || ext == "jpg" || ext == "JPG" || ext == "bmp" || ext == "BMP") {
                 return true;
             }
             else {
                 alert("Upload Gif,Bmp or Jpg images only");
                 fup.focus();
                 return false;
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomForms" runat="server">
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
    <%-- <div class="pageTitle" style="padding: 50px">
        Page Under Construction</div>--%>
 <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblFromDate" runat="server" Text="From Date" AssociatedControlID="txtFromDate">
                    
                </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" onkeydown="return isBS(event);" onkeypress="return IsAlphabet(event);">

                </asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter From Date"
                    ControlToValidate="txtFromDate" ForeColor="#CC3300" ValidationGroup="GR">*</asp:RequiredFieldValidator>--%>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblToDate" runat="server" Text="To Date" AssociatedControlID="txtToDate">
                </asp:Label>
            </td>
            <td class="rightMenu" style="width: 198px">
                <asp:TextBox ID="txtToDate" runat="server" onkeydown="return isBS(event);" onkeypress="return IsAlphabet(event);">
                </asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter To Date"
                    ControlToValidate="txtToDate" ForeColor="#CC3300" ValidationGroup="GR">*</asp:RequiredFieldValidator>--%>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Doc Type" Visible="False" AssociatedControlID="ddlDocumentType">
                </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDocumentType" runat="server" Visible="false">
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select DropDown"
                    ControlToValidate="ddlDocumentType" ForeColor="#CC3300" ValidationGroup="GR"
                    InitialValue="Please Select" SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
            </td>
           
        </tr>
            <tr>
            <td style="height:60px">
                <asp:Label ID="lblKeywordsearch" runat="server" Text="Keyword Search" AccessKey="TextBox5">
                    
                </asp:Label>
            </td>
            <td class="rightMenu" style="width: 198px">
                <asp:TextBox ID="TextBox5" runat="server">
                </asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSearchGR" runat="server" Text="Search" OnClick="btnSearch_Click"
                    Style="height: 26px" ValidationGroup="GR" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Style="height: 26px" OnClick="btnClear_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
               
            
            </td>
        </tr>
       
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" CssClass="mGrid" runat="server" AutoGenerateColumns="False"
                    CellPadding="3" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#999999"
                    BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="SR No" SortExpression="SRNo" HeaderStyle-CssClass="gridHeader"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SRNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SRNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Document Name" SortExpression="DocumentName" HeaderStyle-CssClass="gridHeader"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DocumentName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DocumentName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"></HeaderStyle>
                            <ItemStyle CssClass="gridRow"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" SortExpression="CreatedDate" HeaderStyle-CssClass="gridHeader"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Document Path" SortExpression="DocumentPath" HeaderStyle-CssClass="gridHeader"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DocumentPath") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%--<asp:Label ID="Label2" runat="server" Text='<%# Bind("DocumentPath") %>'></asp:Label>--%>
                                <%--<asp:HyperLink ID="btnPath" ImageUrl="~/SITE/Graphics/Images/pdf-icon.png" Text='<%# Bind("DocumentPath") %>' NavigateUrl='<%# Bind("DocumentPath") %>' Width="10px"  runat="server">
                       </asp:HyperLink>--%>
                                <%-- <a href='<%# Eval("DocumentPath","../Upload/{0}") %>' target="_blank" ><img id="img1" src="../Graphics/Images/pdf-icon.png" alt="" width="20px" /></a>--%>
                                <a href='<%# Eval("DocumentPath") %>' target="_blank">
                                    <img id="img1" src="../Graphics/Images/pdf-icon.png" alt="" width="20px" /></a>
                                <%-- <asp:ImageButton ID="btnPath" runat="server" ImageUrl="~/SITE/Graphics/Images/pdf-icon.png"  CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Img" Width="20px"  />--%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"></HeaderStyle>
                            <ItemStyle CssClass="gridRow"></ItemStyle>
                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="Document Type" SortExpression="DocumentType">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DocumentType") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DocumentType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created Date" SortExpression="CreatedDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="Doc Id" SortExpression="DOC ID" HeaderStyle-CssClass="gridHeader" Visible ="false"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DocumentID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblDocID" runat="server" Text='<%# Bind("DocumentID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="delete" HeaderStyle-CssClass="gridHeader" Visible ="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" CommandArgument='<%# Eval("DocumentID") %>'>Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#cccccc" HorizontalAlign="Center" CssClass="pager" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <uc1:PagerControl ID="pgCtr1" runat="server" PageSize="10" PageMode="LinkButton" />
</asp:Content>

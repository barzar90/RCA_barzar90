<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="UploadInstruction.aspx.cs" Inherits="MSHC.App.Forms.UploadInstruction" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1><span>Upload Instruction</span></h1>
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
                    <asp:DataGrid ID="dg_PDF" AutoGenerateColumns="False" ShowFooter="True" runat="server"
                        Width="100%" DataKeyField="ID" CssClass="table table-bordered table-striped" OnCancelCommand="dg_PDF_CancelCommand" OnDeleteCommand="dg_PDF_DeleteCommand"
                        OnEditCommand="dg_PDF_EditCommand" OnItemCommand="dg_PDF_ItemCommand" OnItemDataBound="dgev_PDF_ItemDataBound"
                        OnUpdateCommand="dg_PDF_UpdateCommand">
                        <Columns>
                            <asp:TemplateColumn HeaderText="Sr No" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Sr_No" runat="server" Text='<%# Bind("Sr_No") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_Sr_No" runat="server" Text='<%# Bind("Sr_No") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="File ID" Visible="false" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Date" ItemStyle-Width="5%">
                               <ItemTemplate>
                                    <asp:Label ID="lbl_Date" runat="server" Text='<%#  Eval("CreatedDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                         <asp:TextBox ID="txt_CreatedDate" runat="server" onkeydown="return isBS(event);"></asp:TextBox>
                         <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_CreatedDate"></asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_CreatedDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red" Font-Size="X-Small" Text="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>                                
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_CreatedDate" onkeydown="return isBS(event);"  runat="server" Width="95%" Height="40px" Text='<%#  Eval("CreatedDate","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_CreatedDate"></asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_CreatedDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red" Font-Size="X-Small" Text="*"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Instruction" ItemStyle-Width="50%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Instruction" runat="server" Text='<%# Bind("Instruction") %>' />
                                    <span>
                                        <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txt_Instruction" runat="server" CssClass="formn-control"></asp:TextBox><span
                                        style="color: #f00;">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter events"
                                        Text="*" ForeColor="Red" ControlToValidate="txt_Instruction" ValidationGroup="UPN"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Instruction" runat="server" Width="95%" Height="40px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Instruction in Local Language" ItemStyle-Width="50%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Instruction_LL" runat="server" Text='<%# Bind("Instruction_LL") %>' />
                                    <span>
                                        <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <cc1:TextBoxControl ID="txt_Instruction_LL" runat="server" CssClass="formn-control" DestinationLanguage="MARATHI"
                                        Width="95%" Height="40px" TypingMode="CDAC" CDACDestinationLanguage="MARATHI"
                                        TextMode="MultiLine"></cc1:TextBoxControl>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter Instruction"
                                        Text="*" ForeColor="Red" ControlToValidate="txt_Instruction_LL" ValidationGroup="UPN"></asp:RequiredFieldValidator><span
                                            style="color: #f00;">*</span>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <cc1:TextBoxControl ID="txt_Instruction_LL" runat="server" DestinationLanguage="MARATHI"
                                        Width="95%" Height="40px" CDACDestinationLanguage="MARATHI" TypingMode="CDAC"
                                        TextMode="MultiLine"></cc1:TextBoxControl>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="Is PDF/URL">
                                <%--  <ItemTemplate>
                                <asp:CheckBox ID="chk_URL" runat="server" Checked='<%# Convert.ToBoolean(Eval("IsLink")) %>'
                                    AutoPostBack="true" OnCheckedChanged="chk_URL_OnCheckedChanged2"/>
                            </ItemTemplate>--%>
                                <FooterTemplate>
                                    <asp:CheckBox ID="chkFt_URL" runat="server" AutoPostBack="true" OnCheckedChanged="chkFt_URL_OnCheckedChanged" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkEd_URL" runat="server" AutoPostBack="true" OnCheckedChanged="chkEd_URL_OnCheckedChanged" />
                                    <%--<asp:FileUpload ID="txt_URL" runat="server" />--%>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <%--<asp:TemplateColumn HeaderText="Image">
                            <ItemTemplate>
                                <asp:FileUpload ID="UploadFileImage" runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:FileUpload ID="UploadFileEditEmage" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>--%>
                            <asp:TemplateColumn HeaderText=" URL / SelectFile" ItemStyle-Width="16%">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lbl_URL" runat="server" Text='<%# Bind("URL") %>' />--%>
                                    <a href='<%#Eval("URL")%>' target="_blank">
                                        <asp:Label ID="lbl_URL" runat="server" Text='<%# Bind("URL") %>' />
                                    </a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txt_URL" runat="server" Width="90%" Height="40px" Visible="false"></asp:TextBox>
                                    <asp:FileUpload ID="UploadFile" runat="server" Width="90%" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_URL" runat="server" Width="95%" Height="40px" Visible="false"></asp:TextBox>
                                    <asp:FileUpload ID="UploadFile" runat="server" />
                                    <%--<asp:FileUpload ID="txt_URL" runat="server" />--%>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Active">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Is_Active" runat="server" Checked='<%# Convert.ToBoolean(Eval("Is_Active")) %>'
                                        AutoPostBack="true" OnCheckedChanged="chk_Is_Active_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="IsNew">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chkstatus" AutoPostBack="true" key='<%# Eval("ID") %>' OnCheckedChanged="chkbox_OnCheckedChanged"
                                        runat="server" />
                                    <asp:Label ID="lblIsnew" Visible="false" runat="server" Text='<%# Eval("IsNew") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:EditCommandColumn UpdateText="Update" CancelText="Cancel" ItemStyle-CssClass="btn btn-info btn-sm" EditText="Edit" HeaderText="Edit">
                                <HeaderStyle Width="10%" />
                            </asp:EditCommandColumn>
                            <asp:TemplateColumn HeaderText="Delete">
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtn_Add" Text="Add" runat="Server" CssClass="btn btn-success btn-sm" CommandName="Add" ValidationGroup="UPN" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <span onclick="return confirm('Are you sure to Delete?')">
                                        <asp:LinkButton ID="lbtn_Delete" runat="Server" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="Delete" />
                                    </span>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>

                    <asp:Label ID="lbl_Error" runat="server" CssClass="text-danger"></asp:Label>
    </asp:Panel>
</asp:Content>

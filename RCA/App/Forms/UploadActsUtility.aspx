<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="UploadActsUtility.aspx.cs" Inherits="MSHC.App.Forms.UploadActsUtility" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel2" runat="server">
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="lblact" runat="server" Text="Act No "></asp:Label>
            <div class="form-group">
                <asp:TextBox ID="txtact" runat="server" class="form-control" AutoCompleteType="Disabled" autocomplete="off" ></asp:TextBox></div>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblactyear" runat="server" Text="Act year "></asp:Label>
            <div class="form-group">
                <asp:TextBox ID="txtactyear" runat="server" class="form-control" 
                    AutoCompleteType="Disabled" autocomplete="off" 
                    onkeypress=" return ValidateCharacter('0123456789-/', event);" MaxLength="7"></asp:TextBox></div>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblpublishdate" runat="server" Text="Publish Date"></asp:Label>
            <div class="form-group">
                <asp:TextBox ID="txtpublishdate" runat="server" class="form-control" AutoCompleteType="Disabled" autocomplete="off" onkeypress=" return ValidateCharacter('0123456789-/', event);"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtpublishdate">
                </asp:CalendarExtender>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="lblacttitle" runat="server" Text="Short Title "></asp:Label>
            <div class="form-group">
                <asp:TextBox ID="txtacttittle" runat="server" TextMode="MultiLine" class="form-control" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox></div>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblupload" runat="server" Text="File Name "></asp:Label>
            <br />
            <asp:FileUpload ID="FU1" runat="server" CssClass="form-control" />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <%--<asp:Label ID="lblSavede" runat="server" Text=""></asp:Label>--%>
            </div>
        <div class="col-md-4">
            <asp:Button ID="btnsave" runat="server" Text="Save " OnClick="btnsave_Click" CssClass="btn btn-sm btn-success mtop20" />
            <asp:Button ID="btnreset" runat="server" Text="Reset"  
                CssClass="btn btn-sm btn-success mtop20" onclick="btnreset_Click"/>
            </div>
    </div>

    
 
        <asp:DataList ID="DataList1" runat="server" Width="100%" CellSpacing="3" CellPadding="3"
            OnEditCommand="DataList1_EditCommand1" OnUpdateCommand="DataList1_UpdateCommand"
            OnCancelCommand="DataList1_CancelCommand" OnDeleteCommand="DataList1_DeleteCommand">
            <HeaderTemplate>
                <table style="width: 100%;" class="table table-bordered">
                    <tr>
                        <th>
                             <asp:Label ID="lblsrno" runat="server" Text="SR.NO."></asp:Label>
                        </th>
                    
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="Act No"></asp:Label>
                        </th>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="Act Year"></asp:Label>
                        </th>
                     
                        <th>
                            <asp:Label ID="Label9" runat="server" Text="Short Title"></asp:Label>
                        </th>
                        <th>
                            <asp:Label ID="Label13" runat="server" Text="Pdf Name"></asp:Label>
                        </th>
                        <th>
                            Edit
                        </th>
                        <th>
                            Delete
                        </th>
                    
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("SRNO") %>'></asp:Label> 
                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("ActNo") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Actyear") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ShortTitle") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("PdfName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-sm btn-warning" />
                    </td>
                    <td>
                        <asp:Button ID="dltbtn" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-sm btn-warning" />  
                    </td>
                
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("SRNO") %>'></asp:Label>
                    
                    </td>
                    <td>
                        <asp:Label ID="lblpdf" runat="server" Text='<%# Eval("PdfName") %>' Visible="false"></asp:Label>
                        <asp:TextBox ID="txteactno" runat="server" Text='<%# Eval("ActNo") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblactyear" runat="server" Text='<%# Eval("Actyear") %>' Visible="false"></asp:Label>
                        <asp:TextBox ID="txteactyear" runat="server" Text='<%# Eval("Actyear") %>'></asp:TextBox>
                    </td>
                 
                    <td>
                        <asp:Label ID="lblshorttitle" runat="server" Text='<%# Eval("ShortTitle") %>' Visible="false"></asp:Label>
                        <asp:TextBox ID="txteshortitle" runat="server" Text='<%# Eval("ShortTitle") %>' ></asp:TextBox>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpdate" runat="server" />
                        <asp:Button ID="Save" runat="server" Text="Update" CommandName="Update" CssClass="button" />
                    </td>
                    <td>
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="button" />
                    </td>
                   <td>
                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                   </td>
                </tr>
            </EditItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>

        <div class="text-center">
         <asp:Button ID="btnprev" runat="server" Text="Previous" 
            onclick="btnprev_Click" CssClass="btn btn-default" />
        <asp:Button ID="btnnext" runat="server" Text="Next" onclick="btnnext_Click" CssClass="btn btn-default" />
       </div>

    </asp:Panel>
</asp:Content>

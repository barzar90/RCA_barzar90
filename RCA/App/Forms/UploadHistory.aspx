<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="UploadHistory.aspx.cs" Inherits="MSHC.App.Forms.UploadHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>    
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">
   
   function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
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

    function validate() {

        if (document.getElementById("txtYear").value == "") {
            alert("Please enter product Code");
            document.getElementById("txtYear").focus();
            return false;
        }
        if (document.getElementById("txtDescription").value == "") {
            alert("Please enter product name");
            document.getElementById("txtDescription").focus();
            return false;
        }

    }

    </script>
<h1> Upload History</h1>
<p>&nbsp;</p>
    <table width="0" border="0" class="t_view">
  <tr>
    <td><asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
</td>
    <td><asp:TextBox ID="txtYear"  onkeypress="return isNumberKey(event)" CausesValidation="false"  runat="server" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox></td>
  </tr>
  <tr>
    <td><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></td>
    <td> <asp:TextBox ID="txtDescription" runat="server" Height="120px" 
            TextMode="MultiLine" Width="277px" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox></td>
  </tr>



  <tr>
    <td><asp:Label ID="lblImage" runat="server" Text="Image"></asp:Label></td>
    <td><asp:FileUpload ID="FileUploadImage" runat="server"/></td>
  </tr>


 <tr>
    <td> <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="Submit" OnClientClick="javascript:return validate();" /></td>
    <td><asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click"  Text="Cancel" /></td>
  </tr>
</table>
        <asp:GridView ID="grdHistory" runat="server" CssClass="t_view"
            onrowcommand="grdHistory_RowCommand" 
            onrowdeleting="grdHistory_RowDeleting"             
            onrowupdating="grdHistory_RowUpdating" AutoGenerateColumns="False" 
            onrowcancelingedit="grdHistory_RowCancelingEdit" 
            onrowediting="grdHistory_RowEditing">
            <Columns>            
                <asp:TemplateField HeaderText="Sr No" Visible = "true">
                    <ItemTemplate>
                        <asp:Label ID="lblSrNo" runat="server" Text='<%# Bind("SrNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Year Of History" >
                 <EditItemTemplate>
                   <asp:TextBox ID="EditYearOfHistory" runat="server" Text='<%# Bind("YearOfHistory") %>'></asp:TextBox>
                </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="YearOfHistory" runat="server" Text='<%# Bind("YearOfHistory") %>'></asp:Label>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" >
                <EditItemTemplate>
                   <asp:TextBox ID="EditDetails" textmode="MultiLine" runat="server" Text='<%# Bind("Details") %>'></asp:TextBox>
                </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="Details" ReadOnly ="true" runat="server" ToolTip =""  Text='<%# Bind("Details") %>'></asp:TextBox>
                    </ItemTemplate>                
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Image Content" >
                  <EditItemTemplate>
                        <asp:FileUpload ID="EditImageContent" runat="server" 
                            ></asp:FileUpload>
                  <%--  <asp:Image ID="ImageContent" Height = "100" Width = "100" runat="server"/>--%>
                </EditItemTemplate>
                   <%-- <ItemTemplate>
                        <asp:Image ID="ImageContent" Height = "100" Width = "100" runat="server" ImageUrl = '<%# Bind("ImageContent") %>'/>                        
                    </ItemTemplate> --%>               
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Name" >
                
                    <ItemTemplate>
                        <asp:Label ID="ImageFileName" runat="server" Text='<%# Bind("ImageFileName") %>'></asp:Label>
                    </ItemTemplate>                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Extention">
                
                    <ItemTemplate>
                        <asp:Label ID="ImageFileType" runat="server" Text='<%# Bind("ImageFileType") %>'></asp:Label>
                    </ItemTemplate>                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created On" >
                 
                    <ItemTemplate>
                        <asp:Label ID="CreatedOn" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label>
                    </ItemTemplate>                
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Modified On" >
                
                    <ItemTemplate>
                        <asp:Label ID="ModifiedOn" runat="server" Text='<%# Bind("ModifiedOn") %>'></asp:Label>
                    </ItemTemplate>                
                </asp:TemplateField>  
                

                 <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit"
                                        CommandName="Edit" CommandArgument='<%# Eval("SrNo") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"
                                        CausesValidation="False" />
                                    &nbsp;
                                    <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"
                                        CausesValidation="False" />
                                </EditItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>
                
                             
                <asp:TemplateField HeaderText=" ">
                <ItemTemplate>
                 <span onclick="return confirm('Are you sure to Delete?')">
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="delete"
                        CommandArgument='<%# Eval("SrNo") %>' Text="Delete"></asp:LinkButton>
                        </span>
                </ItemTemplate>
                </asp:TemplateField>


            </Columns>        
        <PagerSettings FirstPageText="Prev" LastPageText="Last" 
            Mode="NextPreviousFirstLast" NextPageText="Next" />
        <PagerStyle BackColor="#ff6600" HorizontalAlign="Center" CssClass="pager" />
                                
        </asp:GridView>
    </p>
    <p>
        &nbsp;&nbsp;
        </p>




</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="UploadImages.aspx.cs" Inherits="RCA.App.Forms.UploadImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix midht">
    </div>

    <h2>Upload Images</h2>
    <div class="complaint-form ">
    <div class="col-md-4 col-sm-4"> <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Enter Name">
            </asp:Label>
            <asp:TextBox ID="txtName" class="form-control" runat="server" AutoCompleteType="Disabled" autocomplete="off">
            </asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Please Enter Name" ForeColor="Red" ValidationGroup="SMM"></asp:RequiredFieldValidator>
        </div>
        </div>
          <div class="col-md-4 col-sm-4">
        <div class="form-group">
            <asp:Label ID="lblNameLocal" runat="server" Text="Enter Name in Marathi"></asp:Label>
            <asp:TextBox ID="txtMarathi" runat="server" class="form-control" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMarathi"
                    ErrorMessage="Please Enter Marathi Name" ForeColor="Red" ValidationGroup="SMM"></asp:RequiredFieldValidator>
        </div></div>
        <div class="col-md-4 col-sm-4">  <div class="form-group">
            <asp:Label ID="lblUpload" runat="server" Text="Please Select File">
            </asp:Label>
            <asp:FileUpload ID="fileImgUpload" runat="server" />
            <asp:HiddenField ID="hdnImages" runat="server" />
        </div></div>
       <div class="col-md-12 col-sm-12">
      
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Submit" ValidationGroup="SMM"
            OnClick="btnSubmit_Click" />
        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-warning" Text="Reset"
            OnClick="btnReset_Click" />    <br /></div>
    </div>



    <div>
        <asp:GridView ID="gdEditDeelteImages" runat="server" AutoGenerateColumns="False"
            CssClass="table table-bordered" HeaderStyle-BackColor="#fff" ShowFooter="True"
            HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" OnPageIndexChanging="gdEditDeelteImages_PageIndexChanging"
            OnRowDeleting="gdEditDeelteImages_RowDeleting" OnSelectedIndexChanged="gdEditDeelteImages_SelectedIndexChanged"
            OnSelectedIndexChanging="gdEditDeelteImages_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:TemplateField HeaderText="Images">
                    <ItemTemplate>
                        <a target="_blank" id="lnk" runat="server" href='<%# string.Format("~/Site/Upload/Images/{0}", Eval("ImgPath"))%>'>
                            <%#Eval("ImgPath")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button"  SelectText="Edit" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
            <HeaderStyle BackColor="#61A6F8" Font-Bold="True" ForeColor="White"></HeaderStyle>
        </asp:GridView>
    </div>
</asp:Content>

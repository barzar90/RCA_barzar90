<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="InstructionMore.aspx.cs" Inherits="MSHC.Site.Home.InstructionMore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
    function forgetEnterKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 13) && ((node.type == "text") ||
          (node.type == "password"))) {
            return false;
        }
    }
    document.onkeypress = forgetEnterKey;
  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <h1><asp:Label ID="lblInstruction" runat="server" Text="Label"></asp:Label></h1><br />
<div class="clear"></div>
   <ul class="list-group">
  <li class="list-group-item"> <asp:Label ID="lblSearch" Text="Enter A KeyWord To Search : " runat="server" AssociatedControlID="txtSearch"></asp:Label>
      <div class="col-md-8 col-sm-8">
  
      <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server">
        </asp:TextBox>
     </div>
         <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-warning" /></li>

</ul>

<div class="table-responsive">
    <asp:UpdatePanel ID="upInstruction" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvInstruction" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed table-striped"
                ShowFooter="True" OnPageIndexChanging="gvInstruction_PageIndexChanging" AllowPaging="true" PageSize="10">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="instruction" SortExpression="Instruction" HeaderStyle-Width="70%">
                        <ItemTemplate>
                            <asp:Label ID="lblInstruction" runat="server" Text='<%# string.Format("{0}", System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower().Equals("mr-in") ? Eval("Instruction_LL").ToString() : Eval("Instruction").ToString()) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date" SortExpression="Date" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#  Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Download" SortExpression="URL" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblDownload" runat="server" Text="">
                                <a class='align-center' href='<%# Eval("URL") %>' target="_blank"><img id="img1" src="../../Images/pdf.png" alt="PDF" title="Download PDF"/></a>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

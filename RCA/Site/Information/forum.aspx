<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="MSHC.Site.Information.forum" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/PagerControl.ascx" TagName="PagerControl" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomForms" runat="server">

   
   
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">
 
        <h1> <asp:Label ID="lblTitelDownloads" runat="server"></asp:Label></h1>
         
<div>
            <asp:Literal ID="ltrmsg" runat="server" Visible="false"></asp:Literal>
        </div>


 <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblFromDate" runat="server" Text="From Date" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter From Date"
                    ControlToValidate="txtFromDate" ForeColor="#CC3300" ValidationGroup="GR" 
                    Visible="False">*</asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblToDate" runat="server" Text="To Date" Visible="False"></asp:Label>
            </td>
            <td class="rightMenu" style="width: 198px">
                <asp:TextBox ID="txtToDate" runat="server" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter To Date"
                    ControlToValidate="txtToDate" ForeColor="#CC3300" ValidationGroup="GR">*</asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Doc Type" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDocumentType" runat="server" 
                    onselectedindexchanged="ddlDocumentType_SelectedIndexChanged" 
                    Visible="False">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select DropDown"
                    ControlToValidate="ddlDocumentType" ForeColor="#CC3300" ValidationGroup="GR"
                    InitialValue="Please Select" SetFocusOnError="True" Visible="False">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnSearchGR" runat="server" Text="Search" OnClick="btnSearch_Click"
                    ValidationGroup="GR" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
               
            </td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" CssClass="t_view" runat="server" AutoGenerateColumns="False"
                    CellPadding="3" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#999999"
                    BorderStyle="None" BorderWidth="1px"  >
                    <Columns>
                        <asp:TemplateField HeaderText="SR No" SortExpression="SRNo" HeaderStyle-CssClass="gridHeader"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SRNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SRNo") %>'></asp:Label>
                            </ItemTemplate>

<HeaderStyle CssClass="gridHeader"></HeaderStyle>

<ItemStyle CssClass="gridRow"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Document Name" SortExpression="DocumentName" HeaderStyle-CssClass="gridHeader"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DocumentName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DocumentName") %>'></asp:Label>
                                 <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"></HeaderStyle>
                            <ItemStyle CssClass="gridRow"></ItemStyle>
                        </asp:TemplateField>

                      <asp:TemplateField HeaderText="DocumentName_LL">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDocumnetName_LL" runat="server" Text='<%# Bind("DocumnetName_LL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDocumnetName_LL" runat="server" Text='<%# Bind("DocumnetName_LL") %>'></asp:Label>
                          <span>
                                            <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span></a>
                    </ItemTemplate>

<HeaderStyle CssClass="gridHeader"></HeaderStyle>

<ItemStyle CssClass="gridRow"></ItemStyle>
                </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date" Visible="true">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCreatedDate" runat="server" Text='<%# Bind("CreatedDate1") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Bind("CreatedDate1") %>'></asp:Label>
                            </ItemTemplate>

<HeaderStyle CssClass="gridHeader"></HeaderStyle>

<ItemStyle CssClass="gridRow"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View And Download" SortExpression="DocumentPath" HeaderStyle-CssClass="gridHeader"
                            ItemStyle-CssClass="gridRow">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DocumentPath") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate >
                                <%--<asp:Label ID="Label2" runat="server" Text='<%# Bind("DocumentPath") %>'></asp:Label>--%>
                                <%--<asp:HyperLink ID="btnPath" ImageUrl="~/SITE/Graphics/Images/pdf-icon.png" Text='<%# Bind("DocumentPath") %>' NavigateUrl='<%# Bind("DocumentPath") %>' Width="10px"  runat="server">
                       </asp:HyperLink>--%>
                                <%-- <a href='<%# Eval("DocumentPath","../Upload/{0}") %>' target="_blank" ><img id="img1" src="../Graphics/Images/pdf-icon.png" alt="" width="20px" /></a>--%>
                                <a href='<%# Eval("DocumentPath") %>' target="_blank"  style="text-align:center ">
                                    <img id="img1" src="../Graphics/Images/pdf-icon.png" alt="" width="20px" /></a>
                                <%-- <asp:ImageButton ID="btnPath" runat="server" ImageUrl="~/SITE/Graphics/Images/pdf-icon.png"  CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Img" Width="20px"  />--%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"></HeaderStyle>
                            <ItemStyle CssClass="gridRow" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Size"  >
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSize" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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

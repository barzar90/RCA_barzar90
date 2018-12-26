<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="MSHC.Controls.AdminControls.Login" %>
<script src="../../Scripts/md5.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
    function md5auth(seed) {
       var password = document.getElementById("<%= LoginUser.FindControl("Password").ClientID %>").value;
       var md1_password = calcMD5(password).toUpperCase();
       var hash = calcMD5(seed + md1_password);
       document.getElementById("<%= LoginUser.FindControl("Password").ClientID %>").value = hash.toUpperCase();
       return true;
    }
</script>
<h1>
    <asp:Label ID="lblLogin" runat="server"></asp:Label></h1>
    <div class="clearfix">
            </div>
<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
    OnLoggedIn="RedirectUser" OnAuthenticate="CreateLoginAudit">

    <LayoutTemplate>

        <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">
                    <div class="mainbox col-md-4 login">
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    <asp:Label ID="lblLoginPanel" runat="server"></asp:Label></div>
                            </div>
                            <div style="padding-top: 30px" class="panel-body">
                                <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12">
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        CssClass="notification1" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        CssClass="notification1" ErrorMessage="Password is required." ToolTip="Password is required."
                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </div>
                                <div style="margin-bottom: 25px" class="input-group">
                                    <asp:Label ID="UserNameLabel" CssClass="sr-only" runat="server" AssociatedControlID="UserName"></asp:Label>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="UserName" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div style="margin-bottom: 25px" class="input-group">
                                    <asp:Label ID="PasswordLabel" CssClass="sr-only" runat="server" AssociatedControlID="Password"></asp:Label>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                      <input style="display: none" type="password" id="Password1">
                                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"
                                        autocomplete="off"></asp:TextBox>
                                </div>
                                      <div class="textbox-wrap form-group">
                    <div class="input-group">

                     <asp:Label ID="lblCaptcha" runat="server" Text="Captcha (पडताळणी संकेतांक कोड)"></asp:Label>
                    <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" Width="250px"></asp:TextBox>
                    <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                        id="sp_captcha" runat="server" style="color: Red">*</span>
                    <asp:Image ID="Image1" runat="server" Height="50px" Width="220px"  ImageUrl="~/Site/Information/captcha.aspx" />

                    <input type="image" onclick="document.getElementById('form1').submit();" src="../../Images/Refresh.png"
                        alt="Refresh Captcha" style="width: 30px; height: 30px;" />


                    </div>
                                <div class="input-group" style="display:none">
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="RememberMe" CssClass="checkbox" runat="server" />
                                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline"></asp:Label>
                                        </label>
                                     <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Password"
                                        autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <p>
                                    <asp:Label ID="PasswordSent" runat="server"></asp:Label>
                                </p>
                                <div style="margin-top: 10px" class="form-group">
                                    <!-- Button -->
                                    <div class="col-sm-12 "><div class="row">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="btn btn-warning"
                                            ValidationGroup="LoginUserValidationGroup" CommandArgument="Submit" OnClick="LoginButton_Click" />
                                        <asp:Button ID="ForgotPassword" runat="server" Text="Forgot Password" CssClass="btn btn-warning"
                                            CommandArgument="Submit" OnClick="LoginUser_ForgotPassword" />
                                    </div></div>
                                </div>
                            </div>
                        </div>
                    </div>
            <div class="clearfix">
            </div>
        </asp:Panel>
    </LayoutTemplate>    
</asp:Login>
<p>
    &nbsp;</p>


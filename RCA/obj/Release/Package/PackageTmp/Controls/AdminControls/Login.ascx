<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="RCA.Controls.AdminControls.Login" %>
<script src="../../Scripts/md5.js" type="text/javascript"></script>
<link href="../../assets/bootstrap/css/main.css" rel="stylesheet" />
<script language="javascript" type="text/javascript">
    function md5auth(seed) {
       var password = document.getElementById("<%= LoginUser.FindControl("Password").ClientID %>").value;
       var md1_password = calcMD5(password).toUpperCase();
       var hash = calcMD5(seed + md1_password);
       document.getElementById("<%= LoginUser.FindControl("Password").ClientID %>").value = hash.toUpperCase();
       return true;
    }
</script>
<div class="mainbox col-md-6 col-md-offset-3"><h1><asp:Label ID="lblLogin" runat="server"></asp:Label></h1></div>
<div class="clearfix">
</div>
<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
    OnLoggedIn="RedirectUser" OnAuthenticate="CreateLoginAudit">

    <LayoutTemplate>

        <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">
            <%--<div class="text-center col-md-8">
                <div class="login100-pic js-tilt">
                    <img src="../../Images/login.png" alt="" />
                </div>
            </div>--%>
            <div class="mainbox col-md-6 col-md-offset-3">
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <asp:Label ID="lblLoginPanel" runat="server"></asp:Label>
                        </div>
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



                        <div class="form-group">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"></asp:Label>
                            <asp:TextBox ID="UserName" runat="server" autocomplete="off" CssClass="form-control" placeholder="Username"></asp:TextBox>
                        </div>

                        <%--<div style="margin-bottom: 25px" class="input-group"> 
                            <div class="wrap-input100">
                                <asp:Label ID="UserNameLabel" CssClass="sr-only" runat="server" AssociatedControlID="UserName"></asp:Label>
                                <asp:TextBox ID="UserName" runat="server" autocomplete="off" CssClass="input100" placeholder="Username"></asp:TextBox>
                                <span class="focus-input100"></span>
                                <span class="symbol-input100">
                                    <i class="fa fa-user" aria-hidden="true"></i>
                                </span>
                            </div>
                        </div>--%>

                        <div class="form-group">
                             <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"></asp:Label>
                             <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"
                                    autocomplete="off"></asp:TextBox>
                        </div>


                        <%--<div style="margin-bottom: 25px" class="input-group">
                            <div class="wrap-input100">
                                <asp:Label ID="PasswordLabel" CssClass="sr-only" runat="server" AssociatedControlID="Password"></asp:Label>
                                <input style="display: none" type="password" id="Password1">
                                <asp:TextBox ID="Password" runat="server" CssClass="input100" TextMode="Password" placeholder="Password"
                                    autocomplete="off"></asp:TextBox>
                                <span class="focus-input100"></span>
                                <span class="symbol-input100">
                                    <i class="fa fa-lock" aria-hidden="true"></i>
                                </span>
                            </div>
                        </div>--%>

                        <div class="form-group">
                            <asp:Label ID="lblCaptcha" runat="server" Text="Captcha (पडताळणी संकेतांक कोड)"></asp:Label>
                            <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="form-control"></asp:TextBox>                            
                                
                        </div>

                          <div class="form-group">
                              <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                                    id="sp_captcha" runat="server" style="color: Red">*</span>
                                <asp:Image ID="Image1" runat="server" Height="50px" Width="220px" ImageUrl="~/Site/Information/captcha.aspx" />

                                <input type="image" onclick="document.getElementById('form1').submit();" src="../../Images/Refresh.png"
                                    alt="Refresh Captcha" style="width: 30px; height: 30px;" />
                          </div>

                        <div style="margin-bottom: 25px" class="input-group">
                           <%-- <div class="wrap-input100">
                                <asp:Label ID="lblCaptcha" runat="server" Text="Captcha (पडताळणी संकेतांक कोड)"></asp:Label>
                                <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="input100"></asp:TextBox>
                                <span class="focus-input100"></span>
                                
                                <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                                    id="sp_captcha" runat="server" style="color: Red">*</span>
                                <asp:Image ID="Image1" runat="server" Height="50px" Width="220px" ImageUrl="~/Site/Information/captcha.aspx" />

                                <input type="image" onclick="document.getElementById('form1').submit();" src="../../Images/Refresh.png"
                                    alt="Refresh Captcha" style="width: 30px; height: 30px;" />
                            </div>--%>

                            
                            <div class="form-group" style="display: none">
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
                                <div class="col-sm-12 ">
                                    <div class="row">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="btn btn-success"
                                            ValidationGroup="LoginUserValidationGroup" CommandArgument="Submit" OnClick="LoginButton_Click" />
                                        <asp:Button ID="ForgotPassword" runat="server" Text="Forgot Password" CssClass="btn btn-primary"
                                            CommandArgument="Submit" OnClick="LoginUser_ForgotPassword" />
                                    </div>
                                </div>
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
    &nbsp;
</p>
<script src="../../assets/bootstrap/js/tilt.jquery.min.js"></script>
<script>
		$('.js-tilt').tilt({
			scale: 1.1
		})
</script>

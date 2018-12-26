<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="CaseEntryForm.aspx.cs" Inherits="RCA.Admin.MenuManagement.CaseEntryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
     <link href="../../Styles/jquery-ui-1.8.10.custom.css" rel="stylesheet" type="text/css" />
  <%--  <script type="text/javascript" src="../../Styles/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.10.custom.min.js"></script>  
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>--%>
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.10.custom.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".Date").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: false,
                changeYear: false,               
                //maxDate: '0'
            });

            $("#txtNextHearingDate").datepicker({
                minDate : 0
            });

            $("#txtLastHearingDate").datepicker({
                maxDate : 0
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <div>
        <div class="row">
            <div class="text-left col-md-6">
                <h1>
                    <span>Case Entry</span>
                </h1>
            </div>
            <div class="col-md-6 text-right">
                <%--       <asp:LinkButton CssClass="btn btn-sm btn-danger pull-right" ID="linkBack" Text="Back"
                    CausesValsidation="true" runat="server"  OnClick="linkBack_click" />--%>

                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-danger pull-right" OnClick="btnBack_Click" />
                <%--   onclick="linkBack_Click"--%>
            </div>
        </div>
        <div class="hajdivtable">
            <div class="row" id="divcaseno" runat="server">
                <div class="col-md-4">
                    <asp:Label ID="lblCaseNo" runat="server" Text="Enter Case No"></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtCaseNo" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCaseNo" ForeColor="Red" ControlToValidate="txtCaseNo"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter case number."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regCaseNo" ForeColor="Red" runat="server" ControlToValidate="txtCaseNo" ValidationExpression="^[0-9*#+]+$" 
                        ErrorMessage="Please Do Not Enter Alphabets(A-Z)(a-z)" ValidationGroup="save"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row" id="divcity" runat="server">
                <div class="col-md-3">
                    <asp:Label ID="lblDivision" runat="server" Text="Select Division"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drpDivsion" CssClass="form-control" runat="server" DataTextField="DivisionName" AutoPostBack="True" DataValueField="DivisionId" OnSelectedIndexChanged="drpDivsion_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvDivision" InitialValue="0" ForeColor="Red" ControlToValidate="drpDivsion"
                        runat="server" ValidationGroup="save" ErrorMessage="please choose division."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblDistrict" runat="server" Text="Select District"></asp:Label>
                </div>
                  <div class="col-md-3">
                    <asp:DropDownList ID="drpDistrict" DataTextField="DistrictName" DataValueField="DistrictId" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="rfvDistrict" InitialValue="0" ForeColor="Red" ControlToValidate="drpDistrict"
                        runat="server" ValidationGroup="save" ErrorMessage="please choose District."></asp:RequiredFieldValidator>
                </div>
            </div>
            

            <div class="row" id="divapplicant" runat="server">
                <div class="col-md-4">
                    <asp:Label ID="lblApplicant" runat="server" Text="Enter Applicant Name"></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtApplicant" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApplicant" ForeColor="Red" ControlToValidate="txtApplicant"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter applicant name."></asp:RequiredFieldValidator> 
                </div>
            </div>

            <div class="row" id="divopponent" runat="server">
                <div class="col-md-4">
                    <asp:Label ID="lblOpponent" runat="server" Text="Enter Opponent Name"></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtOpponent" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvOpponent" ForeColor="Red" ControlToValidate="txtOpponent"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter Opponent name."></asp:RequiredFieldValidator> 
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblStatus" runat="server" Text="Enter Case Status"></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtStatus" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStatus" ForeColor="Red" ControlToValidate="txtStatus"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter Status."></asp:RequiredFieldValidator> 
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblLastHearingDate" runat="server" Text="Enter LastHearing Date"></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtLastHearingDate" CssClass="Date form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastHearingDate" ForeColor="Red" ControlToValidate="txtLastHearingDate"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter LastHearing Date."></asp:RequiredFieldValidator> 
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblNextHearingDate" runat="server" Text="Enter NextHearing Date"></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNextHearingDate" CssClass="Date form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNextHearingDate" ForeColor="Red" ControlToValidate="txtNextHearingDate"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter NextHearing Date."></asp:RequiredFieldValidator> 
                </div>
            </div>

             <div class="row">
                <div class="col-md-3">
                    <asp:Button ID="btnSave" CssClass="btn btn-sm btn-success" runat="server" Text="Save"
                        OnClick="btnSave_Click" ValidationGroup="save" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-warning"
                        OnClientClick="javascript:history.go(-1);" OnClick="btnCancel_Click" />
                </div>
                <div class="col-md-6"></div>
            </div>
        </div>
    </div>
</asp:Content>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Net;
using System.Text;
using BL;


namespace MSHC.Site.Information
{
    public partial class Complaints : MAHAITPage
    {
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

        String username = "MahaGovDIT";

        String password = "{m@h@g0v]";

        String senderid = "MahaGov";
        HttpWebRequest request;
        Stream dataStream;
        int LangID = 0;
        #region Page_Load
        /// <summary>
        /// The drop box is filled here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
            }

            else
            {
                LangID = 1;
            }

            if (!IsPostBack)
            {
                FillDepartment();
                FillCountry();
                drpDepartment.Items.Insert(0, new ListItem("-Please Select-"));
                DrpCountry.Items.Insert(0, new ListItem("-Please Select-"));
                Drpstate.Items.Insert(0, new ListItem("-Please Select-"));
                Drpdistrict.Items.Insert(0, new ListItem("-Please Select-"));
                DrpTaluka.Items.Insert(0, new ListItem("-Please Select-"));
            }
        }
        #endregion







        protected void Page_PreRender(object sender, EventArgs e)
        {
            string DepartmentName = string.Empty;
            lblFullName.Text = GetResourceValue("General", "lblComp_FullName", "");
            lblAddress.Text = GetResourceValue("General", "lblComp_Address", "");
            lblCountry.Text = GetResourceValue("General", "lblComp_Country", "");
            lblDepartment.Text = GetResourceValue("General", "lblComp_Department", "");
            lblDistrict.Text = GetResourceValue("General", "lblComp_District", "");
            lblEmailId.Text = GetResourceValue("General", "lblComp_EmailId", "");
            lblComplaints.Text = GetResourceValue("General", "lblComp_Complaints", "");
            lblMobileNo.Text = GetResourceValue("General", "lblComp_MobileNo", "");
            lblState.Text = GetResourceValue("General", "lblComp_State", "");
            lblTaluka.Text = GetResourceValue("General", "lblComp_Taluka", "");

            Lblcaptcha.Text = GetResourceValue("General", "lblComp_Captcha", "");

            // lbl_Category.Text = GetResourceValue("FileSystem", "lbl_Category", "");

            btnSendComplaint.Text = GetResourceValue("General", "btnSendComplaint", "");
            btnExit.Text = GetResourceValue("General", "btnreset", "");


            lblComplaintPageTitle.Text = GetResourceValue("General", "lblComplaintPageTitle", "");

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {


                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameMarathi"].ToString();


                Page.Title = lblComplaintPageTitle.Text + "-" + DepartmentName;


            }
            else
            {

                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameEnglish"].ToString();

                Page.Title = lblComplaintPageTitle.Text + "-" + DepartmentName;

            }




        }


        #region FillCountry
        public void FillCountry()
        {
            DataSet dsGetCountry = new DataSet();
            try
            {
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "GetCountry";
                CMD.CommandTimeout = 30;
                CMD.Parameters.AddWithValue("@LangID", LangID);
                dsGetCountry = MAHAITDBAccess.ExecuteDataSet(CMD);
               
                if (dsGetCountry.Tables[0].Rows.Count > 0)
                {
                    DrpCountry.DataSource = dsGetCountry.Tables[0];
                    DrpCountry.DataTextField = "Countryname";
                    DrpCountry.DataValueField = "CountryId";
                    DrpCountry.DataBind();
                }
            }
            catch (Exception Ex)
            {

            }
        }
        #endregion

        #region FillDistrict

        public void FillDistrict(int State)
        {
            DataSet dsstate = new DataSet();
            //string connection = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            //SqlConnection nwindConn = new SqlConnection(connection);
            try
            {

                SqlCommand selectCMD = new SqlCommand();
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandText = "GetDistrict";
                selectCMD.CommandTimeout = 30;
                selectCMD.Parameters.AddWithValue("@State", State);
                selectCMD.Parameters.AddWithValue("@LangID", LangID);
                dsstate = MAHAITDBAccess.ExecuteDataSet(selectCMD);

                if (dsstate.Tables.Count > 0)
                {
                    if (dsstate.Tables[0].Rows.Count > 0)
                    {
                        Drpdistrict.DataSource = dsstate.Tables[0];
                        Drpdistrict.DataTextField = "DistrictName";
                        Drpdistrict.DataValueField = "Districtcode";
                        Drpdistrict.DataBind();
                    }
                }
            }

            catch (Exception Ex)
            {

            }
        }

        #endregion

        #region FillTaluka

        public void FillTaluka(int District)
        {
            DataSet dsstate = new DataSet();
            //string connection = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            //SqlConnection nwindConn = new SqlConnection(connection);
            try
            {
                SqlCommand selectCMD = new SqlCommand();
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandText = "GetTaluka";
                selectCMD.CommandTimeout = 30;
                selectCMD.Parameters.AddWithValue("@District", District);
                selectCMD.Parameters.AddWithValue("@LangID", LangID);
                dsstate = MAHAITDBAccess.ExecuteDataSet(selectCMD);

                if (dsstate.Tables.Count > 0)
                {
                    if (dsstate.Tables[0].Rows.Count > 0)
                    {
                        DrpTaluka.DataSource = dsstate.Tables[0];
                        DrpTaluka.DataTextField = "SubDistrictName";
                        DrpTaluka.DataValueField = "SubDistrictcode";
                        DrpTaluka.DataBind();
                    }
                }
            }
            catch (Exception Ex)
            {
            }
        }
        #endregion

        #region FillDepartment
        /// <summary>
        /// Fill the Department drop box
        /// </summary>
        /// 
        public void FillDepartment()
        {

            DataSet dsGetFileData = new DataSet();
            try
            {

                SqlCommand selectCMD = new SqlCommand();
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandText = "GetDepartment";
                selectCMD.CommandTimeout = 30;
                selectCMD.Parameters.AddWithValue("@Section", "1");
                selectCMD.Parameters.AddWithValue("@LangID", LangID);

                dsGetFileData = MAHAITDBAccess.ExecuteDataSet(selectCMD);

                if (dsGetFileData.Tables.Count > 0)
                {
                    if (dsGetFileData.Tables[0].Rows.Count > 0)
                    {
                        drpDepartment.DataSource = dsGetFileData.Tables[0];
                        drpDepartment.DataTextField = "Department";
                        drpDepartment.DataValueField = "DepartmentId";
                        drpDepartment.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region btnSendComplaint_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendComplaint_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatedata() == true)
                {

                    if (ucCaptcha.Insert() == true)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AddComplaint";
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.ToString());
                        cmd.Parameters.AddWithValue("@Department", Convert.ToInt32(drpDepartment.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@Telephoneno", txtTelephoneNo.Text.ToString());
                        cmd.Parameters.AddWithValue("@EmailId", txtEmailId.Text.ToString());
                        cmd.Parameters.AddWithValue("@Complaints", txtComplaints.Text.ToString());
                        cmd.Parameters.AddWithValue("@savedby", "1");
                        cmd.Parameters.AddWithValue("@Address", Txtaddress.Text.ToString());
                        if (DrpCountry.SelectedItem.Value == "-Please Select-")
                        {
                            cmd.Parameters.AddWithValue("@Country", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Country", Convert.ToInt32(DrpCountry.SelectedValue.ToString()));
                        }
                        if (Drpstate.SelectedItem.Value == "-Please Select-")
                        {
                            cmd.Parameters.AddWithValue("@State", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@State", Convert.ToInt32(Drpstate.SelectedValue.ToString()));
                        }
                        if (Drpdistrict.SelectedItem.Value == "-Please Select-")
                        {
                            cmd.Parameters.AddWithValue("@District", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@District", Convert.ToInt32(Drpdistrict.SelectedValue.ToString()));
                        }
                        if (Drpdistrict.SelectedItem.Value == "-Please Select-")
                        {
                            cmd.Parameters.AddWithValue("@Taluka", DBNull.Value);
                        }

                        else
                        {
                            cmd.Parameters.AddWithValue("@Taluka", Convert.ToInt32(DrpTaluka.SelectedValue.ToString()));
                        }

                        MAHAITDBAccess.ExecuteNonQuery(cmd);

;
                        //#endregion

                        #region access Configurable variable to send a Email
                        string SenderEmail = ConfigurationManager.AppSettings["userName"].ToString();
                        string SMTPstr = ConfigurationManager.AppSettings["host"].ToString();
                        string Portstr = ConfigurationManager.AppSettings["port"].ToString();
                        string NotificationtoDepartmentstr = ConfigurationManager.AppSettings["NotificationtoDepartment"].ToString();
                        #endregion

                        #region Initialise varables
                        string Contstr = "";
                        string Substr = "";
                        #endregion

                        #region Send Notification Email to department

                        string Subject_Mail = _subjectstr(txtFullName.Text.ToString(), txtEmailId.Text.ToString());
                        if (DrpCountry.SelectedItem.Value == "-Please Select-" || Drpstate.SelectedItem.Value == "-Please Select-" || Drpdistrict.SelectedItem.Value == "-Please Select-" || Drpdistrict.SelectedItem.Value == "-Please Select-")
                        {
                            DrpCountry.SelectedItem.Value = "";
                            Drpstate.SelectedItem.Value = "";
                            Drpdistrict.SelectedItem.Value = "";
                            Drpdistrict.SelectedItem.Value = "";
                            Contstr = "Hello Sir /Madam,\n\r" + "\n\r" + "It's a Complaint mail.\n\r" + "\n\r" + "The details are as follows:\n\r" + "1.Name of the Citizen/User: " + txtFullName.Text.ToString() + "\n\r" + "2.Feedback:" + txtComplaints.Text.ToString() + "\n\r" + "3.EmailID:" + txtEmailId.Text.ToString() + "\n\r" + "4.Mobile No:" + txtTelephoneNo.Text.ToString() + "\n\r" + "5.Country:" + "" + "\n\r" + "6.State:" + "" + "\n\r" + "7.District:" + "" + "\n\r" + "8.Taluka:" + "" + "\n\r" + "9.Department:" + drpDepartment.SelectedItem.ToString() + "\n\r" + "10.Address:" + Txtaddress.Text.ToString() + "\n\r" + "Regards,\n\r" + "\n\r" + "Support Team\n\r" + "Sugar Commissionerate Maharashtra State, Pune ";
                        }
                        else
                        {
                            Contstr = "Hello Sir /Madam,\n\r" + "\n\r" + "It's a Complaint mail.\n\r" + "\n\r" + "The details are as follows:\n\r" + "1.Name of the Citizen/User: " + txtFullName.Text.ToString() + "\n\r" + "2.Feedback:" + txtComplaints.Text.ToString() + "\n\r" + "3.EmailID:" + txtEmailId.Text.ToString() + "\n\r" + "4.Mobile No:" + txtTelephoneNo.Text.ToString() + "\n\r" + "5.Country:" + DrpCountry.SelectedItem.Text.ToString() + "\n\r" + "6.State:" + Drpstate.SelectedItem.Text.ToString() + "\n\r" + "7.District:" + Drpdistrict.SelectedItem.Text.ToString() + "\n\r" + "8.Taluka:" + DrpTaluka.SelectedItem.Text.ToString() + "\n\r" + "9.Department:" + drpDepartment.SelectedItem.ToString() + "\n\r" + "10.Address:" + Txtaddress.Text.ToString() + "\n\r" + "Regards,\n\r" + "\n\r" + "Support Team\n\r" + "Sugar Commissionerate Maharashtra State, Pune ";
                        }

                        Substr = "Complaint No. : " + Subject_Mail;
                        SendEmail(SenderEmail, NotificationtoDepartmentstr, Substr, Contstr, SMTPstr, Portstr);

                        UpdateEmailStatus(txtFullName.Text.ToString(), Convert.ToInt32(drpDepartment.SelectedValue.ToString()), txtEmailId.Text.ToString(), 1);
                        #endregion

                        #region Send acknowledgement of Notification Email to User
                        Contstr = "Hello Sir /Madam,\n\r" + "\n\r" + '"' + drpDepartment.SelectedItem.ToString() + '"' + " Department has received your mail.\n\r" + "Your complaint is registered with this No.: " + Subject_Mail + "\n\r" + "\n\r" + "Regards,\n\r" + "Support Team\n\r" + "Sugar Commissionerate Maharashtra State, Pune ";
                        Substr = "RE:Complaint No. : " + Subject_Mail;
                        SendEmail(SenderEmail, txtEmailId.Text.ToString(), Substr, Contstr, SMTPstr, Portstr);
                        UpdateEmailStatus(txtFullName.Text.ToString(), Convert.ToInt32(drpDepartment.SelectedValue.ToString()), txtEmailId.Text.ToString(), 3);


                        //MOLPushService("Sugar Commissionerate Maharashtra State, Pune . Please note down your complaint No. " + Subject_Mail + ". We will get back to you very soon", txtTelephoneNo.Text.ToString());

                        //PushSmsService.PushService pushSvc = new PushSmsService.PushService();
                        //PushSmsService.SMS smsDetails = new PushSmsService.SMS();
                        //smsDetails.UserName = username;
                        //smsDetails.Password = password;
                        //smsDetails.ApplicationUserName = username;
                        //smsDetails.ApplicationUserPassword = password;
                        //smsDetails.MobileNos = txtTelephoneNo.Text.Trim();
                        //smsDetails.Message = "Sugar Commissionerate Maharashtra State, Pune . Please note down your complaint No. " + Subject_Mail + ". We will get back to you very soon";
                        //pushSvc.SendSMSTo(smsDetails);

                        string smsBody = "Sugar Commissionerate Maharashtra State, Pune . Please note down your complaint No. " + Subject_Mail + ". We will get back to you very soon";

                        MSHC.SMSGATEWAY1.PushSMS objSMS = new MSHC.SMSGATEWAY1.PushSMS();

                        string res = objSMS.MOLPushSMS("msis", "msis@123", txtTelephoneNo.Text.Trim(), smsBody, "0", "2");


                        UpdateEmailStatus(txtFullName.Text.ToString(), Convert.ToInt32(drpDepartment.SelectedValue.ToString()), txtEmailId.Text.ToString(), 4);
                      //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('Data Saved Successfully');location.href = 'FactoryCreation.aspx'", true);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Complaint Registered successfully.');", true);
                       // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('Complaint Registered successfully. ')", true);

                        btnExit_Click(sender, e);





                        #endregion
                    }
                }

            }
        
                  catch (Exception ex)
            {
                throw ex;
            }


            if (ucCaptcha.Insert() == true)
            {
                try
                {
                    txtEmailId.Text = string.Empty;
                    txtFullName.Text = string.Empty;
                    txtComplaints.Text = string.Empty;
                    Txtaddress.Text = string.Empty;
                    drpDepartment.SelectedIndex = 0;
                    Drpdistrict.SelectedIndex = 0;
                    Drpstate.SelectedIndex = 0;
                    DrpTaluka.SelectedIndex = 0;
                    //txtSocietyName.Text = "";
                    TextBox tb = (TextBox)ucCaptcha.FindControl("txtCaptchAnswer");
                    tb.Text = string.Empty;
                    //ddlTaluka.Items.Clear();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
        
        #endregion

        #region btnExit_Click
        /// <summary>
        /// The Reset Button click event is here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExit_Click(object sender, EventArgs e)
        {
            txtComplaints.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtTelephoneNo.Text = string.Empty;
            Txtaddress.Text = string.Empty;
            FillDepartment();
            DrpCountry.ClearSelection();
            Drpstate.ClearSelection();
            Drpdistrict.ClearSelection();
            DrpTaluka.ClearSelection();

        }
        #endregion

        #region subjectstr
        /// <summary>
        ///  Createing Subject of Notification email to Department 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strEmailId"></param>
        /// <returns></returns>
        public string _subjectstr(string strName, string strEmailId)
        {
            DataSet dsGetFileData = new DataSet();
            string returnstr = "";
            try
            {
                SqlCommand selectCMD = new SqlCommand();
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandText = "GetComplaintFeedback";
                selectCMD.Parameters.AddWithValue("@FullName", strName);
                selectCMD.Parameters.AddWithValue("@EmailId", strEmailId);
                selectCMD.CommandTimeout = 30;
                dsGetFileData = MAHAITDBAccess.ExecuteDataSet(selectCMD);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dsGetFileData.Tables.Count > 0)
            {
                if (dsGetFileData.Tables[0].Rows.Count > 0)
                {
                    string PaddLeft = "000";

                    string CaseNo = PaddLeft.Substring(0, 3 - dsGetFileData.Tables[0].Rows[0][0].ToString().Length) + dsGetFileData.Tables[0].Rows[0][0].ToString();
                    returnstr = dsGetFileData.Tables[0].Rows[0][3].ToString() + "_" + CaseNo;
                }
            }
            return returnstr;
        }
        #endregion

        #region SendEmail
        /// <summary>
        /// This functionality sends a Email to respective User
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Receiver"></param>
        /// <param name="Subject"></param>
        /// <param name="Cont"></param>
        /// <param name="hostAddress"></param>
        /// <param name="portaddress"></param>
        public void SendEmail(string Sender, string Receiver, string Subject, string Cont, string hostAddress, string portaddress)
        {
            try
            {
                MailMessage message = new MailMessage(Sender, Receiver, Subject, Cont);
                SmtpClient client = new SmtpClient(hostAddress, Convert.ToInt32(portaddress));
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateEmailStatus
        /// <summary>
        /// The status of Email is updated in system.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="dept"></param>
        /// <param name="UserEmail"></param>
        /// <param name="userflag"></param>
        public void UpdateEmailStatus(string UserName, int dept, string UserEmail, int userflag)
        {
            #region Add record in Feedback Table
            string connection = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("EditComplaintForDeptnotification", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FullName", UserName);
            cmd.Parameters.AddWithValue("@Department", dept);
            cmd.Parameters.AddWithValue("@EmailId", UserEmail);
            cmd.Parameters.AddWithValue("@EmailStatus", 1);
            cmd.Parameters.AddWithValue("@Flag", userflag);
            cmd.ExecuteNonQuery();
            conn.Close();
            #endregion
        }
        #endregion

        #region FillStates

        protected void FillStates(int Country)
        {
            DataSet dsstate = new DataSet();

            try
            {
                if (DrpCountry.SelectedValue == "-Please Select-")
                    return;

                SqlCommand selectCMD = new SqlCommand();
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandText = "GetState";
                selectCMD.CommandTimeout = 30;
                selectCMD.Parameters.AddWithValue("@Country", Country);
                selectCMD.Parameters.AddWithValue("@LangID", LangID);
                dsstate = MAHAITDBAccess.ExecuteDataSet(selectCMD);

                if (dsstate.Tables.Count > 0)
                {
                    if (dsstate.Tables[0].Rows.Count > 0)
                    {
                        Drpstate.DataSource = dsstate.Tables[0];
                        Drpstate.DataTextField = "statename";
                        Drpstate.DataValueField = "statecode";
                        Drpstate.DataBind();
                    }
                }

            }

            catch (Exception Ex)
            {

            }
            finally
            {
                // nwindConn.Close();

            }
        }
        #endregion
        private Boolean validatedata()
        {
            ltrmsg.Text = string.Empty;
            Boolean isvalid = true;

            StringBuilder sb = new StringBuilder();

            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {

                    if (txtComplaints.Text == string.Empty || txtComplaints.Text == null)
                    {
                        sb.Append("<li>कृपया नाव टाका</li>");
                    }
                    else
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (txtComplaints.Text.IndexOf(i.ToString()) > -1)
                            {
                                sb.Append("<li>कृपया वैध नाव टाका</li>");
                                break;
                            }
                        }
                    }
                    if (txtEmailId.Text.Trim() == string.Empty)
                    {
                        sb.Append("<li>कृपया ई-मेल टाका </li>");
                    }
                    else if (!txtEmailId.Text.Contains("@"))
                    {
                        sb.Append("<li>कृपया वैध ई-मेल टाका</li>");
                    }
                    else if (!txtEmailId.Text.Contains("."))
                    {
                        sb.Append("<li>कृपया वैध ई-मेल टाका</li>");
                    }

                    if (drpDepartment.SelectedIndex.ToString() == "0")
                    {
                        sb.Append("<li>कृपया विभाग निवडा</li>");
                    }


                    if (txtComplaints.Text == string.Empty || txtComplaints.Text == null)
                    {
                        sb.Append("<li>कृपया प्रतिक्रिया टाका</li>");
                    }
                    TextBox txtans = (TextBox)ucCaptcha.FindControl("txtCaptchAnswer");
                    if (txtans.Text == null)
                    {
                        sb.Append("<li>कृपया सांकेतिक प्रश्नाचे उत्तर बरोबर द्यावेत</li>");
                    }
                    if (Txtaddress.Text == null || Txtaddress.Text == string.Empty)
                    {
                        sb.Append("<li>कृपया पत्ता टाकावा </li>");
                    }
                    if (txtTelephoneNo.Text == string.Empty || txtTelephoneNo.Text.Length != 10)
                    {
                        sb.Append("<li>कृपया दूरध्वनिक्रमांक टाका</li>");
                    }

                    if (sb.Length > 0)
                    {
                        ltrmsg.Text = "<ul><li>खालील प्रमाणे चुका सापडल्या आहेत:</li>" + sb.ToString() + "</ul>";
                        isvalid = false;
                    }

                    return isvalid;
                }
                else
                {


                    if (txtFullName.Text == string.Empty || txtFullName.Text == null)
                    {
                        sb.Append("<li>Please Enter Name</li>");
                    }
                    else
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (txtFullName.Text.IndexOf(i.ToString()) > -1)
                            {
                                sb.Append("<li>Please Enter Valid Name</li>");
                                break;
                            }
                        }
                    }
                    if (txtEmailId.Text.Trim() == string.Empty)
                    {
                        sb.Append("<li>Please Enter Email ID</li>");
                    }
                    else if (!txtEmailId.Text.Contains("@"))
                    {
                        sb.Append("<li>Please Enter Valid Email ID</li>");
                    }
                    else if (!txtEmailId.Text.Contains("."))
                    {
                        sb.Append("<li>Please Enter Valid Email ID</li>");
                    }

                    if (drpDepartment.SelectedIndex.ToString() == "0")
                    {
                        sb.Append("<li>Please Select Department</li>");
                    }


                    if (txtComplaints.Text == string.Empty || txtComplaints.Text == null)
                    {
                        sb.Append("<li>Please Enter Complaints</li>");
                    }
                    TextBox txtans = (TextBox)ucCaptcha.FindControl("txtCaptchAnswer");
                    if (txtans.Text.Trim() == null)
                    {
                        sb.Append("<li>Please Enter Answer</li>");
                    }
                    if (Txtaddress.Text == null || Txtaddress.Text == string.Empty)
                    {
                        sb.Append("<li>Please Enter Address</li>");
                    }
                    if (txtTelephoneNo.Text == string.Empty || txtTelephoneNo.Text.Length != 10)
                    {
                        sb.Append("<li>Please Enter Contact Number</li>");
                    }

                    if (sb.Length > 0)
                    {
                        ltrmsg.Text = "<ul><li>Validation Summary:</li>" + sb.ToString() + "</ul>";
                        isvalid = false;
                    }

                    return isvalid;
                }
            }

            finally
            { sb = null; }
        }
        private string MOLPushService(string message, string mobileNo)
        {

            request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");

            request.ProtocolVersion = HttpVersion.Version10;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";

            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";

            request.Method = "POST";

            //Console.WriteLine("Before Calling Method");

            sendSingleSMS(username, password, senderid, mobileNo, message);

            //sendBulkSMS(username, password, senderid, mobileNos, message);

            //sendScheduledSMS(username, password, senderid, mobileNos, message, scheduledTime);

            return "SMS Sent Sucessfully";

        }


        // Method for sending single SMS.

        private void sendSingleSMS(String username, String password, String senderid,

        String mobileNo, String message)
        {

            String smsservicetype = "singlemsg"; //For single message.

            String query = "username=" + HttpUtility.UrlEncode(username) +

            "&password=" + HttpUtility.UrlEncode(password) +

            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +

            "&content=" + HttpUtility.UrlEncode(message) +

            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +

            "&senderid=" + HttpUtility.UrlEncode(senderid);

            byte[] byteArray = Encoding.ASCII.GetBytes(query);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            //  WriteToLog("Request URI : " + request.Address.AbsoluteUri);

            WebResponse response = request.GetResponse();

            String Status = ((HttpWebResponse)response).StatusDescription;

            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();

            dataStream.Close();

            response.Close();

        }

        // method for sending bulk SMS

        public void sendBulkSMS(String username, String password, String senderid, String mobileNos, String message)
        {

            String smsservicetype = "bulkmsg"; // for bulk msg

            String query = "username=" + HttpUtility.UrlEncode(username) +

            "&password=" + HttpUtility.UrlEncode(password) +

            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +

            "&content=" + HttpUtility.UrlEncode(message) +

            "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +

            "&senderid=" + HttpUtility.UrlEncode(senderid);

            byte[] byteArray = Encoding.ASCII.GetBytes(query);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            String Status = ((HttpWebResponse)response).StatusDescription;

            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();

            dataStream.Close();

            response.Close();

        }


        void WriteToLog(string p_Message)
        {
            string strLogText = p_Message;
            string t_FileName = Server.MapPath(".") + "\\Logs\\" + "log.txt";
            // Create a writer and open the file:
            StreamWriter log;

            if (!File.Exists(t_FileName))
            {
                log = new StreamWriter(t_FileName);
            }
            else
            {
                log = File.AppendText(t_FileName);
            }

            // Write to the file:
            log.WriteLine(DateTime.Now);
            log.WriteLine(strLogText);
            log.WriteLine();

            // Close the stream:
            log.Close();
        }

        protected void DrpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStates(Convert.ToInt32(DrpCountry.SelectedValue));
            Drpstate.Items.Insert(0, new ListItem("-Please Select-"));
        }

        protected void Drpstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDistrict(Convert.ToInt32(Drpstate.SelectedValue));
                Drpdistrict.Items.Insert(0, new ListItem("-Please Select-"));
            }
            catch (Exception Ex)
            {

            }
        }

        protected void Drpdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillTaluka(Convert.ToInt32(Drpdistrict.SelectedValue));
                DrpTaluka.Items.Insert(0, new ListItem("-Please Select-"));
            }
            catch (Exception Ex)
            {

            }
        }

    }

}
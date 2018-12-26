///This Page is Created by Mahaonline Ltd.
///This Page is Created on 17th Jan 2012
///Coding of this Page is done by Mr. Rahul Rokade
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
using System.Text;
using BL;

namespace RCA.Site.Information
{
    public partial class feedback : MAHAITPage 
    {
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        int LangID = 0;
        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            // string culture = Request.QueryString["culture1"];


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
                FillStates();
                FillDistrict(Convert.ToInt32(Drpstate.SelectedValue));
                //FillDistrict(Convert.ToInt32(Drpdivision.SelectedValue));
                //FillDivision(Convert.ToInt32(Drpstate.SelectedValue));

                if (LangID == 1)
                {
                    drpDepartment.Items.Insert(0, new ListItem("-Please Select-"));
                    DrpCountry.Items.Insert(0, new ListItem("-Please Select-"));
                    //Drpstate.Items.Insert(0, new ListItem("-Please Select-"));
                    Drpdistrict.Items.Insert(0, new ListItem("-Please Select-"));
                    DrpTaluka.Items.Insert(0, new ListItem("-Please Select-"));
                    Drpdivision.Items.Insert(0, new ListItem("-Please Select-"));
                    DrpCity.Items.Insert(0, new ListItem("-Please Select-"));
                }

                else
                {
                    drpDepartment.Items.Insert(0, new ListItem("कृपया निवडा"));
                    DrpCountry.Items.Insert(0, new ListItem("कृपया निवडा"));
                    //Drpstate.Items.Insert(0, new ListItem("कृपया निवडा"));
                    Drpdistrict.Items.Insert(0, new ListItem("कृपया निवडा"));
                    DrpTaluka.Items.Insert(0, new ListItem("कृपया निवडा"));
                    Drpdivision.Items.Insert(0, new ListItem("कृपया निवडा"));
                    DrpCity.Items.Insert(0, new ListItem("कृपया निवडा"));
                }
            }

        }
        #endregion

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            FillCountry();
            //FillStates();
           // FillDistrict(Convert.ToInt32(Drpstate.SelectedValue));
            string DepartmentName = string.Empty;
            lblName.Text = GetResourceValue("General", "lblName", "");
            lblDepartment.Text = GetResourceValue("General", "lblDepartment", "");
            lblEmailId.Text = GetResourceValue("General", "lblEmailId", "");
            lblFeedback.Text = GetResourceValue("General", "lblFeedback", "");
            btnSubmit.Text = GetResourceValue("General", "btnSubmit", "");
            btnReset.Text = GetResourceValue("General", "btnReset", "");
            lbl_Feedback.Text = GetResourceValue("General", "lbl_Feedback", "");
            LblCOuntry.Text = GetResourceValue("General", "LblCOuntry", "");
            Lblstate.Text = GetResourceValue("General", "Lblstate", "");
            LblDistrict.Text = GetResourceValue("General", "LblDistrict", "");
            lblTextCapachAns.Text = GetResourceValue("General", "lblTextCapachAns", "");
            LblMobileNo.Text = GetResourceValue("General", "LblMobileNo", "");
            LblAddress.Text = GetResourceValue("General", "LblAddress", "");
            LblTaluka.Text = GetResourceValue("General", "LblTaluka", "");

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameMarathi"].ToString();
                Page.Title = lbl_Feedback.Text + "-" + DepartmentName;
            }
            else
            {
                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameEnglish"].ToString();
                Page.Title = lbl_Feedback.Text + "-" + DepartmentName;
            }

        }
        #region FillCountry
        public void FillCountry()
        {
            DataSet dsGetCountry = new DataSet();
            try
            {

                SqlCommand CMD = new SqlCommand("GetCountry");
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandTimeout = 30;
                CMD.Parameters.AddWithValue("@LangID", LangID);
                dsGetCountry = MAHAITDBAccess.ExecuteDataSet(CMD);
                if (dsGetCountry.Tables[0].Rows.Count > 0)
                {
                    DrpCountry.DataSource = dsGetCountry.Tables[0];
                    DrpCountry.DataTextField = "Countryname";
                    DrpCountry.DataValueField = "CountryId";
                    DrpCountry.DataBind();
                    DrpCountry.SelectedValue = "88";
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                dsGetCountry = null;
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

                    if (txtName.Text == string.Empty || txtName.Text == null)
                    {
                        sb.Append("<li>कृपया नाव टाका</li>");
                    }
                    else
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (txtName.Text.IndexOf(i.ToString()) > -1)
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

                    if (drpDepartment.SelectedIndex == 0)
                    {
                        sb.Append("<li>कृपया विभाग निवडा</li>");
                    }


                    if (txtFeedback.Text == string.Empty || txtFeedback.Text == null)
                    {
                        sb.Append("<li>कृपया प्रतिक्रिया टाका</li>");
                    }
                    TextBox txtans = (TextBox)ucCaptcha.FindControl("txtCaptchAnswer");
                    if (txtans.Text == string.Empty)
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


                    if (txtName.Text == string.Empty || txtName.Text == null)
                    {
                        sb.Append("<li>Please Enter Name</li>");
                    }
                    else
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (txtName.Text.IndexOf(i.ToString()) > -1)
                            {
                                sb.Append("<li>Please Enter Valid Name</li>");
                                break;
                            }
                        }
                    }
                    if (txtEmailId.Text == string.Empty)
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

                    //if(drpDepartment.SelectedIndex == 0)
                    //{
                    //    sb.Append("<li>Please Select Department</li>");
                    //}


                    if (txtFeedback.Text == string.Empty || txtFeedback.Text == null)
                    {
                        sb.Append("<li>Please Enter Remarks</li>");
                    }
                    TextBox txtans = (TextBox)ucCaptcha.FindControl("txtCaptchAnswer");
                    if (txtans.Text == null || txtans.Text == string.Empty)
                    {
                        sb.Append("<li>Please Enter Answer</li>");
                    }
                    if (Txtaddress.Text == string.Empty || Txtaddress.Text == null)
                    {
                        sb.Append("<li>Please Enter Address</li>");
                    }
                    if (txtTelephoneNo.Text == string.Empty || txtTelephoneNo.Text.Length != 10)
                    {
                        sb.Append("<li>Please Enter Contact Number</li>");
                    }

                    if (sb.Length > 0)
                    {
                        ltrmsg.Text = "<ul><li>Summarize List:</li>" + sb.ToString() + "</ul>";
                        isvalid = false;
                    }

                    return isvalid;
                }
            }

            finally
            { sb = null; }
        }


        #region FillStates

        //protected void FillStates(int Country)
        protected void FillStates()
        {            
            DataSet dsstate = new DataSet();
            //string connection = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            //SqlConnection nwindConn = new SqlConnection(connection);

            try
            {
                if (LangID == 1)
                {
                    if (DrpCountry.SelectedValue == "-Please Select-")
                        return;
                }

                else
                {
                    if (DrpCountry.SelectedValue == "कृपया निवडा")
                        return;
                }
                SqlCommand selectCMD = new SqlCommand("GetState");
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandTimeout = 30;
                //selectCMD.Parameters.AddWithValue("@Country", Country);
                selectCMD.Parameters.AddWithValue("@Country", 88);
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
                        Drpstate.SelectedValue = "27";

                        if (LangID == 1)
                        {
                            Drpstate.Items.Insert(0, new ListItem("--Please Select--", "0"));
                        }
                        else
                        {
                            Drpstate.Items.Insert(0, new ListItem("--कृपया निवडा--", "0"));
                        }


                    }
                }

            }

            catch (Exception Ex)
            {

            }
            finally
            {
                dsstate = null;

            }
        }
        #endregion

        #region FillDivision
        protected void FillDivision(int state)
        {
            DataSet dsdivision = new DataSet();
            try
            {
                SqlCommand selectCMD = new SqlCommand("sp_dataforJoinus");
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandTimeout = 30;
                //selectCMD.Parameters.AddWithValue("@Country", Country);
                selectCMD.Parameters.AddWithValue("@statecode", state);
                selectCMD.Parameters.AddWithValue("@LangID", LangID);
                selectCMD.Parameters.AddWithValue("@para", "getdivision");
                dsdivision = MAHAITDBAccess.ExecuteDataSet(selectCMD);

                if (dsdivision.Tables.Count > 0)
                {
                    if (dsdivision.Tables[0].Rows.Count > 0)
                    {
                        Drpdivision.DataSource = dsdivision.Tables[0];
                        Drpdivision.DataTextField = "divname";
                        Drpdivision.DataValueField = "divid";
                        Drpdivision.DataBind();

                        if (LangID == 1)
                        {
                            Drpdivision.Items.Insert(0, new ListItem("--Please Select--", "0"));
                        }
                        else
                        {
                            Drpdivision.Items.Insert(0, new ListItem("--कृपया निवडा--", "0"));
                        }


                    }
                }

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                dsdivision = null;

            }
        }
        #endregion

        #region FillDistrict

        public void FillDistrict(int State)
        {
            DrpCity.Items.Clear();
            if (LangID == 1)
            {
                DrpCity.Items.Insert(0, new ListItem("-Please Select-"));
            }

            else
            {
                Drpdivision.Items.Insert(0, new ListItem("-कृपया निवडा-"));
            }
            DataSet dsstate = new DataSet();
            //string connection = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            //SqlConnection nwindConn = new SqlConnection(connection);
            try
            {
                SqlCommand selectCMD = new SqlCommand("GetDistrict");
                selectCMD.CommandType = CommandType.StoredProcedure;
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

            finally { dsstate = null; }
        }

     

        #endregion

        #region Fillcities

        public void FillCities(int district)
        {
            DrpCity.Items.Clear();
            DataSet dscity = new DataSet();
            try
            {
                //SqlCommand selectCMD = new SqlCommand("sp_dataforJoinus");
                SqlCommand selectCMD = new SqlCommand("GetCities");
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandTimeout = 30;
                selectCMD.Parameters.AddWithValue("@distcode", district);
                selectCMD.Parameters.AddWithValue("@LangID", LangID);
                //selectCMD.Parameters.AddWithValue("@para", "getcities");
                dscity = MAHAITDBAccess.ExecuteDataSet(selectCMD);
                if (dscity.Tables.Count > 0)
                {
                    if (dscity.Tables[0].Rows.Count > 0)
                    {
                        DrpCity.DataSource = dscity.Tables[0];
                        DrpCity.DataTextField = "cityname";
                        DrpCity.DataValueField = "cityid";
                        DrpCity.DataBind();
                    }
                }
                if (LangID == 1)
            {
                DrpCity.Items.Insert(0, new ListItem("-Please Select-"));
            }

            else
            {
                Drpdivision.Items.Insert(0, new ListItem("-कृपया निवडा-"));
            }
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

            finally { dscity = null; }
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
                SqlCommand selectCMD = new SqlCommand("GetTaluka");
                selectCMD.CommandType = CommandType.StoredProcedure;
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

            finally { dsstate = null; }
        }
        #endregion

        #region ResetFormControlValues

        public void ResetFormControlValues(Control parent)
        {

            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }

                else
                {
                    switch (c.GetType().ToString())
                    {

                        case "System.Web.UI.WebControls.TextBox":

                            ((TextBox)c).Text = "";

                            break;

                        case "System.Web.UI.WebControls.CheckBox":

                            ((CheckBox)c).Checked = false;

                            break;

                        case "System.Web.UI.WebControls.RadioButton":

                            ((RadioButton)c).Checked = false;

                            break;

                        case "System.Web.UI.WebControls.DropDownList":

                            if (((DropDownList)c).Items.Count > 0)

                                ((DropDownList)c).SelectedIndex = 0;

                            break;



                        case "System.Web.UI.WebControls.FileUpload":

                            //string f =  ((FileUpload)c).FileName;

                            break;

                    }

                }

            }

        }

        #endregion
        #region btnSubmit_Click
        /// <summary>
        /// On This button click the Notification Email sends to Department and Acknowledge Email sends to User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (validatedata() == true)
                {

                    if (ucCaptcha.Insert() == true)
                    {


                        if (Page.IsValid)
                        {

                            #region Add record in Feedback Table

                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure; ;
                            cmd.CommandText = "Addjoinusdate";
                            cmd.Parameters.AddWithValue("@Name", txtName.Text.ToString());
                            cmd.Parameters.AddWithValue("@EmailId", txtEmailId.Text.ToString());
                            cmd.Parameters.AddWithValue("@Remark", txtFeedback.Text.ToString());
                            cmd.Parameters.AddWithValue("@MobileNo", txtTelephoneNo.Text.ToString());
                            cmd.Parameters.AddWithValue("@Address", Txtaddress.Text.ToString());
                            //if (DrpCountry.SelectedItem.Value == "-Please Select-")
                            //{
                            //    cmd.Parameters.AddWithValue("@Country", DBNull.Value);
                            //}
                            //else
                            //{
                            //    cmd.Parameters.AddWithValue("@Country", Convert.ToInt32(DrpCountry.SelectedValue.ToString()));
                            //}
                            cmd.Parameters.AddWithValue("@Country", 88);
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
                            if (Drpdivision.SelectedItem.Value == "-Please Select-")
                            {
                                cmd.Parameters.AddWithValue("@Division", DBNull.Value);
                            }

                            else
                            {
                                cmd.Parameters.AddWithValue("@Division", Convert.ToInt32(Drpdivision.SelectedValue.ToString()));
                            }

                            if (DrpCity.SelectedItem.Value == "-Please Select-")
                            {
                                cmd.Parameters.AddWithValue("@City", DBNull.Value);
                            }

                            else
                            {
                                cmd.Parameters.AddWithValue("@City", Convert.ToInt32(DrpCity.SelectedValue.ToString()));
                            }

                            MAHAITDBAccess.ExecuteNonQuery(cmd);

                       
                            #endregion

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
                            string Subject_Mail = subjectstr(txtName.Text.ToString(), txtEmailId.Text.ToString());

                            if (DrpCountry.SelectedItem.Value == "-Please Select-" || Drpstate.SelectedItem.Value == "-Please Select-" || Drpdistrict.SelectedItem.Value == "-Please Select-")
                            {
                                DrpCountry.SelectedItem.Value = "";
                                Drpstate.SelectedItem.Value = "";
                                Drpdistrict.SelectedItem.Value = "";
                                Drpdistrict.SelectedItem.Value = "";

                                Contstr = "Hello Sir /Madam,\n\r" + "\n\r" + "It's a Notification mail.\n\r" + "\n\r" + "The details are as follows:\n\r" + "1.Name of the Citizen/User: " + txtName.Text.ToString() + "\n\r" + "2.Remark:" + txtFeedback.Text.ToString() + "\n\r" + "3.Country:" + "" + "\n\r" + "4.State:" + "" + "\n\r"  + "5.District:" + "\n\r" + "6.City:" + "" + "\n\r" + "7.Address:" + Txtaddress.Text.ToString() + "\n\r" + "Regards,\n\r" + "Support Team\n\r" + "Swachha Maharashra Mission ";

                            }
                            else
                            {
                                Contstr = "Hello Sir /Madam,\n\r" + "\n\r" + "It's a Notification mail.\n\r" + "\n\r" + "The details are as follows:\n\r" + "1.Name of the Citizen/User: " + txtName.Text.ToString() + "\n\r" + "2.Remark:" + txtFeedback.Text.ToString() + "\n\r" + "3.Country:India\n\r" + "4.State:" + Drpstate.SelectedItem.Text.ToString() + "\n\r"  + "5.District:" + Drpdistrict.SelectedItem.Text.ToString() + "\n\r" + "6.City:" + DrpCity.SelectedItem.Text.ToString() + "\n\r" + "7.Address:" + Txtaddress.Text.ToString() + "\n\r" + "Regards,\n\r" + "Support Team\n\r" + "Swachha Maharashtra Mission";

                            }
                            //Substr = "Join No. : " + Subject_Mail;
                            Substr = "RE:Join Us Notification";
                            SendEmail(SenderEmail, NotificationtoDepartmentstr, Substr, Contstr, SMTPstr, Portstr);

                            //UpdateEmailStatus(txtName.Text.ToString(), Convert.ToInt32(drpDepartment.SelectedValue.ToString()), txtEmailId.Text.ToString(), 1);
                            #endregion

                            #region Send acknowledgement of Notification Email to User
                            Contstr = "Dear Sir/Madam,\n\r" + "\n\r Thank you for joining with Swacch Maharashtra Mission.\n\r" + "We hope your efforts will lead to a cleaner city. \n\r" + "\n\r" + "Regards,\n\r" +  "Swachha Maharashtra Mission ";
                           // Substr = "RE:Join No. : " + Subject_Mail;
                            Substr = "Swachha Maharashtra Mission Notification ";
                            
                            SendEmail(SenderEmail, txtEmailId.Text.ToString(), Substr, Contstr, SMTPstr, Portstr);
                             #endregion

                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('you have been joined successfully.');", true);
                            
                            btnReset_Click1(sender, e);
                            
                        }
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
                    txtFeedback.Text = string.Empty;
                    txtName.Text = string.Empty;
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

        public string ToGetEmailIdOfDepartments()
        {
            string con = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            string Id = drpDepartment.SelectedValue.ToString();
            string select = "Select Email From Department_mst where DepartmentId='" + Id + "'";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string EmailOfDepartment = dt.Rows[0]["Email"].ToString();
            return EmailOfDepartment;
        }

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
                selectCMD.Parameters.AddWithValue("@LangId", LangID);
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

        #region subjectstr
        /// <summary>
        ///  Createing Subject of Notification email to Department 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strEmailId"></param>
        /// <returns></returns>
        public string subjectstr(string strName, string strEmailId)
        {
            DataSet dsGetFileData = new DataSet();
            string returnstr = "";
            try
            {

                SqlCommand selectCMD = new SqlCommand();
                selectCMD.CommandType = CommandType.StoredProcedure;
                selectCMD.CommandText = "GetNotificationFeedback";
                selectCMD.CommandTimeout = 30;
                selectCMD.Parameters.AddWithValue("@Name", strName);
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
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EditFeedbackForDeptnotification";
            cmd.Parameters.AddWithValue("@Name", UserName);
            cmd.Parameters.AddWithValue("@Department", dept);
            cmd.Parameters.AddWithValue("@EmailId", UserEmail);
            cmd.Parameters.AddWithValue("@EmailStatus", 1);
            cmd.Parameters.AddWithValue("@Flag", userflag);
            MAHAITDBAccess.ExecuteNonQuery(cmd);
            #endregion
        }
        #endregion

        #region btnReset_Click
        /// <summary>
        /// The action of reset Button is here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmailId.Text = string.Empty;
            txtFeedback.Text = string.Empty;
            txtName.Text = string.Empty;
            FillDepartment();
            DrpCountry.ClearSelection();
            Drpstate.ClearSelection();
            Drpdistrict.ClearSelection();
            DrpTaluka.ClearSelection();
            txtTelephoneNo.Text = string.Empty;
        }
        #endregion

        protected void DrpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillStates(Convert.ToInt32(DrpCountry.SelectedValue));
            Drpstate.Items.Insert(0, new ListItem("-Please Select-"));
        }

        protected void Drpstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                FillDistrict(Convert.ToInt32(Drpstate.SelectedValue));
                //FillDivision(Convert.ToInt32(Drpstate.SelectedValue));
                Drpdistrict.Items.Insert(0, new ListItem("-Please Select-"));
                if (Convert.ToInt32(Drpstate.SelectedValue.ToString()) != 27)
                    DrpCity.Enabled = false;
                else
                    DrpCity.Enabled = true;
            }
            catch (Exception Ex)
            {

            }
        }

        protected void Drpdivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDistrict(Convert.ToInt32(Drpdivision.SelectedValue));
                Drpdistrict.Items.Insert(0, new ListItem("-Please Select-"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Drpdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillCities(Convert.ToInt32(Drpdistrict.SelectedValue));
                //DrpCity.Items.Insert(0, new ListItem("-Please Select-"));
            }
            catch (Exception Ex)
            {

            }
        }
        protected void btnReset_Click1(object sender, EventArgs e)
        {
            txtTelephoneNo.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtFeedback.Text = string.Empty;
            txtName.Text = string.Empty;
            drpDepartment.SelectedIndex = 0;
            DrpCountry.SelectedIndex = 0;

            Drpstate.SelectedIndex = 0;
            Drpdistrict.SelectedIndex = 0;
            DrpTaluka.SelectedIndex = 0;
            Drpdivision.SelectedIndex = 0;
            DrpCity.SelectedIndex = 0;
        }

        protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtTelephoneNo_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
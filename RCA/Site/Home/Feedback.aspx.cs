using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Net.Mail;
using BL;

namespace MSHC.Site.Home
{
    public partial class Feedback : System.Web.UI.Page
    {
        DataSet ds;
        public BL.BL MAHAITDBAccess;
        string TextCapchaAns, TextCapachaQues;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox box = (TextBox)this.uctextcapcha.FindControl("TextBox1");
            TextCapchaAns = box.Text;
            Label lblRandomNo = (Label)this.uctextcapcha.FindControl("lblRandomNo");
            TextCapachaQues = lblRandomNo.Text;
            if (!IsPostBack)
            {
                Binddropdown();
            }
        }

        private void Binddropdown()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from mstDivision where Langid=@Langid";
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
            {
                cmd.Parameters.Add("@Langid", SqlDbType.Int).Value = 2;
            }
            else
            {
                cmd.Parameters.Add("@Langid", SqlDbType.Int).Value = 1;
            }

            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                bindddl(ddlDivision, ds, "Divisionname", "Divisioncode");
            }
            else
            {
            }
        }

        private void bindddl(DropDownList ddl, object ds, string text, string value)
        {
            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Please select --");
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataSource = ds;
            ddl.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validatedata())
            {
                if (uctextcapcha.ISCorrect() == true)
                {
                    string insert = " Insert into Feedback_mst(EmailId,Mobile,DivisionID,DistrictID,TalukaID,SocietyName,Feedback) " +
                  "  values('" + txtEmailId.Text + "','" + txtContactNo.Text + "','" + ddlDivision.SelectedValue + "', '" + ddlDistrict.SelectedValue + "','" + ddlTaluka.SelectedValue + "','" + txtSocietyName.Text + "','" + txtFeedback.Text + "')";
 
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = " Insert into Feedback_mst(EmailId,Mobile,DivisionID,DistrictID,TalukaID,SocietyName,Feedback) " +
                                        " values(@EmailId, @ContactNo, @Division, @District, @Taluka,@SocietyName, @Feedback)";
                    cmd.Parameters.Add("@EmailId", SqlDbType.Int).Value = txtEmailId.Text;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = txtContactNo.Text;
                    cmd.Parameters.Add("@Division", SqlDbType.Int).Value = ddlDivision.SelectedValue;
                    cmd.Parameters.Add("@District", SqlDbType.Int).Value = ddlDistrict.SelectedValue;
                    cmd.Parameters.Add("@Taluka", SqlDbType.Int).Value = ddlTaluka.SelectedValue;
                    cmd.Parameters.Add("@SocietyName", SqlDbType.Int).Value = txtSocietyName.Text;
                    cmd.Parameters.Add("@Feedback", SqlDbType.Int).Value = txtFeedback.Text;
                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                    int i = MAHAITDBAccess.ExecuteNonQuery(cmd);

                    //Email #region access Configurable variable to send a Email
                    string SenderEmail = ConfigurationManager.AppSettings["userName"].ToString();
                    string SMTPstr = ConfigurationManager.AppSettings["host"].ToString();
                    string Portstr = ConfigurationManager.AppSettings["port"].ToString();
                    string NotificationtoDepartmentstr = txtEmailId.Text.ToString();
                    string _Message = string.Empty;

                    _Message = txtFeedback.Text;

                    SendEmail(SenderEmail, NotificationtoDepartmentstr, "Feedback", _Message, SMTPstr, Portstr);

                    ltrmsg.Text = "Feedback Saved Successfully!!";
                }
                else
                {
                    ltrmsg.Text = "Feedback Saved Failed";
                }
                Reset();
            }
        }

        private void SendEmail(string Sender, string Receiver, string Subject, string Cont, string hostAddress, string portaddress)
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

        public void Reset()
        {
            txtName.Text = "";
            txtEmailId.Text = "";
            txtContactNo.Text = "";
            Binddropdown();
            ddlDistrict.Items.Clear();
            ddlTaluka.Items.Clear();
            txtSocietyName.Text = "";
            txtFeedback.Text = "";
        }

        private Boolean validatedata()
        {
            ltrmsg.Text = string.Empty;
            Boolean isvalid = true;

            StringBuilder sb = new StringBuilder();

            if (txtName.Text.Trim() == string.Empty)
            {
                sb.Append("<li>Please Enter Name</li>");
            }
            else
            {
                for (int i = 0; i <= 9; i++)
                {
                    if (txtName.Text.Trim().IndexOf(i.ToString()) > -1)
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

            if (txtContactNo.Text.Trim() == string.Empty || txtContactNo.Text.Length != 10)
            {
                sb.Append("<li>Please Enter Contact Number</li>");
            }


            if (ddlDivision.SelectedIndex == 0)
            {
                sb.Append("<li>Please Select Division</li>");
            }
            if (ddlDistrict.SelectedIndex == 0)
            {
                sb.Append("<li>Please Select District</li>");
            }
            if (ddlTaluka.SelectedIndex == 0)
            {
                sb.Append("<li>Please Select Taluka</li>");
            }

            if (txtFeedback.Text.Trim() == string.Empty)
            {
                sb.Append("<li>Please Enter Feedback</li>");
            }

            if (TextCapchaAns == string.Empty)
            {
                sb.Append("<li>Please Enter Correct Answer</li>");
            }


            if (sb.Length > 0)
            {
                ltrmsg.Text = "<ul><li>Validation Summary:</li>" + sb.ToString() + "</ul>";
                isvalid = false;
            }

            return isvalid;
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

            long div = Convert.ToInt64(ddlDivision.SelectedItem.Value);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from mstDistrict where Statecode = 27 and Divisionid = @Divisionid and Langid = @Langid";
            cmd.Parameters.Add("@Divisionid", SqlDbType.Int).Value = div;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
            {
                cmd.Parameters.Add("@Langid", SqlDbType.Int).Value = 2;
            }
            else
            {
                cmd.Parameters.Add("@Langid", SqlDbType.Int).Value = 1;
            }
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                bindddl(ddlDistrict, ds, "districtname", "Districtcode");
            }
            else
            {

            }

        }

        protected void ddlDistrict_SelectedIndexChanged1(object sender, EventArgs e)
        {

            string div = (ddlDistrict.SelectedValue.ToString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from mstTaluka where DistrictCode = @DistrictCode and Langid = @Langid";
            cmd.Parameters.Add("@DistrictCode", SqlDbType.VarChar).Value = div;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
            {
                cmd.Parameters.Add("@Langid", SqlDbType.Int).Value = 2;
            }
            else
            {
                cmd.Parameters.Add("@Langid", SqlDbType.Int).Value = 1;
            }
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                bindddl(ddlTaluka, ds, "SubDistrictname", "DistrictCode");
            }
            else
            {

            }
        }

    }
}
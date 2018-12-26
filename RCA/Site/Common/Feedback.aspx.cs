using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.Configuration;
using Schema;
using BL;


namespace RCA.Site.Common
{
    public partial class Feedback : MAHAITPage
    {
        #region Public variable declaration
        Feedback_BL objFeedback_BL =new Feedback_BL();
        FeddbackSchema objFeedback_Schema =new FeddbackSchema ();
        int result=0;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion

        #region PageEvents
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["format"] != null)
            {
                if (Convert.ToString(Request.QueryString["format"]) == "print")
                {
                    BreadCrum.Visible = false;
                }
            } 
            if (!IsPostBack)
            {
                //For Numeric KeyPad in mobile, tablet
                if (MAHAITPage.isMobileBrowser() != string.Empty)
                {
                    txtMobile.Attributes.Add("type", "tel");
                }
                ViewState["IsRefresh"] = true;
            }
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
           
            lblFeedbackHeading.Text= _MahaITUC.GetResourceValue("FeedBack", "lblFeedbackHeading", "");
            lblName.Text = _MahaITUC.GetResourceValue("FeedBack", "lblName", "");
            lblEmail.Text = _MahaITUC.GetResourceValue("FeedBack", "lblEmail", "");
            lblMobile.Text = _MahaITUC.GetResourceValue("FeedBack", "lblMobile", "");
            lblSub.Text = _MahaITUC.GetResourceValue("FeedBack", "lblSub", "");
            btnSubmit.Text = _MahaITUC.GetResourceValue("FeedBack", "btnSubmit", "");
            btnReset.Text = _MahaITUC.GetResourceValue("FeedBack", "btnReset", "");
            lblFeedback.Text= _MahaITUC.GetResourceValue("FeedBack", "lblFeedbackHeading", "");
            lblMandatory.Text = _MahaITUC.GetResourceValue("FeedBack", "lblMandatory", "");

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() != Convert.ToString(ViewState["PreviousCulture"]))
            {
                ResetControls(false);
                ShowData();
            }

            ViewState["PreviousCulture"] = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();

            if (ViewState["IsRefresh"] == null || Convert.ToBoolean(ViewState["IsRefresh"]))
            {
                ViewState["IsRefresh"] = false;
                ucCaptcha.RefreshQuestion();
            }
        }
        #endregion

        #region Methods
        private void ShowData()
        {           
            rfvName.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvName", "");
            rfvFeedback.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvFeedback", "");
            revEmail.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "revEmail", "");
            revMobile.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "revMobile", "");
            rfvSubject.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvSubject", "");
            this.Page.Title = _MahaITUC.GetResourceValue("FeedBack", "PageTitle", ""); ;
        }

        private void ResetControls(Boolean RefreshQuestion)
        {
            txtName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtMobile.Text = String.Empty;
            TxtSubject.Text = String.Empty;
            txtFeedback.Text = String.Empty;
            TextBox tb = (TextBox)ucCaptcha.FindControl("txtCaptchAnswer");
            tb.Text = string.Empty;
            if (RefreshQuestion)
            {
                ucCaptcha.RefreshQuestion();
            }
        }

        private Boolean validatedata()
        {
            Boolean isvalid = true;
            string txtcap = "";
            TextBox txtans = (TextBox)ucCaptcha.FindControl("txtCaptchAnswer");
            if (txtans.Text.Trim() == null)
            {
                txtcap = _MahaITUC.GetResourceValue("FeedBack", "txtCaptcha", "");
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + txtcap + "');", true);
                isvalid = false;              
            }
            return isvalid;
        }
        #endregion

        #region ButtonEvents
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatedata() == true)
                {
                    string validate = "";

                    if (txtName.Text.Trim() == String.Empty)
                    {
                        validate=_MahaITUC.GetResourceValue("FeedBack", "rfvName", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('"+ validate + "');", true);
                        txtName.Focus();
                        return;
                    }

                    if (txtFeedback.Text.Trim() == String.Empty)
                    {
                        validate = _MahaITUC.GetResourceValue("FeedBack", "rfvFeedback", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + validate + "');", true);
                        txtFeedback.Focus();
                        return;
                    }
                    if (ucCaptcha.Insert() == false)
                    {
                        validate = _MahaITUC.GetResourceValue("FeedBack", "txtCaptcha", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + validate + "');", true);
                        return;
                    }

                    objFeedback_Schema.Name = txtName.Text.Trim();
                    objFeedback_Schema.Email = txtEmail.Text.Trim();
                    objFeedback_Schema.Contact = txtMobile.Text.Trim();
                    objFeedback_Schema.Subject = TxtSubject.Text.Trim();
                    objFeedback_Schema.Message = txtFeedback.Text.Trim();
                    objFeedback_Schema.CreatedOn = DateTime.Now;
                    if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                    {
                        objFeedback_Schema.Langid = 2;
                    }
                    else if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                    {
                        objFeedback_Schema.Langid = 1;
                    }
                    else
                    {
                        objFeedback_Schema.Langid = 3;
                    }



                    result = objFeedback_BL.SaveFeedbackDeatails(objFeedback_Schema);         
                    if (result > 0)
                    {
                        string savemsg = "";
                        savemsg = _MahaITUC.GetResourceValue("FeedBack", "Savemessage", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('"+ savemsg + "');", true);

                    }
                    ResetControls(true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "alert('" + ex.Message + "')", true);
                return;
            }
            finally
            {
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls(true);
        }
        #endregion

        #region SendEmail
        private void SendEmail(string Sender, string Receiver, string Name, string Subject, string Body)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(Sender, Name);
                smtpClient.Host = ConfigurationManager.AppSettings["Host"].ToString();
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());

                message.From = fromAddress;
                message.To.Add(Receiver);

                message.Subject = Subject;
                message.IsBodyHtml = false;
                message.Body = Body;

                smtpClient.Send(message);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "alert('" + ex.Message + "')", true);
                return;
            }
        }
        #endregion

        private String GetURL(String strURLPath)
        {
            String strOrgUrl = Request.Url.OriginalString;
            String strPathQuery = Request.Url.PathAndQuery;
            String strSiteUrl = String.Empty;

            strSiteUrl = strOrgUrl.Replace(HttpUtility.UrlDecode(strPathQuery), string.Empty);
            if (strOrgUrl == strSiteUrl)
            {
                strSiteUrl = strOrgUrl.Replace(strPathQuery, string.Empty);
            }

            strURLPath = strURLPath.Replace("~", strSiteUrl);

            return strURLPath;
        }
    }
}
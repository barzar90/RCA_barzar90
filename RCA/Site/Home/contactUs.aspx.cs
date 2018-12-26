using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using BL;
using Schema;

namespace RCA.Site.Home
{
    public partial class contactUs : System.Web.UI.Page
    {
        #region Public variable declaration
        public BL.BL MAHAITDBAccess;
        FeddbackSchema objFeddbackSchema = new FeddbackSchema();
        Feedback_BL objFeedback_BL = new Feedback_BL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

       
        protected void btnSend_Click(object sender, EventArgs e)
        {

            if (TextCaptcha1.Insert() == false)
            {
                TextBox txtans = (TextBox)TextCaptcha1.FindControl("txtCaptchAnswer");
                txtans.Text = "";
                TextCaptcha1.RefreshQuestion();
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alertPopup('Information','Enter a valid text.');", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alertPopup('Information','Enter a valid text.');", true);
                return;
            }
            if (txtcontact.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Please Enter Contact No.');", true);
                return;
            }

            objFeddbackSchema.Name =  txtName.Text.Trim();
            objFeddbackSchema.Contact = txtcontact.Text.Trim();
            objFeddbackSchema.Subject = txtSubject.Text.Trim();
            objFeddbackSchema.Email = txtEmail.Text.ToString().Trim();
            objFeddbackSchema.Message = txtMessage.Text.Trim();
            int result = objFeedback_BL.SaveFeedbackDeatails(objFeddbackSchema);

            if (result > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Your Feedback Saved Successfully!!');", true);
                ClearData();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Feedback not saved. Please Try Again!!');", true);
                lblMessage.Text = " unsecussful";
                ClearData();
            }
        }

        public void ClearData()
        {
            txtName.Text = "";
            txtcontact.Text = "";
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
        }
    }
}
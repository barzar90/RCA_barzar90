using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCA.App.Profiles
{
    public partial class ShowProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Profile.IsAnonymous == false)
            {
                pnlInfo.Visible = true;
                lblFullName.Text = HttpContext.Current.Profile.GetPropertyValue("firstName")+ " " + HttpContext.Current.Profile.GetPropertyValue("lastName");
                lblPhone.Text = HttpContext.Current.Profile.GetPropertyValue("phoneNumber").ToString();
                lblBirthDate.Text = Convert.ToDateTime(HttpContext.Current.Profile.GetPropertyValue("birthDate").ToString()).ToShortDateString();
            }
            else
            {
                pnlInfo.Visible = false;
            }
        }
    }
}
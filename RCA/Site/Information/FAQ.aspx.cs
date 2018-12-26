using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace RCA.Site.Information
{
    public partial class FAQ : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string culture = Request.QueryString["culture1"];

            if (culture != null)
            {
                if (culture == "en-US")
                {
                    Session["CurrentCulture"] = "en-US";
                }

                if (culture == "mr-IN")
                {
                    Session["CurrentCulture"] = "mr-IN";
                }

            }

            /*The page is serach from Google, which is showing plain url
           We need to show CMS page, Following is the url
           If we delete the cms menu and again created then the following MENU ID WILL CHANGE. */

            Response.Redirect("~/1044/FAQs");

            //-------------------------------------------------------------
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            Hashtable controls = new Hashtable();
            controls.Add(lbl_FAQtitle, "lbl_FAQtitle");
            controls.Add(lbl_FAQDetail, "lbl_FAQDetail");
            ((PageBase)Page).SetUICulture(controls);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace RCA.Site.Information
{
    public partial class events : PageBase
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
        }
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            Hashtable controls = new Hashtable();
            controls.Add(lbl_eventstitle, "lbl_eventstitle");
            controls.Add(lbl_eventscontent, "lbl_eventscontent");
            ((PageBase)Page).SetUICulture(controls);
        }
    }
}
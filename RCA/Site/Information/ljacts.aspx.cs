using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace RCA.Site.Information
{
    public partial class ljacts : MAHAITPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            lbl_reprint.Text = GetResourceValue("General", "lblReprint", "");
        }
    }
}
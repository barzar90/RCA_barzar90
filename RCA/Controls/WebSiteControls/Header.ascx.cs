using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace RCA.Controls.WebSiteControls
{
    public partial class Header : MAHAITUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login/Login.aspx");
        }

        void Page_PreRender(Object o, EventArgs e)
        {
            imgMahaOnline_alt.Alt = GetResourceValue("Common", "imgMahaIT_alt", "");
            btnlogin.Text = GetResourceValue("Common", "btnlogin", "");
        }
    }
}
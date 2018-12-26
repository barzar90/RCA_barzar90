using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MSHC.App.STD
{
    public partial class OpenMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("../../App/Forms/Forms.aspx?ID="+Request.QueryString["ID"].ToString());
        }
    }
}
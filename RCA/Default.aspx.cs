using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using BL;
using Schema;

namespace RCA
{
    public partial class Default : MAHAITPage 
    {
        #region Public variable declaration
        MenuSchema objMenuSchema = new MenuSchema();
        MenuBL objMenuBL = new MenuBL();
        DataSet ds;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
          
            objMenuSchema.MenuName = "Home";
            ds = objMenuBL.GetMenuDetails(objMenuSchema);

            if (ds.Tables[0].Rows.Count > 0)
            {
                String strHomePageLink = HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["MenuID"]) + "/";
                strHomePageLink += Convert.ToString(ds.Tables[0].Rows[0]["MenuName"]).TrimStart().TrimEnd().Replace(" ", "-");
                Response.Redirect(HttpUtility.UrlDecode(strHomePageLink, System.Text.Encoding.UTF8));
            }
            else
            {
                Response.Redirect("~/Site/Home/Index.aspx");
            }
        }
    }
}
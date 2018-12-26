using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace RCA.Site.Information
{
    public partial class Albums : PageBase
    {
        int LangID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayEvents();
            }
        }

        public void DisplayEvents()
        {
            SqlConnection conn = Helper.SQLHelper.OpenConnection();

            DataSet ds = Helper.SQLHelper.ExecuteDataset(conn, null, "sp_GetPhotoGalleryAlbumList", null);

            LV_Events.DataSource = ds;

            LV_Events.DataBind();

        }

        protected void LV_Events_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
          
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
                lblAlbum.Text = "छायाचित्रपुस्तक";
            }
            else
            {
                LangID = 1;
                lblAlbum.Text = "Albums";
            }

        }

        protected void Lnkhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/1035/Home");
        }


    }
}
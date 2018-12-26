using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;
using BL;
using Helper;

namespace RCA.Site.Information
{
    public partial class SubAlbum : MAHAITPage 
    {
        BL.BL MAHAITDBAccess;
        int AlbumID;
        protected void Page_Load(object sender, EventArgs e)
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            if ((Request.QueryString["ID"] == null))
            {
                AlbumID = 0;

            }
            else
            {
                AlbumID = Convert.ToInt32((Request.QueryString["ID"]));

            }
            if (!IsPostBack)
            {

                DisplayEvents();
            }
        }
        public void DisplayEvents()
        {              
            SqlConnection conn = Helper.HelperCls.OpenConnection();            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_GetPhotoGallerySubAlbumList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AlbumID", AlbumID);

            DataSet ds = MAHAITDBAccess.ExecuteDataSet(cmd);

            LV_Events.DataSource = ds;

            LV_Events.DataBind();

        }



        protected void LV_Events_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //Image ImgCover = (Image) e.Item.FindControl("imgCover");
            //SqlConnection conn = SQLHelper.OpenConnection();
            //DataSet ds = SQLHelper.ExecuteDataset(conn, null, "sp_GetPressNewsAlbumList_Anjani", null);

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    hdnImageUrl.Text = "~/SITE" + ds.Tables[0].Rows[i]["Photo"].ToString();
            //    ImgCover.ImageUrl = hdnImageUrl.Text;
            //}


        }
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            int LangID = 0;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
                lblAlbum.Text = "छायाचित्रपुस्तक";



            }
            else
            {
                LangID = 1;
                lblAlbum.Text = "Album";

            }

        }

        protected void Lnkhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/1035/Home");
        }
    }
}
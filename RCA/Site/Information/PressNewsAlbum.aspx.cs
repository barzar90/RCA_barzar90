using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BL;

namespace RCA.Site.Information
{
    public partial class PressNewsAlbum : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;
      //  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack != true)
            {
                ListviewBind();
            }
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

        public void ListviewBind()
        {


            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            string query = "SELECT PressNewsAlbum.PressNewsAlbumID, PressNewsAlbum.DefaultPhotID, PressNewsAlbum.AlbumName, PressNewsPhotoAlbum.Photo FROM PressNewsAlbum INNER JOIN PressNewsPhotoAlbum ON PressNewsAlbum.PressNewsAlbumID = PressNewsPhotoAlbum.AlbumID ";
            query += " where PressNewsPhotoAlbum.IsCoverPhoto=1";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);


            //string query = "SELECT PressNewsAlbum.PressNewsAlbumID, PressNewsAlbum.DefaultPhotID, PressNewsAlbum.AlbumName, PressNewsPhotoAlbum.Photo FROM PressNewsAlbum INNER JOIN PressNewsPhotoAlbum ON PressNewsAlbum.PressNewsAlbumID = PressNewsPhotoAlbum.AlbumID ";
            //query += " where PressNewsPhotoAlbum.IsCoverPhoto=1";
            //SqlDataAdapter da = new SqlDataAdapter(query,con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            lvAlbums.DataSource = ds;
            lvAlbums.DataBind();
        }


        //protected void Page_PreRender(Object sender, EventArgs e)
        //{
        //    Hashtable controls = new Hashtable();
        //    controls.Add(lbl_PressNewsAlbum, "lbl_Album");

        //    ((PageBase)Page).SetUICulture(controls);
        //}
    }
}
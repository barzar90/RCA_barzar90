using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Helper;


namespace RCA.Site.Information
{
    public partial class GalleryPhoto : System.Web.UI.Page
    {
        public int AlbumID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["ID"] == null))
            {
                AlbumID = 0;

            }
            else
            {
                AlbumID = Convert.ToInt32((Request.QueryString["ID"]));

            }

            GetData();
        }

        public void GetData()
        {


            SqlConnection conn =Helper.SQLHelper.OpenConnection();

            SqlParameter[] cmmParameters = new SqlParameter[1];
            cmmParameters[0] = new SqlParameter("@AlbumID", AlbumID);
           

            DataSet ds = Helper.SQLHelper.ExecuteDataset(conn, null, CommandType.StoredProcedure, "[sp_GetPhotoGalleryAlbumwithPhoto]", cmmParameters);
            DL_EventPhoto.DataSource = ds;
            DL_EventPhoto.DataBind();
        }
    }
}
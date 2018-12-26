using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using BL;


namespace RCA.Site.Information
{
    public partial class PhotoViewer : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

        protected void Page_Load(object sender,System. EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string photoID = Request.QueryString["PhotoID"];
                string albumID = Request.QueryString["AlbumID"];
                ViewState["hfAlbumID"] = albumID;
                //Get Page number by passing photo id
                int index = GetPageNumber(int.Parse(photoID), int.Parse(albumID));
                DataPager1.SetPageProperties(index, 1, true);
            }
        }
        /// <summary>
        /// Since the pagesize is 1 the row number can be taken as page number
        /// </summary>
        /// <param name="PhotoID"></param>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public int GetPageNumber(int PhotoID, int AlbumID)
        {
            //MOLDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            //string query = "SELECT PageNumber FROM (SELECT row_number() Over (order by photoid asc) AS PageNumber,photoid,Albumid FROM PhotAlbum where Albumid=@Albumid) As Photos where photoid=@photoid and Albumid=@Albumid ";
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = query;
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@Albumid", AlbumID.ToString());
            //cmd.Parameters.AddWithValue("@photoid", PhotoID.ToString());
            //cmd.Parameters.AddWithValue("@Albumid", AlbumID);
            //DataSet ds = new DataSet();
            //ds = MOLDBAccess.ExecuteDataSet(cmd);



            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);
            //con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PageNumber FROM (SELECT row_number() Over (order by photoid asc) AS PageNumber,photoid,Albumid FROM PhotAlbum where Albumid=@Albumid1) As Photos where photoid=@photoid and Albumid=@Albumid";
            cmd.Parameters.AddWithValue("@Albumid1", AlbumID.ToString());
            cmd.Parameters.AddWithValue("@Albumid", AlbumID.ToString());
            cmd.Parameters.AddWithValue("@photoid", PhotoID.ToString());
            //SqlCommand com = new SqlCommand("SELECT PageNumber FROM (SELECT row_number() Over (order by photoid asc) AS PageNumber,photoid,Albumid FROM PhotAlbum where Albumid=" + AlbumID.ToString() + ") As Photos where photoid=" + PhotoID.ToString() + " and Albumid=" + AlbumID.ToString(), con);
            
          //  SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds=new DataSet ();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);

            int pageno = 1;
            if (ds.Tables[0].Rows.Count>0)
            {
                pageno = int.Parse(ds.Tables[0].Rows[0]["PageNumber"].ToString());
            }
           
            return (pageno - 1);

            //int pageno = 1;
            //if (dr.Read())
            //{
            //    pageno = int.Parse(dr["PageNumber"].ToString());
            //}
            //dr.Close();
            //con.Close();
            //return (pageno - 1);
        }
        public DataSet GetPhoto(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            DataSet ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);

            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);
            //SqlDataAdapter ada = new SqlDataAdapter(query, con);
            //DataTable dtEmp = new DataTable();
            //ada.Fill(dtEmp);
            return ds;
        }
        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            lvPhotoViewer.DataSource = GetPhoto("Select * from PhotAlbum where AlbumID = " + ViewState["hfAlbumID"].ToString());
            lvPhotoViewer.DataBind();
        }    
    }
}
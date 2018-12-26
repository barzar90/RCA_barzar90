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
using System.Configuration;
using BL;

namespace RCA.Site.Information
{
    public partial class Photos : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        protected void Page_Load(object sender, System. EventArgs e)
        {
            if (!IsPostBack)
            {
                string albumid = Request.QueryString["AlbumID"];
                hfAlbumID.Value = albumid;
                string query = "SELECT DefaultPhotID, AlbumName,photo FROM [Album] INNER JOIN PhotAlbum ON [Album].[DefaultPhotID] = PhotAlbum.PhotoID WHERE Album.[AlbumID] =" + hfAlbumID.Value;
                GetAlbumDetails(query);

               
            }
        }
        public void GetAlbumDetails(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            DataSet ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblAlbumName.Text = ds.Tables[0].Rows[0]["AlbumName"].ToString();
                imAlbumPhoto.ImageUrl = "ThumbNail.ashx?ImURL=" + ds.Tables[0].Rows[0]["photo"].ToString();
            
            }

        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            lblNoofPicz.Text = e.AffectedRows.ToString();
        }
        protected void lbUploadPhotos_Click(object sender,System. EventArgs e)
        {
            HttpContext.Current.Items.Add("AlbumID", hfAlbumID.Value);
            Server.Transfer("ImageUpload.aspx");
        }

        protected void lvPhotos_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected void lvPhotos_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void lvPhotos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

       
    }
}
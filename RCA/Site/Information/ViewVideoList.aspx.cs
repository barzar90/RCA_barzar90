using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Schema;
using DAL;
using BL;

namespace RCA.Site.Information
{
    public partial class ViewVideoList : System.Web.UI.Page
    {
        String SearchText = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnPageIndex.Value = "0";
            BindVideoDataList(SearchText);     

            if (Request.QueryString["SearchText"] != null)
            {
                SearchText = Convert.ToString(Request.QueryString["SearchText"]);
                BindVideoDataList(SearchText);
            }
        }

        private void BindVideoDataList(string SearchText)
        {
            try
            {
                DataTable dt = new DataTable();

                UploadVideoSchema objUploadVideo_Schema = new UploadVideoSchema();
                objUploadVideo_Schema.Keyword = SearchText;


                dt = ViewVideos(objUploadVideo_Schema);
                PagedDataSource pds = new PagedDataSource();
                //pds.DataSource = ds.Tables[0].DefaultView;
                pds.DataSource = dt.DefaultView;

                pds.AllowPaging = true;
                pds.PageSize = 8;
                pds.CurrentPageIndex = Convert.ToInt32(hdnPageIndex.Value);
                dlVideoList.DataSource = pds;
                dlVideoList.DataBind();
            }
            catch { }
            finally
            {

            }
        }

        public DataTable ViewVideos(UploadVideoSchema UploadVideo_Schema)
        {
            try
            {
                UploadVideoDL objUploadVideo_DAL = new UploadVideoDL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.ViewVideoList(UploadVideo_Schema);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }

        public DataTable FetchVideoPath(String VideoID)
        {
            try
            {
                UploadVideoDL objUploadVideo_DAL = new UploadVideoDL();
                DataTable dt = new DataTable();
                dt = objUploadVideo_DAL.FetchVideoPath(VideoID);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }
    
}
}
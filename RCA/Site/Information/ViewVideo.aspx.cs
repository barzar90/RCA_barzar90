using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using System.Data;
using DAL;
using BL;


namespace RCA.Site.Information
{
    public partial class ViewVideo : MAHAITPage 
    {
        UploadVideoSchema objUploadVideo_Schema;
        DataSet ds;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string myVideoID = Request.QueryString["str"].ToString();

                dt = new DataTable();
                dt = FetchVideoPath(myVideoID);
                if (dt.Rows.Count > 0)
                {
                    ViewState["VideoPath"] = dt.Rows[0]["VideoPath"].ToString();
                }


                //String sourceUrl = Server.MapPath("../../Site/Upload/Video//");
                String sourceUrl = Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty) + "/Site/Upload/Video/";
                //String sourceUrl = Server.MapPath("../Upload/Video//");
                String sourceUrl1 = ViewState["VideoPath"].ToString();

                String filePath = String.Concat(sourceUrl, sourceUrl1);
                String strUrl = sourceUrl + sourceUrl1;

                String myObjectTag = String.Empty;
                myObjectTag = myObjectTag + "<object classid='clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6' id='Player1' width='424' height='379'>";
                myObjectTag = myObjectTag + "<param name='URL' value='" + strUrl + "'>";
                myObjectTag = myObjectTag + " <param name=' " + sourceUrl1 + "'>";
                myObjectTag = myObjectTag + "<param name='AutoStart' value='1'>";
                myObjectTag = myObjectTag + "<param name='ShowControls' value='1'>";
                myObjectTag = myObjectTag + "<param name='ShowStatusBar' value='1'>";
                myObjectTag = myObjectTag + "<param name='ShowDisplay' value='1'>";
                myObjectTag = myObjectTag + "<param name='ClickToPlay' value='1'>";
                myObjectTag = myObjectTag + "<param name='stretchToFit' value='1'>";
                myObjectTag = myObjectTag + "<embed type='application/x-shockwave-flash' pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/MediaPlayer/'  width='424' height='379' src='" + "../Upload/Video/" + ViewState["VideoPath"].ToString() + "'    autostart='1' showcontrols='1' showstatusbar='1' showdisplay='1' ClickToPlay='1'>";

                //myObjectTag = myObjectTag + "<embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/MediaPlayer/'  width='424' height='379' src='" + strUrl + "' filename='" + sourceUrl1 + "'    autostart='1' showcontrols='1' showstatusbar='1' showdisplay='1' ClickToPlay='1'>";
                myObjectTag = myObjectTag + "</embed>";
                myObjectTag = myObjectTag + "</object>";

                ltrVideo.Text = myObjectTag;
            }
            catch (Exception ex)
            {

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
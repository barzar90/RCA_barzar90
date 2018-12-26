using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System;
using BL;

namespace RCA.Site.Common
{
    public partial class ViewVideo : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;

        protected void Page_Init(object sender, EventArgs e)
        {
            //MOLDBAccess = ((MOLMasterPage)this.Master).MOLDBAccess;
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string myVideoID = Request.QueryString["str"].ToString();
                String strUrl = "../STD/DisplayFile.ashx?ID=" + myVideoID;

                String myObjectTag = String.Empty;
                myObjectTag = myObjectTag + "<object classid='clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6' id='Player1' width='424' height='379'>";
                myObjectTag = myObjectTag + "<param name='URL' value='" + strUrl + "'>";
                //myObjectTag = myObjectTag + " <param name=' " + sourceUrl1 + "'>";
                myObjectTag = myObjectTag + "<param name='AutoStart' value='1'>";
                myObjectTag = myObjectTag + "<param name='ShowControls' value='1'>";
                myObjectTag = myObjectTag + "<param name='ShowStatusBar' value='1'>";
                myObjectTag = myObjectTag + "<param name='ShowDisplay' value='1'>";
                myObjectTag = myObjectTag + "<param name='stretchToFit' value='1'>";
                //myObjectTag = myObjectTag + "<embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/MediaPlayer/'  width='424' height='379' src='" + strUrl + "' filename='" + sourceUrl1 + "'    autostart='1' showcontrols='1' showstatusbar='1' showdisplay='1'>";
                myObjectTag = myObjectTag + "<embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/MediaPlayer/'  width='424' height='379' src='" + strUrl + "' autostart='1' showcontrols='1' showstatusbar='1' showdisplay='1'>";

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
    }
}
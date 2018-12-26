using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using BL;
using System.Net.NetworkInformation;
using System.Data;
using System.Data.SqlClient;
using Schema;

namespace RCA.Controls.WebSiteControls
{
    public partial class FooterMenu : MAHAITUserControl //: System.Web.UI.UserControl
    {
        #region Public variable declaration

        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        BannerBL objBannerBL = new BannerBL();
        DataTable dt;
        DataSet ds;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion

        public string RenderDevice { get; set; }

        private void BindMenu()
        {
            try
            {
                BL.BL MAHAITDBAccess = ((MAHAITMasterPage)this.Page.Master).MAHAITDBAccess;
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                objBannerControlSchema.UserName = MAHAITDBAccess.UserName;
                if(!string.IsNullOrWhiteSpace(objBannerControlSchema.UserName)) {
                    ds = objBannerBL.GetVisitorCount(objBannerControlSchema);
                    dt = ds.Tables[0];
                }
                

                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {

                    string FooterMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Footer_Mr.xml");
                    FooterMenu = FooterMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Footermenu1.InnerHtml = FooterMenu;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    string FooterMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Footer_En.xml");
                    FooterMenu = FooterMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Footermenu1.InnerHtml = FooterMenu;
                }
                else
                {
                    string FooterMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Footer_Ur.xml");
                    FooterMenu = FooterMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Footermenu1.InnerHtml = FooterMenu;
                }

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string no = dt.Rows[0]["TOTALCOUNT"].ToString();
                        string todaycount = dt.Rows[0]["TodayVisit"].ToString();

                        
                        lblTotalVisitHeading.Text = _MahaITUC.GetResourceValue("Common", "lblTotalVisitor", "");
                        lblTodayVisitHeading.Text = _MahaITUC.GetResourceValue("Common", "lblTodaysVisitor", "");
                       

                        if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                        {
                            lblCounter.Text = no.ToString();
                            lbltodayCount.Text = todaycount.ToString();
                        }
                        else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                        {
                            lblCounter.Text = no.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
                            lbltodayCount.Text = todaycount.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
                        }
                    }
                }
            }
            finally
            { }
        }

        protected void Page_PreRender(Object o, EventArgs e)
        {
            BindMenu();
            lbl_copyright.Text = GetResourceValue("Common", "lbl_copyright", "");
            lbl_developedby.Text = GetResourceValue("Common", "lbl_developedby", "");
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
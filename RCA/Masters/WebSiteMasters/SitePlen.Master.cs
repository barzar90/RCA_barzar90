using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MSHC.Controls.WebSiteControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using BL;

namespace MSHC.Masters.WebSiteMasters
{
    public partial class SitePlen : MAHAITMasterPage
    {
        LastReviewedDate objLastReviewedDate = new LastReviewedDate();
        SetCulture objSetCulture = new SetCulture();
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ToString());

        protected void Page_Init(object sender, EventArgs e)
        {

            if (Request.Cookies[".ASPXANONYMOUS"] != null)
            {
                HttpCookie myCookie = new HttpCookie(".ASPXANONYMOUS");
                Request.Cookies[".ASPXANONYMOUS"].Value = "";
            }

            Response.Cookies[".ASPXAUTH"].Value = String.Empty;
            Response.Cookies.Remove(".ASPXAUTH");
            Request.Cookies.Remove(".ASPXAUTH");

            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1;

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Culture = HeaderMain1.SetCulture1.MAHAITCurrentCultureID;
            HeaderMain1.SetCulture1.ButtonClickedLarger += new EventHandler(SetCulture1_ButtonClickedLarger);
            HeaderMain1.SetCulture1.ButtonClickedLarge += new EventHandler(SetCulture1_ButtonClickedLarge);
            HeaderMain1.SetCulture1.ButtonClickedMedium += new EventHandler(SetCulture1_ButtonClickedMedium);
            HeaderMain1.SetCulture1.ButtonClickedSmall += new EventHandler(SetCulture1_ButtonClickedSmall);
            HeaderMain1.SetCulture1.ButtonClickedSmallest += new EventHandler(SetCulture1_ButtonClickedSmallest);
            HeaderMain1.SetCulture1.ButtonClickedABlack += new EventHandler(SetCulture1_ButtonClickedContrast);
            HeaderMain1.SetCulture1.ButtonClickedAWhite += new EventHandler(SetCulture1_ButtonClickedWhite);
            HeaderMain1.SetCulture1.ButtonClickedCultureSheet += new EventHandler(SetCulture1_ButtonClickedCultureSheet);

        }

        protected void HandleSessionFixation()
        {
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                HttpCookie myCookie = default(HttpCookie);
                myCookie = Request.Cookies[i];
                myCookie.Value = string.Empty;
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Set(myCookie);
            }
        }

        void SetCulture1_ButtonClickedCultureSheet(object sender, EventArgs e)
        {
            HtmlLink Link = FindControl("CultureSheet") as HtmlLink;
            if (Link == null) return;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                Link.Href = @"../../Styles/LayoutMR.css";
            }
            else
            {
                Link.Href = @"../../Styles/LayoutEN.css";
            }
        }

        protected void SetCulture1_ButtonClickedWhite(object sender, System.EventArgs e)
        {
            HtmlLink link = FindControl("mystylesheet") as HtmlLink;
            link.Href = @"../../styles/Layout.css";
        }

        protected void SetCulture1_ButtonClickedContrast(object sender, System.EventArgs e)
        {
            HtmlLink Link = FindControl("MyStyleSheet") as HtmlLink;
            Link.Href = @"../../Styles/LayoutBlack.css";
        }

        protected void SetCulture1_ButtonClickedLarger(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "larger");
        }

        protected void SetCulture1_ButtonClickedLarge(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "large");
        }
        protected void SetCulture1_ButtonClickedMedium(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "medium");
        }

        protected void SetCulture1_ButtonClickedSmall(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "small");
        }
        protected void SetCulture1_ButtonClickedSmallest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "smaller");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {

        }
    }
}
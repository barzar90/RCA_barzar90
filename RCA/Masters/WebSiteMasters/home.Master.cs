
using System;
using System.Web.UI.HtmlControls;
using RCA.Controls.WebSiteControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using BL;

namespace RCA.Masters.WebSiteMasters
{
    public partial class home : MAHAITMasterPage
    {

        int LangID = 0;
        LastReviewedDate objLastReviewedDate = new LastReviewedDate();

        protected void Page_Init(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();

            if (Request.Cookies[".ASPXANONYMOUS"] != null)
            {
                HttpCookie myCookie = new HttpCookie(".ASPXANONYMOUS");
                Request.Cookies[".ASPXANONYMOUS"].Value = "";
            }
            Response.Cookies[".ASPXAUTH"].Value = String.Empty;
            Response.Cookies.Remove(".ASPXAUTH");
            Request.Cookies.Remove(".ASPXAUTH");

            HttpContext.Current.Profile.SetPropertyValue("RandomToken", string.Empty);
            HttpContext.Current.Profile.SetPropertyValue("AuthToken", string.Empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Culture = HeaderMain1.SetCulture1.MAHAITCurrentCultureID;
            HeaderMain1.SetCulture1.ButtonClickedLarger += new EventHandler(SetCulture1_ButtonClickedBrightest);
            HeaderMain1.SetCulture1.ButtonClickedLarge += new EventHandler(SetCulture1_ButtonClickedBright);
            HeaderMain1.SetCulture1.ButtonClickedMedium += new EventHandler(SetCulture1_ButtonClickedNormal);
            HeaderMain1.SetCulture1.ButtonClickedSmall += new EventHandler(SetCulture1_ButtonClickedDark);
            HeaderMain1.SetCulture1.ButtonClickedSmallest += new EventHandler(SetCulture1_ButtonClickedDarkest);
            HeaderMain1.SetCulture1.ButtonClickedABlack += new EventHandler(SetCulture1_ButtonClickedContrast);
            HeaderMain1.SetCulture1.ButtonClickedAWhite += new EventHandler(SetCulture1_ButtonClickedWhite);
            HeaderMain1.SetCulture1.ButtonClickedCultureSheet += new EventHandler(SetCulture1_ButtonClickedCultureSheet);



            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                LangID = 2;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-US").ToLower())
                LangID = 1;
            else
                LangID = 3;

        }
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            if (LangID == 1)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                Head1.Attributes["lang"] = "en-US";
            }
            //Added By K.p
            else if (LangID == 3)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                Head1.Attributes["lang"] = "ur";
            }
            else
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                Head1.Attributes["lang"] = "mr-IN";
            }

            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            lbldepName.Text = _MahaITUC.GetResourceValue("Common", "lbldepName", "");

        }

        void SetCulture1_ButtonClickedCultureSheet(object sender, EventArgs e)
        {
            HtmlLink Link = FindControl("CultureSheet") as HtmlLink;
            if (Link == null) return;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                Link.Href = @"../../Styles/LayoutMR.css";
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                Link.Href = @"../../Styles/LayoutEN.css";
            }
            else
            {
                Link.Href = @"../../Styles/LayoutUR.css";
            }
        }

        protected void SetCulture1_ButtonClickedBrightest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "larger");
        }
        protected void SetCulture1_ButtonClickedBright(object sender, System.EventArgs e)
        {

            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "large");

        }
        protected void SetCulture1_ButtonClickedNormal(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "medium");

        }
        protected void SetCulture1_ButtonClickedDark(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "small");

        }
        protected void SetCulture1_ButtonClickedDarkest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "smaller");

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

        protected void Page_Unload(object sender, EventArgs e)
        {
        }


    }
}
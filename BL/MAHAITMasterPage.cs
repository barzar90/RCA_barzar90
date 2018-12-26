using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace BL
{
    public class MAHAITMasterPage : System.Web.UI.MasterPage
    {
        public BL MAHAITDBAccess;
        public LinkButton Culture { get; set; }

        public MAHAITMasterPage()
        {
            Unload += new EventHandler(MAHAITMasterPage_Unload);
            Init += new EventHandler(MAHAITMasterPage_Init);
            Load += new EventHandler(MAHAITMasterPage_Load);
            PreRender += new EventHandler(MAHAITMasterPage_PreRender);

            if (HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString() != System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToString())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
            }

        }

        void MAHAITMasterPage_PreRender(object sender, EventArgs e)
        {

            HtmlGenericControl HtmlLang = FindControl("Html") as HtmlGenericControl;
            if (HtmlLang != null)
            {
                HtmlLang.Attributes.Remove("lang");
                HtmlLang.Attributes.Add("lang", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
                HtmlLang.Attributes.Remove("xml:lang");
                HtmlLang.Attributes.Add("xml:lang", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
            }

            if (Culture != null)
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
                {
                    Culture.Text = "English";
                }
                else //if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
                {
                    Culture.Text = "मराठी";
                }                    
               //else
               //     Culture.Text = "Urdu";
        }

        void MAHAITMasterPage_Load(object sender, EventArgs e)
        {
            ApplyUICulture();
        }

        void MAHAITMasterPage_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

            MAHAITDBAccess.ServerPath = Server.MapPath("~\\App_Data\\" + HttpContext.Current.Profile.UserName);
            MAHAITDBAccess.UserName = HttpContext.Current.Profile.UserName;

            if (!Directory.Exists(MAHAITDBAccess.ServerPath))
            {
                //  Directory.CreateDirectory(MOLDBAccess.ServerPath);
            }

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
                MAHAITDBAccess.LangID = "2";
            else
                MAHAITDBAccess.LangID = "1";
        }

        void MAHAITMasterPage_Unload(object sender, EventArgs e)
        {
        }

       

        private void ApplyColorLevel()
        {
            HtmlLink Link = FindControl("MyStyleSheet") as HtmlLink;
            if (Link != null)
                Link.Href = (Convert.ToString(HttpContext.Current.Profile.GetPropertyValue("ColorLevel")) == "" ? Link.Href : Convert.ToString(HttpContext.Current.Profile.GetPropertyValue("ColorLevel")));
        }

        private void ApplyFontLevel()
        {
            string value = Convert.ToString(HttpContext.Current.Profile.GetPropertyValue("FontLevel"));
            HtmlGenericControl divMaster = FindControl("divnew") as HtmlGenericControl;
            if (divMaster != null)
            {
                divMaster.Attributes.Remove("class");
                divMaster.Attributes.Add("class", value);
            }
        }

        private void ApplyCultureLevel()
        {
            HtmlLink Link = FindControl("CultureSheet") as HtmlLink;
            if (Link == null) return;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-in").ToLower())
                Link.Href = @"~/Styles/LayoutMR.css";
            else
                Link.Href = @"~/Styles/LayoutEN.css";
        }

        protected void ApplyUICulture()
        {
            ApplyColorLevel();

            ApplyFontLevel();

            ApplyCultureLevel();
        }
    }
}

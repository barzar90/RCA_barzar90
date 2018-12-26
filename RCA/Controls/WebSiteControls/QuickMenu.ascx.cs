using System;
using System.Web;
using System.IO;
using System.Xml;
using System.Text;
using System.Configuration;

namespace MSHC.Controls.WebSiteControls
{
    public partial class QuickMenu : System.Web.UI.UserControl
    {
        public string LangID = "en-IN";
        public int MenuID = 0;
        public string RenderDevice { get; set; }

        private void BindMenu()
        {
            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    lblHeading.Text = "Quick Link"; //TODO Marathi
                    string UserMenu = GetMrQuickMenuByMenuID(MenuID);
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    QuickMenu.InnerHtml = UserMenu;
                }
                else
                {
                    lblHeading.Text = "Quick Link";
                    string UserMenu = GetEnQuickMenuByMenuID(MenuID);
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    QuickMenu.InnerHtml = UserMenu;
                }
            }
            finally
            {
            }
        }

        //Function which returns Quick Menu in English w.r.t  Menu ID

        private string GetEnQuickMenuByMenuID(int MenuID)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "QuickMenu_En.xml").ToString());
                XmlNodeList xnList = xml.SelectNodes("/ul/Menu[@id='" + MenuID.ToString() + "']");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (XmlNode xn in xnList)
                    sb.Append(xn.InnerXml.ToString());

                sb.AppendLine("</ul>");
                return sb.ToString();
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        //Function which returns Quick Menu in Marathi w.r.t  Menu ID

        private string GetMrQuickMenuByMenuID(int MenuID)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                if (RenderDevice == "Mobile")
                {
                    xml.LoadXml(File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "MobileQuickMenu_Mr.xml").ToString());
                }
                else
                {
                    xml.LoadXml(File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "QuickMenu_Mr.xml").ToString());
                }

                XmlNodeList xnList = xml.SelectNodes("/ul/Menu[@id='" + MenuID.ToString() + "']");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (XmlNode xn in xnList)
                {

                    sb.Append(xn.InnerXml.ToString());

                }
                sb.AppendLine("</ul>");
                return sb.ToString();
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        void Page_PreRender(Object o, EventArgs e)
        {
            BindMenu();
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
    }
}
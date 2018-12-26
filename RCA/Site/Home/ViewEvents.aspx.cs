using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using AjaxControlToolkit;
using System.Web.UI.HtmlControls;
using BL;

namespace MSHC.Site.Home
{
    public partial class ViewEvents : MAHAITPage
    {
        int LangID = 0;
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        DataSet ds = new DataSet();
        DataTable table = new DataTable();

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                LangID = 2;
            else
                LangID = 1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                byte[] b;
                SqlCommand sqlComm = new SqlCommand("select id,EventTitle,EventTitleLL,ImageContent,EventCost,CONVERT(varchar,StrtDate,103) As StrtDate,CONVERT(varchar,EndDate,103) As EndDate,EventDescr,EventDescrLL,createddate from tbl_Events  where CONVERT(varchar,EndDate,111)>=CONVERT(varchar,getdate(),111)  order by id ");
                sqlComm.CommandType = CommandType.Text;
                ds = new DataSet();
                ds = MAHAITDBAccess.ExecuteDataSet(sqlComm);

                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append(String.Format("<ul id='dates'>"));

                    string descr = "";
                    byte[] data = (byte[])ds.Tables[0].Rows[i]["ImageContent"];
                    string ImageValue = GetImage(data);
                    sb.Append("<li><img class='imgevent' alt=''  src='" + ImageValue + "' /></li>");
                    if (LangID.ToString() == "1")
                    {
                        sb.Append(String.Format("<h2>" + Convert.ToString(ds.Tables[0].Rows[i]["EventTitle"]) + "</h2>"));
                        descr = Convert.ToString(ds.Tables[0].Rows[i]["EventDescr"]);
                    }
                    else
                    {
                        sb.Append(String.Format("<h2>" + Convert.ToString(ds.Tables[0].Rows[i]["EventTitleLL"]) + "</a></h2>"));
                        descr = Convert.ToString(ds.Tables[0].Rows[i]["EventDescrLL"]);
                    }
                    sb.Append(String.Format("<li><b> Event Start Date :  &nbsp </b>" + Convert.ToString(ds.Tables[0].Rows[i]["StrtDate"]) + "</li>"));
                    sb.Append(String.Format("<li><b> Event Last Date :  &nbsp </b>" + Convert.ToString(ds.Tables[0].Rows[i]["EndDate"]) + "</li>"));
                    sb.Append(String.Format("<li><b> Event Fees &nbsp Rs:  &nbsp  </b>" + Convert.ToString(ds.Tables[0].Rows[i]["EventCost"]) + "</li>"));
                    sb.Append(String.Format("<p>" + descr.ToString() + "</p>"));
                    sb.Append(String.Format("</ul><br><br><br><div class='clear'></div>"));

                    Literal1.Text = sb.ToString();
                }
            }
        }

        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
    }
}
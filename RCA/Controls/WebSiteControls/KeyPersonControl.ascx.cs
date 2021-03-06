﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using Schema;
using BL;

namespace RCA.Controls.WebSiteControls
{
    public partial class KeyPersonControl : System.Web.UI.UserControl
    {
        #region Public variable declaration
        public BL.BL MAHAITDBAccess;
        public string PageTile = "";
        DataSet ds = null;
        StringBuilder sb;
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        BannerBL objBannerBL = new BannerBL();
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            GetRecord();
        }

        protected void GetRecord()
        {
            // Added By K.P. on 22-05-2018
            string strquery = string.Empty, heading = string.Empty;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {             
                heading = _MahaITUC.GetResourceValue("Common", "heading", ""); 
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {             
                heading = _MahaITUC.GetResourceValue("Common", "heading", ""); 
            }
            else 
            {
                _MahaITUC.GetResourceValue("Common", "heading", "");
            }

            objBannerControlSchema.FileType = "Key Persons";
            objBannerControlSchema.LangType = System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower();
            ds = objBannerBL.GetKeyPersonDetails(objBannerControlSchema);
                sb = new StringBuilder();
                sb.Append("<div class='col-md-3 col-sm-12 col-xs-12 keyperson'><ul>");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                        string Filedetails = ds.Tables[0].Rows[i]["FileDtl"].ToString();

                        string[] Filedata = Filedetails.Split(';');

                        string strUrl = "/Publicapp/Std/ViewFile.ashx?ID=" + ds.Tables[0].Rows[i]["RowID"];
                        sb.Append("<li><img src='" + strUrl + "' alt='" + ds.Tables[0].Rows[i]["FileDtl"].ToString() + "' class='img-responsive'>");
                        if (Filedata.Length == 2)
                        {
                            sb.Append("<p>" + ds.Tables[0].Rows[i]["FileTitle"].ToString() + "</p><small>" + "" + Filedata[0] + "</small></br><small>" + Filedata[1] + "</small></li>");
                        }
                        else       
                        {
                            sb.Append("<p>" + ds.Tables[0].Rows[i]["FileTitle"].ToString() + "</p><small>" + ds.Tables[0].Rows[i]["FileDtl"].ToString() + "</small></li>");
                        }
                    }
                sb.AppendLine("</ul></div>");
                LitKeyPerson.Text = sb.ToString();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
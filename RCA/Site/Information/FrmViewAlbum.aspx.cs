﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BL;

namespace RCA.Site.Information
{
    public partial class FrmViewAlbum : MAHAITPage
    {
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayAlbum();
            }
        }

        private void DisplayAlbum()
        {
            SqlCommand t_SQLCmd = new SqlCommand();

            t_SQLCmd.CommandType = CommandType.Text;
            t_SQLCmd.CommandText = "select PhotoAlbumID,Name,'../../App/PhotoAlbum/'+FileName as FileName from tblPhotoAlbum where IsActive =1";
            DataSet ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);
            lblAlbum.Text = GetResourceValue("General", "lblAlbum", "");
            LV_Events.DataSource = ds;
            LV_Events.DataBind();
        }




    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BL;

namespace RCA.Site.Common
{
    public partial class ViewAudioList : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            lblAudioHeading.Text = GetResourceValue("Login", "lblViewAudioHeading", lblAudioHeading.Text);
            lblArchives.Text = GetResourceValue("Login", "lblArchives", lblArchives.Text).ToString();

            if (hdncult.Value == String.Empty)
            {
                hdncult.Value = MAHAITDBAccess.LangID.ToString();
                LoadArchivesRadioList(hdncult.Value);
                BindAudioDataList(Convert.ToInt32(hdncult.Value));
            }
            else
            {
                if (MAHAITDBAccess.LangID.ToString() != hdncult.Value)
                {
                    hdncult.Value = MAHAITDBAccess.LangID.ToString();
                    LoadArchivesRadioList(hdncult.Value);
                    BindAudioDataList(Convert.ToInt32(hdncult.Value));
                }
            }
        }

        private void LoadArchivesRadioList(string langid)
        {
            switch (langid)
            {
                case "1":
                    rblArchives.Items.Add(new ListItem("Current", "1"));
                    rblArchives.Items.Add(new ListItem("Archives", "2"));
                    break;
                case "2":
                    rblArchives.Items.Add(new ListItem("जारी", "1"));
                    rblArchives.Items.Add(new ListItem("संग्रहित", "2"));
                    break;
            }
            rblArchives.SelectedValue = "1";
        }

        private void BindAudioDataList(int LangID)
        {
            try
            {
                DataTable dtAudioList = new DataTable();
                dtAudioList = FetchAudioListByLangid(LangID);

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dtAudioList.DefaultView;

                pds.AllowPaging = true;
                pds.PageSize = 6;
                dlAudioList.RepeatColumns = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["AudioRepeatColumns"].ToString());
                dlAudioList.DataSource = pds;

                dlAudioList.DataBind();

            }
            catch { }
            finally
            {

            }
        }

        public DataTable FetchAudioListByLangid(int langid)
        {
            DataTable dtAudio;
            string sqlQuery;
            SqlCommand cmdAudio = new SqlCommand();
            try
            {
                sqlQuery = "select A.FileID, ";
                if (langid == 1)
                {
                    sqlQuery += " Case When (FileTitle Is Not Null And FileDtl Is Not Null) And (FileTitle <> '' And FileDtl <> '') ";
                    sqlQuery += " Then FileTitle + ' - ' + FileDtl Else IsNull(FileTitle, '') + IsNull(FileDtl, '') End As FileTitleWithDtl, FileTitle as Title, ";
                }
                else
                {
                    sqlQuery += " Case When (FileTitle_LL Is Not Null And FileDtl_LL Is Not Null) And (FileTitle_LL <> '' And FileDtl_LL <> '') ";
                    sqlQuery += " Then FileTitle_LL + ' - ' + FileDtl_LL Else IsNull(FileTitle_LL, '') + IsNull(FileDtl_LL, '') End As FileTitleWithDtl, FileTitle_LL as Title, ";
                }

                sqlQuery += "  A.* from MOLUploadFile A INNER JOIN MOLFileCategory B ON B.FileTypeValue=A.Category and B.LangID=A.LangID ";
                sqlQuery += " WHERE B.FileTypeValue=16 AND A.LangID=@LangID AND A.ApprovalStatus = 1 AND A.Archives = @Archives ORDER BY A.CreatedOn";
                cmdAudio.CommandText = sqlQuery;
                cmdAudio.Parameters.Add("@LangID", SqlDbType.Int).Value = langid;
                cmdAudio.Parameters.Add("@Archives", SqlDbType.Bit);
                if (rblArchives.SelectedValue == "1")
                {
                    cmdAudio.Parameters["@Archives"].Value = 0;
                }
                else
                {
                    cmdAudio.Parameters["@Archives"].Value = 1;
                }

                dtAudio = MAHAITDBAccess.ExecuteDataSet(cmdAudio).Tables[0];

                return dtAudio;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                dtAudio = null;
            }
        }

        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = GetGlobalResourceObject(ResourceFile, ResourceKey);
            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        protected void rblArchives_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindAudioDataList(Convert.ToInt32(hdncult.Value));
            }
            catch
            {
            }
        }
    }
}
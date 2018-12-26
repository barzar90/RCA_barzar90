using System;
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

namespace MSHC.Site.Information
{
    public partial class FrmViewUploadImages : MAHAITPage  
    {
       BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               DisplayUploadIamges();
            }
        }

        private void DisplayUploadIamges()
        {
            SqlCommand t_SQLCmd = new SqlCommand();

            t_SQLCmd.CommandType = CommandType.Text;
            t_SQLCmd.CommandText = " select Name,NameMr,'../../Site/Upload/Images/'+ImgPath as ImgPath from UploadImages_SMM where IsActive=1";          
            DataSet ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);
            DL_EventPhoto.DataSource = ds;
            DL_EventPhoto.DataBind();
        }

        }
    
}
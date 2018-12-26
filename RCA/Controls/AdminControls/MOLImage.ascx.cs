using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace MSHC.Controls.AdminControls
{
    public partial class MOLImage : System.Web.UI.UserControl
    {
        public BL.BL MAHAITDBAccess { get; set; }
        public string ImageText { get; set; }
        public string ImageID { get; set; }
        HiddenField m_FieldData = null;
        Image m_Image = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            {
                m_Image = new Image();

                m_Image.ImageUrl = "~/App/STD/GetFile.ashx?ID=" + ImageText;
                m_Image.ID = ImageID + "__IMG";
                m_Image.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                m_FieldData = new HiddenField();

                m_FieldData.Value = ImageText;
                m_FieldData.ID = ImageID;
                m_FieldData.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                IMG.Controls.Add(m_Image);
                IMG.Controls.Add(m_FieldData);
            }
        }

        protected void btnCapture_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            if (ImageText == "-1")
            {
                ImageText = Guid.NewGuid().ToString();
                m_FieldData.Value = ImageText;
            }

            m_Image.ImageUrl = "~/App/STD/GetFile.ashx?ID=" + m_FieldData.Value;

        }

        protected void takePhoto_Click(object sender, EventArgs e)
        {

        }

        protected void cptCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
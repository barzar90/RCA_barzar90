using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;
using System.Data.SqlClient;

namespace RCA.Controls.AdminControls
{
    public partial class SRDHControl : System.Web.UI.UserControl
    {
        public BL.BL MAHAITDBAccess { get; set; }
        public XmlNode FieldNode { get; set; }
        public DataTable DataSource { get; set; }

        //public string[] ControlsToAssign { get; set; }
        string ControlsToAssign, ControlsToMap;
        string m_SRDHLink = "";
        string m_SRDHToken = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string t_XMLName = "";

            t_XMLName = Server.MapPath("../../App_Data/SRDHConfig.xml");

            XmlDocument t_Form = new XmlDocument();
            t_Form.Load(t_XMLName);

            foreach (XmlNode t_Element in t_Form.DocumentElement)
            {

                if (t_Element.Name.ToUpper() == "LINK" && t_Element.Attributes["Value"].Value.ToString() != "")
                {
                    m_SRDHLink = t_Element.Attributes["Value"].Value.ToString();
                }
                else if (t_Element.Name.ToUpper() == "TOKEN" && t_Element.Attributes["Value"].Value.ToString() != "")
                {
                    m_SRDHToken = t_Element.Attributes["Value"].Value.ToString();
                }

            }

            if (FieldNode.Attributes["ControlsToAssign"] != null && FieldNode.Attributes["ControlsToAssign"].Value != "" &&
                FieldNode.Attributes["ControlsToMap"] != null && FieldNode.Attributes["ControlsToMap"].Value != "")
            {
                ControlsToAssign = FieldNode.Attributes["ControlsToAssign"].Value;
                ControlsToMap = FieldNode.Attributes["ControlsToMap"].Value;
            }
        }

        void GetSRDHDetails(string UID, ref DataTable SRDH_DT, ref string ImageString, ref byte[] imagearray)
        {

            if (!string.IsNullOrWhiteSpace(UID))
            {
                string address = null;
                address = m_SRDHLink;
                //address = "http://182.72.59.52:8080/searchsrdh/rest/searchSRDHReq";
                WebRequest request__1 = WebRequest.Create(address) as WebRequest;
                request__1.Method = "POST";
                //request.ContentType = "application/x-www-form-urlencoded";
                request__1.ContentType = "application/xml";
                StringBuilder data = new StringBuilder();
                string Token = null;
                Token = m_SRDHToken;
                data.Append("<searchSRDHReq><sourceType>gazetteer</sourceType><token>" + Token + "</token><building></building><district></district><eid></eid><gender></gender><locality></locality><mobile></mobile><name></name><pincode></pincode><state></state><uid>" + UID + "</uid><vtc></vtc></searchSRDHReq>");
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
                request__1.ContentLength = byteData.Length;
                Stream postStream = request__1.GetRequestStream();
                postStream.Write(byteData, 0, byteData.Length);
                using (WebResponse response__2 = request__1.GetResponse() as WebResponse)
                {
                    StreamReader reader = new StreamReader(response__2.GetResponseStream(), Encoding.UTF8);
                    //Console.WriteLine(reader.ReadToEnd());
                    string result = reader.ReadToEnd();
                    DataSet ds = new DataSet();
                    DataTable dt = default(DataTable);
                    ds.ReadXml(new StringReader(result));
                    try
                    {
                        dt = ds.Tables["enrollmentReports"];
                        SRDH_DT = dt;
                        byte[] arrpicture = new byte[-1 + 1];
                        string photo = "";
                        photo = dt.Rows[0]["photo"].ToString();
                        arrpicture = System.Convert.FromBase64String(photo);
                        imagearray = arrpicture;
                        string base64String = Convert.ToBase64String(arrpicture, 0, arrpicture.Length);
                        ImageString = "";
                        ImageString = base64String;

                        InsertImage(arrpicture);

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

        }

        void InsertImage(byte[] p_ImageContent)
        {
            string t_NewID = "";
            DataTable t_DT = null;
            byte[] t_Image = p_ImageContent;

            SqlCommand t_SQLCmd = new SqlCommand();

            t_SQLCmd.CommandText = "Select NewID()";
            t_DT = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];
            t_NewID = t_DT.Rows[0][0].ToString();

            t_SQLCmd.CommandText = "Insert Into MOLImages(CreatedBy,IPadd,MacID,FormID,TransactionID,ImageCategory,ImageFileName,ImageType,ImageContent,ImageDescription,ImageID) Values(@CreatedBy,@IPadd,@MacID,@FormID,@TransactionID,@ImageCategory,@ImageFileName,@ImageType,@ImageContent,@ImageDescription,@ImageID)";
            t_SQLCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@IPadd", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@MacID", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@FormID", SqlDbType.Int);
            t_SQLCmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@ImageCategory", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@ImageFileName", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@ImageType", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@ImageContent", SqlDbType.Image, t_Image.Length);
            t_SQLCmd.Parameters.Add("@ImageDescription", SqlDbType.NVarChar);
            t_SQLCmd.Parameters.Add("@ImageID", SqlDbType.NVarChar);

            t_SQLCmd.Parameters["@CreatedBy"].Value = HttpContext.Current.Profile.UserName;
            t_SQLCmd.Parameters["@IPadd"].Value = Request.UserHostAddress;
            t_SQLCmd.Parameters["@MacID"].Value = "1";
            t_SQLCmd.Parameters["@FormID"].Value = 1;
            t_SQLCmd.Parameters["@TransactionID"].Value = "1";
            t_SQLCmd.Parameters["@ImageCategory"].Value = "1";
            t_SQLCmd.Parameters["@ImageFileName"].Value = DBNull.Value;
            t_SQLCmd.Parameters["@ImageType"].Value = "image/png";
            t_SQLCmd.Parameters["@ImageContent"].Value = t_Image;
            t_SQLCmd.Parameters["@ImageDescription"].Value = "1";
            t_SQLCmd.Parameters["@ImageID"].Value = t_NewID;
            MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);

            t_SQLCmd.Parameters.Clear();
            t_SQLCmd.CommandText = "Select RowID From MOLImages Where ImageID=@ImageID";
            t_SQLCmd.Parameters.Add("@ImageID", SqlDbType.VarChar).Value = t_NewID;

            t_DT = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtUID.Text == "") return;

            DataTable dt = new DataTable();
            DataTable t_MainTable = DataSource;
            string image = null;
            byte[] Imagearray = null;
            string[] t_ColsAssign = ControlsToAssign.Split(',');
            string[] t_ColsMap = ControlsToMap.Split(',');
            dt = new DataTable();
            image = "";


            GetSRDHDetails(txtUID.Text, ref dt, ref image, ref Imagearray);

            if (dt != null && dt.Rows.Count > 0)
            {

                if (t_MainTable.Rows.Count == 0)
                {
                    DataRow t_Row = t_MainTable.NewRow();
                    t_MainTable.Rows.Add(t_Row);
                }

                for (int i = 0; i < t_ColsAssign.Length; i++)
                {
                    t_MainTable.Rows[0][t_ColsAssign[i]] = dt.Rows[0][t_ColsMap[i]];
                }
                t_MainTable.AcceptChanges();

            }

            if (!string.IsNullOrEmpty(image))
            {
                
            }
        }

    }
}
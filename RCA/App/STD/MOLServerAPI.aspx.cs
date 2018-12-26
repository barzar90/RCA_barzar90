using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using BL;

namespace MSHC.App.STD
{
    public partial class MOLServerAPI : MAHAITValidate
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<MAHAITResponse> GetUID(string UID)
        {
            List<MAHAITResponse> t_Response = new List<MAHAITResponse>();

            LoadProfile(HttpContext.Current.Server.MapPath("..\\..\\App_Data\\" + HttpContext.Current.Profile.UserName));
            DataTable dt = new DataTable();
            string t_ImageID = "";

            string image = null;
            byte[] Imagearray = null;

            dt = new DataTable();
            image = "";
            string t_UID = UID;

            t_ImageID = MOLServerAPI.GetSRDHDetails(t_UID, ref dt, ref image, ref Imagearray);

            if (dt != null)
            {
                MAHAITResponse t_HasUID = new MAHAITResponse();

                t_HasUID.Action = "HASUID";
                t_HasUID.FieldName = "UID";
                t_HasUID.Message = UID;

                MAHAITDBAccess.ValidationResponse.Add(t_HasUID);


                try
                {
                    MAHAITDBAccess.AssignValue("TEST", "TEST", "UIDTEST");
                    MAHAITDBAccess.AssignValue("UID", "UID", UID);
                    MAHAITDBAccess.AssignValue("UID", "FullName", dt.Rows[0]["Name"].ToString());
                    MAHAITDBAccess.AssignValue("UID", "FullName_LL", dt.Rows[0]["NameMr"].ToString());
                    MAHAITDBAccess.AssignValue("UID", "DOB", dt.Rows[0]["DOB"].ToString());
                    MAHAITDBAccess.AssignValue("UID", "Mobile", dt.Rows[0]["Mobile"].ToString());
                    MAHAITDBAccess.AssignValue("UID", "Gender", dt.Rows[0]["Gender"].ToString());
                    MAHAITDBAccess.AssignValue("UID", "Pincode", dt.Rows[0]["addrPinCode"].ToString());
                    if (MAHAITDBAccess.LangID == "2")
                    {
                        MAHAITDBAccess.AssignValue("UID", "Street", dt.Rows[0]["AddrStreetMr"].ToString());
                        MAHAITDBAccess.AssignValue("UID", "Building", dt.Rows[0]["AddrBuildingMr"].ToString());
                        MAHAITDBAccess.AssignValue("UID", "Landmark", dt.Rows[0]["AddrLandmarkMr"].ToString());
                        MAHAITDBAccess.AssignValue("UID", "Locality", dt.Rows[0]["AddrLocalityMr"].ToString());

                    }
                    else
                    {
                        MAHAITDBAccess.AssignValue("UID", "Street", dt.Rows[0]["AddrStreet"].ToString());
                        MAHAITDBAccess.AssignValue("UID", "Building", dt.Rows[0]["AddrBuilding"].ToString());
                        MAHAITDBAccess.AssignValue("UID", "Landmark", dt.Rows[0]["AddrLandmark"].ToString());
                        MAHAITDBAccess.AssignValue("UID", "Locality", dt.Rows[0]["AddrLocality"].ToString());

                    }

                    if (t_ImageID != "")
                    {
                        MAHAITDBAccess.AssignValue("UID", "IMG", t_ImageID);
                    }

                }
                catch (Exception E)
                {
                    MAHAITDBAccess.SendException(MAHAITDBAccess.GetResourceValue("General", "DNA_MSG", "Data Not Available"));
                }
            }
            else
            {
                MAHAITDBAccess.SendException(MAHAITDBAccess.GetResourceValue("General", "DNA_MSG", "Data Not Available"));
            }

            return MAHAITDBAccess.ValidationResponse;


        }


        protected static string GetSRDHDetails(string UID, ref DataTable SRDH_DT, ref string ImageString, ref byte[] imagearray)
        {
            string m_SRDHLink = "";
            string m_SRDHToken = "";
            m_SRDHLink = "http://srdh.maharashtra.gov.in/searchsrdh/rest/searchSRDHReq";
            m_SRDHToken = "Z2F6ZXR0ZWVyX01haGFyYXNodHJh";
            string t_ImageID="";

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

                        t_ImageID = InsertImage(arrpicture);

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return t_ImageID;
        }


        protected static string InsertImage(byte[] p_ImageContent)
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
            t_SQLCmd.Parameters["@IPadd"].Value = "";
            t_SQLCmd.Parameters["@MacID"].Value = "1";
            t_SQLCmd.Parameters["@FormID"].Value = 1;
            t_SQLCmd.Parameters["@TransactionID"].Value = "1";
            t_SQLCmd.Parameters["@ImageCategory"].Value = "1";
            t_SQLCmd.Parameters["@ImageFileName"].Value = "";
            t_SQLCmd.Parameters["@ImageType"].Value = "image/png";
            t_SQLCmd.Parameters["@ImageContent"].Value = t_Image;
            t_SQLCmd.Parameters["@ImageDescription"].Value = "1";
            t_SQLCmd.Parameters["@ImageID"].Value = t_NewID;

            MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);

            t_SQLCmd.Parameters.Clear();
            t_SQLCmd.CommandText = "Select RowID From MOLImages Where ImageID=@ImageID";
            t_SQLCmd.Parameters.Add("@ImageID", SqlDbType.VarChar).Value = t_NewID;

            t_DT = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_NewID;
        }
    }
}
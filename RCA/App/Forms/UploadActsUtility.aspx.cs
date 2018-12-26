using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.Cryptography;



namespace MSHC.App.Forms
{
    public partial class UploadActsUtility : System.Web.UI.Page
    {

        #region Variable Declaration

        public BL.BL MAHAITDBAccess;
        SqlCommand t_SQLCmd = null;
        CommonFuntion _ObjFunction;
        DataSet ds;
      
        int currentpage = 0;
        int count = 0;
        int pg = 0;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                CurrentPageIndex = 0;
                clear();
                Viewacts();
            }
        }


        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
        [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
        [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
        System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
        System.UInt32 dwMimeFlags,
        out System.UInt32 ppwzMimeOut,
        System.UInt32 dwReserverd);  

        protected void btnsave_Click(object sender, EventArgs e)
        {

            if (FU1.HasFile)
            {

                string filename = Path.GetFileName(FU1.FileName);
                string fileExtension = Path.GetExtension(filename).ToLower();
                HttpPostedFile file = FU1.PostedFile;
                byte[] document = new byte[file.ContentLength];
                file.InputStream.Read(document, 0, file.ContentLength);
                System.UInt32 mimetype;
                FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                string mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);

                if (mime == "application/pdf")
                {
                    if (fileExtension.Equals(".pdf") || fileExtension.Equals(".docx") || fileExtension.Equals(".xlsx"))
                    {
                        if (FU1.PostedFile.ContentLength < 5242880)
                        {
                            try
                            {

                                // now save the file to the disk
                                SqlCommand t_SQLCmd = new SqlCommand();
                                SqlParameter[] param = new SqlParameter[8];
                                string Path1 = Server.MapPath("~/Site/Upload/Acts/");
                                param[0] = new SqlParameter("@ActNo", SqlDbType.NVarChar);
                                param[0].Value = txtact.Text != string.Empty ? txtact.Text : string.Empty;//Convert.ToInt32(txtact.Text);
                                param[1] = new SqlParameter("@Actyear", SqlDbType.NVarChar);
                                param[1].Value = txtactyear.Text;
                                param[2] = new SqlParameter("@Publishdate", SqlDbType.Date);
                                param[2].Value = txtpublishdate.Text != string.Empty ? Convert.ToDateTime(txtpublishdate.Text) : (object)DBNull.Value;
                                param[3] = new SqlParameter("@ShortTitle", SqlDbType.NVarChar);
                                param[3].Value = txtacttittle.Text;
                                param[4] = new SqlParameter("@PdfName", SqlDbType.NVarChar);
                                param[4].Value = Convert.ToString(FU1.FileName);
                                param[5] = new SqlParameter("@Path", SqlDbType.NVarChar);
                                param[5].Value = Convert.ToString("~/Site/Upload/Acts/" + FU1.FileName);
                                param[6] = new SqlParameter("@FileSize", SqlDbType.Decimal);
                                param[6].Value = Math.Round(((decimal)FU1.PostedFile.ContentLength / (decimal)1024), 2);
                                param[7] = new SqlParameter("@Createdby", SqlDbType.NVarChar);
                                param[7].Value = Convert.ToString(Session["User"]);

                                foreach (SqlParameter parameter in param)
                                {
                                    t_SQLCmd.Parameters.Add(parameter);
                                }
                                Dictionary<string, object> Outputparam = new Dictionary<string, object>();
                                t_SQLCmd.CommandText = "Insert_Actsuploadutility";
                                t_SQLCmd.CommandType = CommandType.StoredProcedure;
                                t_SQLCmd.CommandTimeout = 5000;
                                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                                int k = MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);

                                if (k > 0)
                                {
                                    FU1.SaveAs(Path1 + FU1.FileName);

                                    lblMessage.Text += "File : <b>" + FU1.FileName + "</b> uploaded successfully !<br />";
                                    clear();
                                    Viewacts();
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Acts Saved  Successfully');", true);

                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Acts Failed to Saved');", true);
                                   
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                MAHAITDBAccess = null;
                                t_SQLCmd = null;
                            }
                        }

                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Please Upload File Under  5 MB ');", true);

                        }
                    }
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File is InValid');", true);
                }


            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Please Upload File');", true);
            }


        }



        private void Viewacts()
        {

            try
            {
                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                t_SQLCmd = new SqlCommand();
                ds = new DataSet();
                t_SQLCmd.CommandText = "View_Acts";
                t_SQLCmd.CommandType = CommandType.StoredProcedure;
                t_SQLCmd.CommandTimeout = 500;
                ds = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = ds.Tables[0].DefaultView;
                pds.AllowPaging = true;
                pds.PageSize = 10;
                pds.CurrentPageIndex = CurrentPageIndex;

                btnnext.Enabled = !(pds.IsLastPage);
                btnprev.Enabled = !(pds.IsFirstPage);
                DataList1.DataSource = pds;
                DataList1.DataBind();
            }

            catch (Exception ex)
            {

            }

            finally
            {
                MAHAITDBAccess = null;
                t_SQLCmd = null;

            }

        }

        public int CurrentPageIndex
        {
            get
            {
                if (ViewState["pg"] == null)
                    return 0;
                else
                    return Convert.ToInt16(ViewState["pg"]);
            }
            set
            {
                ViewState["pg"] = value;
            }
        } 


        protected void DataList1_EditCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                
                DataList1.EditItemIndex = e.Item.ItemIndex;
                Viewacts();
            }
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = DataList1.Items[e.Item.ItemIndex].FindControl("lblid") as Label;

            if (e.CommandName == "Delete")
            {
                try
                {

                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                    
                    SqlCommand t_SQLCmd = new SqlCommand();
                    t_SQLCmd.Parameters.Add("@Id", SqlDbType.Int);
                    t_SQLCmd.Parameters["@Id"].Value = lbl.Text;

                    string query = @"Update  tblUploadActs set IsActive=0 where id=@Id";

                    t_SQLCmd.CommandText = query;
                    if (MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd) != 0)
                    {
                        DataList1.EditItemIndex = -1;
                        Viewacts();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data delete Successfully !!!')", true);
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('error!!!')", true);

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                Label lblpdf = DataList1.Items[e.Item.ItemIndex].FindControl("lblpdf") as Label;
                FileUpload fileUploadReply = (FileUpload)e.Item.FindControl("FileUpdate");
                if ((fileUploadReply.HasFile))
                {
                    string filename = Path.GetFileName(fileUploadReply.FileName);
                    string fileExtension = Path.GetExtension(filename).ToLower();
                    if (fileExtension.Equals(".pdf") || fileExtension.Equals(".docx") || fileExtension.Equals(".xlsx"))
                    {

                        if (fileUploadReply.PostedFile.ContentLength < 5242880)
                        {
                            try
                            {

                                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                                Label lbl = DataList1.Items[e.Item.ItemIndex].FindControl("lblid") as Label;
                                //Label lbl_actno = DataList1.Items[e.Item.ItemIndex].FindControl("lblactno") as Label;
                                TextBox txteactno =DataList1.Items[e.Item.ItemIndex].FindControl("txteactno") as TextBox;
                                TextBox txteactyear = DataList1.Items[e.Item.ItemIndex].FindControl("txteactyear") as TextBox;
                                TextBox txteshorttitle = DataList1.Items[e.Item.ItemIndex].FindControl("txteshortitle") as TextBox;
                                //Label lbl_actyear = DataList1.Items[e.Item.ItemIndex].FindControl("lblactyear") as Label;
                                Label lbl_publishdate = DataList1.Items[e.Item.ItemIndex].FindControl("lblpublishdate") as Label;
                                //Label lbl_shorttitle = DataList1.Items[e.Item.ItemIndex].FindControl("lblshorttitle") as Label;
                          

                                SqlCommand t_SQLCmd = new SqlCommand();
                                t_SQLCmd.Parameters.Add("@path", SqlDbType.NVarChar);
                                t_SQLCmd.Parameters["@path"].Value = Convert.ToString("~/Site/Upload/Acts/" + fileUploadReply.FileName);
                                t_SQLCmd.Parameters.Add("@ActNo", SqlDbType.NVarChar);
                                t_SQLCmd.Parameters["@ActNo"].Value = txteactno.Text != string.Empty ? txteactno.Text : string.Empty; //lbl_actno.Text; txteactno.Text != string.Empty ? txteactno.Text : string.Empty;
                                t_SQLCmd.Parameters.Add("@Actyear", SqlDbType.NVarChar);
                                t_SQLCmd.Parameters["@Actyear"].Value = txteactyear.Text;//lbl_actyear.Text;
                             
                                t_SQLCmd.Parameters.Add("@ShortTitle", SqlDbType.NVarChar);
                                t_SQLCmd.Parameters["@ShortTitle"].Value = txteshorttitle.Text;//lbl_shorttitle.Text;
                                t_SQLCmd.Parameters.Add("@PdfName", SqlDbType.NVarChar);
                                t_SQLCmd.Parameters["@PdfName"].Value = fileUploadReply.FileName;
                                t_SQLCmd.Parameters.Add("@FileSize", SqlDbType.NVarChar);
                                t_SQLCmd.Parameters["@FileSize"].Value = Math.Round(((decimal)fileUploadReply.PostedFile.ContentLength / (decimal)1024), 2);
                                t_SQLCmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar);
                                t_SQLCmd.Parameters["@UpdatedBy"].Value = Convert.ToString(Session["User"]); 
                                t_SQLCmd.Parameters.Add("@Id", SqlDbType.BigInt);
                                t_SQLCmd.Parameters["@Id"].Value = Convert.ToInt32(lbl.Text);
                                t_SQLCmd.CommandText = "Insert_Actsuploadutility";
                                t_SQLCmd.CommandType = CommandType.StoredProcedure;
                                t_SQLCmd.CommandTimeout = 5000;
                                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                                if (MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd) != 0)
                                {
                                    
                                    fileUploadReply.SaveAs(Server.MapPath("~/Site/Upload/Acts/") + filename);
                                    DataList1.EditItemIndex=-1;
                                    Viewacts();
                                    //lblSavede.Text = "Acts Updated  Successfully";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Acts Updated  Successfully !!!')", true);
                                }
                                else
                                {
                                    
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Failed To Updated !!!')", true);
                                    //lblSavede.Text = "Failed To Updated";
                                }

                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                            finally
                            {
                                MAHAITDBAccess = null;
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Please Upload File Under  5 MB ');", true);
                        }

                    }

                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File is InValid');", true);
                    }

                }

                else 
                {
                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                    Label lbl = DataList1.Items[e.Item.ItemIndex].FindControl("lblid") as Label;
                    //Label lbl_actno = DataList1.Items[e.Item.ItemIndex].FindControl("lblactno") as Label;
                    TextBox txteactno = DataList1.Items[e.Item.ItemIndex].FindControl("txteactno") as TextBox;
                    TextBox txteactyear = DataList1.Items[e.Item.ItemIndex].FindControl("txteactyear") as TextBox;
                    TextBox txteshorttitle = DataList1.Items[e.Item.ItemIndex].FindControl("txteshortitle") as TextBox;
                    //Label lbl_actyear = DataList1.Items[e.Item.ItemIndex].FindControl("lblactyear") as Label;
                    Label lbl_publishdate = DataList1.Items[e.Item.ItemIndex].FindControl("lblpublishdate") as Label;
                    //Label lbl_shorttitle = DataList1.Items[e.Item.ItemIndex].FindControl("lblshorttitle") as Label;


                    SqlCommand t_SQLCmd = new SqlCommand();
                    t_SQLCmd.Parameters.Add("@path", SqlDbType.NVarChar);
                    t_SQLCmd.Parameters["@path"].Value = string.Empty;
                    t_SQLCmd.Parameters.Add("@ActNo", SqlDbType.NVarChar);
                    t_SQLCmd.Parameters["@ActNo"].Value = txteactno.Text != string.Empty ? txteactno.Text : string.Empty;// lbl_actno.Text;
                    t_SQLCmd.Parameters.Add("@Actyear", SqlDbType.NVarChar);
                    t_SQLCmd.Parameters["@Actyear"].Value = txteactyear.Text;//lbl_actyear.Text;

                    t_SQLCmd.Parameters.Add("@ShortTitle", SqlDbType.NVarChar);
                    t_SQLCmd.Parameters["@ShortTitle"].Value = txteshorttitle.Text;//lbl_shorttitle.Text;
                    t_SQLCmd.Parameters.Add("@PdfName", SqlDbType.NVarChar);
                    t_SQLCmd.Parameters["@PdfName"].Value = string.Empty;
                    t_SQLCmd.Parameters.Add("@FileSize", SqlDbType.NVarChar);
                    t_SQLCmd.Parameters["@FileSize"].Value ="0";
                    t_SQLCmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar);
                    t_SQLCmd.Parameters["@UpdatedBy"].Value =Convert.ToString(Session["User"]);
                    t_SQLCmd.Parameters.Add("@Id", SqlDbType.BigInt);
                    t_SQLCmd.Parameters["@Id"].Value = Convert.ToInt32(lbl.Text);
                    t_SQLCmd.CommandText = "Insert_Actsuploadutility";
                    t_SQLCmd.CommandType = CommandType.StoredProcedure;
                    t_SQLCmd.CommandTimeout = 5000;
                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                    if (MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd) != 0)
                    {
                        DataList1.EditItemIndex=-1;
                        Viewacts();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Acts Updated  Successfully !!!')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Failed To Updated !!!')", true);
                    }

                }
            }
        }

        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                DataList1.EditItemIndex = -1;
                Viewacts();
            }
        }


        private void clear()
        {
            txtact.Text = string.Empty;
            txtacttittle.Text = string.Empty;
            txtactyear.Text = string.Empty;
            txtpublishdate.Text = string.Empty;
            lblMessage.Text = string.Empty;
            //lblSavede.Text = string.Empty;
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            CurrentPageIndex++;
            Viewacts();

        }

        protected void btnprev_Click(object sender, EventArgs e)
        {          
            CurrentPageIndex--;
            Viewacts();       
        }



    }
}
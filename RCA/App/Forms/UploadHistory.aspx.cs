using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using BL;

namespace MSHC.App.Forms
{
    public partial class UploadHistory : MAHAITPage
    {       
            SqlConnection con = new SqlConnection("Password=maha@123;Persist Security Info=True;User ID=dbdeveloper;Initial Catalog=MOl_SGNP;Data Source=172.16.0.30");
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    bindData();
                }
            }

            public void bindData()
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getHistory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.ExecuteNonQuery();



                con.Close();
                try
                {
                    if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        grdHistory.DataSource = ds;
                        grdHistory.DataBind();
                    }
                    else
                    {
                        grdHistory.DataSource = null;
                        grdHistory.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            public void clear()
            {
                txtYear.Text = string.Empty;
                txtDescription.Text = string.Empty;
                FileUploadImage.Attributes.Clear();
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                string fileName = string.Empty;
                string filePath = string.Empty;
                FileStream fs;
                BinaryReader br;
                try
                {
                    if (txtYear.Text == "")
                    {
                        Response.Write("<script alanguage = 'JavaScript'> alert('Please Enter Year')</script>");
                        txtYear.Focus();
                    }
                    else if (txtDescription.Text == "")
                    {
                        Response.Write("<script Language = 'JavaScript'> alert('Please Enter Description')</script>");
                        txtDescription.Focus();
                    }
                    else if (FileUploadImage.HasFile)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_IsExistYearOfHistory", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@YearOFHistory", txtYear.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet Ds = new DataSet();
                        da.Fill(Ds);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        if (Ds != null && Ds.Tables[0].Rows.Count > 0)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Year Already Exist. Try Another Year');", true);
                        }
                        else
                        {
                            int fileLen;
                            fileLen = FileUploadImage.PostedFile.ContentLength;
                            byte[] bytes = FileUploadImage.FileBytes;

                            if (CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Image, ".jpg") || CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Image, ".jpeg") || CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Image, ".png"))
                            {
                                String ext = FileUploadImage.FileName;
                                String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                                if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                                {
                                    string Filepath = Server.MapPath("../../Site/Upload/GR/") + FileUploadImage.FileName;
                                    FileUploadImage.SaveAs(Filepath);

                                    con.Open();
                                    SqlCommand sqlComm = new SqlCommand("sp_SetHistory", con);
                                    sqlComm.CommandType = CommandType.StoredProcedure;

                                    sqlComm.Parameters.AddWithValue("@year", txtYear.Text.Trim());
                                    sqlComm.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                                    sqlComm.Parameters.AddWithValue("@ImageContent", bytes);
                                    sqlComm.Parameters.AddWithValue("@ImageName", FileUploadImage.FileName.Trim());
                                    sqlComm.Parameters.AddWithValue("@ImageType", Path.GetExtension(FileUploadImage.FileName));
                                    sqlComm.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                                    sqlComm.Parameters.AddWithValue("@CreatedBy", "Admin");
                                    //sqlComm.Parameters.AddWithValue("@ModifiedOn", "");
                                    //sqlComm.Parameters.AddWithValue("@ModifiedBy", "");
                                    sqlComm.Parameters.AddWithValue("@IsActive", "1");

                                    int i = sqlComm.ExecuteNonQuery();
                                    if (i != 0)
                                    {
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Record Saved Successfully');", true);
                                    }
                                    else
                                    {
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Record not Saved. Try Again');", true);
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Enter a valid file');", true);
                                    //Lblmessage.Visible = true;
                                    //Lblmessage.Text = "PDF file is in wrong format";
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.ToString();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", s + "alert('Record not Saved. Try Again');", true);
                }
                finally
                {
                    con.Close();
                    //cmd.Dispose();
                    fileName = null;
                    filePath = null;
                    fs = null;
                    br = null;
                    clear();
                    bindData();
                }
            }

            protected void btnCancel_Click(object sender, EventArgs e)
            {
                clear();
            } 
        
            protected void grdHistory_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                try
                {   
                    if (e.CommandName == "delete")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_DeleteHistory", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SrNo", e.CommandArgument.ToString());
                        
                        int count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Deleted Successfully');", true);
                        }
                        else 
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not Deleted. Try Again');", true);
                        }
                    }
                    if (e.CommandName == "Update")
                    {
                        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                        FileUpload ImageContent = (FileUpload)row.FindControl("EditImageContent");
                        Label SrNo = row.FindControl("lblSrNo") as Label;
                        Label FileName = row.FindControl("ImageFileName") as Label;
                        Label Extention = row.FindControl("ImageFileType") as Label;
                        TextBox YearOfHistory = (TextBox)row.FindControl("EditYearOfHistory");
                        TextBox Details = (TextBox)row.FindControl("EditDetails");

                        byte[] bytes = ImageContent.FileBytes;

                        int fileLen;
                        fileLen = FileUploadImage.PostedFile.ContentLength;

                        if (CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Image, ".jpg") || CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Image, ".jpeg") || CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Image, ".png"))
                        {
                            String ext = FileUploadImage.FileName;
                            String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                            if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand("sp_UpdateHistory", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SrNo", Convert.ToInt32(SrNo.Text.Trim()));
                                cmd.Parameters.AddWithValue("@YearOfHistory", Convert.ToInt32(YearOfHistory.Text.Trim()));
                                cmd.Parameters.AddWithValue("@Details", Convert.ToString(Details.Text.Trim()));
                                cmd.Parameters.AddWithValue("@ImageContent", bytes);
                                cmd.Parameters.AddWithValue("@ImageFileName", ImageContent.FileName);
                                cmd.Parameters.AddWithValue("@ImageFileType", Path.GetExtension(ImageContent.FileName));
                                cmd.Parameters.AddWithValue("@ModifiedOn", DateTime.Now);
                                cmd.Parameters.AddWithValue("@ModifiedBy", "Admin");
                                cmd.Parameters.AddWithValue("@IsActive", "1");

                                int count = cmd.ExecuteNonQuery();

                                if (count > 0)
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Record Edited Successfully')", true);
                                }
                                else
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Record not Edited. Try Again')", true);
                                }

                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Enter a valid file');", true);
                                return;
                            }
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Enter a valid file');", true);
                            return;
                        }
                    }
                    if (e.CommandName == "Edit")
                    {
                        //GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                        //Image ImageContent = (Image)grdHistory.FindControl("ImageContent");
                        //getImage();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally 
                {
                    con.Close();
                    //Image1.ImageUrl = "";
                }
            }

            protected void grdHistory_RowEditing(object sender, GridViewEditEventArgs e)
            {               
                grdHistory.EditIndex = e.NewEditIndex;
                bindData();
            }

            protected void grdHistory_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {                
                grdHistory.EditIndex = -1;
                bindData();
            }            

            protected void grdHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
                grdHistory.EditIndex = -1;
                bindData();
                //Image1.ImageUrl = "";
            }
           
            protected void grdHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                grdHistory.EditIndex = -1;
                bindData();
            }

            public string GetImage(object img)
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }

        }    
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace RCA.App.Forms
{
    public partial class UploadImages : System.Web.UI.Page
    {

        SqlCommand cmd;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString());
        string[] validfiletypes = { "jpg", "jpeg", "img", "png" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBlank())
                {
                    SaveUpdate();
                }
            }
            catch (Exception ex)
            {
                this.Title = "Error: " + ex.Message;

            }
        }

        private bool checkBlank()
        {
            bool flag = false;
            string msg = string.Empty;

            if (!fileImgUpload.HasFile)
            {
                Showmsg("Please upload Image File");
                flag = false;
            }
            else
            {
                string extension = System.IO.Path.GetExtension(fileImgUpload.PostedFile.FileName);
                for (int i = 0; i < validfiletypes.Length; i++)
                {
                    if (extension == "." + validfiletypes[i])
                    {
                        flag = true;
                        break;

                    }

                }
                if (!flag)
                {
                    Showmsg("Please Insert Valid Image File");
                }
            }

            return flag;
        }

        private void SaveUpdate()
        {
            try
            {
                using (cmd = new SqlCommand("Images_Upload_SMM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (btnSubmit.Text.Equals("Submit"))
                    {
                        cmd.Parameters.AddWithValue("@Para", "ADD");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Para", "Update");
                        cmd.Parameters.AddWithValue("@Id", int.Parse(gdEditDeelteImages.Rows[gdEditDeelteImages.SelectedIndex].Cells[0].Text));

                    }
                    string FileName = UploadImage();
                    if (fileImgUpload.HasFile)
                    {
                        cmd.Parameters.AddWithValue("@ImgPath", FileName);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ImgPath", hdnImages.Value);
                    }
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@NameMr", txtMarathi.Text);
                    cmd.Parameters.AddWithValue("@AddedUpdatedBy", "admin");
                    if (con.State.Equals(ConnectionState.Closed))
                        con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (btnSubmit.Text.Equals("Submit"))
                    {
                        Showmsg("Record added successfully");
                    }
                    else
                    {
                        Showmsg("Record updated successfully");
                    }
                    Reset();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Showmsg(string Message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('" + Message + "');", true);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtMarathi.Text = "";
            txtName.Text = "";
            btnSubmit.Text = "Submit";
        }

        public string UploadImage()
        {
            string result = string.Empty;
            if (fileImgUpload.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fileImgUpload.PostedFile.FileName);
                for (int i = 0; i < validfiletypes.Length; i++)
                {
                    if (extension == "." + validfiletypes[i])
                    {
                        result = fileImgUpload.PostedFile.FileName;
                        fileImgUpload.PostedFile.SaveAs(MapPath("~") + "/Site/Upload/Images/" + result);
                    }
                }
            }
            return result;
        }

        protected void gdEditDeelteImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int Id = int.Parse(gdEditDeelteImages.Rows[e.RowIndex].Cells[0].Text);
                using (SqlCommand cmd = new SqlCommand("Images_Upload_SMM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Delete");
                    cmd.Parameters.AddWithValue("@AddedUpdatedBy", "admin");
                    cmd.Parameters.AddWithValue("@Id", Id);
                    if (con.State.Equals(ConnectionState.Closed))
                        con.Open();
                    cmd.ExecuteNonQuery();
                    Showmsg("Record deleted successfully.");
                    BindGrid();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void gdEditDeelteImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdEditDeelteImages.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gdEditDeelteImages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gdEditDeelteImages_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int id = int.Parse(gdEditDeelteImages.Rows[e.NewSelectedIndex].Cells[0].Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Images_Upload_SMM 'Get_By_Id'," + id, con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                hdnImages.Value = dt.Rows[0]["ImgPath"].ToString();
                txtMarathi.Text = dt.Rows[0]["NameMr"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                btnReset.Visible = true;
                btnSubmit.Text = "Update";
            }
        }
        private void BindGrid()
        {
            try
            {
                using (cmd = new SqlCommand("Images_Upload_SMM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "SELECT_FOR_GRID");
                    if (con.State.Equals(ConnectionState.Closed))
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gdEditDeelteImages.Columns[0].Visible = true;
                    gdEditDeelteImages.DataSource = dt;
                    gdEditDeelteImages.DataBind();
                    gdEditDeelteImages.Columns[0].Visible = false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BL;

namespace MSHC.App.Forms
{
    public partial class MarqueeDataActiveOrNot : MAHAITPage
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["APPID"].ToString());
        SqlCommand cmd;
        DataSet ds;
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindMarquee();
        }

        public void BindMarquee()
        {
            try
            {
                using (cmd = new SqlCommand("MarqueeActiveOrNot", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Select_For_Marquee");
                    if (con.State.Equals(ConnectionState.Closed))
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        grdupload.DataSource = dt;
                        grdupload.DataBind();
                    }
                    else
                    {
                        ShowMessage("No Data Found");

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }

        }


        private void ShowMessage(string msg)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('" + msg + "');", true);
        }

        protected void grdupload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdupload.PageIndex = e.NewPageIndex;
            BindMarquee();
        }

        protected void grdupload_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdupload.EditIndex = e.NewEditIndex;
            BindMarquee();


            HiddenField HD = new HiddenField();
            HD = (HiddenField)grdupload.Rows[grdupload.EditIndex].FindControl("HD_DocumentID");

        }

        protected void grdupload_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            CheckBox chk = (CheckBox)grdupload.Rows[e.RowIndex].FindControl("ChkView");

            string id = grdupload.DataKeys[e.RowIndex].Value.ToString(); //Int32.Parse(grdupload.DataKeys[e.RowIndex].Value.ToString());

            HiddenField type = new HiddenField();
            type = (HiddenField)grdupload.Rows[grdupload.EditIndex].FindControl("HD_TYPE");

            string type1 = type.Value;

            changeActiveStatus(id, chk, type1);

        }

        protected void grdupload_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdupload.EditIndex = -1;
            BindMarquee();
        }

        protected void ChkView_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            int rowIndex = row.RowIndex;
            string id = grdupload.DataKeys[row.RowIndex].Value.ToString();
            CheckBox check = (CheckBox)grdupload.Rows[row.RowIndex].FindControl("chkView");
            HiddenField type = new HiddenField();
            type = (HiddenField)grdupload.Rows[row.RowIndex].FindControl("HD_TYPE");
            string type1 = Convert.ToString(type.Value);
            changeActiveStatus(id, check, type1);

        }

        public void changeActiveStatus(string id, CheckBox status, string type)
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.Text;
            if (type == "document")
                cmd1.CommandText = "Update Documents set IsActive=@IsActive where DocumentID=@DocumentID ";
            else if (type.ToString() == "letter")
                cmd1.CommandText = "Update UploadLetters set IsActive=@IsActive where DocumentID=@DocumentID ";
            if (status.Checked == true)
                cmd1.Parameters.AddWithValue("@IsActive", 1);
            else
                cmd1.Parameters.AddWithValue("@IsActive", 0);
            cmd1.Parameters.AddWithValue("@DocumentID", id);

            int retnval = MAHAITDBAccess.ExecuteNonQuery(cmd1);
            if (retnval > 0)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Update Successfully')", true);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Update Successfully')", true);
            }
            else
            {

            }
            grdupload.EditIndex = -1;
            BindMarquee();
        }



    }
}
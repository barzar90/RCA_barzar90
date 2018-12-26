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
using Schema;

namespace MSHC.App.Forms
{
    public partial class CreateDocType : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        CreateEnumerationBL objCreateEnumerationBL;
        EnumerationSchema objEnumerationSchema;
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                ClearCntrol();
            }

            if (Request.QueryString["Mode"].ToString() == "1")
                tr0.Visible = false;
            else
                tr0.Visible = true;
            if (IsPostBack)
                if (tr0.Visible == true && DDLEnumeration.SelectedIndex > 0)
                    BindGrid(DDLEnumeration.SelectedValue);
            if (tr0.Visible == false)
                GetEnumeration();
        }

        protected void grdupload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                HdValue.Value = e.CommandArgument.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select EnumerationValueID,EnumerationValue,EnumerationValue_LL,SortOrder,IsActive,parent_EnumerationValueID from EnumerationValue where EnumerationValueID=@EnumerationValueID ";
                cmd.Parameters.AddWithValue("@EnumerationValueID ", HdValue.Value.ToString());
                dt = new DataTable();
                dt = null;
                dt = MAHAITDBAccess.ExecuteDataSet(cmd).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_DocTypNm.Text = dt.Rows[0]["EnumerationValue"].ToString();
                    txt_DocTypNmLL.Text = dt.Rows[0]["EnumerationValue_LL"].ToString();
                    txt_SeqNo.Text = dt.Rows[0]["SortOrder"].ToString();
                    chk_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    if (tr0.Visible == true)
                        DDLEnumeration.SelectedValue = dt.Rows[0]["parent_EnumerationValueID"].ToString();
                }

            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (HdValue.Value != "0")
                UpdateDB();
            else
                SaveToDB();

            if (tr0.Visible == true && DDLEnumeration.SelectedIndex > 0)
                BindGrid(DDLEnumeration.SelectedValue);
            if (tr0.Visible == false)
                GetEnumeration();
        }

        private void SaveToDB()
        {
            objEnumerationSchema = new EnumerationSchema();
            objCreateEnumerationBL = new CreateEnumerationBL();
            objEnumerationSchema.EnumerationValue = txt_DocTypNm.Text.Trim().ToString();
            objEnumerationSchema.EnumationValue_LL = txt_DocTypNmLL.Text.Trim().ToString();
            objEnumerationSchema.SortOrder = Convert.ToInt32(txt_SeqNo.Text);
            objEnumerationSchema.Isactive = chk_IsActive.Checked;
            objEnumerationSchema.Parent_EnumerationValueID = tr0.Visible == true ? DDLEnumeration.SelectedValue.ToString() : "0";
            int retnVal = objCreateEnumerationBL.InsertEnumeration(objEnumerationSchema);
            if (retnVal > 0)
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Save SucessFully');", true);
            else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Record Not Saved');", true);
            ClearCntrol();
        }

        private void UpdateDB()
        {
            dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE EnumerationValue SET EnumerationValue=@EnumerationValue,EnumerationValue_LL=@EnumerationValue_LL,SortOrder=@SortOrder,IsActive=@IsActive Where EnumerationValueID=@EnumerationValueID";
            cmd.Parameters.AddWithValue("@EnumerationValue", txt_DocTypNm.Text);
            cmd.Parameters.AddWithValue("@EnumerationValue_LL", txt_DocTypNmLL.Text);
            cmd.Parameters.AddWithValue("@SortOrder", txt_SeqNo.Text);
            cmd.Parameters.AddWithValue("@IsActive", chk_IsActive.Checked);
            cmd.Parameters.AddWithValue("@EnumerationValueID", HdValue.Value);
            int retnVal = MAHAITDBAccess.ExecuteNonQuery(cmd);
            if (retnVal > 0)
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Update  SucessFully');", true);
            else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Record Not Updated');", true);
            ClearCntrol();
            HdValue.Value = "0";
        }


        private void BindDDL()
        {
            dt = new DataTable();
            objCreateEnumerationBL = new CreateEnumerationBL();
            try
            {
                dt = objCreateEnumerationBL.GetEnumeration().Tables[0];
                DDLEnumeration.DataSource = dt;
                DDLEnumeration.DataTextField = "EnumerationValue";
                DDLEnumeration.DataValueField = "EnumerationValueID";
                DDLEnumeration.DataBind();
                DDLEnumeration.Items.Insert(0, "Please Select");
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void BindGrid(string EnumerationID)
        {
            dt = new DataTable();
            objCreateEnumerationBL = new CreateEnumerationBL();
            try
            {
                dt = new DataTable();
                dt = null;
                dt = objCreateEnumerationBL.GetEnumerationValues(EnumerationID.ToUpper()).Tables[0];
                grdupload.DataSource = dt;
                grdupload.DataBind();
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void GetEnumeration()
        {
            dt = new DataTable();
            objCreateEnumerationBL = new CreateEnumerationBL();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select ROW_NUMBER() over(order by EnumerationValueID)as ID,EnumerationValueID,EnumerationValue,EnumerationValue_LL,SortOrder,IsActive from EnumerationValue where parent_EnumerationValueID Is NULL";
                dt = new DataTable();
                dt = null;
                dt = MAHAITDBAccess.ExecuteDataSet(cmd).Tables[0];
                grdupload.DataSource = dt;
                grdupload.DataBind();
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void ClearCntrol()
        {
            txt_DocTypNm.Text = "";
            txt_DocTypNmLL.Text = "";
            txt_SeqNo.Text = "";
            chk_IsActive.Checked = false;
        }

        protected void DDLEnumeration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLEnumeration.SelectedValue != "Please Select")
            {
                BindGrid(DDLEnumeration.SelectedValue.ToUpper());
            }
        }

        protected void grdupload_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (tr0.Visible == true && DDLEnumeration.SelectedIndex > 0)
                BindGrid(DDLEnumeration.SelectedValue);
            if (tr0.Visible == false)
                GetEnumeration();
        }

        protected void grdupload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdupload.PageIndex = e.NewPageIndex;
            GetEnumeration();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BL;

namespace MSHC.Admin.MenuManagement
{
    public partial class QuickMenuContentList : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;
        string valueID, Quickmenuid, menuid;
        string querystring;
        int record;
        DataTable DT;
        string _QuickMenuName;

        public string QuickMenuName
        {
            get { return _QuickMenuName; }
            set { _QuickMenuName = value; }
        }

        protected void Page_init(object sender, EventArgs e)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            menuid = Request.QueryString["MenuID"];
            Quickmenuid = Request.QueryString["shvid"];
            SqlCommand cmd_sql = new SqlCommand();
            cmd_sql.Parameters.Add("@QuickMenuID", SqlDbType.NVarChar);
            cmd_sql.Parameters["@QuickMenuID"].Value = Quickmenuid;
            cmd_sql.CommandText = @"Select QuickMenuName From MOLQuickMenuMaster where QuickMenuID=@QuickMenuID";
            DT = MAHAITDBAccess.ExecuteDataSet(cmd_sql).Tables[0];
            if (DT != null)
            {
                if (DT.Rows.Count > 0)
                {
                    QuickMenuName = DT.Rows[0]["QuickMenuName"].ToString();

                }
            }
            if (!IsPostBack)
            {

                BindContentListGrid();
            }
        }

        private void BindContentListGrid()
        {
            SqlCommand sql_cmd = new SqlCommand();

            try
            {
                valueID = Request.QueryString["shvid"];
                sql_cmd.Parameters.Add("@QuickMenuID", SqlDbType.Int);
                sql_cmd.Parameters["@QuickMenuID"].Value = valueID;

                querystring = @"Select QuickContentID,QuickMenuID,PageTitle,Left(ShortDescription,50) AS ShortDescription,Left(LongDescription,50) AS LongDescription, SequenceNo,IsApprove,Active from MOLQuickMenuContent where QuickMenuID=@QuickMenuID and DeleteStatus=0";

                sql_cmd.CommandText = querystring;
                DT = MAHAITDBAccess.ExecuteDataSet(sql_cmd).Tables[0];

                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        grdQuickMenuContentList.DataSource = DT;
                        grdQuickMenuContentList.DataBind();

                    }
                    else
                    {
                        grdQuickMenuContentList.DataSource = null;
                        grdQuickMenuContentList.DataBind();

                    }

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdQuickMenuContentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                try
                {
                    SqlCommand sqlcmd = new SqlCommand();

                    sqlcmd.Parameters.Add("@QuickContentID", SqlDbType.Int);
                    sqlcmd.Parameters["@QuickContentID"].Value = e.CommandArgument;

                    querystring = @"Update MOLQuickMenuContent SET DeleteStatus=1 where QuickContentID=@QuickContentID";

                    sqlcmd.CommandText = querystring;
                    record = MAHAITDBAccess.ExecuteNonQuery(sqlcmd);

                    if (record != 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Quick-Menu Content deleted Succesfully !!!')", true);
                        BindContentListGrid();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error record not deleted !!!')", true);
                    }

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }


        protected void grdQuickMenuContentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MenuManagement/QuickMenuList.aspx?MenuID=" + menuid);
        }
    }
}
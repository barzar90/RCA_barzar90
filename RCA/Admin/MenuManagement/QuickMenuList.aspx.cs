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
    public partial class QuickMenuList : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;
        string _QuickMenuName;

        public string QuickMenuName
        {
            get { return _QuickMenuName; }
            set { _QuickMenuName = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["MenuID"] != null)
                {
                    DataTable Ddt;
                    SqlCommand cmd_sql = new SqlCommand();
                    cmd_sql.Parameters.Add("@MenuID", SqlDbType.NVarChar);
                    cmd_sql.Parameters["@MenuID"].Value = Request.QueryString["MenuID"];
                    cmd_sql.CommandText = @"Select MenuName From MOLMenuMaster where MenuID=@MenuID";
                    Ddt = MAHAITDBAccess.ExecuteDataSet(cmd_sql).Tables[0];
                    if (Ddt != null)
                    {
                        if (Ddt.Rows.Count > 0)
                        {
                            QuickMenuName = Ddt.Rows[0]["MenuName"].ToString();

                        }
                    }
                    BindQuickGridList(Request.QueryString["MenuID"]);
                }
   
            }

        }

        private void BindQuickGridList(string mid)
        {
            try
            {
                DataTable Dt_t;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Parameters.Add("@MenuID", SqlDbType.Int);
                Sqlcmd.Parameters["@MenuID"].Value = mid;

                string Querystring = @"Select * from MOLQuickMenuMaster WHERE DeleteStatus=0 and MenuID=@MenuID";

                Sqlcmd.CommandText = Querystring;
                Dt_t = MAHAITDBAccess.ExecuteDataSet(Sqlcmd).Tables[0];

                if (Dt_t != null)
                {
                    if (Dt_t.Rows.Count > 0)
                    {
                        grdQuickMenuList.DataSource = Dt_t.DefaultView;
                        grdQuickMenuList.DataBind();
                    }
                    else
                    {
                        grdQuickMenuList.DataSource = null;
                        grdQuickMenuList.DataBind();
                    }
                }
            }

            catch (Exception eee)
            {
                throw eee;
            }
        }

        protected void grdQuickMenuList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int record;

            if (e.CommandName == "Delete")
            {

                try
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Parameters.Add("@QuickMenuID", SqlDbType.VarChar);
                    sqlcmd.Parameters["@QuickMenuID"].Value = e.CommandArgument;

                    sqlcmd.CommandText = @"Update MOLQuickMenuMaster SET DeleteStatus=1 where QuickMenuID=@QuickMenuID";
                    record = MAHAITDBAccess.ExecuteNonQuery(sqlcmd);
                    if (record != 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('QuickMenu deleted Succesfully !!!')", true);
                        BindQuickGridList(Request.QueryString["MenuID"]);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error !!!')", true);
                    }

                }

                catch (Exception ee)
                {
                    throw ee;
                }

            }

        }

        protected void grdQuickMenuList_delete(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddQuickMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MenuManagement/QuickMenu.aspx?MenuID=" + Request.QueryString["MenuID"]);
        }
    }
}
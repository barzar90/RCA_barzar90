using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BL;

namespace MSHC.Site.Home
{
    public partial class InstructionMore : System.Web.UI.Page
    {
        int LangID = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["APPID"].ToString());
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvInstruction.Visible = false;
                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                using (cmd = new SqlCommand("InstructionMPSC", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Select_Instruction");
                    if (con.State.Equals(ConnectionState.Closed))
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvInstruction.DataSource = dt;
                        gvInstruction.DataBind();
                        gvInstruction.Visible = true;
                    }

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

        private void BindGridSearch()
        {
            try
            {
                using (cmd = new SqlCommand("InstructionMPSC", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Search_Instruction");
                    cmd.Parameters.AddWithValue("@Search", txtSearch.Text);
                    if (con.State.Equals(ConnectionState.Closed))
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvInstruction.DataSource = dt;
                        gvInstruction.DataBind();
                        gvInstruction.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { con.Close(); }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
                Session["LangId"] = LangID;
                if (txtSearch.Text == string.Empty)
                {
                    BindGrid();
                }
            }

            else
            {
                LangID = 1;
                Session["LangId"] = LangID;
                if (txtSearch.Text == string.Empty)
                {
                    BindGrid();
                }

            }

            MAHAITUserControl _mahaITUC = new MAHAITUserControl();
            lblSearch.Text = _mahaITUC.GetResourceValue("General", "lblKeywordsearch", "").ToString();
            lblInstruction.Text = _mahaITUC.GetResourceValue("General", "lblInstruction", "").ToString();
            btnSearch.Text = _mahaITUC.GetResourceValue("General", "Search_btn", "").ToString();
            Reset();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != string.Empty)
                {
                    BindGridSearch();
                }
                else
                {
                    ShowMessage("Please Enter A KeyWord To Search");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Reset()
        {
            txtSearch.Text = "";
        }

        private void ShowMessage(string Message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('" + Message + "');", true);
        }

        protected void gvInstruction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInstruction.PageIndex = e.NewPageIndex;
            if (txtSearch.Text != "")
                BindGrid();
            else
                BindGridSearch();

        }

    }
}
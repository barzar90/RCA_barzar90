using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Schema;
using BL;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace RCA.FORMS
{
    public partial class CreateAlbumForPressNews : System.Web.UI.Page
    {
        #region Public variable declaration
        DataSet ds;
        DataTable dt;
        AlbumSchema objAlbumSchema = new AlbumSchema();
        AlbumBL objAlbumBL = new AlbumBL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            pgCtr1.PagerControl_PageIndexChanged += new EventHandler(pgCtr1_PagerControl_PageIndexChanged);
            if (!Page.IsPostBack)
            {
                    Gridbind();
            }
        }

        void pgCtr1_PagerControl_PageIndexChanged(object sender, EventArgs e)
        {
            Gridbind();
        }

        public void Gridbind()
        {
            txtAlbumName.Text = "";
            objAlbumSchema.Type = "BindGrid";
            objAlbumSchema.AlbumName = "";
            ds = objAlbumBL.GetPressNewsAlbumdetails(objAlbumSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataView dv = (DataView)ds.Tables[0].DefaultView;
                pgCtr1.BindDataWithPaging(grdCreateAlbum, dv.Table);
                grdCreateAlbum.Columns[0].Visible = false;
            }

            else
            {
                grdCreateAlbum.DataSource = null;
                grdCreateAlbum.DataBind();
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Page.Validate("CA");
            if (!Page.IsValid)
                return;

            objAlbumSchema.Type = "CREATE";
            objAlbumSchema.AlbumName = txtAlbumName.Text.ToString();
            ds = objAlbumBL.GetPressNewsAlbumdetails(objAlbumSchema);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string Albumname = ds.Tables[0].Rows[0]["AlbumName"].ToString();
                if (Albumname.ToUpper().Trim().ToString() == txtAlbumName.Text.ToUpper().Trim().ToString())
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Required", "alert('Album Name For Press Gallery is Already Created')", true);
                    txtAlbumName.Text = "";
                    txtAlbumName.Focus();
                    return;
                }
            }
            objAlbumSchema.Actiontype = "CREATE";
            objAlbumSchema.AlbumName = txtAlbumName.Text.ToString();
            int a = objAlbumBL.DMLAlbumForPressNews(objAlbumSchema);
            HttpContext.Current.Items.Add("AlbumID", a);
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo category has Created');", true);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alert('Photo category has Created');", true);
            Gridbind();

        }

        protected void grdCreateAlbum_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCreateAlbum.EditIndex = -1;
            Gridbind();
        }

        protected void grdCreateAlbum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string pdfName;
            try
            {
                if (e.CommandName == "delete1")
                {
                    objAlbumSchema.PressNewsAlbumID = Convert.ToInt32(e.CommandArgument.ToString());
                    objAlbumSchema.Actiontype = "DELETE";
                    int a = objAlbumBL.DMLAlbumForPressNews(objAlbumSchema);

                    if (a > 0)
                    {
                        Gridbind();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void grdCreateAlbum_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCreateAlbum.EditIndex = e.NewEditIndex;
            Gridbind();
        }

        protected void grdCreateAlbum_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            TextBox txtName = (TextBox)grdCreateAlbum.Rows[e.RowIndex].FindControl("txtgrdAlbum");
            LinkButton LinkButton1 = (LinkButton)grdCreateAlbum.Rows[e.RowIndex].FindControl("LinkButton1");
            objAlbumSchema.AlbumName = txtName.Text.Trim();
            objAlbumSchema.PressNewsAlbumID = Convert.ToInt32(LinkButton1.CommandArgument.Trim());
            objAlbumBL.DMLAlbumForPressNews(objAlbumSchema);

            grdCreateAlbum.EditIndex = -1;
            Gridbind();

        }

        protected void grdCreateAlbum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex >= 0)
            //{
            //    Label Sr = (Label)e.Row.Cells[0].FindControl("LblSrNo");

            //    Sr.Text = (e.Row.RowIndex + 1).ToString();
            //}
        }
        protected void chkbox_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chknew = (CheckBox)grdCreateAlbum.Rows[0].FindControl("Chkstatus");
            CheckBox chk = (CheckBox)sender;
            GridViewRow gr = (GridViewRow)chk.Parent.Parent;
            string key = ((CheckBox)sender).Attributes["key"];

            int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;

   
            objAlbumSchema.PressNewsAlbumID = Convert.ToInt32(key);

            if (chk.Checked == true)
            {
                objAlbumSchema.ChkStatus = true;
            }
            else
            {
                objAlbumSchema.ChkStatus = false;
            }

            int a = objAlbumBL.DMLAlbumForPressNews(objAlbumSchema);
            if (a > 0)
            {
                Gridbind();
            }

        }

        protected void grdCreateAlbum_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblIsNew = (Label)e.Row.FindControl("lblIsNew");
                CheckBox chknew = (CheckBox)e.Row.FindControl("Chkstatus");
                Label Label1 = (Label)e.Row.FindControl("Label1");

                if (lblIsNew.Text == "False")
                {
                    chknew.Checked = false;
                }
                else
                {
                    chknew.Checked = true;
                }
            }
        }
        
    }
}
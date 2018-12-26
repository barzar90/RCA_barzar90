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

namespace MSHC.Site.Information
{
    public partial class pressRelease : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;
       // SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Local"].ToString());
        EnumerationSchema objEnumerationSchema;
        EnumerationBL objEnumerationBL;
        DataSet ds;
        public string sgridID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string culture = Request.QueryString["culture1"];

            if (culture != null)
            {
                if (culture == "en-US")
                {
                    Session["CurrentCulture"] = "en-US";
                }

                if (culture == "mr-IN")
                {
                    Session["CurrentCulture"] = "mr-IN";
                }

            }

            pgCtr1.PagerControl_PageIndexChanged += new EventHandler(pgCtr1_PagerControl_PageIndexChanged);
            if (!Page.IsPostBack)
            {
                GridBind(string.Empty);
                LoadDropdown();

            }
        }


        private void LoadDropdown()
        {
            //  Gridbind();
            AttachDropdownValues("DocumentType", ddlDocumentType);
            //ddlDocumentType. = "4aedb1bd-9983-4096-baca-05ddace272b9";  
            ddlDocumentType.SelectedValue = "7c14839d-16f0-4da2-8658-18c0f998e981";
        }




        private void AttachDropdownValues(string enumname, DropDownList ddl)
        {
            objEnumerationSchema = new EnumerationSchema();
            objEnumerationBL = new EnumerationBL();

            try
            {
                objEnumerationSchema.EnumerationName = enumname;
                ds = objEnumerationBL.GetEnumValues(objEnumerationSchema);
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "EnumerationValue";
                ddl.DataValueField = "EnumerationValueID";
                ddl.DataBind();
                //ddl.Items.Insert(0, "Please Select");
            }
            catch (Exception)
            {


            }
            finally
            {
                objEnumerationSchema = null;
                objEnumerationBL = null;
                ds = null;

            }
        }

        public void GridBind(string strWhere)
        {
            try
            {
                if (txtFromDate.Text != "")
                {
                    DateTime d1 = Convert.ToDateTime(txtFromDate.Text);
                    DateTime d2 = Convert.ToDateTime(txtToDate.Text);
                    //  strWhere = " where CONVERT(datetime,CreatedDate,103) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='C9179345-E344-4E9F-A554-6BDE4EEE5626' order by CreatedDate desc";
                    strWhere = " where CONVERT(datetime,CreatedDate,102) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='7c14839d-16f0-4da2-8658-18c0f998e981' and Flag='1'";
                }
                else
                {
                    strWhere = " where DocumentType='7c14839d-16f0-4da2-8658-18c0f998e981' and Flag='1'";

                }




                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select ROW_NUMBER ()over(order by DocumentID desc) as 'SRNo',DocumentName, DocumentPath,DocumentType,CONVERT(varchar(10), CreatedDate ,103) as CreatedDate,DocumentID,isnull(IsNew,'') as IsNew from dbo.Documents " + strWhere + " order by cast(CreatedDate as datetime) desc";
                cmd.CommandType = CommandType.Text;

                DataSet ds = new DataSet();
                ds = MAHAITDBAccess.ExecuteDataSet(cmd);


                if (ds.Tables[0].Rows.Count > 0)
                {
                   
                    DataView dv = (DataView)ds.Tables[0].DefaultView;
                    pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                    GridView1.Columns[0].Visible = false;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    pgCtr1.Visible = false;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Grid page index changed 

        void pgCtr1_PagerControl_PageIndexChanged(object sender, EventArgs e)
        {
            if (txtFromDate.Text != string.Empty)
            {
                DateTime d1 = Convert.ToDateTime(txtFromDate.Text);
                DateTime d2 = Convert.ToDateTime(txtToDate.Text);
                //ddlDocumentType.SelectedValue = "C9179345-E344-4E9F-A554-6BDE4EEE5626";
                ddlDocumentType.SelectedItem.Text = "7c14839d-16f0-4da2-8658-18c0f998e981";     //Set By defalut laws By Laws
                GridBind("where CONVERT(datetime,CreatedDate,103) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='" + ddlDocumentType.SelectedValue + "' and Flag='1'");
            }
            else
            {
                GridBind(string.Empty);
            }
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {


                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Delete from Documents where DocumentID='" + e.CommandArgument.ToString() + "'";
                cmd.CommandType = CommandType.Text;

                DataSet ds = new DataSet();
                ds = MAHAITDBAccess.ExecuteDataSet(cmd);



                GridBind(string.Empty);
                LoadDropdown();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFromDate.Text != "" && txtToDate.Text != "" && ddlDocumentType.SelectedIndex.ToString() != "Please Select" && TextBox5.Text == "")
                {
                   

                    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
                    string fromdate = FromDate.ToString("yyyy-MM-dd");

                    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
                    string todate = ToDate.ToString("yyyy-MM-dd");

                    string DocumentType = ddlDocumentType.SelectedValue;
                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "GetGr";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", fromdate);
                    cmd.Parameters.AddWithValue("@ToDate", todate);
                    cmd.Parameters.AddWithValue("@DocumentType", DocumentType);
                    cmd.Parameters.AddWithValue("@Flag", 'D');
                    cmd.Parameters.AddWithValue("@DocName", "");
                    DataSet ds = new DataSet();
                    ds = MAHAITDBAccess.ExecuteDataSet(cmd);



                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataView dv = (DataView)ds.Tables[0].DefaultView;
                        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                        GridView1.Columns[0].Visible = false;
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        pgCtr1.Visible = false;
                    }
                   
                }
                if (txtFromDate.Text == "" && txtToDate.Text == "" && TextBox5.Text != "")
                {

                    string DocumentType1 = ddlDocumentType.SelectedValue;
                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "GetGr";
                    cmd1.Parameters.AddWithValue("@FromDate", "");
                    cmd1.Parameters.AddWithValue("@ToDate", "");
                    cmd1.Parameters.AddWithValue("@DocumentType", DocumentType1);
                    cmd1.Parameters.AddWithValue("@Flag", 'K');
                    cmd1.Parameters.AddWithValue("@DocName", TextBox5.Text.Trim());
                    DataSet ds1 = new DataSet();
                    ds1 = MAHAITDBAccess.ExecuteDataSet(cmd1);

                    if (ds1.Tables[0].Rows.Count > 0)
                    {

                        DataView dv = (DataView)ds1.Tables[0].DefaultView;
                        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                        GridView1.Columns[0].Visible = false;

                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        pgCtr1.Visible = false;
                    }
                   
                }


                else if (txtFromDate.Text != "" && txtToDate.Text != "" && TextBox5.Text != "")
                {
                    DateTime FromDate11 = Convert.ToDateTime(txtFromDate.Text);
                    string fromdate11 = FromDate11.ToString("yyyy-MM-dd");

                    DateTime ToDate11 = Convert.ToDateTime(txtToDate.Text);
                    string todate11 = ToDate11.ToString("yyyy-MM-dd");

                    string DocumentType11 = ddlDocumentType.SelectedValue;

                    SqlCommand cmd11 = new SqlCommand();
                    cmd11.CommandType = CommandType.StoredProcedure;
                    cmd11.Parameters.AddWithValue("@FromDate", fromdate11);
                    cmd11.Parameters.AddWithValue("@ToDate", todate11);
                    cmd11.Parameters.AddWithValue("@DocumentType", DocumentType11);
                    cmd11.Parameters.AddWithValue("@Flag", 'B');
                    cmd11.Parameters.AddWithValue("@DocName", TextBox5.Text.Trim());
                    DataSet ds11 = new DataSet();
                    ds11 = MAHAITDBAccess.ExecuteDataSet(cmd11);

                    if (ds11.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = (DataView)ds11.Tables[0].DefaultView;
                        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                        GridView1.Columns[0].Visible = false;
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        pgCtr1.Visible = false;
                    }

                }
            }


            catch (Exception Ex)
            {
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
            TextBox5.Text = "";
            GridBind(string.Empty);
            LoadDropdown();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

    }
}
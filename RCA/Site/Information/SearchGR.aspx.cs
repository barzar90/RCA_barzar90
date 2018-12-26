using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Text;
using Schema;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using BL;


namespace MSHC.Site.Information
{
    public partial class SearchGR : MAHAITPage
    {
        public BL.BL MAHAITDBAccess;
        SqlCommand t_SQLCmd = null;
        EnumerationSchema objEnumerationSchema;
        EnumerationBL objEnumerationBL;
        DataSet ds;
        int LangID = 0;
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["APPID"]].ConnectionString;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connString);
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
            }

            else
            {
                LangID = 1;
            }
            if (!Page.IsPostBack)
            {
                //GridBind();
                LoadDropdown();
                LoadCategory();

            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {


            //lbl_GRHeading.Text = GetResourceValue("General", "lbl_GRHeading", "");


            lblFromDate.Text = GetResourceValue("General", "lblFromDate", "");
            lblToDate.Text = GetResourceValue("General", "lblToDate", "");
            lblDocType.Text = GetResourceValue("General", "lblDocType", "");
            lblGRNumber.Text = GetResourceValue("General", "lblGRNumber", "");
            lblIssuedBy.Text = GetResourceValue("General", "lblIssuedBy", "");
            btnSearchGR.Text = GetResourceValue("General", "btnSearchGR", "");

            btnClear.Text = GetResourceValue("General", "btnClear", "");
            lblKeywordSearch.Text = GetResourceValue("General", "lblKeywordSearch", "");



            string DepartmentName = string.Empty;

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {



                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameMarathi"].ToString();


                Page.Title = lbl_GRHeading.Text + "-" + DepartmentName;


            }
            else
            {

                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameEnglish"].ToString();

                Page.Title = lbl_GRHeading.Text + "-" + DepartmentName;

            }

        }

       

        private void LoadDropdown()
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());


            string sqlqry = "Select FileTypeValue,FileType from MOLFileCategory where FileTypeValue in (1,18,3,4,5,6,7,8,15,16,13,14,17,19,20,9,10,11,12,23,24) and LangID='" + LangID + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlqry;

            DataSet ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);

            ddlDocumentType.DataSource = ds;
            ddlDocumentType.DataTextField = "FileType";
            ddlDocumentType.DataValueField = "FileTypeValue";
            ddlDocumentType.DataBind();

        }

        private void LoadCategory()
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            string sqlqry = "Select * from EnumerationValue where EnumerationID='CA2EFFC1-964C-41D0-9D55-8CC786FCD357'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlqry;
            DataSet ds = new DataSet();
            ds = MAHAITDBAccess.ExecuteDataSet(cmd);


        }


        //private void AttachDropdownValues(string enumname, DropDownList ddl)
        //{
        //    objEnumerationSchema = new EnumerationSchema();
        //    objEnumerationBL = new EnumerationBL();

        //    //try
        //    //{
        //    objEnumerationSchema.EnumerationName = enumname;
        //    ds = objEnumerationBL.GetEnumValues(objEnumerationSchema);
        //    ddl.DataSource = ds.Tables[0];
        //    ddl.DataTextField = "EnumerationValue";
        //    ddl.DataValueField = "EnumerationValueID";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, "Please Select");
        //    //}
        //    //catch (Exception)
        //    //{


        //    //}
        //    //finally
        //    //{
        //    //    objEnumerationSchema = null;
        //    //    objEnumerationBL = null;
        //    //    ds = null;

        //    //}
        //}

        public void GridBind()
        {
            try
            {
                DataSet dt = new DataSet();
                dt = getData();
                //da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {


                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    //foreach (DataRow row in dt.Tables[0].Rows)
                    //{
                    //    string[] _path = row["DocumentPath"].ToString().Split('/');
                    //    string path = string.Empty;
                    //    for (int i = 0; i <= _path.Length - 1; i++)
                    //    {
                    //        if (!_path[i].ToLower().StartsWith("site"))
                    //        {
                    //            path += _path[i].ToString() + "/";

                    //        }
                    //    }
                    //    if (path.EndsWith("/"))
                    //        path = path.Substring(0, path.Length - 1);

                    //    row["DocumentPath"] = path;
                    //    dt.AcceptChanges();
                    //}
                    //DataView dv = (DataView)dt.Tables[0].DefaultView;
                    ////pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                    //GridView1.Columns[0].Visible = false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GridBind_old(string strWhere)
        {
            try
            {
                if (txtFromDate.Text != "")
                {
                    DateTime d1 = Convert.ToDateTime(txtFromDate.Text);
                    DateTime d2 = Convert.ToDateTime(txtToDate.Text);
                    //  strWhere = " where CONVERT(datetime,CreatedDate,103) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='0d6d688b-df19-49dc-ab84-f7c3dd7d7e6e' order by CreatedDate desc";
                    strWhere = " where CONVERT(datetime,CreatedDate,102) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='0d6d688b-df19-49dc-ab84-f7c3dd7d7e6e'";
                }
                else
                {
                    strWhere = "where DocumentType='0d6d688b-df19-49dc-ab84-f7c3dd7d7e6e'";

                }
                //string select = "Select ROW_NUMBER ()over(order by DocumentID desc) as 'SRNo',DocumentName, DocumentPath,DocumentType,CONVERT(varchar(10), CreatedDate ,103) as CreatedDate,DocumentID from Documents " + strWhere + " order by cast(CreatedDate as datetime) desc ";
                string select = "";
                StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("Select ROW_NUMBER ()over(order by DocumentID desc) as 'SRNo',DocumentName, DocumentPath,DocumentType,CONVERT(varchar(10), CreatedDate ,103) as CreatedDate,DocumentID");
                sbSelect.Append(",GRNumber,IssuedBy,Category,DocType.EnumerationValue As DocumentTypeName,Cat.EnumerationValue As CategoryTypeName ");
                sbSelect.Append("from Documents ");
                sbSelect.Append("LEFT OUTER JOIN (Select EnumerationValueID,EnumerationValue from EnumerationValue where EnumerationID =(Select EnumerationID from Enumeration where EnumerationName='DocumentType')) As DocType ");
                sbSelect.Append("ON DocumentType=DocType.EnumerationValueID ");
                sbSelect.Append("LEFT OUTER JOIN (Select EnumerationValueID,EnumerationValue from EnumerationValue where EnumerationID =(Select EnumerationID from Enumeration where EnumerationName='DocumentCategory')) As Cat ");
                sbSelect.Append("ON Category=Cat.EnumerationValueID ");
                sbSelect.Append(strWhere);
                sbSelect.Append("order by cast(CreatedDate as datetime) desc ");

                select = sbSelect.ToString();
                SqlDataAdapter da = new SqlDataAdapter(select, con);
                DataSet dt = new DataSet();
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    //GridView1.DataSource = dt;
                    //GridView1.DataBind();

                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        string[] _path = row["DocumentPath"].ToString().Split('/');
                        string path = string.Empty;
                        for (int i = 0; i <= _path.Length - 1; i++)
                        {
                            if (!_path[i].ToLower().StartsWith("site"))
                            {
                                path += _path[i].ToString() + "/";

                            }
                        }
                        if (path.EndsWith("/"))
                            path = path.Substring(0, path.Length - 1);

                        row["DocumentPath"] = path;
                        dt.AcceptChanges();
                    }
                    DataView dv = (DataView)dt.Tables[0].DefaultView;
                    // pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                    GridView1.Columns[0].Visible = false;
                }
                else
                {
                    GridView1.DataMember = null;
                    GridView1.DataBind();
                    // pgCtr1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //public void ProcessRequest(HttpContext context)
        //{
        //    //context.Response.ContentType = "text/plain";
        //    //context.Response.Write("Hello World");
        //    try
        //    {
        //        if (!String.IsNullOrEmpty(context.Request.QueryString["ID"]))
        //        {
        //            string t_FileID = context.Request.QueryString["ID"];

        //            SqlCommand t_SQLCmd = new SqlCommand();
        //            DataSet t_DS = null;

        //            t_SQLCmd.CommandText = "Select FileType,FileContent,Category,ImageType,ImageContent From MOLUploadFile where RowID = @ID";
        //            t_SQLCmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
        //            t_SQLCmd.Parameters["@ID"].Value = t_FileID;
        //            byte[] pict;
        //            t_DS = MOLDBAccess.ExecuteDataSet(t_SQLCmd);

        //            context.Response.ContentType = t_DS.Tables[0].Rows[0]["FileType"].ToString();
        //            pict = (byte[])t_DS.Tables[0].Rows[0]["FileContent"];


        //                    context.Response.Cache.SetCacheability(HttpCacheability.Public);
        //                    context.Response.Cache.SetLastModified(DateTime.Now);
        //                    //context.Response.AppendHeader("Content-Type", "video/x-flv");
        //                    //context.Response.AppendHeader("Content-Type", "video/x-ms-wmv");
        //                    context.Response.AppendHeader("Content-Type", t_DS.Tables[0].Rows[0]["FileType"].ToString());
        //                    context.Response.AppendHeader("Content-Length", (pict).Length.ToString());
        //                    context.Response.BinaryWrite(pict);


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }



        //}

        protected DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetGr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string fromdate = null;
                string todate = null;
                string DocumentType = null;
                string DocName = null;
                string GRNumber = null;
                string IssuedBy = null;
                // string category = null;
                if (txtFromDate.Text.Trim() != "")
                {
                    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
                    fromdate = FromDate.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@FromDate", fromdate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
                }
                if (txtToDate.Text.Trim() != "")
                {
                    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
                    todate = ToDate.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@ToDate", todate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
                }

                if (ddlDocumentType.SelectedIndex <= 0)
                {
                    cmd.Parameters.AddWithValue("@DocumentType", DBNull.Value);

                }
                else
                {
                    DocumentType = ddlDocumentType.SelectedValue;
                    cmd.Parameters.AddWithValue("@DocumentType", DocumentType);
                }

                if (TextBox5.Text.Trim() != "")
                {
                    DocName = TextBox5.Text.Trim();
                    cmd.Parameters.AddWithValue("@DocName", DocName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DocName", DBNull.Value);
                }
                if (txtGRNumber.Text.Trim() != "")
                {
                    GRNumber = txtGRNumber.Text.Trim();
                    cmd.Parameters.AddWithValue("@GRNumber", GRNumber);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GRNumber", DBNull.Value);
                }
                if (txtIssuedBy.Text.Trim() != "")
                {
                    IssuedBy = txtIssuedBy.Text.Trim();
                    cmd.Parameters.AddWithValue("@IssuedBy", IssuedBy);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IssuedBy", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@LangID", LangID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }




        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {


        //        //SqlCommand cmd = new SqlCommand("GetGr", con);
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        //string fromdate = null;
        //        //string todate = null;
        //        //string DocumentType = null;
        //        //string DocName = null;                
        //        //string GRNumber = null;
        //        //string IssuedBy = null;
        //        //string category = null;
        //        //if (txtFromDate.Text.Trim() != "")
        //        //{
        //        //    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
        //        //    fromdate = FromDate.ToString("yyyy-MM-dd");
        //        //    cmd.Parameters.AddWithValue("@FromDate", fromdate);
        //        //}
        //        //else
        //        //{
        //        //    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
        //        //}
        //        //if (txtToDate.Text.Trim() != "")
        //        //{
        //        //    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
        //        //    todate = ToDate.ToString("yyyy-MM-dd");
        //        //    cmd.Parameters.AddWithValue("@ToDate", todate);
        //        //}
        //        //else
        //        //{
        //        //    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
        //        //}
        //        //if (ddlDocumentType.SelectedValue != "Please Select")
        //        //{
        //        //    DocumentType = ddlDocumentType.SelectedValue;
        //        //    cmd.Parameters.AddWithValue("@DocumentType", DocumentType);
        //        //}
        //        //else
        //        //{
        //        //    cmd.Parameters.AddWithValue("@DocumentType", DBNull.Value);
        //        //}
        //        //if (TextBox5.Text.Trim() != "")
        //        //{
        //        //    DocName = TextBox5.Text.Trim();
        //        //    cmd.Parameters.AddWithValue("@DocName", DocName);
        //        //}
        //        //else
        //        //{
        //        //    cmd.Parameters.AddWithValue("@DocName", DBNull.Value);
        //        //}
        //        //if (txtGRNumber.Text.Trim() != "")
        //        //{
        //        //    GRNumber = txtGRNumber.Text.Trim();
        //        //    cmd.Parameters.AddWithValue("@GRNumber", GRNumber);
        //        //}
        //        //else
        //        //{
        //        //    cmd.Parameters.AddWithValue("@GRNumber", DBNull.Value);
        //        //}
        //        //if (txtIssuedBy.Text.Trim() != "")
        //        //{
        //        //    IssuedBy = txtIssuedBy.Text.Trim();
        //        //    cmd.Parameters.AddWithValue("@IssuedBy", IssuedBy);
        //        //}
        //        //else
        //        //{
        //        //    cmd.Parameters.AddWithValue("@IssuedBy", DBNull.Value);
        //        //}
        //        //if (ddlCategory.SelectedValue != "Please Select")
        //        //{
        //        //    category = ddlCategory.SelectedValue;
        //        //    cmd.Parameters.AddWithValue("@Category", category);
        //        //}
        //        //else
        //        //{
        //        //    cmd.Parameters.AddWithValue("@Category", DBNull.Value);
        //        //}
        //        ////cmd.Parameters.OfType<SqlParameter>().ToList().ForEach(para => para.IsNullable = true);
        //        //DataSet dt = new DataSet();
        //        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        //da.Fill(dt);

        //        DataSet dt = new DataSet();
        //        dt = getData();
        //        if (dt.Tables[0].Rows.Count > 0)
        //        {
        //            //GridView1.DataSource = dt;
        //            //GridView1.DataBind();


        //            //DataView dv = (DataView)dt.Tables[0].DefaultView;
        //            //pgCtr1.BindDataWithPaging(GridView1, dv.Table);



        //            foreach (DataRow row in dt.Tables[0].Rows)
        //            {
        //                string[] _path = row["DocumentPath"].ToString().Split('/');
        //                string path = string.Empty;
        //                for (int i = 0; i <= _path.Length - 1; i++)
        //                {
        //                    if (!_path[i].ToLower().StartsWith("site"))
        //                    {
        //                        path += _path[i].ToString() + "/";

        //                    }
        //                }
        //                if (path.EndsWith("/"))
        //                    path = path.Substring(0, path.Length - 1);

        //                row["DocumentPath"] = path;
        //                dt.AcceptChanges();
        //            }
        //            DataView dv = (DataView)dt.Tables[0].DefaultView;
        //            //pgCtr1.BindDataWithPaging(GridView1, dv.Table);
        //            GridView1.Columns[0].Visible = false;



        //        }
        //        else
        //        {
        //            GridView1.DataMember = null;
        //            GridView1.DataBind();
        //           // pgCtr1.Visible = false;
        //        }

        //        #region Commented Out Existing Search Code


        //        //if (txtFromDate.Text != "" && txtToDate.Text != "" && ddlDocumentType.SelectedIndex.ToString() != "Please Select" && TextBox5.Text == "")
        //        //{
        //        //    //DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
        //        //    //string fromdate = FromDate.ToString("dd-MM-yyyy");

        //        //    //DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
        //        //    //string todate = ToDate.ToString("dd-MM-yyyy");

        //        //    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
        //        //    string fromdate = FromDate.ToString("yyyy-MM-dd");

        //        //    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
        //        //    string todate = ToDate.ToString("yyyy-MM-dd");

        //        //    string DocumentType = ddlDocumentType.SelectedValue;
        //        //    SqlCommand cmd = new SqlCommand("GetGr", con);
        //        //    cmd.CommandType = CommandType.StoredProcedure;
        //        //    cmd.Parameters.AddWithValue("@FromDate", fromdate);
        //        //    cmd.Parameters.AddWithValue("@ToDate", todate);
        //        //    cmd.Parameters.AddWithValue("@DocumentType", DocumentType);
        //        //    cmd.Parameters.AddWithValue("@Flag", 'D');
        //        //    cmd.Parameters.AddWithValue("@DocName", "");
        //        //    DataSet dt = new DataSet();
        //        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        //    da.Fill(dt);
        //        //    if (dt.Tables[0].Rows.Count > 0)
        //        //    {
        //        //        //GridView1.DataSource = dt;
        //        //        //GridView1.DataBind();


        //        //        //DataView dv = (DataView)dt.Tables[0].DefaultView;
        //        //        //pgCtr1.BindDataWithPaging(GridView1, dv.Table);



        //        //        foreach (DataRow row in dt.Tables[0].Rows)
        //        //        {
        //        //            string[] _path = row["DocumentPath"].ToString().Split('/');
        //        //            string path = string.Empty;
        //        //            for (int i = 0; i <= _path.Length - 1; i++)
        //        //            {
        //        //                if (!_path[i].ToLower().StartsWith("site"))
        //        //                {
        //        //                    path += _path[i].ToString() + "/";

        //        //                }
        //        //            }
        //        //            if (path.EndsWith("/"))
        //        //                path = path.Substring(0, path.Length - 1);

        //        //            row["DocumentPath"] = path;
        //        //            dt.AcceptChanges();
        //        //        }
        //        //        DataView dv = (DataView)dt.Tables[0].DefaultView;
        //        //        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
        //        //        GridView1.Columns[0].Visible = false;



        //        //    }
        //        //    else
        //        //    {
        //        //        GridView1.DataMember = null;
        //        //        GridView1.DataBind();
        //        //        pgCtr1.Visible = false;
        //        //    }
        //        //    ////////else if (txtFromDate.Text == "" && txtToDate.Text == "" || TextBox5.Text != "")
        //        //    ////////{
        //        //    ////////    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failed", "alert('Data Is not Available')", true);


        //        //    ////////    //DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
        //        //    ////////    //string fromdate = FromDate.ToString("dd-MM-yyyy");

        //        //    ////////    //DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
        //        //    ////////    //string todate = ToDate.ToString("dd-MM-yyyy");



        //        //    ////////    string DocumentType1 = ddlDocumentType.SelectedValue;
        //        //    ////////    SqlCommand cmd1 = new SqlCommand("GetGr", con);
        //        //    ////////    cmd1.CommandType = CommandType.StoredProcedure;
        //        //    ////////    cmd1.Parameters.AddWithValue("@FromDate", "");
        //        //    ////////    cmd1.Parameters.AddWithValue("@ToDate", "");
        //        //    ////////    cmd1.Parameters.AddWithValue("@DocumentType", DocumentType1);
        //        //    ////////    cmd1.Parameters.AddWithValue("@Flag", 'K');
        //        //    ////////    cmd1.Parameters.AddWithValue("@DocName", TextBox5.Text.Trim());
        //        //    ////////    DataSet dt1 = new DataSet();
        //        //    ////////    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        //        //    ////////    da1.Fill(dt);
        //        //    ////////    if (dt1.Tables[0].Rows.Count > 0)
        //        //    ////////    {


        //        //    ////////        foreach (DataRow row in dt1.Tables[0].Rows)
        //        //    ////////        {
        //        //    ////////            string[] _path = row["DocumentPath"].ToString().Split('/');
        //        //    ////////            string path = string.Empty;
        //        //    ////////            for (int i = 0; i <= _path.Length - 1; i++)
        //        //    ////////            {
        //        //    ////////                if (!_path[i].ToLower().StartsWith("site"))
        //        //    ////////                {
        //        //    ////////                    path += _path[i].ToString() + "/";

        //        //    ////////                }
        //        //    ////////            }
        //        //    ////////            if (path.EndsWith("/"))
        //        //    ////////                path = path.Substring(0, path.Length - 1);

        //        //    ////////            row["DocumentPath"] = path;
        //        //    ////////            dt1.AcceptChanges();
        //        //    ////////        }
        //        //    ////////        DataView dv = (DataView)dt1.Tables[0].DefaultView;
        //        //    ////////        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
        //        //    ////////        GridView1.Columns[0].Visible = false;




        //        //    ////////    }
        //        //    ////////    //DataTable dt = new DataTable();
        //        //    ////////    //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        //    ////////    //da.Fill(dt);
        //        //    ////////    //GridView1.DataSource = dt;
        //        //    ////////    //GridView1.DataBind();

        //        //    ////////    //txtFromDate.Text = "";
        //        //    ////////    //txtToDate.Text = "";
        //        //    ////////    //ddlDocumentType.SelectedIndex = 0;
        //        //    ////////}

        //        //}
        //        //if (txtFromDate.Text == "" && txtToDate.Text == "" && TextBox5.Text != "")
        //        //{
        //        //    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failed", "alert('Data Is not Available')", true);


        //        //    //DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
        //        //    //string fromdate = FromDate.ToString("dd-MM-yyyy");

        //        //    //DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
        //        //    //string todate = ToDate.ToString("dd-MM-yyyy");



        //        //    string DocumentType1 = ddlDocumentType.SelectedValue;
        //        //    SqlCommand cmd1 = new SqlCommand("GetGr", con);
        //        //    cmd1.CommandType = CommandType.StoredProcedure;
        //        //    cmd1.Parameters.AddWithValue("@FromDate", "");
        //        //    cmd1.Parameters.AddWithValue("@ToDate", "");
        //        //    cmd1.Parameters.AddWithValue("@DocumentType", DocumentType1);
        //        //    cmd1.Parameters.AddWithValue("@Flag", 'K');
        //        //    cmd1.Parameters.AddWithValue("@DocName", TextBox5.Text.Trim());
        //        //    DataSet dt1 = new DataSet();
        //        //    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        //        //    da1.Fill(dt1);
        //        //    if (dt1.Tables[0].Rows.Count > 0)
        //        //    {


        //        //        foreach (DataRow row in dt1.Tables[0].Rows)
        //        //        {
        //        //            string[] _path = row["DocumentPath"].ToString().Split('/');
        //        //            string path = string.Empty;
        //        //            for (int i = 0; i <= _path.Length - 1; i++)
        //        //            {
        //        //                if (!_path[i].ToLower().StartsWith("site"))
        //        //                {
        //        //                    path += _path[i].ToString() + "/";

        //        //                }
        //        //            }
        //        //            if (path.EndsWith("/"))
        //        //                path = path.Substring(0, path.Length - 1);

        //        //            row["DocumentPath"] = path;
        //        //            dt1.AcceptChanges();
        //        //        }
        //        //        DataView dv = (DataView)dt1.Tables[0].DefaultView;
        //        //        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
        //        //        GridView1.Columns[0].Visible = false;




        //        //    }
        //        //    else
        //        //    {
        //        //        GridView1.DataMember = null;
        //        //        GridView1.DataBind();
        //        //        pgCtr1.Visible = false;
        //        //    }
        //        //    //DataTable dt = new DataTable();
        //        //    //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        //    //da.Fill(dt);
        //        //    //GridView1.DataSource = dt;
        //        //    //GridView1.DataBind();

        //        //    //txtFromDate.Text = "";
        //        //    //txtToDate.Text = "";
        //        //    //ddlDocumentType.SelectedIndex = 0;
        //        //}


        //        //else if (txtFromDate.Text != "" && txtToDate.Text != "" && TextBox5.Text != "")
        //        //{
        //        //    DateTime FromDate11 = Convert.ToDateTime(txtFromDate.Text);
        //        //    string fromdate11 = FromDate11.ToString("yyyy-MM-dd");

        //        //    DateTime ToDate11 = Convert.ToDateTime(txtToDate.Text);
        //        //    string todate11 = ToDate11.ToString("yyyy-MM-dd");

        //        //    string DocumentType11 = ddlDocumentType.SelectedValue;
        //        //    SqlCommand cmd11 = new SqlCommand("GetGr", con);
        //        //    cmd11.CommandType = CommandType.StoredProcedure;
        //        //    cmd11.Parameters.AddWithValue("@FromDate", fromdate11);
        //        //    cmd11.Parameters.AddWithValue("@ToDate", todate11);
        //        //    cmd11.Parameters.AddWithValue("@DocumentType", DocumentType11);
        //        //    cmd11.Parameters.AddWithValue("@Flag", 'B');
        //        //    cmd11.Parameters.AddWithValue("@DocName", TextBox5.Text.Trim());
        //        //    DataSet dt11 = new DataSet();
        //        //    SqlDataAdapter da11 = new SqlDataAdapter(cmd11);
        //        //    da11.Fill(dt11);
        //        //    if (dt11.Tables[0].Rows.Count > 0)
        //        //    {


        //        //        foreach (DataRow row in dt11.Tables[0].Rows)
        //        //        {
        //        //            string[] _path = row["DocumentPath"].ToString().Split('/');
        //        //            string path = string.Empty;
        //        //            for (int i = 0; i <= _path.Length - 1; i++)
        //        //            {
        //        //                if (!_path[i].ToLower().StartsWith("site"))
        //        //                {
        //        //                    path += _path[i].ToString() + "/";

        //        //                }
        //        //            }
        //        //            if (path.EndsWith("/"))
        //        //                path = path.Substring(0, path.Length - 1);

        //        //            row["DocumentPath"] = path;
        //        //            dt11.AcceptChanges();
        //        //        }
        //        //        DataView dv = (DataView)dt11.Tables[0].DefaultView;
        //        //        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
        //        //        GridView1.Columns[0].Visible = false;
        //        //    }
        //        //    else
        //        //    {
        //        //        GridView1.DataMember = null;
        //        //        GridView1.DataBind();
        //        //    }

        //        //}
        //        #endregion
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //}


        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //if (e.CommandName == "Img")
        //    //{
        //    //    Response.Redirect(e.CommandArgument.ToString());
        //    //}

        //    if (e.CommandName == "delete")
        //    {

        //        string connection = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
        //        SqlConnection nwindConn = new SqlConnection(connection);
        //        nwindConn.Open();
        //        SqlCommand cmd = new SqlCommand("Delete from Documents where DocumentID='" + e.CommandArgument.ToString() + "'", nwindConn);
        //        cmd.ExecuteNonQuery();
        //        nwindConn.Close();

        //        GridBind(string.Empty);
        //        LoadDropdown();
        //    }

        //}

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //}

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox5.Text = "";
                txtFromDate.Text = "";
                txtToDate.Text = "";
                txtIssuedBy.Text = "";
                txtGRNumber.Text = "";
                //ddlCategory.SelectedIndex = -1;
                ddlDocumentType.SelectedIndex = -1;
                //GridBind(string.Empty);
                GridBind();
                LoadDropdown();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds_data = new DataSet();
            AccordianDy();
        }
        public void AccordianDy()
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            DataSet ds_data = new DataSet();
            string _frmdate = (txtFromDate.Text);
            string DocumentType = ddlDocumentType.SelectedValue.ToString();
            string DocumentTypeName = ddlDocumentType.SelectedItem.ToString();
            // Guid Category = new Guid(ddlCategory.SelectedValue.ToString());
            string _todate = (txtToDate.Text);
            string _Grno = txtGRNumber.Text;
            string _IssuedBy = txtIssuedBy.Text;
            string _KeywordSearch = TextBox5.Text;
            SqlCommand t_SQLCmd = new SqlCommand();
            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@FromDate", SqlDbType.VarChar);

            param[0] = new SqlParameter("@FromDate", _frmdate);


            param[1] = new SqlParameter("@todate", SqlDbType.VarChar);

            param[1] = new SqlParameter("@todate", _todate);


            param[2] = new SqlParameter("@DocumentType", SqlDbType.VarChar);

            param[2] = new SqlParameter("@DocumentType", DocumentType);

            param[3] = new SqlParameter("@DocumentTypeName", SqlDbType.VarChar);

            param[3] = new SqlParameter("@DocumentTypeName", DocumentTypeName);


            param[4] = new SqlParameter("@DocName", SqlDbType.VarChar);

            param[4] = new SqlParameter("@DocName", _KeywordSearch);

            param[5] = new SqlParameter("@GRNumber", SqlDbType.VarChar);

            param[5] = new SqlParameter("@GRNumber", _Grno);

            param[6] = new SqlParameter("@IssuedBy", SqlDbType.VarChar);

            param[6] = new SqlParameter("@IssuedBy", _IssuedBy);


            param[7] = new SqlParameter("@LangID", SqlDbType.Int);
            param[7] = new SqlParameter("@LangID", LangID);



            t_SQLCmd.Parameters.Add(param[0]);
            t_SQLCmd.Parameters.Add(param[1]);
            t_SQLCmd.Parameters.Add(param[2]);
            t_SQLCmd.Parameters.Add(param[3]);
            t_SQLCmd.Parameters.Add(param[4]);
            t_SQLCmd.Parameters.Add(param[5]);
            t_SQLCmd.Parameters.Add(param[6]);
            t_SQLCmd.Parameters.Add(param[7]);

            t_SQLCmd.CommandText = "GetGr_MolMSISGR";
            t_SQLCmd.CommandType = CommandType.StoredProcedure;
            t_SQLCmd.CommandTimeout = 5000;

            ds_data = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);
            GridView1.DataSource = ds_data;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            AccordianDy();

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ProcessRequest(Convert.ToString(e.CommandArgument));


        }


        public void ProcessRequest(string t_FileID)
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            try
            {
                if (!String.IsNullOrEmpty(t_FileID))
                {
                    SqlCommand t_SQLCmd = new SqlCommand();
                    DataSet t_DS = null;

                    t_SQLCmd.CommandText = "Select FileType,FileContent,Category,ImageType,ImageContent From MOLUploadFile where RowID = '" + t_FileID + "'";
                    t_SQLCmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                    t_SQLCmd.Parameters["@ID"].Value = t_FileID;
                    byte[] pict;
                    t_DS = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);

                    Response.ContentType = t_DS.Tables[0].Rows[0]["FileType"].ToString();
                    pict = (byte[])t_DS.Tables[0].Rows[0]["FileContent"];


                    Response.Cache.SetCacheability(HttpCacheability.Public);
                    Response.Cache.SetLastModified(DateTime.Now);
                    //context.Response.AppendHeader("Content-Type", "video/x-flv");
                    //context.Response.AppendHeader("Content-Type", "video/x-ms-wmv");
                    Response.AppendHeader("Content-Type", t_DS.Tables[0].Rows[0]["FileType"].ToString());
                    Response.AppendHeader("Content-Length", (pict).Length.ToString());
                    Response.BinaryWrite(pict);


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                MAHAITDBAccess.Dispose();
            }



        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Schema;
using System.Text;
using BL;

namespace MSHC.Site.Information
{
    public partial class forum : MAHAITPage 
    {
       // SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Local"].ToString());
        EnumerationSchema objEnumerationSchema;
        EnumerationBL objEnumerationBL;
        DataSet ds;
        BL.BL MAHAITDBAccess;
        int LangID = 0;
        public string sgridID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
            }

            else
            {
                LangID = 1;
            }

            pgCtr1.PagerControl_PageIndexChanged += new EventHandler(pgCtr1_PagerControl_PageIndexChanged);
            if (!Page.IsPostBack)
            {
                GridBind(string.Empty);
                LoadDropdown();

            }
        }


        private Boolean validatedata()
        {
            ltrmsg.Text = string.Empty;
            Boolean isvalid = true;

            StringBuilder sb = new StringBuilder();

            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {

                    if (txtFromDate.Text == string.Empty || txtFromDate.Text == null)
                    {
                        sb.Append("<li>कृपया या दिनांकापासून टाका</li>");
                    }

                    if (txtToDate.Text == null || txtToDate.Text == string.Empty)
                    {
                        sb.Append("<li>कृपया या दिनांकापर्यंत टाका</li>");
                    }


                    if (sb.Length > 0)
                    {
                        ltrmsg.Text = "<ul><li>खालील प्रमाणे चुका सापडल्या आहेत:</li>" + sb.ToString() + "</ul>";
                        isvalid = false;
                    }

                    return isvalid;
                }
                else
                {


                    if (txtFromDate.Text == string.Empty || txtFromDate.Text == null)
                    {
                        sb.Append("<li>Enter From date</li>");
                    }

                    if (ddlDocumentType.SelectedIndex.ToString() == "")
                    {
                        sb.Append("<li>Select Document Type</li>");
                    }

                    if (txtToDate.Text == null || txtToDate.Text == string.Empty)
                    {
                        sb.Append("<li>Enter To Date </li>");
                    }


                    if (sb.Length > 0)
                    {
                        ltrmsg.Text = "<ul><li>Validation Summary:</li>" + sb.ToString() + "</ul>";
                        isvalid = false;
                    }

                    return isvalid;
                }
            }

            finally
            { sb = null; }
        }

        //Load Dropdown to fill All PDF TYPE
        private void LoadDropdown()
        {
            //  Gridbind();
            AttachDropdownValues("DocumentType", ddlDocumentType);
   

            if (LangID == 1)
            {

                ddlDocumentType.SelectedValue= "1D21A8F0-1A86-4CE8-A80B-AAF5EFC54D20".ToLower();
            }

            else
            {
                ddlDocumentType.SelectedValue = "1D21A8F0-1A86-4CE8-A80B-AAF5EFC54D20".ToLower();
              //  ddlDocumentType.SelectedValue = "7E67C436-73EF-4D3E-821B-AE8148DE22E1".ToLower();
            }


            
        }


        private void AttachDropdownValues(string enumname, DropDownList ddl)
        {
            objEnumerationSchema = new EnumerationSchema();
            objEnumerationBL = new EnumerationBL();

            try
            {
                objEnumerationSchema.EnumerationName = enumname;
                objEnumerationSchema.LangID = Convert.ToString(LangID);
                ds = objEnumerationBL.GetEnumValues_AllPDF(objEnumerationSchema);
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
                if (txtFromDate.Text != "")  //00A290C3-1982-40C8-A025-57C9BECA4E52
                {
                    DateTime d1 = Convert.ToDateTime(txtFromDate.Text);
                    DateTime d2 = Convert.ToDateTime(txtToDate.Text);
                    if (LangID == 1)
                    {
                        //  strWhere = " where CONVERT(datetime,CreatedDate,103) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='C9179345-E344-4E9F-A554-6BDE4EEE5626' order by CreatedDate desc";
                        strWhere = " where CONVERT(datetime,CreatedDate,102) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='1D21A8F0-1A86-4CE8-A80B-AAF5EFC54D20' and Flag='1' and LangID=1";
                    }
                    else
                    {
                        strWhere = " where CONVERT(datetime,CreatedDate,102) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='1D21A8F0-1A86-4CE8-A80B-AAF5EFC54D20' and Flag='1' and LangID=1";
                    }
                }
                else
                {
                    if (LangID == 1)
                    {
                        strWhere = "where DocumentType='1D21A8F0-1A86-4CE8-A80B-AAF5EFC54D20' and Flag='1' and LangID=1";
                    }
                    else
                    {
                        strWhere = "where DocumentType='1D21A8F0-1A86-4CE8-A80B-AAF5EFC54D20' and Flag='1' and LangID=1";
                    }
                }

                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select *,ROW_NUMBER ()over(order by DocumentID desc) as 'SRNo',DocumentName, DocumentPath,DocumentType,CONVERT(varchar(10), CreatedDate ,105) as CreatedDate,DocumentID,isnull(IsNew,'') as IsNew from dbo.Documents " + strWhere + " order by cast(CreatedDate as datetime) desc";
                cmd.CommandType = CommandType.Text;

                DataSet ds = new DataSet();
                ds = MAHAITDBAccess.ExecuteDataSet(cmd);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (LangID == 1)
                    {
                        DataView dv = (DataView)ds.Tables[0].DefaultView;
                        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                        GridView1.Columns[0].Visible = false;
                        GridView1.Columns[1].Visible = false;

                        GridView1.Columns[0].Visible = false;
                        GridView1.Columns[1].Visible = true;
                        GridView1.Columns[2].Visible = false;
                        GridView1.Columns[1].HeaderText = "Document Name";
                        GridView1.Columns[3].HeaderText = "Date";
                        GridView1.Columns[4].HeaderText = "Document Path";
                        GridView1.Columns[5].HeaderText = "Size";

                    }
                    else
                    {
                        DataView dv = (DataView)ds.Tables[0].DefaultView;
                        pgCtr1.BindDataWithPaging(GridView1, dv.Table);
                        GridView1.Columns[0].Visible = false;
                        GridView1.Columns[2].Visible = false;

                        GridView1.Columns[0].Visible = false;
                        GridView1.Columns[1].Visible = false;
                        GridView1.Columns[2].Visible = true;
                        GridView1.Columns[2].HeaderText = "दस्तऐवज नाव";
                        GridView1.Columns[3].HeaderText = "दिनांक";
                        GridView1.Columns[4].HeaderText = "दस्तऐवज पाथ";
                        GridView1.Columns[5].HeaderText = "आकार";
                    }
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    pgCtr1.Visible = false;
                }


            }
            catch(Exception ex)
            {
            throw ex;
            }
            }


        protected void Page_PreRender(Object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
                GridView1.Columns[0].Visible = false;
                GridView1.Columns[1].Visible = false;
                GridView1.Columns[2].Visible = true;
                GridView1.Columns[2].HeaderText = "दस्तऐवज नाव";
                GridView1.Columns[3].HeaderText = "दिनांक";
                GridView1.Columns[4].HeaderText = "दस्तऐवज पाथ";
                GridView1.Columns[5].HeaderText = "आकार";
            }

            else
            {
                LangID = 1;

                GridView1.Columns[0].Visible = false;
                GridView1.Columns[1].Visible = true;
                GridView1.Columns[2].Visible = false;
                GridView1.Columns[1].HeaderText = "Document Name";
                GridView1.Columns[3].HeaderText = "Date";
                GridView1.Columns[4].HeaderText = "Document Path";
                GridView1.Columns[5].HeaderText = "Size";
            }



            GridBind(string.Empty);
            LoadDropdown();


            string DepartmentName = string.Empty;
            // lblCourtOrders.Text = GetResourceValue("General", "lblCourtOrders", "");

            lblFromDate.Text = GetResourceValue("General", "lblFromDate", "");
            lblToDate.Text = GetResourceValue("General", "lblToDate", "");

            btnSearchGR.Text = GetResourceValue("General", "btnSearch", "");


            lblTitelDownloads.Text = GetResourceValue("General", "lblTitelDownloads", "");

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameMarathi"].ToString();
                Page.Title = lblTitelDownloads.Text + "-" + DepartmentName;
            }
            else
            {
                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameEnglish"].ToString();
                Page.Title = lblTitelDownloads.Text + "-" + DepartmentName;
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
                if (LangID == 1)
                {
                    ddlDocumentType.SelectedItem.Text = "1d21a8f0-1a86-4ce8-a80b-aaf5efc54d20";     //Set By defalut laws By Laws
                    GridBind("where CONVERT(datetime,CreatedDate,103) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='" + ddlDocumentType.SelectedValue + "' and Flag='1' and LangID=1");
                }

                else
                {
                    ddlDocumentType.SelectedItem.Text = "7E67C436-73EF-4D3E-821B-AE8148DE22E1";     //Set By defalut laws By Laws
                    GridBind("where CONVERT(datetime,CreatedDate,103) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='" + ddlDocumentType.SelectedValue + "' and Flag='1' and LangID=1");
                }
            }
            else
            {
                GridBind(string.Empty);
            }


            if (txtFromDate.Text != string.Empty)
            {
                DateTime d1 = Convert.ToDateTime(txtFromDate.Text);
                DateTime d2 = Convert.ToDateTime(txtToDate.Text);
                //ddlDocumentType.SelectedValue = "C9179345-E344-4E9F-A554-6BDE4EEE5626";
                ddlDocumentType.SelectedItem.Text = "1d21a8f0-1a86-4ce8-a80b-aaf5efc54d20";     //Set By defalut laws By Laws
                GridBind("where CONVERT(datetime,CreatedDate,103) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' and DocumentType='" + ddlDocumentType.SelectedValue + "' and Flag='1'");
            }
            else
            {
                GridBind(string.Empty);
            }
        }


        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
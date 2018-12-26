using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Schema;

namespace RCA.Admin.MenuManagement
{
    public partial class CaseEntryForm : System.Web.UI.Page
    {
        #region Public variable declaration
        //BL.BL MAHAITDBAccess;
        DataSet ds;
        DataTable dt;
        DistrictDivisionBL ObjDistrictDivisionBL = new DistrictDivisionBL();
        DistrictDivisionSchema objDistrictDivisionSchema = new DistrictDivisionSchema();
        CaseDetailSchema objCaseDetailSchema = new CaseDetailSchema();
        CaseDetailBL objCaseDetailBL = new CaseDetailBL();
        int result = 0;
        int CaseID = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDivisionList();
                if (Convert.ToString(Request.QueryString["action"]) == "edit" && Request.QueryString["action"] != null)
                {
                    CaseID = Convert.ToInt32(Request.QueryString["ID"]);
                    try {
                        objCaseDetailSchema.CaseID = CaseID;
                        objCaseDetailSchema.ActionType = "Edit";
                        objCaseDetailSchema.CaseNo = string.Empty;
                        DataSet dseditcase;
                        DataTable dteditcase;
                        dseditcase = objCaseDetailBL.GetCaseListDetails(objCaseDetailSchema);
                        dteditcase = dseditcase.Tables[0];

                        if (dteditcase.Rows.Count > 0) {
                            txtCaseNo.Text = dteditcase.Rows[0]["CaseNo"].ToString();
                            txtCaseNo.Enabled = false;
                            drpDivsion.SelectedValue = dteditcase.Rows[0]["DivisionId"].ToString();
                            drpDivsion.Enabled = false;
                            BindDistrictList(dteditcase.Rows[0]["DivisionId"].ToString());
                            drpDistrict.SelectedValue = dteditcase.Rows[0]["DistrictId"].ToString();
                            drpDistrict.Enabled = false;

                            txtOpponent.Text = dteditcase.Rows[0]["OpponentName"].ToString();
                            txtOpponent.Enabled = false;
                            txtApplicant.Text = dteditcase.Rows[0]["ApplicantName"].ToString();
                            txtApplicant.Enabled = false;

                            txtStatus.Text = dteditcase.Rows[0]["CaseStatus"].ToString();
                            txtLastHearingDate.Text = dteditcase.Rows[0]["LastHearingDate"] != null ? dteditcase.Rows[0]["LastHearingDate"].ToString().Split(' ')[0].Trim() : string.Empty;
                            txtNextHearingDate.Text = dteditcase.Rows[0]["NextHearingDate"] != null ? dteditcase.Rows[0]["NextHearingDate"].ToString().Split(' ')[0].Trim() : string.Empty;

                            btnSave.Text = "Update";
                        }
                    }
                    catch(Exception ex) { throw ex; }
                }

                if (Convert.ToString(Request.QueryString["action"]) == "editupatedcase" && Request.QueryString["action"] != null)
                {
                    CaseID = Convert.ToInt32(Request.QueryString["ID"]);
                    try
                    {
                        objCaseDetailSchema.CaseID = CaseID;
                        objCaseDetailSchema.ActionType = "EditUpdatedCase";
                        objCaseDetailSchema.CaseNo = string.Empty;
                        DataSet dseditupdatecase;
                        DataTable dteditupdatecase;
                        dseditupdatecase = objCaseDetailBL.GetCaseListDetails(objCaseDetailSchema);
                        dteditupdatecase = dseditupdatecase.Tables[0];

                        if (dteditupdatecase.Rows.Count > 0)
                        {
                            txtCaseNo.Text = dteditupdatecase.Rows[0]["CaseNo"].ToString();
                            divcaseno.Style.Add("display","none");
                            drpDivsion.SelectedValue = dteditupdatecase.Rows[0]["DivisionId"].ToString();
                            
                            BindDistrictList(dteditupdatecase.Rows[0]["DivisionId"].ToString());
                            drpDistrict.SelectedValue = dteditupdatecase.Rows[0]["DistrictId"].ToString();
                            divcity.Style.Add("display", "none");

                            txtOpponent.Text = dteditupdatecase.Rows[0]["OpponentName"].ToString();
                            divopponent.Style.Add("display", "none");

                            txtApplicant.Text = dteditupdatecase.Rows[0]["ApplicantName"].ToString();
                            divapplicant.Style.Add("display", "none");

                            txtStatus.Text = dteditupdatecase.Rows[0]["CaseStatus"].ToString();
                            txtLastHearingDate.Text = dteditupdatecase.Rows[0]["LastHearingDate"] != null ? dteditupdatecase.Rows[0]["LastHearingDate"].ToString().Split(' ')[0].Trim() : string.Empty;
                            txtNextHearingDate.Text = dteditupdatecase.Rows[0]["NextHearingDate"] != null ? dteditupdatecase.Rows[0]["NextHearingDate"].ToString().Split(' ')[0].Trim() : string.Empty;

                            btnSave.Text = "Update";
                        }
                    }
                    catch (Exception ex) { throw ex; }
                }
            }
            
        }

        void Page_PreRender(Object o, EventArgs e)
        {
            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            btnBack.Text = _MahaITUC.GetResourceValue("Resource", "btnBack", "Case Entry");
            lblCaseNo.Text = _MahaITUC.GetResourceValue("Resource", "lblCaseNo", "Enter Case No");
            lblDivision.Text = _MahaITUC.GetResourceValue("Resource", "lblDivision", "Select Division");
            lblDistrict.Text = _MahaITUC.GetResourceValue("Common", "lblDistrict", "Select Division");
            lblApplicant.Text = _MahaITUC.GetResourceValue("Resource", "lblApplicant", "Enter Applicant Name");
            lblOpponent.Text = _MahaITUC.GetResourceValue("Resource", "lblOpponent", "Enter Opponent Name");
            lblStatus.Text = _MahaITUC.GetResourceValue("Resource", "lblStatus", "Enter Opponent Name");
            lblLastHearingDate.Text = _MahaITUC.GetResourceValue("Resource", "lblLastHearingDate", "Enter LastHearing Date");
            lblNextHearingDate.Text = _MahaITUC.GetResourceValue("Resource", "lblNextHearingDate", "Enter NextHearing Date");
            btnSave.Text = _MahaITUC.GetResourceValue("Common", "btnSave", "Save");
            btnCancel.Text = _MahaITUC.GetResourceValue("Common", "btnCancel", "Cancel");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try {
                if(drpDistrict.SelectedValue == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "message", "alert('Please Select District!!')", true);
                }
                else
                {
                    objCaseDetailSchema.CaseNo = txtCaseNo.Text.Trim();
                    objCaseDetailSchema.DivisionId = drpDivsion.SelectedItem.Value.Trim();
                    objCaseDetailSchema.DistrictId = drpDistrict.SelectedItem.Value.Trim();
                    objCaseDetailSchema.ApplicantName = txtApplicant.Text.Trim();
                    objCaseDetailSchema.OpponentName = txtOpponent.Text.Trim();
                    objCaseDetailSchema.CaseStatus = txtStatus.Text.Trim();
                    objCaseDetailSchema.LastHearingDate = Convert.ToDateTime(txtLastHearingDate.Text);
                    objCaseDetailSchema.NextHearingDate = Convert.ToDateTime(txtNextHearingDate.Text);
                    objCaseDetailSchema.CreatedDate = DateTime.Now;
                    objCaseDetailSchema.CreatedBy = Session["User"] != null ? Session["User"].ToString() : DBNull.Value.ToString();
                    objCaseDetailSchema.UpdatedBy = DBNull.Value.ToString();
                    objCaseDetailSchema.UpdatedDate = null;
                    objCaseDetailSchema.IsDelete = false;

                   
                    
                    if (Request.QueryString["action"] == "edit")
                    {
                        objCaseDetailSchema.UpdatedBy = Session["User"] != null ? Session["User"].ToString() : DBNull.Value.ToString();
                        objCaseDetailSchema.UpdatedDate = DateTime.Now;
                    }

                    if(Request.QueryString["action"] == "editupatedcase")
                    {
                        CaseID = Convert.ToInt32(Request.QueryString["ID"]);
                        objCaseDetailSchema.CaseID = CaseID;
                        objCaseDetailSchema.CaseStatus = txtStatus.Text.Trim();
                        objCaseDetailSchema.NextHearingDate = Convert.ToDateTime(txtNextHearingDate.Text);
                        objCaseDetailSchema.LastHearingDate = Convert.ToDateTime(txtLastHearingDate.Text);
                        objCaseDetailSchema.UpdatedBy = Session["User"] != null ? Session["User"].ToString() : DBNull.Value.ToString();
                        objCaseDetailSchema.UpdatedDate = DateTime.Now;

                       int resultupdatecase = objCaseDetailBL.UpdateCaseDetails(objCaseDetailSchema);
                       if(resultupdatecase > 0) {
                            if(Request.QueryString["action"] == "editupatedcase") { ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Data updated Successfully !!!');window.location.href='UpdatedCaseList.aspx'", true); }
                        }
                    }

                    DataSet dsexistCaseNo = objCaseDetailBL.CheckIsCaseExist(objCaseDetailSchema);
                    if (dsexistCaseNo.Tables[0].Rows.Count == 0 || Request.QueryString["action"] == "edit")
                    {
                        result = objCaseDetailBL.SaveCaseDetails(objCaseDetailSchema);
                        if (result != 0)
                        {
                            if (Request.QueryString["action"] == "edit") { ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Data updated Successfully !!!');window.location.href='UpdatedCaseList.aspx'", true); }
                            else { ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Data saved Successfully !!!');window.location.href='CaseList.aspx'", true); }

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Error !!!')", true);
                        }
                    }
                    else if(dsexistCaseNo.Tables[0].Rows.Count > 0 && Request.QueryString["action"] == null)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Record with provided CaseNo is already Exist, Kindly do update the case to make any change.');window.location.href='CaseList.aspx'", true);
                    }
                        
                    
                }
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if(Convert.ToString(Request.QueryString["action"]) == "edit" && Request.QueryString["action"] != null) {
                Response.Redirect("CaseList.aspx");
            }
            else if(Convert.ToString(Request.QueryString["action"]) == "editupatedcase" && Request.QueryString["action"] != null)
            {
                Response.Redirect("UpdatedCaseList.aspx");
            }
            else
            {
                Response.Redirect("CaseList.aspx");
            }
        }

        private void BindDivisionList()
        {
            try
            {
                ds = ObjDistrictDivisionBL.GetDivisionList();
                dt = ds.Tables[0];
                drpDivsion.DataSource = dt.DefaultView;
                drpDivsion.DataBind();
                drpDivsion.Items.Insert(0, new ListItem("Select", "0"));
                drpDivsion.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void drpDivsion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictList(drpDivsion.SelectedItem.Value);
        }

        private void BindDistrictList(string Parent)
        {
            try
            {
                drpDistrict.Items.Clear();
                objDistrictDivisionSchema.DivisionId = Parent.Trim();
                ds = ObjDistrictDivisionBL.GetDistrictList(objDistrictDivisionSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    drpDistrict.DataSource = dt.DefaultView;
                    drpDistrict.DataBind();
                    drpDistrict.Items.Insert(0, new ListItem("Select", "0"));
                    drpDistrict.SelectedValue = "0";
                }
                else {
                    drpDistrict.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
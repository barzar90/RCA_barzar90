using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Helper;
using BL;

namespace MSHC.Admin.MenuManagement
{
    public partial class AddQuickMenuContent : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;
        string Sqlquery;
        string menuID, status, Quickid;
        string _MID;
        DataTable DTt;

        public string MID
        {
            get { return _MID; }
            set { _MID = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MID = Request.QueryString["MenuID"];
                if (Request.QueryString["status"] == "Edit" && Request.QueryString["SendContentID"] != null)
                {
                    Quickid = Request.QueryString["SendContentID"];

                    SqlCommand sqlcmd_DTt = new SqlCommand();
                    sqlcmd_DTt.Parameters.Add("@QuickContentID", SqlDbType.Int);
                    sqlcmd_DTt.Parameters["@QuickContentID"].Value = Quickid;

                    sqlcmd_DTt.CommandText = @"Select * from MOLQuickMenuContent where QuickContentID=@QuickContentID and DeleteStatus=0";
                    DTt = MAHAITDBAccess.ExecuteDataSet(sqlcmd_DTt).Tables[0];
                    if (DTt != null)
                    {
                        if (DTt.Rows.Count > 0)
                        {
                            txtPageTitle.Text = DTt.Rows[0]["PageTitle"].ToString();
                            txtpageTitle_LL.Text = DTt.Rows[0]["PageTitle_LL"].ToString();
                            txtSequenceNo.Text = DTt.Rows[0]["SequenceNo"].ToString();
                            FCKeditor1.Value = DTt.Rows[0]["ShortDescription"].ToString();
                            FCKeditor2.Value = DTt.Rows[0]["ShortDescription_LL"].ToString();
                            FCKeditor3.Value = DTt.Rows[0]["LongDescription"].ToString();
                            FCKeditor4.Value = DTt.Rows[0]["LongDescription_LL"].ToString();

                            if (Convert.ToString(DTt.Rows[0]["IsApprove"]) == "True")
                            {
                                chkIsApprove.Checked = true;
                            }
                            else
                            {
                                chkIsApprove.Checked = false;
                            }

                            if (Convert.ToString(DTt.Rows[0]["Active"]) == "True")
                            {
                                chkActive.Checked = true;
                            }
                            else
                            {
                                chkActive.Checked = false;
                            }
                        }

                    }
                }
            }
        }
        private void Clear()
        {
            txtPageTitle.Text = "";
            txtSequenceNo.Text = "";
            FCKeditor1.Value = "";
            FCKeditor2.Value = "";
            FCKeditor3.Value = "";
            FCKeditor4.Value = "";
            txtpageTitle_LL.Text = "";


        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            SqlCommand sql_cmd = new SqlCommand();

            if (Request.QueryString["status"] == "Edit")
            {
                menuID = Request.QueryString["shvid"];
                Quickid = Request.QueryString["SendContentID"];
            }
            else
            {
                menuID = Request.QueryString["shvid"];
            }

            try
            {

                if (CommonFuntion.IsValid(txtPageTitle.Text) && CommonFuntion.IsValid(FCKeditor1.Value) && CommonFuntion.IsValid(FCKeditor2.Value) && CommonFuntion.IsValid(FCKeditor3.Value) && CommonFuntion.IsValid(FCKeditor4.Value))
                {

                    sql_cmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar);
                    sql_cmd.Parameters["@PageTitle"].Value = txtPageTitle.Text;

                    sql_cmd.Parameters.Add("@PageTitle_LL", SqlDbType.NVarChar);
                    sql_cmd.Parameters["@PageTitle_LL"].Value = txtpageTitle_LL.Text;

                    sql_cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar);
                    sql_cmd.Parameters["@ShortDescription"].Value = FCKeditor1.Value;

                    sql_cmd.Parameters.Add("@ShortDescription_LL", SqlDbType.NVarChar);
                    sql_cmd.Parameters["@ShortDescription_LL"].Value = FCKeditor2.Value;

                    sql_cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar);
                    sql_cmd.Parameters["@LongDescription"].Value = FCKeditor3.Value;

                    sql_cmd.Parameters.Add("@LongDescription_LL", SqlDbType.NVarChar);
                    sql_cmd.Parameters["@LongDescription_LL"].Value = FCKeditor4.Value;

                    sql_cmd.Parameters.Add("@SequenceNo", SqlDbType.Int);
                    sql_cmd.Parameters["@SequenceNo"].Value = txtSequenceNo.Text;

                    sql_cmd.Parameters.Add("@QuickMenuID", SqlDbType.Int);
                    sql_cmd.Parameters["@QuickMenuID"].Value = menuID;

                    sql_cmd.Parameters.Add("@IsApprove", SqlDbType.Bit);
                    sql_cmd.Parameters["@IsApprove"].Value = chkIsApprove.Checked;

                    sql_cmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                    sql_cmd.Parameters["@IsActive"].Value = chkActive.Checked;

                    if (Request.QueryString["status"] == "Edit")
                    {

                        sql_cmd.Parameters.Add("@QuickContentID", SqlDbType.Int);
                        sql_cmd.Parameters["@QuickContentID"].Value = Quickid;

                        sql_cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar);
                        sql_cmd.Parameters["@UpdatedBy"].Value = DBNull.Value;

                        Sqlquery = @"Update MOLQuickMenuContent SET PageTitle=@PageTitle,PageTitle_LL=@PageTitle_LL,
                                ShortDescription=@ShortDescription, ShortDescription_LL=@ShortDescription_LL, LongDescription=@LongDescription,IsApprove=@IsApprove,
                                LongDescription_LL=@LongDescription_LL,SequenceNo=@SequenceNo,QuickMenuID=@QuickMenuID,UpdatedBy=@UpdatedBy,UpdatedOn=getdate(),Active=@IsActive where QuickContentID=@QuickContentID ";

                    }

                    else
                    {
                        sql_cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                        sql_cmd.Parameters["@CreatedBy"].Value = DBNull.Value;


                        Sqlquery = @"Declare @QuickContentID int;
                                Select @QuickContentID = ISNULL(MAX(QuickContentID),'1000')+1 From MOLQuickMenuContent
                                Insert INTO MOLQuickMenuContent (QuickContentID,QuickMenuID,PageTitle,PageTitle_LL,ShortDescription,ShortDescription_LL,LongDescription,LongDescription_LL,SequenceNo,
                                            CreatedOn,CreatedBy,Active,DeleteStatus,IsApprove)
                                Values(@QuickContentID,@QuickMenuID,@PageTitle,@PageTitle_LL,@ShortDescription,@ShortDescription_LL,@LongDescription,@LongDescription_LL,@SequenceNo,getdate(),@CreatedBy,@IsActive,0,@IsApprove)";

                    }
                    sql_cmd.CommandText = Sqlquery;

                    if (MAHAITDBAccess.ExecuteNonQuery(sql_cmd) != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Data Saved Successfully');window.location.href='QuickMenuContentList.aspx?shvid=" + Request.QueryString["shvid"] + "&MenuID=" + menuID + "';", true);
                        Clear();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Error in Saving Data');", true);
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('We are not allowing [script|body|embed|object|frameset|frame|iframe|meta|link|style|input|javascript] and allowed only these charactor [<>;:\\-.,?!@\\$%#*+=/]  !!!');", true);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MenuManagement/QuickMenuContentList.aspx?shvid=" + Request.QueryString["shvid"] + "&MenuID=" + MID);
        }

    }
}
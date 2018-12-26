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
    public partial class QuickMenu : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;
        string valueid;
        string valuepid;
        string valuemID;
        string InsertQuery;

        protected void Page_Init(object sender, EventArgs args)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindParentDropDown();
                BindMenuType();

                #region For edit


                if (Convert.ToString(Request.QueryString["action"]) == "edit" && Request.QueryString["action"] != null)
                {
                    valueid = Request.QueryString["shvid"];
                    valuepid = Request.QueryString["pid"];

                    try
                    {
                        DataTable t_dt;

                        SqlCommand t_SQLCmd = new SqlCommand();
                        SqlCommand t_SQLCmd1 = new SqlCommand();
                        t_SQLCmd.Parameters.Add("@QuickMenuID", SqlDbType.Int);
                        t_SQLCmd.Parameters["@QuickMenuID"].Value = valueid;


                        string MenuID = GetQuickMenuID(valuepid);

                        if (MenuID != "0")
                        {
                            drpQuickMenu.SelectedValue = MenuID;
                            BindChildDropDown(MenuID);
                            drpSubQuickMenu.SelectedValue = valuepid;
                            drpSubQuickMenu.Visible = true;
                        }
                        else
                        {
                            drpQuickMenu.SelectedValue = valuepid;
                            drpSubQuickMenu.Visible = false;

                        }


                        t_SQLCmd.CommandText = @"Select * From MOLQuickMenuMaster  where QuickMenuID=@QuickMenuID and DeleteStatus=0 ";
                        t_dt = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];
                        if (t_dt.Rows.Count > 0)
                        {
                            txtMenuName.Text = t_dt.Rows[0]["QuickMenuName"].ToString();
                            txtMenuName_LL.Text = t_dt.Rows[0]["QuickMenuName_LL"].ToString();
                            txtMDesc.Text = t_dt.Rows[0]["MetaDescription"].ToString();
                            txtMDesc_LL.Text = t_dt.Rows[0]["MetaDescription_LL"].ToString();

                            txtPageHead.Text = t_dt.Rows[0]["PageHeading"].ToString();
                            txtPageHead_LL.Text = t_dt.Rows[0]["PageHeading_LL"].ToString();


                            txtMKeywords.Text = t_dt.Rows[0]["MetaKeywords"].ToString();

                            txtMKeyWords_LL.Text = t_dt.Rows[0]["MetaKeywords_LL"].ToString();
                            txtSequence.Text = t_dt.Rows[0]["SequenceNo"].ToString();

                            txtMTValue.Text = t_dt.Rows[0]["MenuTypeValue"].ToString();
                            drpMenuType.SelectedValue = t_dt.Rows[0]["MenuType"].ToString();

                            if (Convert.ToString(t_dt.Rows[0]["IsNewFlag"]) == "True")
                            {
                                chkIsNew.Checked = true;
                            }
                            else
                            {
                                chkIsNew.Checked = false;
                            }

                            if (Convert.ToString(t_dt.Rows[0]["Active"]) == "True")
                            {
                                chkActive.Checked = true;
                            }
                            else
                            {
                                chkActive.Checked = false;
                            }

                            if (Convert.ToString(t_dt.Rows[0]["IsExternalLink"]) == "True")
                            {
                                chkNewTab.Checked = true;
                            }
                            else
                            {
                                chkNewTab.Checked = false;
                            }


                            if (Convert.ToString(t_dt.Rows[0]["ForMobileVersion"]) == "True")
                            {
                                chkmobileversion.Checked = true;
                            }
                            else
                            {
                                chkmobileversion.Checked = false;
                            }


                        }

                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion
            }
        }

        private void BindMenuType()
        {
            try
            {
                DataTable t_dt;

                SqlCommand t_SQLCmd = new SqlCommand();
                t_SQLCmd.CommandText = @"SELECT RowID,MenuType FROM MOLMenuType WHERE  DeleteStatus=0 and Active=1";
                t_dt = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];

                drpMenuType.DataSource = t_dt.DefaultView;
                drpMenuType.DataBind();

                drpMenuType.Items.Insert(0, new ListItem("Select", "0"));
                drpMenuType.SelectedValue = "0";
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        private void BindParentDropDown()
        {
            try
            {
                DataTable t_dt;

                SqlCommand t_SQLCmd = new SqlCommand();
                t_SQLCmd.Parameters.Add("@MenuID", SqlDbType.Int);
                t_SQLCmd.Parameters["@MenuID"].Value = Request.QueryString["MenuID"];

                t_SQLCmd.CommandText = @"Select QuickMenuID,QuickMenuName FROM MOLQuickMenuMaster WHERE ParentID=0 and DeleteStatus=0  and MenuID=@MenuID";
                t_dt = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];

                drpQuickMenu.DataSource = t_dt.DefaultView;
                drpQuickMenu.DataBind();

                drpQuickMenu.Items.Insert(0, new ListItem("Select", "0"));
                drpQuickMenu.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindChildDropDown(string Parent)
        {
            try
            {
                drpSubQuickMenu.Items.Clear();

                DataTable t_dt;

                SqlCommand t_SQLCmd = new SqlCommand();

                t_SQLCmd.Parameters.Add("@QuickMenuID", SqlDbType.Int);
                t_SQLCmd.Parameters["@QuickMenuID"].Value = Parent;
                t_SQLCmd.CommandText = @"SELECT QuickMenuID,QuickMenuName FROM MOLQuickMenuMaster WHERE ParentID=@QuickMenuID and ParentID!=0 and DeleteStatus=0 ";

                t_dt = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];
                if (t_dt.Rows.Count > 0)
                {
                    drpSubQuickMenu.DataSource = t_dt.DefaultView;
                    drpSubQuickMenu.DataBind();
                    drpSubQuickMenu.Items.Insert(0, new ListItem("Select", "0"));
                    drpSubQuickMenu.SelectedValue = "0";
                    drpSubQuickMenu.Visible = true;
                }
                else
                {
                    drpSubQuickMenu.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region for edit
        private string GetQuickMenuID(string valuepid)
        {
            DataTable t_dt1;

            SqlCommand t_SQLCmd1 = new SqlCommand();
            t_SQLCmd1.Parameters.Add("@ParentID", SqlDbType.Int);
            t_SQLCmd1.Parameters["@ParentID"].Value = valuepid;

            if (valuepid == "0")
            {
                t_SQLCmd1.CommandText = @"Select ParentID,QuickMenuID From MOLQuickMenuMaster where ParentID=@ParentID and DeleteStatus=0";
                drpQuickMenu.Visible = false;
                Label1.Visible = false;

            }
            else
            {
                t_SQLCmd1.CommandText = @"Select ParentID,QuickMenuID From MOLQuickMenuMaster where QuickMenuID=@ParentID and DeleteStatus=0";
            }

            t_dt1 = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd1).Tables[0];
            if (t_dt1.Rows.Count > 0)
            {
                return t_dt1.Rows[0]["ParentID"].ToString();
            }
            else
            {
                return "0";
            }
        }

        #endregion

        protected void drpMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChildDropDown(drpQuickMenu.SelectedValue);
        }

        protected void drpMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!drpMenuType.Items.FindByText("Select").Selected)
                {
                    if (!drpMenuType.Items.FindByText("Link").Selected)
                    {
                        GetPageUrl(drpMenuType.SelectedValue);
                    }
                    else
                    {
                        txtMTValue.Text = "";
                        txtMTValue.Enabled = true;
                    }
                }
                else
                {
                    Alert("Please select the Menu Type");
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void GetPageUrl(string RowId)
        {
            try
            {
                DataTable dt;

                SqlCommand t_SQLCmd = new SqlCommand();
                t_SQLCmd.CommandText = @"SELECT RowID,PageUrl,MenuType FROM MOLMenuType WHERE  DeleteStatus=0 and Active=1 and RowID='" + RowId + "'";
                dt = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];

                if (dt.Rows.Count == 1)
                {
                    txtMTValue.Text = dt.Rows[0]["PageUrl"].ToString();
                    txtMTValue.Enabled = false;
                }

            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        private void Alert(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + msg + "');", true);
        }

        private void Clear()
        {
            txtMDesc.Text = "";
            txtMenuName.Text = "";
            txtMKeywords.Text = "";
            txtSequence.Text = "";
            drpQuickMenu.SelectedValue = "0";
            txtMDesc_LL.Text = "";
            txtMenuName_LL.Text = "";
            txtMKeyWords_LL.Text = "";

            if (drpQuickMenu.SelectedValue != "0")
            {
                drpSubQuickMenu.SelectedValue = "0";
            }

            chkIsNew.Checked = false;

            txtMTValue.Text = "";
            if (drpMenuType.SelectedValue != "0")
            {
                drpMenuType.SelectedValue = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand t_SQLCmd = new SqlCommand();

                byte[] t_Image = new byte[fileMenu.PostedFile.ContentLength];
                HttpPostedFile t_ImageReader = fileMenu.PostedFile;

                t_ImageReader.InputStream.Read(t_Image, 0, (int)fileMenu.PostedFile.ContentLength);

                t_SQLCmd.Parameters.Add("@QuickMenuName", SqlDbType.NVarChar);
                t_SQLCmd.Parameters["@QuickMenuName"].Value = txtMenuName.Text;

                t_SQLCmd.Parameters.Add("@QuickMenuName_LL", SqlDbType.NVarChar);

                if (txtMenuName_LL.Text == null)
                {
                    t_SQLCmd.Parameters["@QuickMenuName_LL"].Value = DBNull.Value;
                }
                else
                {
                    t_SQLCmd.Parameters["@QuickMenuName_LL"].Value = txtMenuName_LL.Text;
                }

                t_SQLCmd.Parameters.Add("@IsNewFlag", SqlDbType.Bit);
                t_SQLCmd.Parameters["@IsNewFlag"].Value = chkIsNew.Checked;

                t_SQLCmd.Parameters.Add("@Active", SqlDbType.Bit);
                t_SQLCmd.Parameters["@Active"].Value = chkActive.Checked;

                t_SQLCmd.Parameters.Add("@IsExternalLink", SqlDbType.Bit);
                t_SQLCmd.Parameters["@IsExternalLink"].Value = chkNewTab.Checked;

                t_SQLCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar);
                t_SQLCmd.Parameters["@MetaDescription"].Value = txtMDesc.Text;

                t_SQLCmd.Parameters.Add("@MetaDescription_LL", SqlDbType.NVarChar);

                if (txtMDesc_LL.Text == null)
                {
                    t_SQLCmd.Parameters["@MetaDescription_LL"].Value = DBNull.Value;
                }
                else
                {
                    t_SQLCmd.Parameters["@MetaDescription_LL"].Value = txtMDesc_LL.Text;
                }

                t_SQLCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar);
                t_SQLCmd.Parameters["@MetaKeywords"].Value = txtMKeywords.Text;

                t_SQLCmd.Parameters.Add("@MetaKeywords_LL", SqlDbType.NVarChar);

                if (txtMKeyWords_LL.Text == null)
                {
                    t_SQLCmd.Parameters["@MetaKeywords_LL"].Value = DBNull.Value;
                }
                else
                {
                    t_SQLCmd.Parameters["@MetaKeywords_LL"].Value = txtMKeyWords_LL.Text;
                }

                t_SQLCmd.Parameters.Add("@QuickMenuImage", SqlDbType.Image);
                t_SQLCmd.Parameters["@QuickMenuImage"].Value = t_Image;

                t_SQLCmd.Parameters.Add("@SequenceNo", SqlDbType.Int);
                t_SQLCmd.Parameters["@SequenceNo"].Value = txtSequence.Text;

                t_SQLCmd.Parameters.Add("@MenuType", SqlDbType.Int);
                t_SQLCmd.Parameters["@MenuType"].Value = Convert.ToInt32(drpMenuType.SelectedValue);

                t_SQLCmd.Parameters.Add("@MenuTypeValue", SqlDbType.NVarChar);
                t_SQLCmd.Parameters["@MenuTypeValue"].Value = txtMTValue.Text;


                if (drpQuickMenu.SelectedValue != "0" && drpQuickMenu.SelectedValue != "")
                {
                    if (drpSubQuickMenu.SelectedValue != "0" && drpSubQuickMenu.SelectedValue.Trim() != "")
                    {
                        t_SQLCmd.Parameters.Add("@ParentID", SqlDbType.Int);
                        t_SQLCmd.Parameters["@ParentID"].Value = drpSubQuickMenu.SelectedValue;
                    }
                    else
                    {
                        t_SQLCmd.Parameters.Add("@ParentID", SqlDbType.Int);
                        t_SQLCmd.Parameters["@ParentID"].Value = drpQuickMenu.SelectedValue;
                    }

                }
                else
                {
                    t_SQLCmd.Parameters.Add("@ParentID", SqlDbType.Int);
                    t_SQLCmd.Parameters["@ParentID"].Value = drpQuickMenu.SelectedValue;
                }

                t_SQLCmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier);
                t_SQLCmd.Parameters["@RoleID"].Value = DBNull.Value;

                if (Request.QueryString["action"] == "edit")
                {
                    t_SQLCmd.Parameters.Add("@UpdatedBy", SqlDbType.Int);
                    t_SQLCmd.Parameters["@UpdatedBy"].Value = DBNull.Value;

                    //t_SQLCmd.Parameters.Add("@UpdatedOn", SqlDbType.Int);
                    //t_SQLCmd.Parameters["@UpdatedBy"].Value = DBNull.Value;
                }
                else
                {
                    t_SQLCmd.Parameters.Add("@CreatedBy", SqlDbType.Int);
                    t_SQLCmd.Parameters["@CreatedBy"].Value = DBNull.Value;
                }



                t_SQLCmd.Parameters.Add("@MenuID", SqlDbType.Int);
                t_SQLCmd.Parameters["@MenuID"].Value = Request.QueryString["MenuID"];


                t_SQLCmd.Parameters.Add("@PageHeading", SqlDbType.NVarChar);
                t_SQLCmd.Parameters["@PageHeading"].Value = txtPageHead.Text;

                t_SQLCmd.Parameters.Add("@PageHeading_LL", SqlDbType.NVarChar);
                if (txtPageHead_LL.Text == null)
                {
                    t_SQLCmd.Parameters["@PageHeading_LL"].Value = DBNull.Value;
                }
                else
                {
                    t_SQLCmd.Parameters["@PageHeading_LL"].Value = txtPageHead_LL.Text;
                }


                t_SQLCmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar);
                t_SQLCmd.Parameters["@PageTitle"].Value = txtPageTitle.Text;

                t_SQLCmd.Parameters.Add("@PageTitle_LL", SqlDbType.NVarChar);
                if (txtPageTitle_LL.Text == null)
                {
                    t_SQLCmd.Parameters["@PageTitle_LL"].Value = DBNull.Value;
                }
                else
                {
                    t_SQLCmd.Parameters["@PageTitle_LL"].Value = txtPageTitle_LL.Text;
                }


                t_SQLCmd.Parameters.Add("@ForMobileVersion", SqlDbType.Bit);
                t_SQLCmd.Parameters["@ForMobileVersion"].Value = chkmobileversion.Checked;


                if (Request.QueryString["action"] == "edit")
                {
                    valueid = Request.QueryString["shvid"];
                    t_SQLCmd.Parameters.Add("@QuickMenuID", SqlDbType.Int);
                    t_SQLCmd.Parameters["@QuickMenuID"].Value = valueid;

                    if (fileMenu.HasFile)
                    {
                        string fileext = System.IO.Path.GetExtension(fileMenu.FileName);
                        if (fileext == ".jpeg" || fileext == ".JPEG" || fileext == ".png" || fileext == ".bmp" || fileext == ".tiff")
                        {

                            InsertQuery = @"Update MOLQuickMenuMaster set 
                                   QuickMenuName=@QuickMenuName,QuickMenuName_LL=@QuickMenuName_LL,IsNewFlag=@IsNewFlag,MetaDescription=@MetaDescription,
                                   MetaDescription_LL=@MetaDescription_LL,MetaKeywords=@MetaKeywords,MetaKeywords_LL=@MetaKeywords_LL,QuickMenuImage=@QuickMenuImage,
                                   SequenceNo=@SequenceNo,ParentID=@ParentID,RoleID=@RoleID,UpdatedBy=@UpdatedBy,UpdatedOn=getdate(),MenuID=@MenuID,
                                   MenuType=@MenuType,MenuTypeValue=@MenuTypeValue,Active=@Active,IsExternalLink=@IsExternalLink,PageHeading=@PageHeading,PageHeading_LL=@PageHeading_LL,PageTitle=@PageTitle,PageTitle_LL=@PageTitle_LL,ForMobileVersion=@ForMobileVersion
                                    Where QuickMenuID=@QuickMenuID ";
                            t_SQLCmd.CommandText = InsertQuery;

                            if (MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd) != 0)
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='QuickMenuList.aspx?shvid=" + Request.QueryString["shvid"] + "&pid=" + Request.QueryString["pid"] + "&MenuID=" + Request.QueryString["MenuID"] + "';", true);
                                Clear();
                                lblmsg.Text = "";
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error !!!')", true);
                            }


                        }
                        else
                        {
                            lblmsg.Text = "Upload Image file only";
                        }
                    }
                    else
                    {
                        InsertQuery = @"Update MOLQuickMenuMaster set 
                                   QuickMenuName=@QuickMenuName,QuickMenuName_LL=@QuickMenuName_LL,IsNewFlag=@IsNewFlag,MetaDescription=@MetaDescription,
                                   MetaDescription_LL=@MetaDescription_LL,MetaKeywords=@MetaKeywords,MetaKeywords_LL=@MetaKeywords_LL,
                                   SequenceNo=@SequenceNo,ParentID=@ParentID,RoleID=@RoleID,UpdatedBy=@UpdatedBy,UpdatedOn=getdate(),MenuID=@MenuID,
                                   MenuType=@MenuType,MenuTypeValue=@MenuTypeValue,Active=@Active,IsExternalLink=@IsExternalLink,PageHeading=@PageHeading,PageHeading_LL=@PageHeading_LL,PageTitle=@PageTitle,PageTitle_LL=@PageTitle_LL,ForMobileVersion=@ForMobileVersion
                                     Where QuickMenuID=@QuickMenuID ";
                        t_SQLCmd.CommandText = InsertQuery;

                        if (MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd) != 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='QuickMenuList.aspx?shvid=" + Request.QueryString["shvid"] + "&pid=" + Request.QueryString["pid"] + "&MenuID=" + Request.QueryString["MenuID"] + "';", true);
                            Clear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error !!!')", true);
                        }
                    }

                }
                else
                {
                    if (fileMenu.HasFile)
                    {
                        string fileext = System.IO.Path.GetExtension(fileMenu.FileName);
                        if (fileext == ".jpeg" || fileext == ".jpg" || fileext == ".png" || fileext == ".bmp" || fileext == ".tiff")
                        {
                            InsertQuery = @"Declare @QuickMenuID int;
                                SELECT @QuickMenuID=ISNULL(Max(QuickMenuID),'1000')+1 from MOLQuickMenuMaster
                                INSERT INTO MOLQuickMenuMaster(QuickMenuID,QuickMenuName,QuickMenuName_LL,IsNewFlag,MetaDescription,MetaDescription_LL,
                                MetaKeywords,MetaKeywords_LL,QuickMenuImage,SequenceNo,ParentID,RoleID,CreatedBy,CreatedOn,Active,DeleteStatus,MenuID,MenuType,MenuTypeValue,IsExternalLink,PageHeading,PageHeading_LL,PageTitle,PageTitle_LL,ForMobileVersion)
                                VALUES(@QuickMenuID,@QuickMenuName,@QuickMenuName_LL,@IsNewFlag,@MetaDescription,@MetaDescription_LL,
                                @MetaKeywords,@MetaKeywords_LL,@QuickMenuImage,@SequenceNo,@ParentID,@RoleID,@CreatedBy,getdate(),@Active,0,@MenuID,@MenuType,@MenuTypeValue,@IsExternalLink,@PageHeading,@PageHeading_LL,@PageTitle,@PageTitle_LL,@ForMobileVersion)";

                            t_SQLCmd.CommandText = InsertQuery;

                            if (MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd) != 0)
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='QuickMenuList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true);
                                Clear();
                                lblmsg.Text = "";
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error !!!')", true);
                            }
                        }
                        else
                        {
                            lblmsg.Text = "Upload Image file only";
                        }
                    }
                    else
                    {
                        InsertQuery = @"Declare @QuickMenuID int;
                                SELECT @QuickMenuID=ISNULL(Max(QuickMenuID),'1000')+1 from MOLQuickMenuMaster
                                INSERT INTO MOLQuickMenuMaster(QuickMenuID,QuickMenuName,QuickMenuName_LL,IsNewFlag,MetaDescription,MetaDescription_LL,
                                MetaKeywords,MetaKeywords_LL,QuickMenuImage,SequenceNo,ParentID,RoleID,CreatedBy,CreatedOn,Active,DeleteStatus,MenuID,MenuType,MenuTypeValue,IsExternalLink,PageHeading,PageHeading_LL,PageTitle,PageTitle_LL,ForMobileVersion)
                                VALUES(@QuickMenuID,@QuickMenuName,@QuickMenuName_LL,@IsNewFlag,@MetaDescription,@MetaDescription_LL,
                                @MetaKeywords,@MetaKeywords_LL,@QuickMenuImage,@SequenceNo,@ParentID,@RoleID,@CreatedBy,getdate(),@Active,0,@MenuID,@MenuType,@MenuTypeValue,@IsExternalLink,@PageHeading,@PageHeading_LL,@PageTitle,@PageTitle_LL,@ForMobileVersion)";

                        t_SQLCmd.CommandText = InsertQuery;

                        if (MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd) != 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='QuickMenuList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true);
                            Clear();
                            lblmsg.Text = "";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error !!!')", true);
                        }
                    }
                }
                Alert("Data Saved Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
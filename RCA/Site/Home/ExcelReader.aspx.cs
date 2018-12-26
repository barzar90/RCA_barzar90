using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using BL;

namespace MSHC.Site.Home
{
    public partial class ExcelReader : System.Web.UI.Page
    {

        BL.BL MAHAITDBAccess;
        SqlCommand Command;
        OleDbCommand cmd;
        DataSet objDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string path = string.Concat(Server.MapPath("~/ExcelFiles/UCB-Subject-to-Audit.xlsx"));

                string path2 = string.Concat(Server.MapPath("~/ExcelFiles/banks-in-liquidation.xlsx"));


                MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;

                List<string> List = new List<string>();
                List.Add("[summary$]");
                List.Add("[ALL UCBS$]");
                objDs = new DataSet();
                GridView gb;
                foreach (string query in List)
                {
                    string strSQL = "SELECT * FROM " + query;
                    cmd = new OleDbCommand(strSQL);
                    objDs = MAHAITDBAccess.ExecuteDataSet(cmd, path);

                    gb = new GridView();
                    gb.DataSource = objDs; //SelectTopDataRow(ds.Tables[counter], count + 1);
                    gb.DataBind();
                    phGridView.Controls.Add(gb);
                    phGridView.Controls.Add(new LiteralControl("<br/>"));
                }

                List<string> List1 = new List<string>();
                List1.Add("[2010-11$]");
                List1.Add("[2011-12$]");

                foreach (string query in List1)
                {
                    string strSQL = "SELECT * FROM " + query;
                    cmd = new OleDbCommand(strSQL);
                    objDs = MAHAITDBAccess.ExecuteDataSet(cmd, path2);

                    gb = new GridView();
                    gb.DataSource = objDs; //SelectTopDataRow(ds.Tables[counter], count + 1);
                    gb.DataBind();
                    phGridView.Controls.Add(gb);
                    phGridView.Controls.Add(new LiteralControl("<br/>"));
                }
            }
            catch (Exception ee)
            {
                string msg = ee.Message;
            }
            finally
            {
            }
        }
    }
}
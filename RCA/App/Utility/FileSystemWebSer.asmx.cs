using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using BL;

namespace MSHC.WebServices.Utility
{
    /// <summary>
    /// Summary description for FileSystemWebSer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FileSystemWebSer : MAHAITWebServices
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] BindCategory(string knownCategoryValues, string category)
        {
            DataTable t_DT;
            //t_DT = MOLDBAccess.GetCascadingDropDowns("MOLFileCategory", "fileType", "FileTypeValue", null, null, null, null);
            t_DT = MAHAITDBAccess.GetFile();
            List<AjaxControlToolkit.CascadingDropDownNameValue> Categorydetails = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (DataRow dtrow in t_DT.Rows)
            {
                string CategoryCode = dtrow["FileTypeValue"].ToString();
                string Categoryname = dtrow["fileType"].ToString();
                Categorydetails.Add(new AjaxControlToolkit.CascadingDropDownNameValue(Categoryname, CategoryCode));
            }
            return Categorydetails.ToArray();
        }


        [WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] BindSubCategory(string knownCategoryValues, string category)
        {
            DataTable t_DT;
            //t_DT = MOLDBAccess.GetCascadingDropDowns("MOLFileCategory", "fileType", "FileTypeValue", null, null, null, null);
            t_DT = MAHAITDBAccess.GetSubCategory();
            List<AjaxControlToolkit.CascadingDropDownNameValue> Categorydetails = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (DataRow dtrow in t_DT.Rows)
            {
                string CategoryCode = dtrow["SubCatID"].ToString();
                string Categoryname = dtrow["SubCat"].ToString();
                Categorydetails.Add(new AjaxControlToolkit.CascadingDropDownNameValue(Categoryname, CategoryCode));
            }
            return Categorydetails.ToArray();
        }

        [WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] BindLevel(string knownCategoryValues, string category)
        {
            DataTable t_DT;
            //t_DT = MOLDBAccess.GetCascadingDropDowns("MOLFileCategory", "fileType", "FileTypeValue", null, null, null, null);
            t_DT = MAHAITDBAccess.GetLevel();
            List<AjaxControlToolkit.CascadingDropDownNameValue> Categorydetails = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (DataRow dtrow in t_DT.Rows)
            {
                string CategoryCode = dtrow["LevelID"].ToString();
                string Categoryname = dtrow["LevelName"].ToString();
                Categorydetails.Add(new AjaxControlToolkit.CascadingDropDownNameValue(Categoryname, CategoryCode));
            }
            return Categorydetails.ToArray();
        }

        [WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] BindRegions(string knownCategoryValues, string category)
        {
            if (knownCategoryValues == "") return null;

            DataTable t_DT;
            //t_DT = MOLDBAccess.GetCascadingDropDowns("MOLFileCategory", "fileType", "FileTypeValue", null, null, null, null);
            string[] t_Values=knownCategoryValues.Split(':');
            string t_RegionID = t_Values[1].Replace(";", "");
            t_DT = MAHAITDBAccess.GetRegion(t_RegionID);
            List<AjaxControlToolkit.CascadingDropDownNameValue> Categorydetails = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (DataRow dtrow in t_DT.Rows)
            {
                string CategoryCode = dtrow["RegionID"].ToString();
                string Categoryname = dtrow["RegionName"].ToString();
                Categorydetails.Add(new AjaxControlToolkit.CascadingDropDownNameValue(Categoryname, CategoryCode));
            }
            return Categorydetails.ToArray();
        }
    }
}

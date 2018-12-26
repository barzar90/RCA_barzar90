using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;


namespace RCA.Site.Information
{
    public partial class SiteSearch : System.Web.UI.Page
    {
        //private SearchDotnet.Searchs.UserSearch sSite;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string strSearchWords = null;
        //    //If there is no words entered by the user to search for then dont carryout the file search routine
        //    pnlSearchResults.Visible = false;
        //    strSearchWords = Request.QueryString["search"].Trim();

        //    if (!strSearchWords.Equals(""))
        //    {
        //        SearchDotnet.Searchs.Site.ApplicationPath = string.Format("http://{0}{1}", Request.ServerVariables["HTTP_HOST"], Request.ApplicationPath);
        //        sSite = SearchSite(strSearchWords);

        //        if ((sSite.PageDataset != null))
        //        {
        //            pnlSearchResults.Visible = true;
        //            lblSearchWords.Text = sSite.SearchWords;

        //            if (ViewState["SortExpression"] == null)
        //            {
        //                ViewState["SortExpression"] = "MatchCount Desc";
        //            }

        //            BindDataGrid(Convert.ToString(ViewState["SortExpression"]));
        //            lblTotalFiles.Text = Convert.ToString(sSite.TotalFilesSearched);
        //            lblFilesFound.Text = Convert.ToString(sSite.TotalFilesFound);
        //        }
        //    }

           

        //}

        ////*********************************************************************
        ////
        //// SearchSite method
        ////
        //// The  sSite.PageDataset is used to populate the datagrid.
        ////
        ////*********************************************************************
        
        //private SearchDotnet.Searchs.UserSearch SearchSite(string strSearch)
        //{
        //    SearchDotnet.Searchs.UserSearch srchSite = default(SearchDotnet.Searchs.UserSearch);
        //    srchSite = new SearchDotnet.Searchs.UserSearch();
        //    //Read in all the search words into one variable
        //    srchSite.SearchWords = strSearch;

        //    //if (Phrase.Checked)
        //    //{
        //    //    srchSite.SearchCriteria = SearchDotnet.Searchs.SearchCriteria.Phrase;
        //    //}
        //    //else if (AllWords.Checked)
        //    //{
        //    //    srchSite.SearchCriteria = Searchs.SearchCriteria.AllWords;
        //    //}
        //    //else if (AnyWords.Checked)
        //    //{
        //    //    srchSite.SearchCriteria = Searchs.SearchCriteria.AnyWords;
        //    //}

        //    srchSite.SearchCriteria = SearchDotnet.Searchs.SearchCriteria.AnyWords;
        //    //srchSite.Search(Server.MapPath("./"));
        //    srchSite.Search(Server.MapPath("~/SITE"));
        //    return srchSite;
        //}

        ////*********************************************************************
        ////
        //// BindDataGrid method
        ////
        //// The  sSite.PageDataset is used to populate the datagrid.
        ////
        ////*********************************************************************
        //private void BindDataGrid(string strSortField)
        //{
        //    DataView dvwPages = null;
        //    dvwPages = sSite.PageDataset.Tables["Pages"].DefaultView;
        //    dvwPages.Sort = strSortField;
        //    dgrdPages.DataSource = dvwPages;
        //    dgrdPages.DataBind();
        //}

        ////*********************************************************************
        ////
        //// dgrdPages_SortCommand event
        ////
        //// The ViewState( "SortExpression" ) is Assigned the sort expression value.
        //// The datagrid is then populated using the BindDataGrid function.
        ////
        ////*********************************************************************
        //protected void dgrdPages_SortCommand(object s, DataGridSortCommandEventArgs e)
        //{
        //    ViewState["SortExpression"] = e.SortExpression;
        //    BindDataGrid(Convert.ToString(ViewState["SortExpression"]));
        //}

        ////*********************************************************************
        ////
        //// dgrdPages_PageIndexChanged event
        ////
        //// The CurrentPageIndex is Assigned the page index value.
        //// The datagrid is then populated using the BindDataGrid function.
        ////
        ////*********************************************************************
        //protected void dgrdPages_PageIndexChanged(object s, DataGridPageChangedEventArgs e)
        //{
        //    dgrdPages.CurrentPageIndex = e.NewPageIndex;
        //    BindDataGrid(Convert.ToString(ViewState["SortExpression"]));
        //}

        ////*********************************************************************
        ////
        //// DisplayTitle method
        ////
        //// Display title of searched pages 
        ////
        ////*********************************************************************
        //protected string DisplayTitle(string Title, string Path)
        //{
        //    return string.Format("<A href='{1}'>{0}</a>", Path, getBaseURL() + Path);
        //}

        ////*********************************************************************
        ////
        //// DisplayPath method
        ////
        //// Path of the file is returned 
        ////
        ////*********************************************************************
        //protected string DisplayPath(string Path)
        //{
        //    return string.Format("{0}{1}/{2}", Request.ServerVariables["HTTP_HOST"], Request.ApplicationPath, Path);
        //}

        //public string getBaseURL()
        //{
        //    string urlString;
        //    urlString = "http://" + System.Web.HttpContext.Current.Request.Url.Host;
        //    if (System.Web.HttpContext.Current.Request.Url.IsDefaultPort == false)
        //    {
        //        urlString = urlString + ":" + System.Web.HttpContext.Current.Request.Url.Port;
        //    }
        //    urlString = urlString + System.Web.HttpContext.Current.Request.ApplicationPath;
        //    return urlString;
        //}

        //private void abc()
        //{
        //    //String str = Resources.Resource.ResourceManager.
        //}
    }
}
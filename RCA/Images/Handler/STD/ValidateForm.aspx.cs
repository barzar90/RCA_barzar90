using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
using System.Data;

namespace MOLFrameWork.Handler.STD
{


    public partial class ValidateForm : MOLValidate
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<MOLResponse> SendRegistration(NameValue[] formVars)
        {
           bool t_DocSaved=true;

            LoadProfile( HttpContext.Current.Server.MapPath("..\\..\\App_Data\\" + HttpContext.Current.Profile.UserName));

            List<MOLResponse> t_Response = new List<MOLResponse> {new MOLResponse{FieldName="Name", Action="Error", Message="It is mandatory to fill name"} };

            MOLDBAccess.AssignValuesToDataSet(formVars,HttpContext.Current.Server.MapPath("..\\..\\"));

            DataSet ds = MOLDBAccess.ActiveDocument;

            /****
             * 
             *  Processs The Business Logic Here
             * 
             ****/

            MOLDBAccess.SendErrorMessage("HealthCardDetails", "Landmark","Data Not Found in Master");

            MOLDBAccess.AssignValue("HealthCardDetails", "Landmark", "This is assigned by the server");

            MOLDBAccess.MakeFieldReadOnly("HealthCardDetails", "Landmark");

            MOLDBAccess.MakeFieldEditable("HealthCardDetails", "DOB");
            

            /******
             * 
             *  To Send Success / Fail attempt to save data
             * 
             *****/

            MOLDBAccess.SetDocumentSaveState(t_DocSaved);

            return MOLDBAccess.ValidationResponse;
        }

        public static string GetResults(string query, int size, int page)
        {
            string[] words = {
                             "abjure", "abrogate", "abstemious", "acumen", "antebellum", "auspicious", "belie", "bellicose",
                             "bowdlerize", "chicanery", "chromosome", "churlish", "circumlocution", "circumnavigate",
                             "deciduous", "deleterious", "diffident", "enervate", "enfranchise", "epiphany", "equinox",
                             "euro", "evanescent", "expurgate", "facetious", "fatuous", "feckless", "fiduciary",
                             "filibuster", "gamete", "gauche", "gerrymander", "hegemony", "hemoglobin", "homogeneous",
                             "hubris", "hypotenuse", "icicle", "imbibe", "immediate", "impeach", "impossible", "incognito", "incontrovertible", "inculcate",
                             "infrastructure", "interpolate", "inviolate", "irony", "jejune", "kinetic", "kowtow", "laissez faire",
                             "lexicon", "loquacious", "lugubrious", "metamorphosis", "mitosis", "moiety", "nanotechnology",
                             "nihilism", "nomenclature", "nonsectarian", "notarize", "obsequious", "oligarchy",
                             "omnipotent", "orthography", "oxidize", "parabola", "paradigm", "parameter", "pecuniary",
                             "photosynthesis", "plagiarize", "plasma", "polymer", "precipitous", "quasar", "quotidian",
                             "recapitulate", "reciprocal", "reparation", "respiration", "sanguine", "soliloquy",
                             "subjugate", "suffragist", "supercilious", "tautology", "taxonomy", "tectonic", "tempestuous",
                             "thermodynamics", "totalitarian", "unctuous", "usurp", "vacuous", "vehement", "vortex",
                             "winnow", "wrought", "xenophobe", "yeoman", "ziggurat"
                         };

            var sb = new StringBuilder();

            sb.Append("{\"results\":[");

            var results = new List<string>();

            int total = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(query))
                {
                    results.Add("{\"id\":" + i + ",\"name\":\"" + words[i] + "\"}");
                    total++;
                }
            }

            string[] resultsArray = results.ToArray();
            var pagedResults = new List<string>();

            if (size > 0)
            {
                int start = (page - 1) * size + 1;
                int end = (start > (total - size)) ? total : start + size - 1;
                for (int i = start - 1; i < end; i++)
                {
                    pagedResults.Add(resultsArray[i]);
                }
            }

            if (pagedResults.Count > 0)
            {
                sb.Append(string.Join(",", pagedResults.ToArray()));
            }
            else if (resultsArray.Length > 0)
            {
                sb.Append(string.Join(",", resultsArray));
            }

            sb.Append("],\"total\":\"" + total + "\"}");

            return sb.ToString();
        }

    }
}
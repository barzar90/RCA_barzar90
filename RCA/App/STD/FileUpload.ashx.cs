using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;

namespace MSHC.App.STD
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;

            string results = GetResults("", 100, 1);

            context.Response.Write(results);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
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
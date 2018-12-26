using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace MOLFrameWork.Handler.MOLForms
{
    public partial class HealthCard : MOLValidate
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static void SaveData(NameValue[] formVars)
        {
            bool t_DocSaved = true;

            LoadProfile(HttpContext.Current.Server.MapPath("..\\..\\App_Data\\" + HttpContext.Current.Profile.UserName));

            List<MOLResponse> t_Response = new List<MOLResponse> { new MOLResponse { FieldName = "Name", Action = "Error", Message = "It is mandatory to fill name" } };

            MOLDBAccess.AssignValuesToDataSet(formVars,HttpContext.Current.Server.MapPath("..\\..\\"));

            DataSet ds = MOLDBAccess.ActiveDocument;

            /****
             * 
             *  Processs The Business Logic Here
             * 
             ****/

            //MOLDBAccess.SendErrorMessage("HealthCardDetails", "Landmark", "Data Not Found in Master");

            //MOLDBAccess.AssignValue("HealthCardDetails", "Landmark", "This is assigned by the server");

            //MOLDBAccess.MakeFieldReadOnly("HealthCardDetails", "Landmark");

            //MOLDBAccess.MakeFieldEditable("HealthCardDetails", "DOB");


            /******
             * 
             *  To Send Success / Fail attempt to save data
             * 
             *****/
        }

        [WebMethod]
        public static List<MOLResponse> SaveSection(NameValue[] formVars)
        {
            try
            {
                SaveData(formVars);
                MOLDBAccess.SaveToActiveFile();
            }
            catch (Exception E)
            {
                MOLDBAccess.SendException(E.Message);
            }
            MOLDBAccess.SetDocumentSaveState(!MOLDBAccess.HasErrors);
            return MOLDBAccess.ValidationResponse;
        }

        [WebMethod]
        public static List<MOLResponse> SaveDocument(NameValue[] formVars)
        {
            try
            {
                SaveData(formVars);
                MOLDBAccess.SaveToActiveFile();
                if (!MOLDBAccess.HasErrors)
                {
                    //MOLDBAccess.SaveDocument();
                }
            }
            catch (Exception E)
            {
                MOLDBAccess.SendException(E.Message);
            }
            MOLDBAccess.SetDocumentSaveState(!MOLDBAccess.HasErrors);
            return MOLDBAccess.ValidationResponse;
        }

    }
}
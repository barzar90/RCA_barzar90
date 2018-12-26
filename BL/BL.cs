using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Resources;
using System.Web;
using System.Data.OleDb;
using System.Net.Mail;
using DAL;

namespace BL
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string ColumnCaption { get; set; }
        public XmlNode FieldInfo { get; set; }
    }

    public class ColumnGroup
    {
        public string GroiupHeading { get; set; }
        public int Columns { get; set; }
    }



    public class BL : IDisposable
    {
        public DataSet ActiveDocument { get { return applicationDL.ActiveDocument; } set { applicationDL.ActiveDocument = value; } }
        public int SerialNumberLength { get { return applicationDL.SerialNumberLength; } set { applicationDL.SerialNumberLength = value; } }
        public string UserName { get { return applicationDL.UserName; } set { applicationDL.UserName = value; } }
        public string IPAddress { get { return applicationDL.IPAddress; } set { applicationDL.IPAddress = value; } }
        public string MacAddress { get { return applicationDL.MacAddress; } set { applicationDL.MacAddress = value; } }
        public string ServerPath { get { return applicationDL.ServerPath; } set { applicationDL.ServerPath = value; } }
        public string LangID { get; set; }

        public string ActiveXML;
        public bool HasErrors = false;

        private DL applicationDL;

        private SqlCommand ValidateCommadText(SqlCommand Commad)
        {
            if (Commad.CommandText.ToString().Contains("'"))
            {
                // throw new Exception("Sql Query contain single Quote !!!");
            }
            else
            {
                return Commad;
            }
            return Commad;
        }

        public List<MAHAITResponse> ValidationResponse = new List<MAHAITResponse>();
        XmlDocument XMLForm = new XmlDocument();

        public BL(string appId)
        {
            applicationDL = new DL(appId);
        }


        public SqlDataReader ExecuteReader(SqlCommand Command)
        {
            return applicationDL.ExecuteReader(ValidateCommadText(Command));
        }


        /// <summary>
        /// Executes a Query(Use this method to execute Select query or Mix Mode query)
        /// </summary>
        public DataSet ExecuteDataSet(SqlCommand Command)
        {
            return applicationDL.ExecuteDataSet(ValidateCommadText(Command));
        }

        public object ExecuteScalar(SqlCommand Command)
        {
            return applicationDL.ExecuteScalar(ValidateCommadText(Command));
        }
        /// <summary>
        /// Executes a NonQuery(Use it to execute Insert,update and delete command)
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCommand Command)
        {
            return applicationDL.ExecuteNonQuery(ValidateCommadText(Command));
        }


        public DataSet ExecuteDataSet(OleDbCommand Command, string ExcelFilePath)
        {
            return applicationDL.ExecuteDataSet(Command, ExcelFilePath);
        }

        public void GetDocument(string[] DocumentTables, string KeyValue)
        {
            applicationDL.GetDocument(DocumentTables, KeyValue);
        }

        public void ReadFromFile(string FileName)
        {
            ActiveXML = FileName;
            applicationDL.ReadFromFile(FileName);
        }

        public void WriteToFile(string FileName)
        {
            applicationDL.WriteToFile(FileName);
        }

        public void SetFieldValue(string TableName, int RowNo, string FieldName, string FieldValue)
        {
            applicationDL.SetFieldValue(TableName, RowNo, FieldName, FieldValue);
        }

        public Boolean SaveDocument(string FormGroup, string Template, bool HasProc)
        {
            return applicationDL.SaveDocument(FormGroup, Template, HasProc);
        }

        public DataRow GetMenuInfo(string MenuID)
        {
            DataRowCollection t_Info;
            DataRow t_Return;

            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * From MOLMenus where MenuID=@ID";
            t_SQLCmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);

            t_SQLCmd.Parameters["@ID"].Value = MenuID.ToString();
            t_Info = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0].Rows;

            if (t_Info.Count > 0)
            {
                t_Return = t_Info[0];
            }
            else
            {
                t_Return = null;
            }

            return t_Return;
        }

        public void Dispose()
        {
            applicationDL.Dispose();
        }

        public DataTable GetCascadingDropDowns(string TableName, string DisplayField, string ValueField, List<string> FilterCols, List<string> DataType, List<string> FilterValues, XmlNode fieldNode)
        {
            DataTable t_DT;
            string t_SQLQuery = "";
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLQuery = "Select " + DisplayField;

            if (DisplayField.ToUpper() != ValueField.ToUpper())
                t_SQLQuery = t_SQLQuery + ", " + ValueField;

            t_SQLQuery = t_SQLQuery + " From " + TableName;

            if (fieldNode != null && fieldNode.Attributes["HasLangID"] != null && fieldNode.Attributes["HasLangID"].Value == "Y")
            {
                t_SQLQuery = t_SQLQuery + " Where LangID = " + LangID;
            }

            if (FilterCols != null && DataType != null && FilterValues != null)
            {
                if (FilterCols.Count > 0 && DataType.Count > 0 && FilterValues.Count > 0)
                {
                    if (FilterCols.Count == DataType.Count && FilterCols.Count == FilterValues.Count)
                    {
                        for (int i = 0; i < FilterCols.Count; i++)
                        {
                            t_SQLCmd.Parameters.Add("@" + FilterCols[i], System.Data.SqlDbType.NVarChar).Value = FilterValues[i];
                        }

                    }
                }
            }

            t_SQLCmd.CommandText = t_SQLQuery;

            t_DT = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_DT;
        }

        public DataTable GetDistricts()
        {
            DataTable t_Return;

            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * From mstDistrict where StateCode = @StateCode And LangID = @LangID Order By DistrictName";
            t_SQLCmd.Parameters.Add("@StateCode", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);

            t_SQLCmd.Parameters["@StateCode"].Value = "27";
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }

        public DataTable GetSubDistricts(string DistrictCode)
        {
            DataTable t_Return;

            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * From mstTaluka where DistrictCode = @DistrictCode And LangID = @LangID Order By SubDistrictName";
            t_SQLCmd.Parameters.Add("@DistrictCode", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);

            t_SQLCmd.Parameters["@DistrictCode"].Value = DistrictCode;
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }

        public DataTable GetVillages(string SubDistrictCode)
        {
            DataTable t_Return;

            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * From mstVillage where SubDistrictCode = @SubDistrictCode And LangID = @LangID Order By VillageName";
            t_SQLCmd.Parameters.Add("@SubDistrictCode", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);

            t_SQLCmd.Parameters["@SubDistrictCode"].Value = SubDistrictCode;
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }

        public string AssignValuesToDataSet(NameValue[] formVars, string AppPath)
        {
            string TableFieldName = "";
            string[] FieldSplit;
            string TableName = "";
            string ColumnName = "";
            string[] Columninfo;
            string t_FileName = "";
            bool t_IsMultiSection = false;
            int t_Row = -1;
            string t_Return = "";
            string t_SectionName = "";
            string t_FRMGRP = "";
            string t_FRMTMP = "";

            for (int i = 0; i < formVars.Length; i++)
            {
                FieldSplit = formVars[i].name.Split('$');

                if (FieldSplit.Length == 3)
                {
                    if (FieldSplit[2] == "FRMDT")
                    {
                        t_FileName = formVars[i].value;
                        ReadFromFile(t_FileName);
                    }

                    if (FieldSplit[2] == "FRMR")
                    {
                        t_IsMultiSection = true;
                        t_Row = Convert.ToInt16(formVars[i].value);
                    }

                    if (FieldSplit[2] == "FRMS")
                    {
                        t_SectionName = formVars[i].value;
                    }

                    if (FieldSplit[2] == "FRMGRP")
                    {
                        t_FRMGRP = formVars[i].value;
                    }

                    if (FieldSplit[2] == "FRMTMP")
                    {
                        t_FRMTMP = formVars[i].value;
                    }
                }

                if (FieldSplit.Length >= 4)
                {
                    TableFieldName = FieldSplit[FieldSplit.Length - 1];
                    Columninfo = TableFieldName.Split(new string[] { "__" }, StringSplitOptions.None);

                    if (Columninfo.Length == 2)
                    {
                        TableName = Columninfo[0];
                        ColumnName = Columninfo[1];
                        if (!t_IsMultiSection)
                        {
                            SetFieldValue(TableName, 0, ColumnName, formVars[i].value);
                        }
                        else
                        {
                            if (t_Row == -1)
                            {
                                t_Row = ActiveDocument.Tables[TableName].Rows.Count;
                            }
                            SetFieldValue(TableName, t_Row, ColumnName, formVars[i].value);
                        }
                    }
                }
            }

            if (t_IsMultiSection)
            {
                MAHAITResponse t_RecData = new MAHAITResponse();
                XmlNode t_Node = null;
                string t_XMLName = "";

                t_XMLName = AppPath + @"APPForms\" + t_FRMGRP + @"\" + t_FRMTMP + ".XML";

                XMLForm.Load(t_XMLName);

                foreach (XmlNode t_Page in XMLForm.DocumentElement)
                {
                    foreach (XmlNode t_Section in t_Page)
                    {
                        if (t_Section.Attributes["MultiRow"] != null && t_Section.Attributes["MultiRow"].Value.ToString().Equals("Y") && t_Section.Attributes["ID"].Value.ToString().Equals(t_SectionName))
                        {
                            t_Node = t_Section;
                        }
                    }
                }


                t_RecData.Action = "SECDATA";
                t_RecData.FieldName = t_SectionName;
                t_RecData.Message = CreateHTMLGrid(ActiveDocument.Tables[TableName], t_Node);
                ValidationResponse.Add(t_RecData);
            }

            return t_Return;
        }

        public void SendSectionToClient(string SectionName, string TableName)
        {
            MAHAITResponse t_RecData = new MAHAITResponse();
            XmlNode t_Node = null;

            foreach (XmlNode t_Page in XMLForm.DocumentElement)
            {
                foreach (XmlNode t_Section in t_Page)
                {
                    if (t_Section.Attributes["MultiRow"] != null && t_Section.Attributes["MultiRow"].Value.ToString().Equals("Y") && t_Section.Attributes["ID"].Value.ToString().Equals(SectionName))
                    {
                        t_Node = t_Section;
                    }
                }
            }

            t_RecData.Action = "SECDATA";
            t_RecData.FieldName = SectionName;
            t_RecData.Message = CreateHTMLGrid(ActiveDocument.Tables[TableName], t_Node);
            ValidationResponse.Add(t_RecData);
        }

        public void SaveToActiveFile()
        {
            WriteToFile(ActiveXML);
        }

        public string CreateHTMLGrid(DataTable DataSource, XmlNode node)
        {
            List<ColumnGroup> t_Groups = null;
            List<ColumnInfo> t_Cols = null;
            ColumnInfo t_Col = null;
            string t_FieldType = "";
            string t_SectionName = node.Attributes["ID"].Value;
            int t_Height = Convert.ToInt32(node.Attributes["FormHeight"].Value);
            int t_Width = Convert.ToInt32(node.Attributes["FormWidth"].Value); ;

            t_Cols = new List<ColumnInfo>();

            foreach (XmlNode rowNode in node.ChildNodes)
            {
                if (rowNode.Name == "Row")
                {
                    foreach (XmlNode t_Field in rowNode)
                    {
                        t_FieldType = t_Field.Attributes["Type"] == null ? "" : t_Field.Attributes["Type"].Value;

                        if (t_FieldType != "L" && t_FieldType != "" && t_FieldType != "BLNK")
                        {
                            t_Col = new ColumnInfo();
                            t_Col.ColumnName = t_Field.Attributes["ColName"].Value.ToString();
                            t_Col.ColumnCaption = t_Field.Attributes["Caption"].Value.ToString();
                            t_Col.FieldInfo = t_Field;
                            t_Cols.Add(t_Col);
                        }
                    }
                }
            }

            return GetTableHTML(DataSource, t_Groups, t_Cols, t_SectionName, t_Height, t_Width);
        }



        public void SendErrorMessage(string TableName, string ColumnName, string Message)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "ERR";
            t_NewResponse.Message = Message;
            HasErrors = true;
            ValidationResponse.Add(t_NewResponse);
        }

        public void SendException(string Exception)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = "";
            t_NewResponse.Action = "EXCEPTION";
            t_NewResponse.Message = Exception;
            HasErrors = true;
            ValidationResponse.Add(t_NewResponse);
        }

        public void AssignValue(string TableName, string ColumnName, string Value)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "ASV";
            t_NewResponse.Message = Value;

            ValidationResponse.Add(t_NewResponse);
        }

        public void AssignValueToParent(string TableName, string ColumnName, string Value)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "ASVTP";
            t_NewResponse.Message = Value;

            ValidationResponse.Add(t_NewResponse);
        }

        public void AssignTransactionID(string TransactionID)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = "TRNID";
            t_NewResponse.Action = "TRNID";
            t_NewResponse.Message = TransactionID;

            ValidationResponse.Add(t_NewResponse);
        }

        public string GetDescription(string FieldName, string TableName, string CodeField, string IDValue, bool HasLangId)
        {
            string t_Ret = "";
            DataTable t_DT;

            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select " + FieldName + " From " + TableName + " Where " + CodeField + " = @ID";

            if (HasLangId)
            {
                t_SQLCmd.CommandText = t_SQLCmd.CommandText + " And LangID =  " + LangID;
            }

            t_SQLCmd.Parameters.Add("@ID", SqlDbType.NVarChar);

            t_SQLCmd.Parameters["@ID"].Value = IDValue;

            t_DT = ExecuteDataSet(t_SQLCmd).Tables[0];

            if (t_DT.Rows.Count >= 1)
            {
                t_Ret = t_DT.Rows[0][0].ToString();
            }

            return t_Ret;
        }

        public string GetTableHTML(DataTable Table, List<ColumnGroup> ColumnGroups, List<ColumnInfo> Columns, string SectionName, int Height, int Width)
        {
            XmlDocument t_TableDoc = new XmlDocument();
            t_TableDoc.LoadXml("<table class=\"SectionGrid\"></table>");

            XmlNode t_Table = t_TableDoc.DocumentElement;
            XmlNode t_Row = null;
            XmlNode t_Column = null;
            XmlAttribute t_Attribute = null;
            string t_FieldCaption, t_ResName = null;

            t_Row = t_Table.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "tr", ""));

            foreach (ColumnInfo t_Col in Columns)
            {
                t_Column = t_Row.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "th", ""));
            }

            t_Column = t_Row.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "th", ""));

            if (ColumnGroups != null)
            {
                t_Row = t_Table.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "tr", ""));

                foreach (ColumnGroup t_Col in ColumnGroups)
                {
                    t_Column = t_Row.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "td", ""));
                    t_Attribute = t_TableDoc.CreateAttribute("colspan");
                    t_Attribute.Value = t_Col.Columns.ToString();
                }
            }

            t_Row = t_Table.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "tr", ""));
            foreach (ColumnInfo t_Col in Columns)
            {
                t_Column = t_Row.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "td", ""));
                t_FieldCaption = t_Col.ColumnCaption;
                t_ResName = Table + "__" + t_Col.ColumnName + "_LBL";
                t_FieldCaption = GetResourceValue("HealthCard", t_ResName, t_FieldCaption).ToString();
                t_Column.InnerText = t_FieldCaption;
            }

            t_Column = t_Row.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "td", ""));

            int I = -1;

            foreach (DataRow t_DR in Table.Rows)
            {
                I = I + 1;

                t_Row = t_Table.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "tr", ""));

                foreach (ColumnInfo t_Col in Columns)
                {
                    t_Column = t_Row.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "td", ""));

                    if (t_Col.FieldInfo.Attributes["Type"].Value == "I")
                    {
                        t_Column.InnerXml = "<Img src=\"../../App/STD/GetFile.ashx?ID=" + t_DR[t_Col.ColumnName].ToString() + "\"/>";
                    }
                    else if (t_Col.FieldInfo.Attributes["Type"].Value == "DT")
                    {
                        if (t_DR[t_Col.ColumnName].ToString() == "")
                        {
                            t_Column.InnerText = "";
                        }
                        else
                        {
                            t_Column.InnerText = Convert.ToDateTime(t_DR[t_Col.ColumnName].ToString()).ToShortDateString().Replace('-', '/');
                        }
                    }
                    else if (t_Col.FieldInfo.Attributes["Type"].Value == "D")
                    {
                        t_Column.InnerText = GetDescription(t_Col.FieldInfo.Attributes["DisplayField"].Value, t_Col.FieldInfo.Attributes["TableName"].Value, t_Col.FieldInfo.Attributes["CodeField"].Value, t_DR[t_Col.ColumnName].ToString(), t_Col.FieldInfo.Attributes["HasLangID"] != null && t_Col.FieldInfo.Attributes["HasLangID"].Value == "Y");
                    }
                    else if (t_Col.FieldInfo.Attributes["Type"].Value == "CD")
                    {
                        t_Column.InnerText = GetDescription(t_Col.FieldInfo.Attributes["DisplayField"].Value, t_Col.FieldInfo.Attributes["TableName"].Value, t_Col.FieldInfo.Attributes["CodeField"].Value, t_DR[t_Col.ColumnName].ToString(), t_Col.FieldInfo.Attributes["HasLangID"] != null && t_Col.FieldInfo.Attributes["HasLangID"].Value == "Y");
                    }
                    else
                    {
                        t_Column.InnerText = t_DR[t_Col.ColumnName].ToString();
                    }
                }

                t_Column = t_Row.AppendChild(t_TableDoc.CreateNode(XmlNodeType.Element, "td", ""));
                t_Column.InnerXml = "<input type=\"button\" value=\"" + GetResourceValue("General", "Edit_btn", "Edit") + "\" onclick=\"javascript:MOLEditRow('" + SectionName + "'," + I.ToString() + "," + Height + "," + Width + "); return false;\"/>";
            }

            return t_TableDoc.InnerXml;
        }

        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = HttpContext.GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        public void MakeFieldReadOnly(string TableName, string ColumnName)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "RO";
            t_NewResponse.Message = "";

            ValidationResponse.Add(t_NewResponse);
        }

        public void MakeFieldEditable(string TableName, string ColumnName)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "RW";
            t_NewResponse.Message = "";

            ValidationResponse.Add(t_NewResponse);
        }

        public void SetDocumentSaveState(bool DocSaved)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            if (DocSaved)
            {
                t_NewResponse.FieldName = "";
                t_NewResponse.Action = "DSS";
                t_NewResponse.Message = "";
            }
            else
            {
                t_NewResponse.FieldName = "";
                t_NewResponse.Action = "DSF";
                t_NewResponse.Message = "";
            }

            ValidationResponse.Add(t_NewResponse);
        }
        public DataTable GetFileUploadDtl(string FileType)
        {


            DataTable t_Return;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "select *,b.FileType as Type,Convert(varchar(10), SaveDate, 103) As AppDate from MOLUploadFiles as a inner join MOLFileCategory as b on a.FileTypeByUser=b.FileTypeValue and a.LangID=B.LangID where b.FileTypeValue='" + FileType + "' and a.LangID = @LangID Order by CreatedOn desc";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }

        public DataTable GetFileViewDtl(string FileType)
        {


            DataTable t_Return;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * from MOLFileCategory where FileTypeValue='" + FileType + "' and LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }
        public DataTable GetFile()
        {
            DataTable t_Return;
            DataRow t_dr;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = " Select * From MOLFileCategory where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
            if (LangID == "1")
            {
                t_dr = t_Return.NewRow();
                t_dr["FileType"] = "Select";
                t_dr["FileTypeValue"] = "-1";
            }
            else
            {
                t_dr = t_Return.NewRow();
                t_dr["FileType"] = "निवडा";
                t_dr["FileTypeValue"] = "-1";
            }
            t_Return.Rows.InsertAt(t_dr, 0);
            t_Return.AcceptChanges();
            return t_Return;
        }

        public DataTable GetFileInputConfig(string FileType)
        {


            DataTable t_Return;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * from MOLFileInputConfig where FileTypeValue='" + FileType + "' and LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }

        public DataTable GetDeskDtl()
        {


            DataTable t_Return;
            DataRow t_dr;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * from Mst_Desk where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
            if (LangID == "1")
            {
                t_dr = t_Return.NewRow();
                t_dr["Desk"] = "Select";
                t_dr["DeskID"] = "-1";
            }
            else
            {
                t_dr = t_Return.NewRow();
                t_dr["Desk"] = "निवडा";
                t_dr["DeskID"] = "-1";
            }
            t_Return.Rows.InsertAt(t_dr, 0);
            t_Return.AcceptChanges();
            return t_Return;

        }

        public DataTable GetProgramDtl()
        {


            DataTable t_Return;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "select * from Mst_Program where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }

        public DataTable GetSubCategory()
        {


            DataTable t_Return;
            DataRow t_dr;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = " Select * From MstSubCategory where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
            if (LangID == "1")
            {
                t_dr = t_Return.NewRow();
                t_dr["SubCat"] = "Select";
                t_dr["SubCatID"] = "-1";
            }
            else
            {
                t_dr = t_Return.NewRow();
                t_dr["SubCat"] = "निवडा";
                t_dr["SubCatID"] = "-1";
            }
            t_Return.Rows.InsertAt(t_dr, 0);
            t_Return.AcceptChanges();
            return t_Return;
        }


        public DataTable GeDesignationDtl()
        {


            DataTable t_Return;
            DataRow t_dr;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = " Select * From MstDesignation where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
            if (LangID == "1")
            {
                t_dr = t_Return.NewRow();
                t_dr["Designation"] = "Select";
                t_dr["DesignationID"] = "-1";
            }
            else
            {
                t_dr = t_Return.NewRow();
                t_dr["Designation"] = "निवडा";
                t_dr["DesignationID"] = "-1";
            }
            t_Return.Rows.InsertAt(t_dr, 0);
            t_Return.AcceptChanges();
            return t_Return;
        }

        public DataTable GetGuideLine()
        {


            DataTable t_Return;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * from MstGuildLine where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;
        }

        public DataTable GetMaxNo(string Prefix)
        {
            DataTable t_Return;
            SqlCommand t_SQLCmd = new SqlCommand();
            //  t_SQLCmd.CommandText = "Select * from MOLFileInputConfig where FileTypeValue='" + FileType + "' and LangID = @LangID";

            //    t_SQLCmd.CommandText = "SELECT    CASE WHEN SeqNo IS NULL THEN '00001' ELSE SeqNo END AS SeqNo" +
            //                         "FROM  (SELECT     RIGHT(REPLICATE('0', 5) + CAST(MAX(SeqNo) + 1 AS Varchar(10)), 5) AS SeqNo" +
            //                        "FROM (SELECT     ISNULL(CAST(RIGHT(SeqNo, 5) AS int), 0) AS SeqNo" +
            //                      "FROM MOLUploadFile where Prefix='"+Prefix+"') AS A) AS A";


            t_SQLCmd.CommandText = "SELECT CASE WHEN SeqNo IS NULL THEN '00001' ELSE SeqNo END AS SeqNo FROM (SELECT     RIGHT(REPLICATE('0', 5) + CAST(MAX(SeqNo) + 1 AS Varchar(10)), 5) AS SeqNo FROM (SELECT     ISNULL(CAST(RIGHT(SeqNo, 5) AS int), 0) AS SeqNo FROM MOLUploadFile where Prefix='" + Prefix + "') AS A) AS A";
            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];

            return t_Return;

        }

        public DataTable GetDurationDtl()
        {


            DataTable t_Return;
            DataRow t_dr;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = " Select * From MstDurationDtl where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
            if (LangID == "1")
            {
                t_dr = t_Return.NewRow();
                t_dr["Duration"] = "Select";
                t_dr["DurationID"] = "-1";
            }
            else
            {
                t_dr = t_Return.NewRow();
                t_dr["Duration"] = "निवडा";
                t_dr["DurationID"] = "-1";
            }
            t_Return.Rows.InsertAt(t_dr, 0);
            t_Return.AcceptChanges();
            return t_Return;
        }

        public DataTable GetLevel()
        {


            DataTable t_Return;
            DataRow t_dr;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = " Select * From MstLevel where LangID = @LangID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
            if (LangID == "1")
            {
                t_dr = t_Return.NewRow();
                t_dr["LevelName"] = "Select";
                t_dr["LevelID"] = "-1";
            }
            else
            {
                t_dr = t_Return.NewRow();
                t_dr["LevelName"] = "निवडा";
                t_dr["LevelID"] = "-1";
            }
            t_Return.Rows.InsertAt(t_dr, 0);
            t_Return.AcceptChanges();
            return t_Return;
        }


        public DataTable GetRegion(string p_LevelID)
        {


            DataTable t_Return;
            DataRow t_dr;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * From MstRegion where LangID = @LangID and LevelID=@LevelID";
            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters.Add("@LevelID", System.Data.SqlDbType.VarChar);

            t_SQLCmd.Parameters["@LangID"].Value = LangID;
            t_SQLCmd.Parameters["@LevelID"].Value = p_LevelID;

            t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
            if (LangID == "1")
            {
                t_dr = t_Return.NewRow();
                t_dr["RegionName"] = "Select";
                t_dr["RegionID"] = "-1";
            }
            else
            {
                t_dr = t_Return.NewRow();
                t_dr["RegionName"] = "निवडा";
                t_dr["RegionID"] = "-1";
            }
            t_Return.Rows.InsertAt(t_dr, 0);
            t_Return.AcceptChanges();
            return t_Return;
        }


        public void SendEmailuser(string MailProfile, string _From, string _To, string _Subject, string _Body, string _BodyU)
        {
            string SMTPstr = string.Empty, Portstr = string.Empty, From = string.Empty, To = string.Empty, Subject = string.Empty, Body = string.Empty, BodyU = string.Empty;
            string t_XMLName = HttpContext.Current.Server.MapPath("~/APP_Data/MailConfig.XML");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(t_XMLName);
            XmlNode xnod = xmlDoc.DocumentElement;
            XmlNodeList nodeList = xnod.SelectNodes("Mail");

            foreach (XmlNode _node in nodeList)
            {
                string Profile = _node.Attributes["Profile"].Value.ToString();
                if (_node.Attributes["Profile"].Value.ToString().ToLower() == MailProfile.Split('_')[0].ToLower())
                {
                    SMTPstr = _node.SelectSingleNode("host").InnerText.Trim();
                    Portstr = _node.SelectSingleNode("port").InnerText.Trim();
                    From = _node.SelectSingleNode("from").InnerText.Trim();
                    To = _node.SelectSingleNode("to").InnerText.Trim();
                    Subject = _node.SelectSingleNode("subject").InnerText.Trim();
                    //Body = _node.SelectSingleNode("body").InnerText.Trim();

                    XmlElement e = (XmlElement)_node;
                    Body = e.GetElementsByTagName(MailProfile.Split('_')[1].ToLower())[0].InnerText;
                }
            }


            if (MailProfile.Split('_')[0].ToLower() == "society")
            {


                string[] _body = _Body.Split('|');

                Body = Body.Replace("#UserName", _body[0]);
                Body = Body.Replace("#SocietyName", "'" + _body[1] + "'");
                Body = Body.Replace("#RegistrationDT", _body[2]);
                Body = Body.Replace("#TRNID", _body[3]);
            }

            if (MailProfile.Split('_')[0].ToLower() == "forgotpassword")
            {


                string[] _body = _Body.Split('|');
                string[] _bodyU = _BodyU.Split('|');
                Body = Body.Replace("#UserName", _bodyU[0]);
                //Body = Body.Replace("#SocietyName", "'" + _body[1] + "'");
                //Body = Body.Replace("#RegistrationDT", _body[2]);
                Body = Body.Replace("#TRNID", _body[0]);
            }

            if (_To != string.Empty)
            {
                To = _To;
            }

            //if (MailProfile.Split('_')[0].ToLower() == "forgotpassword")
            //{
            //    To = _To;
            //}

            SendEmail(From, To, Subject, Body, SMTPstr, Portstr, "", "");
        }

        private void SendEmail(string From, string To, string Subject, string Message, string hostAddress, string portaddress, string cc, string bcc)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(From, To, Subject, Message);

                if (cc != string.Empty)
                    message.CC.Add(cc);
                if (bcc != string.Empty)
                    message.Bcc.Add(bcc);

                SmtpClient client = new SmtpClient(hostAddress, Convert.ToInt32(portaddress));
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

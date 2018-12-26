using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class CaseDetailSchema
    {
        private string caseno;
        private string divisionid;
        private string districtid;
        private string applicantname;
        private string opponentname;
        private string casestatus;
        private DateTime lasthearingdate;
        private DateTime nexthearingdate;
        private DateTime? createddate;
        private string createdby;
        private string updatedby;
        private DateTime? updateddate;
        private string actiontype;
        private int caseid;
        private bool isdelete;

        public string CaseNo
        {
            get { return caseno; }
            set { caseno = value; }
        }

        public string DivisionId
        {
            get { return divisionid; }
            set { divisionid = value; }
        }

        public string DistrictId
        {
            get { return districtid; }
            set { districtid = value; }
        }

        public string ApplicantName
        {
            get { return applicantname; }
            set { applicantname = value; }
        }

        public string OpponentName
        {
            get { return opponentname; }
            set { opponentname = value; }
        }

        public string CaseStatus
        {
            get { return casestatus; }
            set { casestatus = value; }
        }

        public DateTime LastHearingDate
        {
            get { return lasthearingdate; }
            set { lasthearingdate = value; }
        }

        public DateTime NextHearingDate
        {
            get { return nexthearingdate; }
            set { nexthearingdate = value; }
        }

        public DateTime? CreatedDate
        {
            get { return createddate; }
            set { createddate = value; }
        }

        public string CreatedBy
        {
            get { return createdby; }
            set { createdby = value; }
        }

        public string UpdatedBy
        {
            get { return updatedby; }
            set { updatedby = value; }
        }

        public DateTime? UpdatedDate
        {
            get { return updateddate; }
            set { updateddate = value; }
        }

        public string ActionType
        {
            get { return actiontype; }
            set { actiontype = value; }
        }

        public int CaseID
        {
            get { return caseid; }
            set { caseid = value; }
        }

        public bool IsDelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }
    }
}

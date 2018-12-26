using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class EmployeeSchema
    {
        #region Variable Declaration
        private string employeename;
        private string emplyee_designation;
        private string employee_type;
        private string employee_division_name;
        private string employee_district;

        public string Employee_district
        {
            get { return employee_district; }
            set { employee_district = value; }
        }
        private string employee_username;
        private string employee_password;
        private int employee_user_isactive;
        private string factory_name;
        #endregion
        private string mobile_No;
        public string Mobile_No
        {
            get { return mobile_No; }
            set { mobile_No = value; }
        }
        private string Email_Id;

        public string Email_Id1
        {
            get { return Email_Id; }
            set { Email_Id = value; }
        }
        #region Properties
        public string EmployeeName
        {
            get
            {
                return employeename;
            }
            set
            {
                employeename = value;
            }
        }

        public string EmployeeDesignation
        {
            get
            {
                return emplyee_designation;
            }
            set
            {
                emplyee_designation = value;
            }
        }

        public string EmployeeType
        {
            get
            {
                return employee_type;
            }
            set
            {
                employee_type = value;
            }
        }

        public string EmployeeDivisionName
        {
            get
            {
                return employee_division_name;
            }
            set
            {
                employee_division_name = value;
            }
        }

        public string EmployeeUsername
        {
            get
            {
                return employee_username;
            }
            set
            {
                employee_username = value;
            }
        }

        public string EmployeePassword
        {
            get
            {
                return employee_password;
            }
            set
            {
                employee_password = value;
            }
        }

        public int EmployeeUserIsactive
        {
            get
            {
                return employee_user_isactive;
            }
            set
            {
                employee_user_isactive = value;
            }
        }

        public string FactoryName
        {
            get
            {
                return factory_name;
            }
            set
            {
                factory_name = value;
            }
        }
        #endregion

    }
 }

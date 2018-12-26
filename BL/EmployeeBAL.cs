using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using System.Data;
using DAL;


namespace BL
{
    public class EmployeeBAL
    {
        EmployeeDAL objEmployeeDAL;
        DataSet ds;
        DataTable dt;


        public int AddEmployee(EmployeeSchema objEmployeeShema)
        {

            int _returnValue;
            try
            {
                objEmployeeDAL = new EmployeeDAL();
                _returnValue = objEmployeeDAL.AddEmployee(objEmployeeShema);
                return _returnValue;
            }
            catch (Exception ex) { return 0; }
            finally
            {


                objEmployeeDAL = null;
            }
        }

        public void ClearValue(EmployeeSchema objEmployeeShema)
        {
            try
            {
                objEmployeeDAL = new EmployeeDAL();
                objEmployeeDAL.cleartext();

            }
            catch (Exception ex) { }
            finally
            {

                ds = null;
                objEmployeeDAL = null;
            }
        }

        public DataSet GetEmployeesLookup()
        {

            try
            {

                objEmployeeDAL = new EmployeeDAL();
                ds = objEmployeeDAL.GetEmployees();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ds = null;
                objEmployeeDAL = null;
            }
        }

        public DataSet GetEmployeesMasterValues(string Id)
        {
            try
            {

                objEmployeeDAL = new EmployeeDAL();
                ds = objEmployeeDAL.GetEmployeeMasterQueryString(Id);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ds = null;
                objEmployeeDAL = null;
            }
        }

        public int DeactivateUser(string UserID, string Status)
        {
            int _returnValue;
            try
            {
                objEmployeeDAL = new EmployeeDAL();

                _returnValue = objEmployeeDAL.DeactivateUser(UserID, Status);
                return _returnValue;
            }
            catch
            {
                return 0;
            }
            finally
            {
                objEmployeeDAL = null;
            }
        }

    }
}

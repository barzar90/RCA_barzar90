using System;
using System.Collections.Generic;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for DbUtil
/// </summary>
public class DbUtil
{
    static string CoonStr;
    static SqlConnection _conn;
    static SqlDataReader _reader;
    static SqlCommand _cmd;
    static SqlDataAdapter _da;

    public static string GetConnectionString()
    {
        //CoonStr = ConfigurationManager.AppSettings["Local"];
        //return CoonStr;
           //CoonStr = ConfigurationManager.AppSettings["Sqlserver"];
       // CoonStr = ConfigurationManager.ConnectionStrings["APPID"].ConnectionString;
        CoonStr = ConfigurationManager.AppSettings["APPID"].ToString();
            return CoonStr;
        }

    public static SqlDataReader GetReader(string Quary)
    {
        try 
	        {	        
		        _conn=new SqlConnection(GetConnectionString());
                _conn.Open();
                _cmd=new SqlCommand(Quary,_conn);
                _reader=_cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return _reader;

	        }
	        catch (System.Exception)
	        {
		
		        throw;
	        }

    }

    public static DataSet GetDataset(string Quary)
    {
         try 
	        {	
                DataSet retDs=new DataSet();    
		        _conn=new SqlConnection(GetConnectionString());
                _conn.Open();
                _cmd=new SqlCommand(Quary,_conn);

                _da=new SqlDataAdapter(_cmd);
                _da.Fill(retDs);
                if(_conn.State == ConnectionState.Open) { _conn.Close(); }
                return retDs;
	        }
	        catch (System.Exception)
	        {
		        throw;
	        }
    }
    public static DataSet GetDatasetWithConnection(string constr, string Quary)
    {
        try
        {
            DataSet retDs = new DataSet();
            _conn = new SqlConnection(constr);
            _conn.Open();
            _cmd = new SqlCommand(Quary, _conn);

            _da = new SqlDataAdapter(_cmd);
            _da.Fill(retDs);
            if (_conn.State == ConnectionState.Open) { _conn.Close(); }
            return retDs;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public static bool ExcuteNonQuary(string Quary)
    {
         try 
	        {	        
		        _conn=new SqlConnection(GetConnectionString());
                _conn.Open();
                _cmd=new SqlCommand(Quary,_conn);
                bool RetStat=Convert.ToBoolean(_cmd.ExecuteNonQuery());
                if (_conn.State == ConnectionState.Open){ _conn.Close(); }
                return true;

	        }
	        catch (System.Exception)
	        {
		        throw;
	        }

    }

    public static object ExcuteScaler(string Quary)
    {
         try 
	        {	        
		        _conn=new SqlConnection(GetConnectionString());
                _conn.Open();
                _cmd=new SqlCommand(Quary,_conn);
                object RetStat=_cmd.ExecuteScalar();
                if (_conn.State == ConnectionState.Open) { _conn.Close(); }
                return RetStat;

	        }
	        catch (System.Exception)
	        {
		        throw;
	        }

    }

      public static int ExcuteNonQuaryandGetID(string Quary)
    {
        
        string query2 = "Select @@Identity";
        int ID;

        try
        {
      
        using (_conn= new SqlConnection(GetConnectionString()))
        {
            using ( _cmd = new SqlCommand(Quary, _conn))
            {
               _conn.Open();

                _cmd.ExecuteNonQuery();

                _cmd.CommandText = query2;

                ID = (int)_cmd.ExecuteScalar();

            }

        }

        return ID;

        }
        catch (System.Exception)
        {

            throw;
        }

    }

      public static DataSet Get_SP_DataSetWithParameters(string StoredProcName, params SqlParameter[] commandParameters)
        {
            DataSet DS = new DataSet();
            // This is the function to execute any stored procedure with Parameter and gets the resultset / Dataset
           
            using (_conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) { _conn.Open(); }
                    SqlCommand Cmd = new SqlCommand();
                    SqlDataAdapter DA;


                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = StoredProcName;

                    Cmd.Connection = _conn;
                    // Opening The Connection
                  
                    foreach (SqlParameter SqlParam in commandParameters)
                    {
                        Cmd.Parameters.Add(SqlParam);

                    }
                    DA = new SqlDataAdapter(Cmd);
                    DA.Fill(DS);

                    Cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (_conn.State != ConnectionState.Closed) { _conn.Close(); }
                }
            }
            return DS;
        }

       // #region Execute  Query With Parameters
      public static void Execute_SP_NonQueryWithParameters (string StoredProcName, params SqlParameter[] commandParameters)
      {
          // This is the function to execute any stored procedure with Parameter
          using (_conn = new SqlConnection(GetConnectionString()))
          {
              try
              {
                  if (_conn.State != ConnectionState.Open) 
                  {
                      _conn.Open(); 
                  }
                  SqlCommand Cmd = new SqlCommand();
                  SqlDataAdapter DA;


                  Cmd.CommandType = CommandType.StoredProcedure;
                  Cmd.CommandText = StoredProcName;

                  Cmd.Connection = _conn;
                  // Opening The Connection

                  foreach (SqlParameter SqlParam in commandParameters)
                  {
                      Cmd.Parameters.Add(SqlParam);

                  }
                  // Executing The Stored Procedure
                  Cmd.ExecuteNonQuery();
                  Cmd.Parameters.Clear();
                  //Tran.Commit();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
              finally
              {
                  if (_conn.State != ConnectionState.Closed) { _conn.Close(); }
              }
          }
      }

}


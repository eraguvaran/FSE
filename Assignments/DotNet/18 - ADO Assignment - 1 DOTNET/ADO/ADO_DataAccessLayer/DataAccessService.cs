using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO_DataAccessLayer
{
  public class DataAccessService
  {
    #region members
    SqlConnection _con;
    DataSet _dataSet = new DataSet();
    SqlCommand _cmd;
    SqlDataAdapter DA;
    public static string ConnectionString;


    #endregion

    public DataAccessService() {
      ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"].ToString();
    }

    //1.Get all records of Product_Details Table
    //2.Get all records of SupplierInfo Table

    public DataSet getAllProducts()
    {
      return SQL_DataFillExecute("Select * from [ADO].[Product_Details]");
    }

    public DataSet getAllSupplierInfo()
    {
      return SQL_DataFillExecute("Select * from [ADO].[SUPPLIER_INFO]");
    }

    public bool InsertProduct(string sqlCommandText)
    {
      return SQLExecuteNonQuery(sqlCommandText);

    }

    public DataTable executeGetResult(string sqlCommandText)
    {
      return SQL_DataFillExecute(sqlCommandText).Tables[0];
    }

    private DataSet SQL_DataFillExecute(string sqlCommandText)
    {
      using (_con = new SqlConnection(ConnectionString))
      {
        
        DA = new SqlDataAdapter(sqlCommandText, _con);
        DA.Fill(_dataSet);
      }
      return _dataSet;
    }

    private bool SQLExecuteNonQuery(string sqlCommandText)
    {
      bool result = false;
      using (_con = new SqlConnection(ConnectionString))
      {
        _con.Open();
        _cmd = new SqlCommand(sqlCommandText, _con);
        result = Convert.ToBoolean(_cmd.ExecuteNonQuery());
      }
      return result;
    }
  }
}

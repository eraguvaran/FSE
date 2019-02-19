using ADO_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ADO_BusinessAccessLayer
{
  public class ProductSupplierService
  {
    DataAccessService _dalObject = new DataAccessService();
    public List<ProductDetails> GetAllProducts()
    {
      List<ProductDetails> objProductsSuppliersInfo = new List<ProductDetails>();
      DataSet ds = _dalObject.getAllProducts();
      objProductsSuppliersInfo = ds.Tables[0].ToList<ProductDetails>();
      return objProductsSuppliersInfo;
    }

    public List<SupplierInfoDetails> GetAllSupplier()
    {
      List<SupplierInfoDetails> objProductsSuppliersInfo = new List<SupplierInfoDetails>();
      DataSet ds = _dalObject.getAllSupplierInfo();
      objProductsSuppliersInfo = ds.Tables[0].ToList<SupplierInfoDetails>();
      return objProductsSuppliersInfo;
    }

    public bool AddProduct(ProductDetails objProductsSuppliersInfo)
    {
      _dalObject.InsertProduct("INSERT INTO [ADO].[Product_Details] ([ProductName] ,[SupplierId]) VALUES ('" + objProductsSuppliersInfo.ProductName + "',  " + objProductsSuppliersInfo.SupplierId + ")");
      return _dalObject.InsertProduct("INSERT INTO [ADO].[Product_Details] ([ProductName] ,[SupplierId]) VALUES ('" + objProductsSuppliersInfo.ProductName + "',  " + objProductsSuppliersInfo.SupplierId + ")");
    }

    public ProductDetails getProductByProductID(int ProductID)
    {
      List<ProductDetails> pdt = new List<ProductDetails>();
      DataTable Dt = _dalObject.executeGetResult("Select * from [ADO].[Product_Details] where ProductID = " + ProductID.ToString());
      return Dt.ToList<ProductDetails>().FirstOrDefault();
    }
  }
  

  public static class Extensions
  {
    public static List<T> ToList<T>(this DataTable table) where T : new()
    {
      IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
      List<T> result = new List<T>();

      foreach (var row in table.Rows)
      {
        var item = CreateItemFromRow<T>((DataRow)row, properties);
        result.Add(item);
      }

      return result;
    }

    private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
    {
      T item = new T();
      foreach (var property in properties)
      {
        if (property.PropertyType == typeof(System.DayOfWeek))
        {
          DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
          property.SetValue(item, day, null);
        }
        else
        {
          try
          {
            
            if (row[property.Name] == DBNull.Value)
              property.SetValue(item, null, null);
            else
              property.SetValue(item, row[property.Name], null);
          }
          catch (Exception)
          { 
          }
        }
      }
      return item;
    }
  }
}

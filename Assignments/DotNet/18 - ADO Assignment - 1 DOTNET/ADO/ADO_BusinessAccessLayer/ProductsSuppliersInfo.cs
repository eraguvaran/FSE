using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_DataAccessLayer
{
  public class ProductsSuppliersInfo
  { //[ProductId] int IDENTITY(300,1) ,
    //[ProductName] varchar(50) Not null,
    //[SupplierId] [INT not null,
    //[SupplierId] INT IDENTITY(100,1),
    //[SupplierName] VARCHAR(50),
    //[Address]      NVARCHAR(Max),
    //[City]         VARCHAR(30),
    //[ContactNo]    NVARCHAR(20),
    //[Email]        NVARCHAR(50)
    //   Primary Key([SupplierId]),
    public ProductsSuppliersInfo()
    {

    }

    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string ContactNo { get; set; }
    public string Email { get; set; }
    
  }
}

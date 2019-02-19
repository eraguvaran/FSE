using ADO_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO_Assignment.Models
{
  public class ProdutSupplierModel
  {
    public ProdutSupplierModel() {
      _ProductDetails = new List<ProductDetails>();
      _SupplierInfoDetails = new List<SupplierInfoDetails>();
      _ProductsSuppliersInfo = new List<ProductsSuppliersInfo>();
    }

    public List<ProductDetails> _ProductDetails { get; set; }
    
    public List<SupplierInfoDetails> _SupplierInfoDetails { get; set; }

    public List<ProductsSuppliersInfo> _ProductsSuppliersInfo { get; set; }
  }
}
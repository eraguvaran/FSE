using ADO_BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ADO_DataAccessLayer
{
  
  public class ProductDetails
  {

    public ProductDetails()
    {
      //List<SelectListItem> Supplier = new List<SelectListItem>();
      //Supplier.Add(new SelectListItem
      //{
      //  Value = "Select",
      //  Text = "Select"
      //});
      //IEnumerable<SelectListItem> obj = Supplier.ToList();
      //Suppliers =  new SelectList(Supplier, "Value", "Text");
      ProductSupplierService _ProductSupplierService = new ProductSupplierService();

      List<SupplierInfoDetails> _SupplierInfoDetails = _ProductSupplierService.GetAllSupplier();
      IEnumerable<SelectListItem> Suppliers = _SupplierInfoDetails
             .OrderBy(n => n.SupplierName)
             .Select(n =>
                new SelectListItem
                {
                  Value = n.SupplierId.ToString(),
                  Text = n.SupplierName
                }).ToList();
      Suppliers = new SelectList(Suppliers, "Value", "Text");
       
    }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int SupplierId { get; set; }

    
    public SelectList Suppliers { get; set; }
  }
}

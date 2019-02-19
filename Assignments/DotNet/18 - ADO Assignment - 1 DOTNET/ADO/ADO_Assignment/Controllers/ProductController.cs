using ADO_Assignment.Models;
using ADO_BusinessAccessLayer;
using ADO_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_Assignment.Controllers
{
  public class ProductController : Controller
  {
    ProductSupplierService _ProductSupplierService = new ProductSupplierService();
    // GET: Product
    public ActionResult Index()
    {
      ProdutSupplierModel objProductsSuppliersInfo = new ProdutSupplierModel();
      objProductsSuppliersInfo._ProductDetails = _ProductSupplierService.GetAllProducts();
      objProductsSuppliersInfo._SupplierInfoDetails = _ProductSupplierService.GetAllSupplier().Where(x => x.SupplierName != null && x.SupplierName != string.Empty).ToList();
      
      return View(objProductsSuppliersInfo);
    }

    // GET: Product/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: Product/Create
    public ActionResult Create()
    {
      ProductDetails model = new ProductDetails();
      ProdutSupplierModel objProductsSuppliersInfo = new ProdutSupplierModel();
         List<SupplierInfoDetails> _SupplierInfoDetails = _ProductSupplierService.GetAllSupplier();
      IEnumerable<SelectListItem> Suppliers = _SupplierInfoDetails
             .OrderBy(n => n.SupplierName)
             .Select(n =>
                new SelectListItem
                {
                  Value = n.SupplierId.ToString(),
                  Text = n.SupplierName
                }).ToList();
      model.Suppliers = new SelectList( Suppliers, "Value", "Text");
      return View(model);
    }

    //public IEnumerable<SelectListItem> GetRegions(string iso3)
    //{
    //  if (!String.IsNullOrWhiteSpace(iso3))
    //  {
    //    using (var context = new ApplicationDbContext())
    //    {
    //      IEnumerable<SelectListItem> regions = context.Regions.AsNoTracking()
    //          .OrderBy(n => n.RegionNameEnglish)
    //          .Where(n => n.Iso3 == iso3)
    //          .Select(n =>
    //             new SelectListItem
    //             {
    //               Value = n.RegionCode,
    //               Text = n.RegionNameEnglish
    //             }).ToList();
    //      return new SelectList(regions, "Value", "Text");
    //    }
    //  }
    //  return null;
    //}

    // POST: Product/Create
    [HttpPost]
    public ActionResult Create(ProductDetails model)
    {
      try
      {
        // TODO: Add insert logic here
        _ProductSupplierService.AddProduct(model);
        return RedirectToAction("Index");
      }
      catch(Exception ex)
      {
        return View();
      }
    }

    // GET: Product/Edit/5
    public ActionResult Edit(int id)
    {
       
      return View(_ProductSupplierService.getProductByProductID(id));
    }

    // POST: Product/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Product/Delete/5
    public ActionResult Delete(int id)
    {
      return View(_ProductSupplierService.getProductByProductID(id));
    }

    // POST: Product/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}

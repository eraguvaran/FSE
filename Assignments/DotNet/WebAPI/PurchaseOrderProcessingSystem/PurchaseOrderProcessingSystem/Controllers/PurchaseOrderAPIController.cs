using PurchaseOrderProcessingSystem.Models;
using PurchaseOrderProcessingSystemBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PurchaseOrderProcessingSystem.Controllers
{
    public class PurchaseOrderAPIController : ApiController
    {
        public List<Item> getItemList()
        {
            PurchaseOrderProcessingsystemBL PO = new PurchaseOrderProcessingsystemBL();
            var itemlist = PO.GetItemList();
            var itmList = (from i in itemlist
                           select new Item
                           {
                               ItemCode = i.ItemCode,
                               ItemName = i.ItemDecription,
                               ItemPrice = i.ItemRate
                           }).ToList();
            return itmList;
        }
    }
}
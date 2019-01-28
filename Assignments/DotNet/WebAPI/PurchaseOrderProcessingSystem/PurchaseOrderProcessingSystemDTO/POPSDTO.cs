using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrderProcessingSystemDTO
{
    public class Status
    {
        public string Message { get; set; }
        public string Error { get; set; }
    }
    public class Item
    {
        public string ItemCode { get; set; }

        public string ItemDecription { get; set; }

        public decimal ItemRate { get; set; }

        public Status Message { get; set; }
    }

    public class PurchaseOrder
    {
        public string PONumber { get; set; }

        public string ItemCode { get; set; }

        public int Quantity { get; set; }

        public Item Item { get; set; }

        public DateTime PODate { get; set; }

        public string SupplierNumber { get; set; }

        public Supplier SupplierDetails { get; set; }

        public Status Message { get; set; }
    }

    public class Supplier
    {
        public string SupplierNumber { get; set; }

        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }

        public Status Message { get; set; }
    }
}

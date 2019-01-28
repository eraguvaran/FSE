using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseOrderProcessingSystem.Models
{
    public class Item
    {
        public Item()
        {
            this.ItemCode = "";
            this.ItemName = "";
            this.ItemPrice = 0.00M;
        }
        [Required(ErrorMessage = "required")]
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "required")]
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "required")]
        [DisplayName("Item Price")]
        public decimal ItemPrice { get; set; }
    }
}
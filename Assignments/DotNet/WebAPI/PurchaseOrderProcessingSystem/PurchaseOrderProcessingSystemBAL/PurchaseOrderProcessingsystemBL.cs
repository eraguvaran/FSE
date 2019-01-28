using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrderProcessingSystemDTO;
using PurchaseOrderProcessingSystemDAL;

namespace PurchaseOrderProcessingSystemBAL
{
    public class PurchaseOrderProcessingsystemBL : IPurchaseOrderProcessingSystem
    {
        PurchaseOrderProcessingSystemDL poDAL = new PurchaseOrderProcessingSystemDL();
        public Item AddItem(Item item)
        {
            Item itemDet = new Item();
            try
            {
                itemDet = poDAL.AddItem(item);
                itemDet.Message.Message = "Item Added Sucessfully";
            }
            catch(Exception ex)
            {
                itemDet.Message.Error = "Error Adding Item";
            }
            return itemDet;
        }

        public PurchaseOrder AddPurchaseOrder(PurchaseOrder item)
        {
            PurchaseOrder poDet = new PurchaseOrder();
            try
            {
                poDet = poDAL.AddPurchaseOrder(item);
                poDet.Message.Message = "Purchase Order Added Sucessfully";
            }
            catch (Exception ex)
            {
                poDet.Message.Error = "Error Adding Purchase Order";
            }
            return poDet;
        }

        public Supplier AddSupplier(Supplier item)
        {
            Supplier supplierDet = new Supplier();
            try
            {
                supplierDet = poDAL.AddSupplier(item);
                supplierDet.Message.Message = "Supplier Added Sucessfully";
            }
            catch (Exception ex)
            {
                supplierDet.Message.Error = "Error Adding Supplier";
            }
            return supplierDet;
        }

        public List<Item> DeleteItem(string itemCode)
        {
            return poDAL.DeleteItem(itemCode);
        }

        public List<PurchaseOrder> DeletePurchaseOrder(string PONumber)
        {
            return poDAL.DeletePurchaseOrder(PONumber);
        }

        public List<Supplier> DeleteSupplier(string supplierNumber)
        {
            return poDAL.DeleteSupplier(supplierNumber);
        }

        public Item GetItem(string itemCode)
        {
            return poDAL.GetItem(itemCode);
        }

        public List<Item> GetItemList()
        {
            return poDAL.GetItemList();
        }

        public PurchaseOrder GetPurchaseOrder(string PONumber)
        {
            return poDAL.GetPurchaseOrder(PONumber);
        }

        public List<PurchaseOrder> GetPurchaseOrderList()
        {
            return poDAL.GetPurchaseOrderList();
        }

        public Supplier GetSupplier(string supplierNumber)
        {
            return poDAL.GetSupplier(supplierNumber);
        }

        public List<Supplier> GetSupplierList()
        {
            return poDAL.GetSupplierList();
        }

        public Item UpdateItem(Item item)
        {
            Item itm = new Item();
            try
            {
                itm = poDAL.UpdateItem(item);
                itm.Message.Message = "Item updated Sucessfully";
            }
            catch(Exception ex)
            {
                itm.Message.Error = "Error updating Item";
            }
            return itm;
        }

        public PurchaseOrder UpdatePurchaseOrder(PurchaseOrder item)
        {
            PurchaseOrder itm = new PurchaseOrder();
            try
            {
                itm = poDAL.UpdatePurchaseOrder(item);
                itm.Message.Message = "Purchase Order updated Sucessfully";
            }
            catch (Exception ex)
            {
                itm.Message.Error = "Error updating Purchase Order";
            }
            return itm;
        }

        public Supplier UpdateSupplier(Supplier item)
        {
            Supplier itm = new Supplier();
            try
            {
                itm = poDAL.UpdateSupplier(item);
                itm.Message.Message = "Supplier updated Sucessfully";
            }
            catch (Exception ex)
            {
                itm.Message.Error = "Error updating Supplier";
            }
            return itm;
        }
    }
}

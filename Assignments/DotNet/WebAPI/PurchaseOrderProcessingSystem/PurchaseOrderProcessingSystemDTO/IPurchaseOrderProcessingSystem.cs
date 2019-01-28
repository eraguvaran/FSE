using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrderProcessingSystemDTO;

namespace PurchaseOrderProcessingSystemDTO
{
    public interface IPurchaseOrderProcessingSystem
    {

        #region item

        Item AddItem(Item item);
        Item UpdateItem(Item item);
        List<Item> DeleteItem(string itemCode);
        Item GetItem(string itemCode);
        List<Item> GetItemList();

        #endregion

        #region Supplier

        Supplier AddSupplier(Supplier item);
        Supplier UpdateSupplier(Supplier item);
        List<Supplier> DeleteSupplier(string supplierNumber);
        Supplier GetSupplier(string supplierNumber);
        List<Supplier> GetSupplierList();

        #endregion

        #region PurchaseOrder

        PurchaseOrder AddPurchaseOrder(PurchaseOrder item);
        PurchaseOrder UpdatePurchaseOrder(PurchaseOrder item);
        List<PurchaseOrder> DeletePurchaseOrder(string PONumber);
        PurchaseOrder GetPurchaseOrder(string PONumber);
        List<PurchaseOrder> GetPurchaseOrderList();

        #endregion

    }
}

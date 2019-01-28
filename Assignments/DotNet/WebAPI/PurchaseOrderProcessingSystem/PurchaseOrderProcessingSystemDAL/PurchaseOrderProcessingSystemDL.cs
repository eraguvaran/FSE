using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrderProcessingSystemDTO;

namespace PurchaseOrderProcessingSystemDAL
{
    public class PurchaseOrderProcessingSystemDL : IPurchaseOrderProcessingSystem
    {
        PODbEntities PODb = new PODbEntities();
        public Item AddItem(Item item)
        {
            if(item != null)
            {
                ITEM itm = new ITEM();
                itm.ITCODE = item.ItemCode;
                itm.ITDESC = item.ItemDecription;
                itm.ITRATE = item.ItemRate;
                PODb.ITEMs.Add(itm);
                PODb.SaveChanges();
            }
            return item;
        }

        public PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder != null)
            {
                POMASTER poMaster = new POMASTER();
                PODETAIL poDetail = new PODETAIL();
                poMaster.PONO = purchaseOrder.PONumber;
                poMaster.PODATE = purchaseOrder.PODate;
                poMaster.SUPLNO = purchaseOrder.SupplierNumber;

                poDetail.PONO = purchaseOrder.PONumber;
                poDetail.ITCODE = purchaseOrder.ItemCode;
                poDetail.QTY = purchaseOrder.Quantity;

                PODb.POMASTERs.Add(poMaster);
                PODb.PODETAILs.Add(poDetail);
                PODb.SaveChanges();
            }
            return purchaseOrder;
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                SUPPLIER supp = new SUPPLIER();
                supp.SUPLNO = supplier.SupplierNumber;
                supp.SUPLNAME = supplier.SupplierName;
                supp.SUPLADDR = supplier.SupplierAddress;
                PODb.SUPPLIERs.Add(supp);
                PODb.SaveChanges();
            }
            return supplier;
        }

        public List<Item> DeleteItem(string ItemCode)
        {
            var item = (from p in PODb.ITEMs
                            where p.ITCODE == ItemCode
                        select p).FirstOrDefault();
            PODb.ITEMs.Remove(item);
            PODb.SaveChanges();
            return GetItemList();
        }

        public List<PurchaseOrder> DeletePurchaseOrder(string PONumber)
        {
            var POMaster = (from p in PODb.POMASTERs
                      where p.PONO == PONumber
                      select p).FirstOrDefault();
            var PODetail = (from p in PODb.PODETAILs
                            where p.PONO == PONumber
                            select p).FirstOrDefault();
            PODb.PODETAILs.Remove(PODetail);
            PODb.POMASTERs.Remove(POMaster);
            PODb.SaveChanges();
            return GetPurchaseOrderList();
        }

        public List<Supplier> DeleteSupplier(string supplierNumber)
        {
            var supplier = (from p in PODb.SUPPLIERs
                        where p.SUPLNO == supplierNumber
                            select p).FirstOrDefault();
            PODb.SUPPLIERs.Remove(supplier);
            PODb.SaveChanges();
            return GetSupplierList();
        }

        public Item GetItem(string itemCode)
        {
            var item = (from itm in PODb.ITEMs
                        where itm.ITCODE == itemCode
                        select new Item()
                        {
                            ItemCode = itm.ITCODE,
                            ItemDecription = itm.ITDESC,
                            ItemRate = itm.ITRATE ?? 0
                        }).FirstOrDefault();
            return item;
        }

        public List<Item> GetItemList()
        {
            var item = (from itm in PODb.ITEMs
                        select new Item()
                        {
                            ItemCode = itm.ITCODE,
                            ItemDecription = itm.ITDESC,
                            ItemRate = itm.ITRATE ?? 0
                        }).ToList();
            return item;
        }

        public PurchaseOrder GetPurchaseOrder(string PONumber)
        {
            var PODetail = (from poDet in PODb.PODETAILs
                            where poDet.PONO == PONumber
                            select poDet).ToList();

            var POMaster = (from itm in PODb.POMASTERs
                        where itm.PONO == PONumber
                            select itm).ToList();

            var PurchaseOrd = (from poDet in PODetail
                               join poMast in POMaster on poDet.PONO equals poMast.PONO
                               select new PurchaseOrder
                               {
                                   PONumber = poDet.PONO,
                                   PODate = poMast.PODATE ?? DateTime.MinValue,
                                   ItemCode = poDet.ITCODE,
                                   Quantity = poDet.QTY ?? 0,
                                   SupplierNumber = poMast.SUPLNO

                               }).FirstOrDefault();
            return PurchaseOrd;

        }

        public List<PurchaseOrder> GetPurchaseOrderList()
        {
            var PODetail = (from poDet in PODb.PODETAILs
                            select poDet).ToList();

            var POMaster = (from itm in PODb.POMASTERs
                            select itm).ToList();

            var PurchaseOrd = (from poDet in PODetail
                               join poMast in POMaster on poDet.PONO equals poMast.PONO
                               select new PurchaseOrder
                               {
                                   PONumber = poDet.PONO,
                                   PODate = poMast.PODATE ?? DateTime.MinValue,
                                   ItemCode = poDet.ITCODE,
                                   Quantity = poDet.QTY ?? 0,
                                   SupplierNumber = poMast.SUPLNO

                               }).ToList();
            return PurchaseOrd;
        }

        public Supplier GetSupplier(string supplierNumber)
        {
            var item = (from itm in PODb.SUPPLIERs
                        where itm.SUPLNO == supplierNumber
                        select new Supplier()
                        {
                            SupplierNumber = itm.SUPLNO,
                            SupplierAddress = itm.SUPLADDR,
                            SupplierName = itm.SUPLNAME
                        }).FirstOrDefault();
            return item;
        }

        public List<Supplier> GetSupplierList()
        {
            var item = (from itm in PODb.SUPPLIERs
                        select new Supplier()
                        {
                            SupplierNumber = itm.SUPLNO,
                            SupplierAddress = itm.SUPLADDR,
                            SupplierName = itm.SUPLNAME
                        }).ToList();
            return item;
        }

        public Item UpdateItem(Item item)
        {
            var itemDet = (from itm in PODb.ITEMs
                           where itm.ITCODE == item.ItemCode
                           select itm).FirstOrDefault();
            itemDet.ITCODE = item.ItemCode;
            itemDet.ITDESC = item.ItemDecription;
            itemDet.ITRATE = item.ItemRate;
            PODb.SaveChanges();
            return GetItem(item.ItemCode);
        }

        public PurchaseOrder UpdatePurchaseOrder(PurchaseOrder item)
        {
            var poMaster = (from itm in PODb.POMASTERs
                           where itm.PONO == item.PONumber
                           select itm).FirstOrDefault();
            var poDetail = (from itm in PODb.PODETAILs
                            where itm.PONO == item.PONumber
                            select itm).FirstOrDefault();

            poMaster.PONO = item.PONumber;
            poMaster.PODATE = item.PODate;
            poMaster.SUPLNO = item.SupplierNumber;

            poDetail.PONO = item.PONumber;
            poDetail.ITCODE = item.ItemCode;
            poDetail.QTY = item.Quantity;

            PODb.SaveChanges();
            return GetPurchaseOrder(item.PONumber);
        }

        public Supplier UpdateSupplier(Supplier item)
        {
            var itemDet = (from itm in PODb.SUPPLIERs
                           where itm.SUPLNO == item.SupplierNumber
                           select itm).FirstOrDefault();
            itemDet.SUPLNO = item.SupplierNumber;
            itemDet.SUPLNAME = item.SupplierName;
            itemDet.SUPLADDR = item.SupplierAddress;
            PODb.SaveChanges();
            return GetSupplier(item.SupplierNumber);
        }
    }
}

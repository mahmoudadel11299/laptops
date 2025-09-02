﻿using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface ISalesInvoice
    {
        //public List<VwSalesInvoice> GetAll();

        public TbSalesInvoice GetById(int id);

        public bool Save(TbSalesInvoice Item, List<TbSalesInvoiceItem> lstItems, bool isNew);

        public bool Delete(int id);
    }
    public class ClsSalesInvoice : ISalesInvoice
    {
        LapShopContext ctx;
        ISalesInvoiceItems salesInvoiceItemsService;
        public ClsSalesInvoice(LapShopContext context,
            ISalesInvoiceItems invoiceItems)
        {
            ctx = context;
            salesInvoiceItemsService = invoiceItems;
        }
        //public List<VwSalesInvoice> GetAll()
        //{
        //    try
        //    {
        //        return ctx.VwSalesInvoices.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception();
        //    }
        //}

        public TbSalesInvoice GetById(int id)
        {
            try
            {
                var Item = ctx.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
                if (Item == null)
                    return new TbSalesInvoice();
                else
                    return Item;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public bool Save(TbSalesInvoice Item, List<TbSalesInvoiceItem> lstItems, bool isNew)
        {
            using var transaction = ctx.Database.BeginTransaction();
            try
            {
                Item.currentstate = 1;
                if (isNew)
                {
                    Item.createdby = "1";
                    Item.createddate = DateTime.Now;
                    ctx.TbSalesInvoices.Add(Item);
                }

                else
                {
                    Item.updatedby = "1";
                    Item.updateddate = DateTime.Now;
                    ctx.Entry(Item).State = EntityState.Modified;
                }

                ctx.SaveChanges();
                salesInvoiceItemsService.Save(lstItems, Item.InvoiceId, true);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var Item = ctx.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
                if (Item != null)
                {
                    ctx.TbSalesInvoices.Remove(Item);
                    ctx.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }

}

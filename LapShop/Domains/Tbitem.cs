using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Tbitem
    {
        [Key]

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal PurchacePrice { get; set; }
        public int Categoryid { get; set; }
        public string? imagename { get; set; }
        public int currentstate { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        public string? createdby { get; set; }
        public string? updatedby { get; set; }
        public TbCategory category { get; set; }
        public List<TbSalesInvoiceItem> salesinvoiceitems { get; set; } = new List<TbSalesInvoiceItem>();
        public List<TbItemImage> images { get; set; } = new List<TbItemImage>();

    }
}

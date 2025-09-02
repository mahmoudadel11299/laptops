using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class TbSalesInvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public int Qty { get; set; }
        public decimal InvoicePrice { get; set; }
        public string? Notes { get; set; }

        public TbSalesInvoice salesinvoice { get; set; }
        public Tbitem items { get; set; }
    }
}

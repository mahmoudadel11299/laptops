using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class TbSalesInvoice
    {
        [Key]

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public int currentstate { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        public string? createdby { get; set; }
        public string? updatedby { get; set; }
        public string? Notes { get; set; }
        public List<TbSalesInvoiceItem> salesinvoiceitems { get; set; } = new List<TbSalesInvoiceItem>();

    }
}

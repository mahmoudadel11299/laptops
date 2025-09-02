using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class VwItemCategory
    {
        public int itemid { get; set; }
        public string itemname { get; set; }
        public int categoryid { get; set; }
        public string categoryname { get; set; }

        public decimal SalesPrice { get; set; }
        public decimal PurchacePrice { get; set; }


    }
}

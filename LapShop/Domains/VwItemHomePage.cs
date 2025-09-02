using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class VwItemHomePage
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public decimal SalesPrice { get; set; }
        public string ItemImageName { get; set; }
        public string CategoryImageName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class TbCategory
    {
        [Key]
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public string ImageName { get; set; }
        public int currentstate { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        public string? createdby { get; set; }
        public string? updatedby { get; set; }
        public ICollection<Tbitem> items { get; set; } = new List<Tbitem>();
    }
}

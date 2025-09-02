using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class TbItemImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int currentstate { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        public string? createdby { get; set; }
        public string? updatedby { get; set; }
        public int ItemId { get; set; }
        public Tbitem item { get; set; }
    }
}

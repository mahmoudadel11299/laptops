using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LapShop.Models
{
    public class ItemModel
    {
        [ValidateNever]
        public int ItemId { get; set; }
        [Required(ErrorMessage ="itemname is required"),MaxLength(200)]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "SalesPrice is required"),Range(1000,10000)]

        public decimal SalesPrice { get; set; }
        [Required(ErrorMessage = "PurchasePrice is required"), Range(1000, 10000)]

        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "CategoryName is required")]
        public int CategoryId { get; set; }


        public string? ImageName { get; set; }
    }
}

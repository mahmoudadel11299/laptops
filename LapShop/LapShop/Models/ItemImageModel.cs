using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LapShop.Models
{
    public class ItemImageModel
    {
        [ValidateNever]
        public int ImageId { get; set; }
        [ValidateNever]
        public string ImageName { get; set; }
        [Required(ErrorMessage = "itemname required")]

        public int ItemId { get; set; }


    }
}

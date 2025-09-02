using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LapShop.Models
{
    public class CategoryModel
    {
        [ValidateNever]
        public int categoryid { get; set; }
        [Required(ErrorMessage ="category is required")]
        public string categoryname { get; set; }
        [ValidateNever]

        public string ImageName { get; set; }
    }
}

using Bl;
using Domains;
using LapShop.Models;
using LapShop.Utlities;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        Icategories Oclscategories;
        public CategoriesController( Icategories clscategories)
        {
            
            Oclscategories = clscategories;
        }
        public IActionResult List()
        {
            var item = Oclscategories.GetALL();
            return View(item);
        }
        public IActionResult Edite(int? id)
        {

            var category = new CategoryModel();
            if (id != null)
            {
               var categoryid=Oclscategories.GetById(Convert.ToInt32(id));
                category.categoryid = categoryid.Categoryid;
                category.categoryname=categoryid.CategoryName;
                category.ImageName = categoryid.ImageName;
            }

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CategoryModel category, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edite", category);
            else
            {
                TbCategory Ocategory = new TbCategory()
                {
                    Categoryid = category.categoryid,
                    CategoryName = category.categoryname,
                    ImageName= await Helper.UploadImage(Files, "Categories")
                };
                Oclscategories.Save(Ocategory);
            }

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            Oclscategories.Delete(id);
            return RedirectToAction("List");
        }
    }
}

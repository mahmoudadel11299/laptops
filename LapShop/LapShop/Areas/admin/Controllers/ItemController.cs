using Bl;
using Domains;
using LapShop.Models;
using LapShop.Utlities;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]
    public class ItemController : Controller
    {
        Iitems Oclsitems;
        Icategories Oclscategories;
        public ItemController(Iitems clsitems,Icategories clscategories)
        {
            Oclsitems = clsitems;
            Oclscategories = clscategories;
        }
        public IActionResult List()
        {
            var item=Oclsitems.GetALLitemcategory();
            return View(item);
        }
       
        public List<VwItemHomePage> ajaxdata()
        {
            var item = Oclsitems.GetALLitemcategory();
            return item;
        }
        public IActionResult ajaxlist()
        {

            return View();
        }
        public IActionResult Edite(int? id)
        {
            var item = new ItemModel();
            ViewBag.LstCategoryid = Oclscategories.GetCategoryId();

            if (id != null) 
            {
              var itemid = Oclsitems.GetById(Convert.ToInt32(id));
                item.ItemId=itemid.ItemId;
                item.ItemName=itemid.ItemName;
                item.SalesPrice=itemid.SalesPrice;
                item.PurchasePrice=itemid.PurchacePrice;
                item.ImageName=itemid.imagename;
            }

            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult>  Save(ItemModel item,List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edite", item);
            else
            {
              
                Tbitem otbitem = new Tbitem()
                {

                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    SalesPrice = item.SalesPrice,
                    PurchacePrice = item.PurchasePrice,
                    imagename= await Helper.UploadImage(Files, "Items"),
                    Categoryid=item.CategoryId,
                    
                };
            Oclsitems.Save(otbitem);

            }

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            Oclsitems.Delete(id);
            return RedirectToAction("List");
        }
    }
}

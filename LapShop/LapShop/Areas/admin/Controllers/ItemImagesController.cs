using Bl;
using Bl.Migrations;
using Domains;
using LapShop.Models;
using LapShop.Utlities;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]
    public class ItemImagesController : Controller
    {
        Iitemimage Oitemimage;
        Iitems oitems;
        public ItemImagesController(Iitemimage itemimage,Iitems items)
        {
           Oitemimage = itemimage;
            oitems = items;
        }
        public IActionResult List()
        {
            var item = Oitemimage.GetALLitemimage();
            return View(item);
        }
        public IActionResult Edite(int? id)
        {
            var category = new ItemImageModel();
            ViewBag.LstItems = oitems.GetALLitem();
            if (id != null)
            {
             var categoryid = Oitemimage.GetById(Convert.ToInt32(id));
                category.ImageName = categoryid.ImageName;
                category.ImageId = categoryid.ImageId;
            }

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ItemImageModel item, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edite", item);
            else
            {
                TbItemImage tbitemimages = new TbItemImage()
                {
                    ImageName = await Helper.UploadImage(Files, "ItemImages"),
                    ImageId = item.ImageId,
                    ItemId=item.ItemId
                };
             Oitemimage.Save(tbitemimages);

            }

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            Oitemimage.Delete(id);
            return View("List");
        }
    }
}

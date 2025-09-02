using Bl;
using Domains;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class ItemDetailsController : Controller
    {
        Iitems oitem;
        public ItemDetailsController(Iitems item)
        {
            oitem = item;
        }
        public IActionResult ItemDetails(int id)
        {
            ItemDetailsModel vwitemDetails = new ItemDetailsModel();
          vwitemDetails.Items=oitem.GetALLitemHomePage(id);
            vwitemDetails.item=oitem.GetById(id);
            vwitemDetails.RecommendedItems = oitem.Getrecommended(id);
            return View(vwitemDetails);
        }
    }
}

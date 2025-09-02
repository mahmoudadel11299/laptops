using Bl;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LapShop.Controllers
{
    public class HomeController : Controller
    {
        Iitems _items;
        Icategories _category;
        public HomeController(Iitems items,Icategories category)
        {
            _items = items;
            _category = category;
        }
        public IActionResult Index() 
        {
           VmHomePage homePage = new VmHomePage();
            homePage.LstitemCategory = _items.GetALLitemcategory();
           return View(homePage);
        }
    }
}

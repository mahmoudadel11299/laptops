using Bl;
using Domains;
using LapShop.Models;
using LapShop.Utlities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _rolemanager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _rolemanager = roleManager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (!ModelState.IsValid)
                return View("CreateRole", model);
            if (model.id == null)
            {
                IdentityRole user = new IdentityRole()
                {
                    
                    Name = model.name.ToUpper()
                };
                IdentityResult result = await _rolemanager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Rolelist");
                }
                else
                {
                    return View("CreateRole", model);
                }
            }
            else
            {

                var Role = await _rolemanager.FindByIdAsync(model.id);
                Role.Name = model.name;
                var result = await _rolemanager.UpdateAsync(Role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Rolelist");

                }
                else
                {
                    return View("CreateRole", model);

                }
            }




        }
        public async Task<IActionResult> CreateRole(string? id)
        {
            var role = new RoleModel();
            if (id != null)
            {
                var roleid = await _rolemanager.FindByIdAsync(id);
                role.id = roleid.Id;
                role.name = roleid.Name;

            }
            return View(role);

        }
        public IActionResult Rolelist()
        {
            var roles = _rolemanager.Roles.ToList();
            return View(roles);
        }
        public async Task<IActionResult> DeleteRole(string id)
        {

            var roles = await _rolemanager.FindByIdAsync(id);
            if (roles != null)
            {
                await _rolemanager.DeleteAsync(roles);
            }
            else
            {
                return RedirectToAction("Rolelist");

            }

            return RedirectToAction("Rolelist");


        }
    }
}

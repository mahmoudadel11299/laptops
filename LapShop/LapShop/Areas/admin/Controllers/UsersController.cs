using Bl;
using LapShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]
    public class UsersController : Controller
    {
        RoleManager<IdentityRole> _rolemanager;
        UserManager<ApplicationUser> _usermanager;
        LapShopContext context;
        public UsersController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager,LapShopContext ctx)
        {
            _rolemanager = roleManager;
            _usermanager = userManager;
            context = ctx;  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserRoleModel model)
        {
            if (!ModelState.IsValid)
                return View("CreateUser", model);
            if (model.UserId == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;
                var adduser = await _usermanager.CreateAsync(user, model.Password);
                if (adduser.Succeeded)
                {
                    var myUser = await _usermanager.FindByEmailAsync(user.Email);
                    var myRole = await _rolemanager.FindByIdAsync(model.RoleId);

                    var loginresult = await _usermanager.AddToRoleAsync(myUser, myRole.Name);

                    if (loginresult.Succeeded)
                    {
                        return Redirect("Userlist");
                    }
                    else
                    {
                        return View("CreateUser", model);
                    }
                }
                else
                {
                    return View("CreateUser", model);

                }
            }
            else
            {
                var newuser = await _usermanager.FindByIdAsync(model.UserId);

                var currentrole = await _usermanager.GetRolesAsync(newuser);

                var roleid = await _rolemanager.FindByIdAsync(model.RoleId);

                var removeresult = await _usermanager.RemoveFromRolesAsync(newuser, currentrole);

                var login = await _usermanager.AddToRoleAsync(newuser, roleid.Name);
                newuser.Email = model.Email;
                newuser.FirstName = model.FirstName;
                newuser.LastName = model.LastName;
                var newpassword = await _usermanager.ChangePasswordAsync(newuser, newuser.PasswordHash, model.Password);

                var x = await _usermanager.UpdateAsync(newuser);


                if (x.Succeeded)
                {
                    return RedirectToAction("Userlist");
                }
                else
                {
                    return View("CreateUser", model);
                }

            }




        }
        public async Task<IActionResult> CreateUser(string? id)
        {
            ViewBag.role = _rolemanager.Roles.ToList();

            var role = new UserRoleModel();
            if (id != null)
            {

                var userid = await _usermanager.FindByIdAsync(id);
                role.UserId = userid.Id;
                role.FirstName = userid.FirstName;
                role.LastName = userid.LastName;
                role.Password = userid.PasswordHash;
                role.Email = userid.Email;
            }
            else
            {

            }
            return View(role);

        }
        public IActionResult Userlist()
        {
            var roleuser = (from user in context.Users
                            from role in context.Roles
                            join r in context.Roles on role.Id equals r.Id

                            select new RoleUser()
                            {
                                rolename = r.Name,
                                username = user.UserName,
                                email = user.Email,
                                userid = user.Id,


                            }).ToList();

            return View(roleuser);

        }
        public async Task<IActionResult> DeleteUser(string id)
        {

            var roles = await _usermanager.FindByIdAsync(id);
            if (roles != null)
            {
                await _usermanager.DeleteAsync(roles);
                return RedirectToAction("Userlist");
            }
            else
            {
                return RedirectToAction("Userlist");
            }



        }

    }
}

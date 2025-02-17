﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var values=_userManager.Users.ToList(); 

            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==id);
            TempData["userid"] = user.Id;

            var roles=_roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

            foreach (var item in roles) {

                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleName = item.Name; 
                model.RoleID=item.Id;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);

            }
            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModels)
        {
            var userid = (int)TempData["userid"];

            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userid);

            foreach (var item in roleAssignViewModels) {


                if (item.RoleExist) { 
                
                    
                
                }
            
            
            }

            




            return View(roleAssignViewModels);
        }
    }
}

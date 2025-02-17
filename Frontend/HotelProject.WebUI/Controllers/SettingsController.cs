using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync("ferhat");//FindByNameAsync metodu kullanıcı adına  göre arama yapıyor....
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = user.Name;
            userEditViewModel.Surname = user.Surname;
            userEditViewModel.Username = user.UserName;
            userEditViewModel.Email = user.Email;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name); //User.Identity.Name ise geçerli olan kullanıcının kullanıcı adını getiriyor

            user.Name = userEditViewModel.Name;
            user.Surname=userEditViewModel.Surname; 
            user.Email=userEditViewModel.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,userEditViewModel.Password);
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Login");
        }
    }
}

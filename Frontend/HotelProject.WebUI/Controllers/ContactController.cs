using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.ferhatture.store/api/MessageCategory");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.MessageCategoryName,
                                                Value = x.MessageCategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2;

            return View();
        }




        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(createContactDto);

            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.ferhatture.store/api/Contact", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                Console.WriteLine("bi sorun var");
                return View();
                

            }

        }


    }
}

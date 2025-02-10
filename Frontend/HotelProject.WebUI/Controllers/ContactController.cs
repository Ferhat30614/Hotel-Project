using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult Index()
        {
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

            var response = await client.PostAsync("http://localhost:5045/api/Contact", stringContent);

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

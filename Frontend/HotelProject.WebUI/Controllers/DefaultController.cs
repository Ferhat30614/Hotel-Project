using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
           
            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(createSubscribeDto);

            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5045/api/Subscribe", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Sayfa yönlendirmesi tamam hacı....");

                return RedirectToAction("Index", "Default");

            }

            Console.WriteLine("Hata var dostum partial viewew geldi");
            return PartialView();

        }



    }
}

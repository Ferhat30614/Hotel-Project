using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.ferhatture.store/api/About");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);

            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/About/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(dataJson);

                return View(values);

            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {

            var client = _httpClientFactory.CreateClient();
            var dataJson = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://api.ferhatture.store/api/About/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }



    }
}

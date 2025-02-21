using HotelProject.WebUI.Dtos.WorkLocation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class WorkLocationController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public WorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.ferhatture.store/api/WorkLocation");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
                return View(values);

            }


            return View();
        }


        [HttpGet]
        public IActionResult AddWorkLocation()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(AddWorkLocationDto model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(model);

            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://api.ferhatture.store/api/WorkLocation", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();


        }

        public async Task<IActionResult> DeleteWorkLocation(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://api.ferhatture.store/api/WorkLocation/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/WorkLocation/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWorkLocationDto>(dataJson);

                return View(values);

            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto model)
        {

            var client = _httpClientFactory.CreateClient();
            var dataJson = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://api.ferhatture.store/api/WorkLocation/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {


                return RedirectToAction("Index");


            }
            return View();



        }
    }
}

using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
   
    public class ServiceController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.ferhatture.store/api/Service");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);

            }


            return View();
        }



        [HttpGet]
        public IActionResult AddService()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            
            }
            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(createServiceDto);

            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://api.ferhatture.store/api/Service", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();


        }

        public async Task<IActionResult> DeleteService(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://api.ferhatture.store/api/Service/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");


            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Service/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(dataJson);

                return View(values);//  burdaki valuesi aşşada nasıl yollayacam

            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {

                return View(updateServiceDto);//buraya values bu değişkenş model olarak göndermek istiyorum nasıl yapcam?


            }

            var client = _httpClientFactory.CreateClient();
            var dataJson = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://api.ferhatture.store/api/Service/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");


            }
            return View();



        }






    }
}

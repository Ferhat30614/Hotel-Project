using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5045/api/Booking");

            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Herşey yolunda");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);

            }


            return View();
        }


        
        [HttpGet]//burda [HttpGet("{id}")] kullanımı yaptıgımdan hata verdi bana çünkü bu tanım api conrollerlarında olurmuş...
        public async Task<IActionResult> ApprovedReservation(int id)
        {

            Console.WriteLine("idmiz "+id);


            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5045/api/Booking/{id}");
     


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBookingDto>(dataJson);
                Console.WriteLine("valuesin değeri "+values.Name+" " +values.BookingID+ " bukadar " );

               return RedirectToAction("Index");
            }
            Console.WriteLine("Birşeyler ters gidiyor");
            return View();




        }
    }
}

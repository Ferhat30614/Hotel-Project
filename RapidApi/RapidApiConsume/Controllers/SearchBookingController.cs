using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchBookingController : Controller
    {
        public async Task<IActionResult> Index(string cityname)
        {

            if (!string.IsNullOrEmpty(cityname))
            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={cityname}"),
                    Headers =
    {
        { "x-rapidapi-key", "6b99735555msh46fe40a0ee44ff2p1db52bjsnc05306989038" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);



                    return View(values.data.Take(1).ToList());
                }



            }
            else {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=Paris"),
                    Headers =
    {
        { "x-rapidapi-key", "6b99735555msh46fe40a0ee44ff2p1db52bjsnc05306989038" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);



                    return View(values.data.Take(1).ToList());
                }


            }
        }
    }
}

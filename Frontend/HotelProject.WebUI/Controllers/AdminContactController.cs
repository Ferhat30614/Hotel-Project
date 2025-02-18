using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5045/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("  http://localhost:5045/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client.GetAsync(" http://localhost:5045/api/SendMessage/GetSendMessageCount");


            if (responseMessage.IsSuccessStatusCode)
            {
          

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);


                ViewBag.ContectCount = jsonData2;
                ViewBag.SendMessageCount = jsonData3;


                return View(values);

            }


            return View();
        }



        public async Task<PartialViewResult> SideBarAdminContactPartial()
        {
            return PartialView();
        }




        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }


        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5045/api/SendMessage");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);
                return View(values);

            }
            return View();
        }



        [HttpGet]
        public IActionResult AddSendMessage()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessage)
        {
            createSendMessage.SenderMail = "admin@gmail.com";
            createSendMessage.SenderName = "Admin";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(createSendMessage);

            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5045/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("SendBox");

            }

            return View();


        }

       



        public async Task<IActionResult> MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5045/api/SendMessage/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(dataJson);

                return View(values);

            }
            return View();

        }


        
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5045/api/Contact/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(dataJson);

                return View(values);

            }
            return View();

        }



      






    }
}

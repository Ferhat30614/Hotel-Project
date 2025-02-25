﻿using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.ferhatture.store/api/Room");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(values);

            }
            return View();
        }


        [HttpGet]
        public IActionResult AddRoom()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto createRoomDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(createRoomDto);

            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://api.ferhatture.store/api/Room", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();


        }

        public async Task<IActionResult> DeleteRoom(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://api.ferhatture.store/api/Room/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Room/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UptadeRoomDto>(dataJson);

                return View(values);

            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UptadeRoomDto uptadeRoomDto)
        {
           

            Console.WriteLine(uptadeRoomDto.RoomID);
            Console.WriteLine(uptadeRoomDto.RoomNumber);
            Console.WriteLine(uptadeRoomDto.RoomCoverImage);
            Console.WriteLine(uptadeRoomDto.Price);
            Console.WriteLine(uptadeRoomDto.Title);
            Console.WriteLine(uptadeRoomDto.BedCount);
            Console.WriteLine(uptadeRoomDto.BathCount);
            Console.WriteLine(uptadeRoomDto.Wifi);
            Console.WriteLine(uptadeRoomDto.Description);

            var client = _httpClientFactory.CreateClient();
            var dataJson = JsonConvert.SerializeObject(uptadeRoomDto);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://api.ferhatture.store/api/Room/", stringContent);
            Console.WriteLine("respoınse mesag ne durumda");

            if (responseMessage.IsSuccessStatusCode)
            {

                Console.WriteLine("Updade tarafı calısıyor");
                return RedirectToAction("Index");


            }
            return View();



        }



    }
}

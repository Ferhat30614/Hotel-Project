﻿using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.ferhatture.store/api/Guest");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
                return View(values);

            }


            return View();
        }


        [HttpGet]
        public IActionResult AddGuest()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                var jsondata = JsonConvert.SerializeObject(model);

                StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("https://api.ferhatture.store/api/Guest", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");

                }
                return View();
            }
            else {             
                return View();
            }
            



        }

        public async Task<IActionResult> DeleteGuest(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://api.ferhatture.store/api/Guest/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Guest/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDto>(dataJson);

                return View(values);

            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var dataJson = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

                var responseMessage = await client.PutAsync($"https://api.ferhatture.store/api/Guest/", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {


                    return RedirectToAction("Index");


                }
                return View();

            }
            else {
                return View();
            }

        }
    }
}

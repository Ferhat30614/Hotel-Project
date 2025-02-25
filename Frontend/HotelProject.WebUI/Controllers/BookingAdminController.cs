﻿using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var responseMessage = await client.GetAsync("https://api.ferhatture.store/api/Booking");

            if (responseMessage.IsSuccessStatusCode)
            {            

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);

            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Booking/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var dataJson = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://api.ferhatture.store/api/Booking/UpdateBooking", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Booking/BookingApproved?id={id}");

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> CancelReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Booking/BookingCancel?id={id}");

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> WaitReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Booking/BookingWait?id={id}");
            return RedirectToAction("Index");
        }

    }
}

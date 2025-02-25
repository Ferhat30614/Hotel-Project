﻿using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage= await client.GetAsync("https://api.ferhatture.store/api/Staff");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                return View(values);

            }

            
            return View();
        }


        [HttpGet]
        public IActionResult AddStaff() { 
        
        return View();
        
        }


        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsondata =JsonConvert.SerializeObject(model);

            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("https://api.ferhatture.store/api/Staff", stringContent);

            if (responseMessage.IsSuccessStatusCode) { 
                
                return RedirectToAction("Index");
            
            }

            return View();


        }

        public async Task<IActionResult> DeleteStaff(int id) {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://api.ferhatture.store/api/Staff/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://api.ferhatture.store/api/Staff/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(dataJson);

                return View(values);

            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {

            var client = _httpClientFactory.CreateClient();
            var dataJson = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(dataJson,Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://api.ferhatture.store/api/Staff/", stringContent);

            if (responseMessage.IsSuccessStatusCode) {
            
            
            return RedirectToAction("Index");   
            
            
            }
            return View();



        }
    }
}

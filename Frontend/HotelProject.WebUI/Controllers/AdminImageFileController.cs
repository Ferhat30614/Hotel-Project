using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
   
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {

            var stream=new MemoryStream();
            await file.CopyToAsync(stream);

            var bytes=stream.ToArray(); 

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent multipartFormDataContent=new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent,"file",file.FileName);

            var httpclient = new HttpClient();
            var response=await httpclient.PostAsync("https://api.ferhatture.store/api/FileImage", multipartFormDataContent);

            if (response.IsSuccessStatusCode)
            {
                return View();  
            }
            return View();  
        }
    }
}

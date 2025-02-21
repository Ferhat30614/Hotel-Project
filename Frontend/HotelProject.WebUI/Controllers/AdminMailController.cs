using HotelProject.DataAccessLayer.Migrations;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();


            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin","ferhat123.ftr69@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("ferhat123.ftr69@gmail.com", "abppswmnfbuqelnm");
            client.Send(mimeMessage);
            client.Disconnect(true);



            //istersen burada  sendmesaage tablona göderdiğin mesajı kaudetme işlemlerini yapabilirsin...

            CreateSendMessageDto createSendMessage = new CreateSendMessageDto();  
            createSendMessage.SenderMail = "ferhat123.ftr69@gmail.com";
            createSendMessage.SenderName = "HotelierAdmin";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            createSendMessage.ReceiverMail =model.ReceiverMail;
            createSendMessage.ReceiverName = model.Name; 
            createSendMessage.Content=model.Body;
            createSendMessage.Title = model.Subject;


            var client2 = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(createSendMessage);

            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client2.PostAsync("https://api.ferhatture.store/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction( "SendBox", "AdminContact");

            }

            return View();





        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        [HttpGet("[Action]")]//ikiside httpget ama iki actişonada aynı ismi versemde çalısıyor ama isim vermesem calısmıyor..//atıyom ikisi simsiz HttpGet olsa api calısmıyor
        public IActionResult Test()
        {
            return Ok(new CreateToken().TokenCreate());
        }


        [HttpGet("[Action]")]
        public IActionResult AdminTokenOlustur()
        {
            return Ok(new CreateToken().AdminTokenCreate());
        }


        [Authorize]
        [HttpGet("[Action]")]
        public IActionResult Test2()
        {
            return Ok("Hoşgeldiniz...");
        }




        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[Action]")]
        public IActionResult Test3()
        {
            return Ok("Hoşgeldiniz...");
        }

    }
}

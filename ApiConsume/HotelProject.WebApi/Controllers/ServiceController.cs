using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult ServiceList()
        {

            return Ok();

        }
        [HttpPost]
        public IActionResult AddService()
        {

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteService()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UptadeService()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetService()
        {
            return Ok();
        }

    }
}

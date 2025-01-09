using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        [HttpGet]
        public IActionResult TestimonialList()
        {

            return Ok();

        }
        [HttpPost]
        public IActionResult AddTestimonial()
        {

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UptadeTestimonial()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial()
        {
            return Ok();
        }

    }
}

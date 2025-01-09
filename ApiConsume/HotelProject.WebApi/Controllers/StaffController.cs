using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var value=_staffService.TGetList();

            return Ok(value);

        }
        [HttpPost]
        public IActionResult AddStaff(Staff staf)
        {
            _staffService.TInsert(staf);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteStaff()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UptadeStaff()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetStaff()
        {
            return Ok();
        }

    }
}

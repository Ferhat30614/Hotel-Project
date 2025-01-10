﻿using HotelProject.BusinessLayer.Abstract;
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
            var values=_staffService.TGetList();

            return Ok(values);

        }
        [HttpPost]
        public IActionResult AddStaff(Staff staf)
        {
            _staffService.TInsert(staf);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            var values=_staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UptadeStaff(Staff staff)
        {
            _staffService.TUptade(staff);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var values=_staffService.TGetById(id);
            return Ok(values);
        }



    }
}

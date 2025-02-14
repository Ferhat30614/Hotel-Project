using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount() 
        {
            var values=_staffService.TGetStaffCount();  
            return Ok(values);
        }


        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var values = _bookingService.TGetBookingCount();
            return Ok(values);
        }

        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var values = _appUserService.TGetAppUserCount();
            return Ok(values);
        }


    }
}

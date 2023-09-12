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
            var value = _staffService.TGetList();
                return Ok(value);
            }
            [HttpPost]
            public IActionResult AddStaff(Staff staff)
            {
               _staffService.TAdd(staff);
                return Ok();
            }
            [HttpDelete ("{id}")]
            public IActionResult DeleteStaff(int id)
            {
            var values = _staffService.TGetBy(id);
            _staffService.TDelete(values);
                return Ok();
            }
            [HttpPut ]
            public IActionResult UpdateStaff(Staff staff)
            {
            _staffService.TUpdate(staff);

                return Ok();
            }

            [HttpGet("{id}")]
            public IActionResult GetStaff(int id)
            {
            var values = _staffService.TGetBy(id);
                return Ok(values);
            }
        }
}

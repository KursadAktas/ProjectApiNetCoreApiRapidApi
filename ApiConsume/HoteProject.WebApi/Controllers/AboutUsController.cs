using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutService _aboutUsService;

        public AboutUsController(IAboutService AboutUsService)
        {
            _aboutUsService = AboutUsService;
        }

        [HttpGet]
        public IActionResult AboutUsList()
        {
            var value = _aboutUsService.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddAboutUs(AboutUs AboutUs)
        {
            _aboutUsService.TAdd(AboutUs);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAboutUs(int id)
        {
            var values = _aboutUsService.TGetBy(id);
            _aboutUsService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAboutUs(AboutUs AboutUs)
        {
            _aboutUsService.TUpdate(AboutUs);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAboutUs(int id)
        {
            var values = _aboutUsService.TGetBy(id);
            return Ok(values);
        }
    }
}

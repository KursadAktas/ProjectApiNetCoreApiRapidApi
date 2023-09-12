using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _bookingService.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TAdd(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBookinf(int id)
        {
            var values = _bookingService.TGetBy(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetBy(id);
            return Ok(values);
        }
        [HttpPut("bbbb")]
        public IActionResult bbbb(int id)
        {
            _bookingService.TBookingStatusChangeAproved2(id);
            return Ok();
        }
    }
}

using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //api Consume: istekte bulunacak adres oluştur, başarlılı durm kodu dönerse if
        {

            var client = _httpClientFactory.CreateClient(); //istemci oluştur.
            var responseMessage = await client.GetAsync("http://localhost:5279/api/Booking"); // istek atılacak adres
            if (responseMessage.IsSuccessStatusCode) // başarılı durum dönerse 200+
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData); // bize gelen datayı listelemek için deserialize
                return View(value);
            }
            return View();


        }
        public async Task<IActionResult> ApprovedReservation(ApprovedReservationBookingDto approvedReservationBookingDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5279/api/Booking/bbbb", stringContent); // update için put
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

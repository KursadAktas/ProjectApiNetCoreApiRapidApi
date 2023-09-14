using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SentMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SentMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createContactDto); //biz data göndereceğiz o yüzden serialize
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // utf8 TR karakterler
            await client.PostAsync("http://localhost:5279/api/Contact", stringContent); // PostAsync listeleme için postasync

            return RedirectToAction("Index", "Default");

        }
    }
}

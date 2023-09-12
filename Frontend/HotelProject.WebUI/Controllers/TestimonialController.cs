using HotelProject.WebUI.Models.Staff;
using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //api Consume: istekte bulunacak adres oluştur, başarlılı durm kodu dönerse if
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluştur.
            var responseMessage = await client.GetAsync("http://localhost:5279/api/Testimonial"); // istek atılacak adres
            if (responseMessage.IsSuccessStatusCode) // başarılı durum dönerse 200+
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData); // bize gelen datayı listelemek için deserialize
                return View(value);
            }
            return View();


        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(model); //biz data göndereceğiz o yüzden serialize
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // utf8 TR karakterler
            var responceMessage = await client.PostAsync("http://localhost:5279/api/Testimonial", stringContent); // PostAsync listeleme için postasync
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5279/api/Testimonial/{id}"); //api staff controllerda httpdelete att. id ver sonra buradaki linke yaz id yi

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5279/api/Testimonial/{id}"); //get async ile güüncellenecek verileri getir.
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> UpdateTestimonial(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5279/api/Testimonial/", stringContent); // update için put
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

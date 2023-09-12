using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutUsPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluştur.
            var responseMessage = await client.GetAsync("http://localhost:5279/api/AboutUs"); // istek atılacak adres
            if (responseMessage.IsSuccessStatusCode) // başarılı durum dönerse 200+
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData); // bize gelen datayı listelemek için deserialize
                return View(value);
            }
            return View();

        }
    }
}

using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _ServicePartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServicePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluştur.
            var responseMessage = await client.GetAsync("http://localhost:5279/api/Service"); // istek atılacak adres
            if (responseMessage.IsSuccessStatusCode) // başarılı durum dönerse 200+
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData); // bize gelen datayı listelemek için deserialize
                return View(value);
            }
            return View();
        }
    }
}

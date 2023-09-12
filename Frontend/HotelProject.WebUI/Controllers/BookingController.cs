﻿using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task <IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor.";
            var client = _httpClientFactory.CreateClient();
           
            var jsonData = JsonConvert.SerializeObject(createBookingDto); //biz data göndereceğiz o yüzden serialize
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // utf8 TR karakterler
            await client.PostAsync("http://localhost:5279/api/Booking", stringContent); // PostAsync listeleme için postasync
            
                return RedirectToAction("Index","Default");
            
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _ReservetionPartial :ViewComponent
    {
        public IViewComponentResult Invoke() {  return View(); }
    }
}

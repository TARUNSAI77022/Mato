using Microsoft.AspNetCore.Mvc;

namespace Mato.Service.WebApi.Controllers
{
    public class DemoController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

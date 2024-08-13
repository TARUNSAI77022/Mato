using Mato.Service.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Mato.Service.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            string g = "hello";
            return Ok(g);
        }

        public IActionResult Privacy()
        {
            int a = 10;
            int b= 10;
            int c = a + b;


            return Ok(c);
        }

        
    }
}

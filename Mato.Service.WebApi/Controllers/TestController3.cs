using Microsoft.AspNetCore.Mvc;
using System;

namespace Mato.Service.WebApi.Controllers
{
    public class TestController3 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTimeDifference()
        {
            // Get current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Get time zones
            TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            // Convert UTC to IST and EST
            DateTime istTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istZone);
            DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, estZone);

            // Calculate the time difference
            TimeSpan timeDifference = istTime - estTime;

            // Return the time difference as a response
            return Ok(new
            {
                ESTTime = estTime.ToString("yyyy-MM-dd HH:mm:ss"),
                ISTTime = istTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Difference = timeDifference.TotalHours + " hours"
            });
        }
    }
}


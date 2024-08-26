using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Mato.Service.WebApi.Models;

namespace Mato.Service.WebApi.Controllers
{
    public class TestController6 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("CalculateMonthlyProfitLoss")]
        public IActionResult CalculateMonthlyProfitLoss([FromBody] List<Transaction> transactions)
        {
            try
            {
                var monthlyData = transactions
                    .GroupBy(t => new { t.Date.Year, t.Date.Month })
                    .Select(g => new
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Profit = g.Where(t => t.Type.Equals("Profit", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount),
                        Loss = g.Where(t => t.Type.Equals("Loss", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount),
                        NetProfitLoss = g.Where(t => t.Type.Equals("Profit", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount) -
                                        g.Where(t => t.Type.Equals("Loss", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount)
                    })
                    .ToList();

                return Ok(new { MonthlyData = monthlyData, Message = "Monthly profit and loss calculated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}

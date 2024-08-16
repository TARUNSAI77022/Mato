using Microsoft.AspNetCore.Mvc;

namespace Mato.Service.WebApi.Controllers
{
    public class TestController2 : Controller
    {
        [HttpGet("SumOfThreeDigits")]
        public IActionResult SumOfThreeDigits(int digit1, int digit2, int digit3)
        {
            try
            {
                int sum = digit1 + digit2 + digit3;
                return Ok(new { Sum = sum, Message = "Sum calculated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

           
        }
    }
}

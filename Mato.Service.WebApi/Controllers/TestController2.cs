using Microsoft.AspNetCore.Mvc;
using System;

namespace Mato.Service.WebApi.Controllers
{
    public class TestController2 : Controller
    {
        [HttpGet("SumOfThreeDigits")]
        public IActionResult SumOfThreeDigits(int digit1, int digit2, int digit3)
        {
            try
            {
                // Validate that all digits are within the range 0-9
                if (!IsValidDigit(digit1) || !IsValidDigit(digit2) || !IsValidDigit(digit3))
                {
                    return BadRequest(new { Message = "All inputs must be single digits (0-9)." });
                }

                int sum = digit1 + digit2 + digit3;

                // Return the result with the digits and the sum
                return Ok(new
                {
                    Digit1 = digit1,
                    Digit2 = digit2,
                    Digit3 = digit3,
                    Sum = sum,
                    Message = "Sum calculated successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        private bool IsValidDigit(int digit)
        {
            // Check if the digit is between 0 and 9 (inclusive)
            return digit >= 0 && digit <= 9;
        }
    }
}

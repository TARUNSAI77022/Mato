using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Mato.Service.WebApi.Controllers
{
    public class TestController4 : Controller
    {
        public IActionResult Index()
        {
            try
            {
                // Get the first 100 prime numbers
                List<int> primes = GetFirst100Primes();

                // Calculate LCM
                long lcm = CalculateLCM(primes);

                // Return the LCM as JSON
                return Json(new { LCM = lcm });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                return Json(new { Error = "An error occurred while calculating the LCM.", Details = ex.Message });
            }
        }

        private List<int> GetFirst100Primes()
        {
            var primes = new List<int>();
            int number = 2; // The first prime number
            while (primes.Count < 100)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
                number++;
            }
            return primes;
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private long CalculateLCM(List<int> numbers)
        {
            long lcm = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                lcm = LCM(lcm, numbers[i]);
            }
            return lcm;
        }

        private long LCM(long a, long b)
        {
            return (a / HCF(a, b)) * b;
        }

        private int HCF(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return (int)a;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mato.Service.WebApi.Controllers
{
    public class TestController4 : Controller
    {
        public IActionResult Index()
        {
            // Get the first 100 prime numbers
            List<int> primes = GetFirst100Primes();

            // Calculate LCM and HCF
            long lcm = CalculateLCM(primes);
            int hcf = CalculateHCF(primes);

            // Return the result as JSON
            return Json(new { LCM = lcm, HCF = hcf });
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
            return numbers.Aggregate((long)1, (x, y) => LCM(x, y));
        }

        private int CalculateHCF(List<int> numbers)
        {
            return numbers.Aggregate((x, y) => HCF(x, y));
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

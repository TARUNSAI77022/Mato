using AutoMapper;
using Mato.Service.WebApi.DTO;
using Mato.Service.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mato.Service.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestingController1 : Controller
    {

        private readonly sampleContext _dbContext;
        private readonly IMapper _mapper;
        ResponseClass result = new ResponseClass();
        //private readonly ILogger<CouponAPIController> _logger;
        public TestingController1(IMapper mapper1)
        {
            _dbContext = new sampleContext();
            _mapper = mapper1;
        }

        [HttpGet]
        public ResponseClass GetAllCoupons()
        {
            try
            {
                IEnumerable<Coupon> data = _dbContext.Coupons;
                result.Res = data;
                result.responsemessage = "Data Received";
                result.responsecode = 200;
                return result;
            }
            catch (Exception ex)
            {
                result.responsemessage = ex.Message;
                result.responsecode = 500;
                result.Issuccess = false;
                return result;
            }
        }

        [HttpGet("ById/{id:int}")]
        public Coupon GetCouponsById(int id)
        {
            try
            {
                var coupon = _dbContext.Coupons.FirstOrDefault(s => s.Couponid == id);
                return coupon;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("ByCode")]
        public IActionResult GetCouponCode(string CouponCode)
        {
            try
            {
                var code = _dbContext.Coupons.FirstOrDefault(s => s.Couponcode.ToLower() == CouponCode.ToLower());
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateCoupon")]
        public ResponseClass CreateCouponcode(CouponDto couponDto)
        {
            Coupon coupon = new Coupon
            {
                Couponcode = couponDto.CouponCode,
                Discountamount = couponDto.DiscountAmount,
                Minamount = couponDto.MinAmount
            };
            _dbContext.Coupons.Add(coupon);
            _dbContext.SaveChanges();

            result.responsemessage = "Coupon created";
            result.responsecode = 200;
            result.Issuccess = true;
            return result;
        }

        [HttpGet("GetPrimesUpTo500")]
        public ResponseClass GetPrimesUpTo500()
        {
            try
            {
                var primes = new List<int>();
                for (int i = 2; i <= 500; i++)
                {
                    bool isPrime = true;
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primes.Add(i);
                    }
                }

                result.Res = primes;
                result.responsemessage = "Prime numbers up to 500 generated successfully.";
                result.responsecode = 200;
                result.Issuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.responsemessage = ex.Message;
                result.responsecode = 500;
                result.Issuccess = false;
                return result;
            }
        }
    }

}


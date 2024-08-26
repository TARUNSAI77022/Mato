using AutoMapper;
using Mato.Service.WebApi.DTO;
using Mato.Service.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mato.Service.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestingController1 : Controller
    {
        private readonly sampleContext _dbContext;
        private readonly IMapper _mapper;
        ResponseClass result = new ResponseClass();

        public TestingController1(IMapper mapper1, sampleContext dbContext)
        {
            _dbContext = dbContext;
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
        public IActionResult GetCouponsById(int id)
        {
            try
            {
                var coupon = _dbContext.Coupons.FirstOrDefault(s => s.Couponid == id);
                if (coupon == null)
                {
                    return NotFound(new { Message = "Coupon not found" });
                }
                return Ok(coupon);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("ByCode")]
        public IActionResult GetCouponCode(string CouponCode)
        {
            try
            {
                var code = _dbContext.Coupons.FirstOrDefault(s => s.Couponcode.ToLower() == CouponCode.ToLower());
                if (code == null)
                {
                    return NotFound(new { Message = "Coupon code not found" });
                }
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("CreateCoupon")]
        public ResponseClass CreateCouponcode(CouponDto couponDto)
        {
            try
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
            catch (Exception ex)
            {
                result.responsemessage = ex.Message;
                result.responsecode = 500;
                result.Issuccess = false;
                return result;
            }
        }

        [HttpPut("UpdateCoupon/{id:int}")]
        public ResponseClass UpdateCoupon(int id, CouponDto couponDto)
        {
            try
            {
                var coupon = _dbContext.Coupons.FirstOrDefault(c => c.Couponid == id);
                if (coupon == null)
                {
                    result.responsemessage = "Coupon not found";
                    result.responsecode = 404;
                    result.Issuccess = false;
                    return result;
                }

                coupon.Couponcode = couponDto.CouponCode;
                coupon.Discountamount = couponDto.DiscountAmount;
                coupon.Minamount = couponDto.MinAmount;

                _dbContext.Coupons.Update(coupon);
                _dbContext.SaveChanges();

                result.responsemessage = "Coupon updated successfully";
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

        [HttpDelete("DeleteCoupon/{id:int}")]
        public ResponseClass DeleteCoupon(int id)
        {
            try
            {
                var coupon = _dbContext.Coupons.FirstOrDefault(c => c.Couponid == id);
                if (coupon == null)
                {
                    result.responsemessage = "Coupon not found";
                    result.responsecode = 404;
                    result.Issuccess = false;
                    return result;
                }

                _dbContext.Coupons.Remove(coupon);
                _dbContext.SaveChanges();

                result.responsemessage = "Coupon deleted successfully";
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

        [HttpGet("ByDiscountAmount/{amount:decimal}")]
        public ResponseClass GetCouponsByDiscountAmount(decimal amount)
        {
            try
            {
                var coupons = _dbContext.Coupons.Where(c => c.Discountamount > amount).ToList();
                result.Res = coupons;
                result.responsemessage = "Coupons retrieved successfully";
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

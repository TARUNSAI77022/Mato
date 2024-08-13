using AutoMapper;
using Mato.Service.WebApi.DTO;
using Mato.Service.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mato.Service.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponAPIController : Controller
    {
        private readonly  MisContext  _dbContext;
        private readonly IMapper _mapper;
        ResponseClass result = new ResponseClass();
        //private readonly ILogger<CouponAPIController> _logger;
        public CouponAPIController(IMapper mapper1)
        {
            _dbContext =  new  MisContext(); 
            _mapper = mapper1;  
          
        }
        
         [HttpGet]
        public ResponseClass GetAllCoupons()
        {
            try
            {
                IEnumerable<Coupon> data = _dbContext.Coupons;
                result.Res = _mapper.Map<IEnumerable<CouponDto>>(data); 
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
        //[Route("{id:int}")]
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
                var code = _dbContext.Coupons.FirstOrDefault(s => s.Couponcode.ToLower()==CouponCode.ToLower());
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("CreateCoupon")]
        public ResponseClass CreateCouponcode(Coupon coupon)
        {
            try
            {
                var data = _dbContext.Coupons.Add(coupon);
                result.responsemessage = "Coupon create";
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
    }
}

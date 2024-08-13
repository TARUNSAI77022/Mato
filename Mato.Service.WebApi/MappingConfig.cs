using AutoMapper;
using Mato.Service.WebApi.DTO;
using Mato.Service.WebApi.Models;

namespace Mato.Service.WebApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MapConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<CouponDto, Coupon>();
                Config.CreateMap<Coupon, CouponDto>();
            });
            return MapConfig;
        }
        
    }
}

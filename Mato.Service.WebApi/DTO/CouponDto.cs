﻿namespace Mato.Service.WebApi.DTO
{
    public class CouponDto
    {
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}

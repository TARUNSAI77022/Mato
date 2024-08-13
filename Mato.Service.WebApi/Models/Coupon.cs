using System;
using System.Collections.Generic;

namespace Mato.Service.WebApi.Models;

public partial class Coupon
{
    public int Couponid { get; set; }

    public string? Couponcode { get; set; }

    public double? Discountamount { get; set; }

    public int? Minamount { get; set; }
}

using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class BookingAffiliate
{
    public int BookingAffiliateId { get; set; }

    public int BookingId { get; set; }

    public int? AffiliateId { get; set; }

    public decimal CommissionAmount { get; set; }

    public string? TransactionStatus { get; set; }

    public virtual Affiliate? Affiliate { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}

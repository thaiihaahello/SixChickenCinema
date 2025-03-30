using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Affiliate
{
    public int AffiliateId { get; set; }

    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public int? Reputation { get; set; }

    public decimal? CommissionRate { get; set; }

    public string AffiliateLink { get; set; } = null!;

    public virtual ICollection<BookingAffiliate> BookingAffiliates { get; set; } = new List<BookingAffiliate>();

    public virtual User User { get; set; } = null!;
}

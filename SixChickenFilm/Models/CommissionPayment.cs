using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class CommissionPayment
{
    public int CommissionId { get; set; }

    public int UserId { get; set; }

    public int? BookingId { get; set; }

    public int? TheaterId { get; set; }

    public decimal Amount { get; set; }

    public string? CommissionType { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Theater? Theater { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}

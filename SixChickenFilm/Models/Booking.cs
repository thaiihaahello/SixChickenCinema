using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? CustomerId { get; set; }

    public int ShowtimeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BookingAffiliate> BookingAffiliates { get; set; } = new List<BookingAffiliate>();

    public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    public virtual ICollection<CommissionPayment> CommissionPayments { get; set; } = new List<CommissionPayment>();

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Showtime Showtime { get; set; } = null!;
}

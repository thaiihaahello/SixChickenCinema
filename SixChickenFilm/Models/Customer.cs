using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string? MembershipTier { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User User { get; set; } = null!;
}

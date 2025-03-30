using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Affiliate? Affiliate { get; set; }

    public virtual ICollection<CommissionPayment> CommissionPayments { get; set; } = new List<CommissionPayment>();

    public virtual Customer? Customer { get; set; }

    public virtual FilmManager? FilmManager { get; set; }
}

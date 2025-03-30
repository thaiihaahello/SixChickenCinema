using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int CommissionId { get; set; }

    public decimal PaymentAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual CommissionPayment Commission { get; set; } = null!;
}

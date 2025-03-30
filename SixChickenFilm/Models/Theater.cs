using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Theater
{
    public int TheaterId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int TotalSeats { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();

    public virtual ICollection<CommissionPayment> CommissionPayments { get; set; } = new List<CommissionPayment>();

    public virtual ICollection<FilmManager> FilmManagers { get; set; } = new List<FilmManager>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}

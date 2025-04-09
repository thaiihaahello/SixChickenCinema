using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Auditorium
{
    public int AuditoriumId { get; set; }

    public int TheaterId { get; set; }

    public string AuditoriumName { get; set; } = null!;

    public int TotalSeats { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

    public virtual Theater Theater { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class FilmManager
{
    public int FilmManagerId { get; set; }

    public int UserId { get; set; }

    public int TheaterId { get; set; }

    public virtual Theater Theater { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

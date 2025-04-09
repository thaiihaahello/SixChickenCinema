﻿using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? BannerUrl { get; set; }

    public string? PosterUrl { get; set; }

    public string? AgeRating { get; set; }

    public string Genre { get; set; } = null!;

    public int Duration { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public decimal? Rating { get; set; }

    public string? Director { get; set; }

    public string? Cast { get; set; }

    public string? Description { get; set; }

    public string? TrailerUrl { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}

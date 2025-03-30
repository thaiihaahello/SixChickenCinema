using System;
using System.Collections.Generic;

namespace SixChickenFilm.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int CustomerId { get; set; }

    public int MovieId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}

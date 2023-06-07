using System;
using System.Collections.Generic;

namespace scaffolding_1.Models;

public partial class Held
{
    public int HeldId { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public string? Beruf { get; set; }

    public virtual ICollection<Bedrohung> Bedrohungs { get; } = new List<Bedrohung>();
}

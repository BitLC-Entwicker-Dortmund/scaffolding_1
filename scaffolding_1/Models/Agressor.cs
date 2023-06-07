using System;
using System.Collections.Generic;

namespace scaffolding_1.Models;

public partial class Agressor
{
    public int AgressorId { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public string? Spezialitaet { get; set; }

    public virtual ICollection<Bedrohung> Bedrohungs { get; } = new List<Bedrohung>();
}

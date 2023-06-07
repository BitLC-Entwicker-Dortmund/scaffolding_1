using System;
using System.Collections.Generic;

namespace scaffolding_1.Models;

public partial class Bedrohung
{
    public int BedrohungId { get; set; }

    public string Name { get; set; } = null!;

    public bool Existent { get; set; }

    public int AgressorId { get; set; }

    public int? HeldId { get; set; }

    public virtual Agressor Agressor { get; set; } = null!;

    public virtual Held? Held { get; set; }
}

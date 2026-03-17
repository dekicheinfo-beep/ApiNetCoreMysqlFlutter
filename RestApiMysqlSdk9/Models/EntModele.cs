using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.Models;

public partial class EntModele
{
    public int IdModele { get; set; }

    public int IdMarque { get; set; }

    public string Modele { get; set; } = null!;
}

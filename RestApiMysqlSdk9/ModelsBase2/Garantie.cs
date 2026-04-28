using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk.ModelsBase2;

public partial class Garantie
{
    public string Codagence { get; set; } = null!;

    public long Numepoli { get; set; }

    public long Coderisq { get; set; }

    public int Codecate { get; set; }

    public string Codegara { get; set; } = null!;

    public string Libgara { get; set; } = null!;

    public string? Avenant { get; set; }

    public string? Capiassu { get; set; }

    public string? Francaise { get; set; }

    public string? PrimeNette { get; set; }
}

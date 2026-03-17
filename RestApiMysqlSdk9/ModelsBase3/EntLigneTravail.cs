using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase3;

public partial class EntLigneTravail
{
    public int Id { get; set; }

    public int IdTravail { get; set; }

    public string Type { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Qtt { get; set; } = null!;

    public string Unite { get; set; } = null!;

    public string Pu { get; set; } = null!;

    public string Total { get; set; } = null!;
}

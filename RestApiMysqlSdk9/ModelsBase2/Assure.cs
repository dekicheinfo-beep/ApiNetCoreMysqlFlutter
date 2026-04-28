using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk.ModelsBase2;

public partial class Assure
{
    public long Codeassu { get; set; }

    public string? Raissoci { get; set; }

    public string Nomprenom { get; set; } = null!;

    public string? Adreassu { get; set; }

    public string? Teleassu { get; set; }

    public string? Prof { get; set; }

    public string? Fiscal { get; set; }

    public string? Ville { get; set; }

    public string? Mailassu { get; set; }

    public string Userassu { get; set; } = null!;

    public string Passassu { get; set; } = null!;

    public string ResetToken { get; set; } = null!;

    public DateTime? ResetTokenExpiry { get; set; }
}

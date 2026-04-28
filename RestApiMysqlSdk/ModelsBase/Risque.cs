using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk.ModelsBase;

public partial class Risque
{
    public string Codagence { get; set; } = null!;

    public string Numepoli { get; set; } = null!;

    public string Coderisq { get; set; } = null!;

    public string Liberisq { get; set; } = null!;

    public string Avenant { get; set; } = null!;

    public string? Marque { get; set; }

    public string? Genre { get; set; }

    public string? Usagee { get; set; }

    public string? Energie { get; set; }

    public string? Typemote { get; set; }

    public string? Puissance { get; set; }

    public string? Type { get; set; }

    public string? Zone { get; set; }

    public string? Chassis { get; set; }

    public string? Immat { get; set; }

    public string? Datemec { get; set; }

    public string? PtcCu { get; set; }

    public string? Place { get; set; }

    public string ValeurNeuf { get; set; } = null!;

    public string ValeurVenale { get; set; } = null!;
}

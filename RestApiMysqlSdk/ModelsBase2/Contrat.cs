using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk.ModelsBase2;

public partial class Contrat
{
    public string Codagence { get; set; } = null!;

    public string Numepoli { get; set; } = null!;

    public string Codeassu { get; set; } = null!;

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

    public string? Dateeffe { get; set; }

    public string? Dateeche { get; set; }

    public string? Adress { get; set; }

    public string Agence { get; set; } = null!;

    public string Prime { get; set; } = null!;
}

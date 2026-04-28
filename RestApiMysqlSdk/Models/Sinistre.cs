using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk.Models;

public partial class Sinistre
{
    public string Codesini { get; set; } = null!;

    public string Numepoli { get; set; } = null!;

    public string Codeassu { get; set; } = null!;

    public string Coderisq { get; set; } = null!;

    public string Datesini { get; set; } = null!;

    public string Descrip { get; set; } = null!;

    public string Statut { get; set; } = null!;

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;
}

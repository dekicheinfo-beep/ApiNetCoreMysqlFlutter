using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk.ModelsBase2;

public partial class Police
{
    public string Direction { get; set; } = null!;

    public string Agence { get; set; } = null!;

    public string Codagence { get; set; } = null!;

    public string Numepoli { get; set; } = null!;

    public string? Avenant { get; set; }

    public string? Codecate { get; set; }

    public string LibCate { get; set; } = null!;

    public string Codeassu { get; set; } = null!;

    public string Dateeffe { get; set; } = null!;

    public string? Codedure { get; set; }

    public string? Dateeche { get; set; }

    public string? Typecont { get; set; }

    public string Adress { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase4;

public partial class EntLigneProforma
{
    public int Id { get; set; }

    public int IdProforma { get; set; }

    public string Type { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Qtt { get; set; } = null!;

    public string Unite { get; set; } = null!;

    public string Pu { get; set; } = null!;

    public string Total { get; set; } = null!;
}

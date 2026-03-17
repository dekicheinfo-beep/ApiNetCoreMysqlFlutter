using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class Resumer
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public int IdCours { get; set; }
}

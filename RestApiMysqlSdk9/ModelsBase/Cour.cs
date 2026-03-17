using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class Cour
{
    public int Id { get; set; }

    public int Annee { get; set; }

    public int Trimestre { get; set; }

    public string Libelle { get; set; } = null!;

    public string Resume { get; set; } = null!;

    public string ResumeImg { get; set; } = null!;

    public string MoktasabatImg { get; set; } = null!;
}

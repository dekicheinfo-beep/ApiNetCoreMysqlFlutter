using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class Exercice
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Ennonce { get; set; } = null!;

    public string EnnonceImg { get; set; } = null!;

    public string Formule { get; set; } = null!;

    public string FormuleImg { get; set; } = null!;

    public string Solution { get; set; } = null!;

    public string SolutionImg { get; set; } = null!;

    public string Explication { get; set; } = null!;

    public string ExplicationImg { get; set; } = null!;

    public int Cours { get; set; }

    public int Annee { get; set; }

    public int Trimestre { get; set; }
}

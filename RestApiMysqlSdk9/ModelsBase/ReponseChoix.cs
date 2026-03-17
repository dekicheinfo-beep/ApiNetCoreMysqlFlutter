using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class ReponseChoix
{
    public int Id { get; set; }

    public string Reponse { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Exercice { get; set; }

    public string ReponseImg { get; set; } = null!;

    public int Question { get; set; }
}

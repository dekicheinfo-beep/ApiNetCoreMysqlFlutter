using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class ReponseExo
{
    public int Id { get; set; }

    public string Formule { get; set; } = null!;

    public string FormuleImg { get; set; } = null!;

    public string Correct { get; set; } = null!;
}

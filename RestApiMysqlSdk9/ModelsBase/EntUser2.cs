using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class EntUser2
{
    public string User { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Passe { get; set; } = null!;

    public string Role { get; set; } = null!;
}

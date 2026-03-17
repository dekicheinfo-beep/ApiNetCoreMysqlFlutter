using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase3;

public partial class EntUser
{
    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Profile { get; set; } = null!;

    public string Etat { get; set; } = null!;
}

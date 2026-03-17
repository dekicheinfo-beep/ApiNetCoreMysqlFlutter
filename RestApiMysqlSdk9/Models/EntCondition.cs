using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.Models;

public partial class EntCondition
{
    public int Id { get; set; }

    public string Cond { get; set; } = null!;

    public string Type { get; set; } = null!;
}

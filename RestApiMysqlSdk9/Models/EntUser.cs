using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestApiMysqlSdk9.Models;

public partial class EntUser
{
    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Profile { get; set; } = null!;

    public string Etat { get; set; } = null!;
}

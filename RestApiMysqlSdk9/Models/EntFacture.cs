using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.Models;

public partial class EntFacture
{
    public int Id { get; set; }

    public string Num { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string Etat { get; set; } = null!;

    public string Total { get; set; } = null!;

    public string Versement { get; set; } = null!;

    public string Reste { get; set; } = null!;

    public int IdClient { get; set; }
}

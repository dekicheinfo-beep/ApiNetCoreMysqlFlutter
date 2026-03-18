using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class EntContrat
{
    public int Id { get; set; }

    public string Numerocontrat { get; set; } = null!;

    public string Typecontrat { get; set; } = null!;

    public string Datedebut { get; set; } = null!;

    public string Datefin { get; set; } = null!;

    public string Montant { get; set; } = null!;

    public int Clientid { get; set; }
}

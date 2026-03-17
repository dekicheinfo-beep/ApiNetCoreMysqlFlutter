using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.Models;

public partial class EntContrat
{
    public int Id { get; set; }

    public string Numerocontrat { get; set; }

    public string Typecontrat { get; set; }

    public string Datedebut { get; set; }

    public string Datefin { get; set; } 

    public string Montant { get; set; }

    public int Clientid { get; set; }
}

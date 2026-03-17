using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.Models;

public partial class EntReservation
{
    public int Id { get; set; }

    public string DateDepart { get; set; } = null!;

    public string DateRetour { get; set; } = null!;

    public string NbJour { get; set; } = null!;

    public string TypePaiement { get; set; } = null!;

    public string Somme { get; set; } = null!;

    public int IdClient { get; set; }

    public int IdVehicule { get; set; }

    public string NomVehicule { get; set; } = null!;

    public string Valider { get; set; } = null!;

    public string NomClient { get; set; } = null!;
}

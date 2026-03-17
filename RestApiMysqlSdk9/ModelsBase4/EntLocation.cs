using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase4;

public partial class EntLocation
{
    public int Id { get; set; }

    public string Num { get; set; } = null!;

    public string Etat { get; set; } = null!;

    public string DateDeb { get; set; } = null!;

    public string DateFin { get; set; } = null!;

    public int Client { get; set; }

    public int Conducteur { get; set; }

    public int Vehicule { get; set; }

    public string Prixu { get; set; } = null!;

    public string Montant { get; set; } = null!;

    public string MontantVerse { get; set; } = null!;

    public string MontantReste { get; set; } = null!;

    public string ModePaiement { get; set; } = null!;

    public string KmJour { get; set; } = null!;

    public string KmDepart { get; set; } = null!;

    public string KmRetour { get; set; } = null!;

    public string Cautionnement { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase4;

public partial class Agence
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Horaire { get; set; } = null!;

    public string Proprietaire { get; set; } = null!;

    public string Banque { get; set; } = null!;

    public string Rib { get; set; } = null!;

    public string Presentation { get; set; } = null!;

    public string Rcommerce { get; set; } = null!;

    public string Aimposition { get; set; } = null!;

    public string Fimposition { get; set; } = null!;
}

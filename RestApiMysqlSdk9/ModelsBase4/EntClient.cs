using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase4;

public partial class EntClient
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Passe { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string DateNaiss { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Raison { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Rcommerce { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public string Narticle { get; set; } = null!;

    public string Nature { get; set; } = null!;

    public string Nis { get; set; } = null!;
}

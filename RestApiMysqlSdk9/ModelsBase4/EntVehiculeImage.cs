using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase4;

public partial class EntVehiculeImage
{
    public int Id { get; set; }

    public int IdVehicule { get; set; }

    public string Image { get; set; } = null!;
}

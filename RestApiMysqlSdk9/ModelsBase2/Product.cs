using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase2;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }
}

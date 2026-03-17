using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.ModelsBase3;

public partial class Photo
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public DateOnly UploadDate { get; set; }

    public int IdProduit { get; set; }
}

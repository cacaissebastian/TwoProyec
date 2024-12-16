using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Sintomasreportado
{
    public int Id { get; set; }

    public int AnimalId { get; set; }

    public string Sintomas { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Animale Animal { get; set; } = null!;
}

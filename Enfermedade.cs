using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Enfermedade
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Sintomas { get; set; }

    public string? TratamientoSugerido { get; set; }

    public virtual ICollection<Historialenfermedade> Historialenfermedades { get; set; } = new List<Historialenfermedade>();
}

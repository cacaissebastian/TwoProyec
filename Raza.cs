using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Raza
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Animale> Animales { get; set; } = new List<Animale>();
}

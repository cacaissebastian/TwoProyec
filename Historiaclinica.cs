using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Historiaclinica
{
    public int Id { get; set; }

    public int AnimalId { get; set; }

    public DateTime? Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Tratamiento { get; set; }

    public string? Veterinario { get; set; }

    public virtual Animale Animal { get; set; } = null!;

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Historialenfermedade> Historialenfermedades { get; set; } = new List<Historialenfermedade>();
}

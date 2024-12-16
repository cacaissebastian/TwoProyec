using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Animale> Animales { get; set; } = new List<Animale>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}

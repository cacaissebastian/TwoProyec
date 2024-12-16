using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Animale
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public int RazaId { get; set; }

    public string? Especie { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public decimal? Peso { get; set; }

    public string? Foto { get; set; }

    public virtual ICollection<Historiaclinica> Historiaclinicas { get; set; } = new List<Historiaclinica>();

    public virtual Raza Raza { get; set; } = null!;

    public virtual ICollection<Sintomasreportado> Sintomasreportados { get; set; } = new List<Sintomasreportado>();

    public virtual Usuario Usuario { get; set; } = null!;
}

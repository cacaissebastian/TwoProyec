using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public int HistoriaClinicaId { get; set; }

    public int UsuarioId { get; set; }

    public string Comentario1 { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Historiaclinica HistoriaClinica { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}

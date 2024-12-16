using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class Historialenfermedade
{
    public int Id { get; set; }

    public int HistoriaClinicaId { get; set; }

    public int EnfermedadId { get; set; }

    public DateTime? FechaDiagnostico { get; set; }

    public virtual Enfermedade Enfermedad { get; set; } = null!;

    public virtual Historiaclinica HistoriaClinica { get; set; } = null!;
}

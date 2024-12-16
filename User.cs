using System;
using System.Collections.Generic;

namespace MiproyectoMySql.Models;

public partial class User
{
    /// <summary>
    /// Primary Key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Create Time
    /// </summary>
    public DateTime? CreateTime { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }
}

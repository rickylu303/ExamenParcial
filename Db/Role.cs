using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Role
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}

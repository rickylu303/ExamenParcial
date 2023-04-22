using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Valoracione
{
    public int IdValoracion { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdLibro { get; set; }

    public int? Puntuacion { get; set; }

    public DateTime? FechaValoracion { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

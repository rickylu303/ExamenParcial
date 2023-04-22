using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Comentario
{
    public int IdComentario { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdLibro { get; set; }

    public string? TextoComentario { get; set; }

    public DateTime? FechaComentario { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

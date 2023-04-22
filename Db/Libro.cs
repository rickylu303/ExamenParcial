using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public int? IdAutor { get; set; }

    public int? IdEditorial { get; set; }

    public int? AnioPublicacion { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Autore? IdAutorNavigation { get; set; }

    public virtual Editoriale? IdEditorialNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Valoracione> Valoraciones { get; set; } = new List<Valoracione>();

    public virtual ICollection<Categoria> IdCategoria { get; set; } = new List<Categoria>();
}

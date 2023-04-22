using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Libro> IdLibros { get; set; } = new List<Libro>();
}

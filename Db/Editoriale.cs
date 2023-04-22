using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Editoriale
{
    public int IdEditorial { get; set; }

    public string? NombreEditorial { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}

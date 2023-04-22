using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Autore
{
    public int IdAutor { get; set; }

    public string? NombreAutor { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaDefuncion { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}

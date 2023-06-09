﻿using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdLibro { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace ExamenPrimerParcial.Db;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contraseña { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Valoracione> Valoraciones { get; set; } = new List<Valoracione>();

    public virtual ICollection<Role> IdRols { get; set; } = new List<Role>();
}

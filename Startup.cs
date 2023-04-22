using Microsoft.AspNetCore.Builder;

namespace ExamenPrimerParcial
{
    public class Startup
    {
        public int IdLibro { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public int? IdAutor { get; set; }

        public int? IdEditorial { get; set; }

        public int? AnioPublicacion { get; set; }
    }
}

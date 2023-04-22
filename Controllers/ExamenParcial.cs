using Microsoft.AspNetCore.Mvc;

namespace ExamenPrimerParcial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamenParcial : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "Alice In Wonderland", "The Lord of the Rings", "The Hunger Games", "Percy Jackson", "Twilight", "Harry Potter"
        };

        private static readonly string[] Description = new[]
        {
            "Some Description", "Some Description", "Some Description", "Some Description", "Some Description", "Some Description"
        };

        private readonly ILogger<ExamenParcial> _logger;

        public ExamenParcial(ILogger<ExamenParcial> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStartup")]

        public IEnumerable<Startup> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Startup
            {
                IdLibro = Random.Shared.Next(1, 6),
                Titulo = Titles[Random.Shared.Next(Titles.Length)],
                Descripcion = Description[Random.Shared.Next(Description.Length)],
                IdAutor = Random.Shared.Next(1, 6),
                IdEditorial = Random.Shared.Next(1, 6),
                AnioPublicacion = Random.Shared.Next(1, 6),
            })
            .ToArray();
        }
    }
}

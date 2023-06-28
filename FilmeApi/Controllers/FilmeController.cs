using FilmeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // ...
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new
            List<Filme>();
        private static int id = 0;

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Duracao);

        }
        [HttpGet]

        public IEnumerable<Filme> RecuperaFilme([FromQuery] int skip, [FromQuery] int take)
        {
            return filmes.Skip(skip).Take(take);
        }
        [HttpGet("{id}")]

        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();

            return Ok(filme);
        }

    }
}


             
        
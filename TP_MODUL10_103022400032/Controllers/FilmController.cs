using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400032;

namespace TP_MODUL10_103022400032.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FilmController : ControllerBase
  {
    private static readonly List<Film> films = new()
    {
      new Film("Inception", "Christopher Nolan", "2010", "Sci-Fi", "9.0"),
      new Film("Interstellar", "Christopher Nolan", "2014", "Sci-Fi", "8.7"),
      new Film("Parasite", "Bong Joon-ho", "2019", "Thriller", "8.6")
    };

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(films);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
      var film = films.FirstOrDefault(x => x.Id == id);
      return film is null ? NotFound() : Ok(film);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Film film)
    {
      film.Id = Guid.NewGuid().ToString("N");
      films.Add(film);
      return CreatedAtAction(nameof(GetById), new { id = film.Id }, film);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] Film updatedFilm)
    {
      var film = films.FirstOrDefault(x => x.Id == id);
      if (film is null)
      {
        return NotFound();
      }

      film.Judul = updatedFilm.Judul;
      film.Sutradara = updatedFilm.Sutradara;
      film.Tahun = updatedFilm.Tahun;
      film.Genre = updatedFilm.Genre;
      film.Rating = updatedFilm.Rating;

      return Ok(film);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
      var film = films.FirstOrDefault(x => x.Id == id);
      if (film is null)
      {
        return NotFound();
      }

      films.Remove(film);
      return NoContent();
    }

  }
}

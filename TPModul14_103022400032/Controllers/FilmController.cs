using Microsoft.AspNetCore.Mvc;

namespace TPModul14_103022400032.Controllers
{
    /// <summary>
    /// Controller for managing film data.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private static readonly List<Film> _films = new()
        {
            new Film("Inception", "Christopher Nolan", "2010", "Sci-Fi", "9.0"),
            new Film("Interstellar", "Christopher Nolan", "2014", "Sci-Fi", "8.7"),
            new Film("Parasite", "Bong Joon-ho", "2019", "Thriller", "8.6")
        };

        /// <summary>
        /// Retrieves all films.
        /// </summary>
        /// <returns>List of all films.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_films);
        }

        /// <summary>
        /// Retrieves a film by its unique identifier.
        /// </summary>
        /// <param name="id">The film ID.</param>
        /// <returns>The matching film, or 404 if not found.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var foundFilm = _films.FirstOrDefault(film => film.Id == id);
            return foundFilm is null ? NotFound() : Ok(foundFilm);
        }

        /// <summary>
        /// Creates a new film.
        /// </summary>
        /// <param name="film">The film data to create.</param>
        /// <returns>The created film with its new ID.</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Film film)
        {
            film.Id = Guid.NewGuid().ToString("N");
            _films.Add(film);
            return CreatedAtAction(nameof(GetById), new { id = film.Id }, film);
        }

        /// <summary>
        /// Updates an existing film.
        /// </summary>
        /// <param name="id">The ID of the film to update.</param>
        /// <param name="updatedFilm">The updated film data.</param>
        /// <returns>The updated film, or 404 if not found.</returns>
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Film updatedFilm)
        {
            var existingFilm = _films.FirstOrDefault(film => film.Id == id);
            if (existingFilm is null)
            {
                return NotFound();
            }

            existingFilm.Judul = updatedFilm.Judul;
            existingFilm.Sutradara = updatedFilm.Sutradara;
            existingFilm.Tahun = updatedFilm.Tahun;
            existingFilm.Genre = updatedFilm.Genre;
            existingFilm.Rating = updatedFilm.Rating;

            return Ok(existingFilm);
        }

        /// <summary>
        /// Deletes a film by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the film to delete.</param>
        /// <returns>204 No Content, or 404 if not found.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var filmToDelete = _films.FirstOrDefault(film => film.Id == id);
            if (filmToDelete is null)
            {
                return NotFound();
            }

            _films.Remove(filmToDelete);
            return NoContent();
        }
    }
}

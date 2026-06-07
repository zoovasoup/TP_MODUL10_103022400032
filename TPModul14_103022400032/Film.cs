namespace TPModul14_103022400032
{
    /// <summary>
    /// Represents a film entity with metadata properties.
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Unique identifier for the film.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Title of the film.
        /// </summary>
        public string Judul { get; set; } = string.Empty;

        /// <summary>
        /// Director of the film.
        /// </summary>
        public string Sutradara { get; set; } = string.Empty;

        /// <summary>
        /// Release year of the film.
        /// </summary>
        public string Tahun { get; set; } = string.Empty;

        /// <summary>
        /// Genre of the film.
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Rating of the film.
        /// </summary>
        public string Rating { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Film"/> class.
        /// </summary>
        public Film()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Film"/> class with specified values.
        /// </summary>
        /// <param name="judul">The film title.</param>
        /// <param name="sutradara">The film director.</param>
        /// <param name="tahun">The release year.</param>
        /// <param name="genre">The film genre.</param>
        /// <param name="rating">The film rating.</param>
        public Film(string judul, string sutradara, string tahun, string genre, string rating)
        {
            Id = Guid.NewGuid().ToString("N");
            Judul = judul;
            Sutradara = sutradara;
            Tahun = tahun;
            Genre = genre;
            Rating = rating;
        }
    }
}

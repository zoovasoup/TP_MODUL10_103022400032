namespace TP_MODUL10_103022400032
{
  public class Film
  {
    public string Id { get; set; } = string.Empty;
    public string Judul { get; set; } = string.Empty;
    public string Sutradara { get; set; } = string.Empty;
    public string Tahun { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Rating { get; set; } = string.Empty;

    public Film() { }

    public Film(string judul, string sutradara, string tahun, string genre, string rating)
    {
      this.Id = Guid.NewGuid().ToString("N");
      this.Judul = judul;
      this.Sutradara = sutradara;
      this.Tahun = tahun;
      this.Genre = genre;
      this.Rating = rating;
    }
  }
}

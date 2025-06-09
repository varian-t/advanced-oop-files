using CsvHelper.Configuration.Attributes;

class Movie {
  [Name("movieId")]
  public int movieId { get; set; }

  [Name("title")]
  public string title { get; set; }

  [Name("genres")]
  public string genres { get; set; }



}
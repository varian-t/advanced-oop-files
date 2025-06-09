using CsvHelper.Configuration.Attributes;

class MovieRating {

  [Name("userId")]
  public int userId { get; set; }

  [Name("movieId")]
  public int movieId { get; set; }

  [Name("rating")]
  public int rating { get; set; }

  [Name("timestamp")]
  public int timestamp { get; set; }

}
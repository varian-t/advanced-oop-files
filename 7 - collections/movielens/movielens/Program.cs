
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

string movie_filepath = "movies.csv";
string ratings_filepath = "ratings.csv";

var config = new CsvConfiguration(CultureInfo.InvariantCulture){
  NewLine = Environment.NewLine,
  Delimiter = ",",
  HasHeaderRecord = true,
};

using var movie_reader = new StreamReader(movie_filepath);
using var movie_csv = new CsvReader(movie_reader, CultureInfo.InvariantCulture);
using var ratings_reader = new StreamReader(ratings_filepath);
using var ratings_csv = new CsvReader(ratings_reader, CultureInfo.InvariantCulture);

var movies = movie_csv.GetRecords<Movie>().ToList();
var ratings = ratings_csv.GetRecords<MovieRating>().ToList();




//var movie_ratings = ratings.join
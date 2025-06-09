using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace ComicSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "data/comics.csv";
            List<Comic> comics;

            // reading csv file
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                comics = csv.GetRecords<Comic>().ToList();
            }

            // task 3.1 
            Console.WriteLine($"TASK 3.1:");
            var before2000 = comics.Where(c => c.ReleaseYear < 2000);
            Console.WriteLine("\nComics before 2000:");
            foreach (var comic in before2000)
                Console.WriteLine($"{comic.Title} released in ({comic.ReleaseYear})");

            // task 3.2 
            Console.WriteLine($"\nTASK 3.2:");
            var authorCounts = comics
                .GroupBy(c => c.Author)
                .Select(g => new { Author = g.Key, Count = g.Count() })
                .OrderByDescending(a => a.Count);

            Console.WriteLine("\nComics count by author:");
            foreach (var entry in authorCounts)
                Console.WriteLine($"{entry.Author}: {entry.Count} comics");

            // task 3.3 
            Console.WriteLine($"\nTASK 3.3:");
            var mostActiveByYear = comics
                .GroupBy(c => c.ReleaseYear)
                .Select(g =>
                    g.GroupBy(c => c.Author)
                     .OrderByDescending(ag => ag.Count())
                     .Select(ag => new { ReleaseYear = g.Key, Author = ag.Key, Count = ag.Count() })
                     .First()
                )
                .OrderBy(x => x.ReleaseYear);

            Console.WriteLine("\nMost active author per ReleaseYear:");
            foreach (var entry in mostActiveByYear)
                Console.WriteLine($"{entry.ReleaseYear}: {entry.Author} ({entry.Count} comics)");
        }
    }

}


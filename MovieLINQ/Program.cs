﻿using System;
using System.Linq;
using NLog;

namespace MovieLINQ
{
    class MainClass
    {
        // create a class level instance of logger (can be used in methods other than Main)
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            logger.Info("Program started");

            string scrubbedFile = FileScrubber.ScrubMovies("../../../movies.csv");
            MovieFile movieFile = new MovieFile(scrubbedFile);


            // LINQ - Where filter operator & Contains quantifier operator
            var Movies = movieFile.Movies.Where(m => m.title.Contains("(1990)"));
            // LINQ - Count aggregation method
            Console.WriteLine($"There are {Movies.Count()} movies from 1990");

            // LINQ - Any quantifier operator & Contains quantifier operator
            var validate = movieFile.Movies.Any(m => m.title.Contains("(1921)"));
            Console.WriteLine($"Any movies from 1921? {validate}");

            // LINQ - Where filter operator & Contains quntifier operator & Count aggregation method
            int num = movieFile.Movies.Where(m => m.title.Contains("(1921)")).Count();
            Console.WriteLine($"There are {num} movies from 1921?");

            // LINQ - Where filter operator & Contains quantifier operator
            var Movies1921 = movieFile.Movies.Where(m => m.title.Contains("(1921)"));
            foreach (Movie m in Movies1921)
            {
                Console.WriteLine(m.Display());
            }

            // LINQ - Select projection operator
            var titles = movieFile.Movies.Where(m => m.title.Contains("Shark")).Select(m => m.title);
            foreach (string t in titles)
            {
                Console.WriteLine(t);
            }

            // LINQ - OrderBy ordering operator
            var MoviesOrdered = movieFile.Movies.Where(m => m.title.Contains("Shark")).OrderBy(m => m.title);
            foreach (Movie m in MoviesOrdered)
            {
                Console.WriteLine(m.Display());
            }

            // LINQ - First element operator
            var FirstMovie = movieFile.Movies.First(m => m.title.StartsWith("Z", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"First movie: {FirstMovie.title}");


            logger.Info("Program ended");
        }
    }
}
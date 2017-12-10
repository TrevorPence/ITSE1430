using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLib.Web.Models
{
    public static class MovieExtension
    {
        /// <summary>Converts a movie to a MovieViewModel.</summary>
        /// <param name="source">The movie.</param>
        /// <returns>Model of the converted movie.</returns>
        public static IEnumerable<MovieViewModel> ToModel( this IEnumerable<Movie> source )
        {
            foreach (Movie item in source)
                yield return item.ToModel();
        }

        /// <summary>Converts a movie to a MovieViewModel.</summary>
        /// <param name="source">The Movie.</param>
        /// <returns>Model of the converted movie.</returns>
        public static MovieViewModel ToModel ( this Movie source )
        {
            return new MovieViewModel() 
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Length = source.Length,
                IsOwned = source.IsOwned
            };
        }

        /// <summary>Converts a MovieViewModel to a Movie.</summary>
        /// <param name="source">The model.</param>
        /// <returns>Movie of the converted model</returns>
        public static Movie ToDomain ( this MovieViewModel source )
        {
            return new Movie() {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Length = source.Length,
                IsOwned = source.IsOwned
            };
        }
    }
}
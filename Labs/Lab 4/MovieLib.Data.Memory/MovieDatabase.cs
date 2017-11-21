using System;
using System.Collections.Generic;

namespace MovieLib.Data.Memory
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <summary> Adds a movie to the database </summary>
        /// <param name="movie"> Movie to be added </param>
        /// <returns> Returns movie to be added. </returns>
        public Movie Add( Movie movie )
        {
            if (String.IsNullOrEmpty(movie.Title) || movie.Length < 0)
                throw new ArgumentNullException(nameof(movie), "Movie is null");

            movie = GetCopy(movie);
            movie.Id = _nextId;
            try
            {
                _nextId++;
                return AddCore(movie);
            } catch (Exception e)
            {
                throw new Exception("Could not add movie", e);
            }
        }

        /// <summary> Gets a movie if it's in the database </summary>
        /// <param name="id"> ID of the movie to be returned </param>
        /// <returns> Returns movie if it's found </returns>
        public Movie Get( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

            return GetCore(id);
        }

        /// <summary> Goes through list to get products </summary>
        /// <returns> An array of movies in the database </returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        /// <summary> Finds and removes a movie and removes it </summary>
        /// <param name="id"> ID of the movie to be deleted </param>
        /// <returns> Returns the deleted movie if it exists </returns>
        public Movie Remove( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

            return RemoveCore(id);
        }

        /// <summary> Updates a currently existing movie </summary>
        /// <param name="movie"> Updated movie based on ID in movie </param>
        /// <returns> Updated Movie </returns>
        public Movie Update( Movie movie )
        {
            if (movie == null || (String.IsNullOrEmpty(movie.Title) || movie.Length < 0))
                throw new ArgumentNullException(nameof(movie));

            return UpdateCore(movie);
        }

        /// <summary> Creates a copy of the movie without creating a reference to it </summary>
        /// <param name="movie"> Movie to be copied </param>
        /// <returns> Copied of the movie </returns>
        public Movie GetCopy( Movie movie )
        {
            if (movie == null)
                return null;

            Movie newMovie = new Movie {
                Title = movie.Title,
                Description = movie.Description,
                Length = movie.Length,
                IsOwned = movie.IsOwned,
                Id = movie.Id
            };

            return newMovie;
        }

        /// <summary> Finds a movie if it exists </summary>
        /// <param name="id"> ID of the movie to be found </param>
        /// <returns> The movie if it's found </returns>
        public Movie FindMovie( int id )
        {
            foreach (Movie current in _movies)
            {
                if (current.Id == id)
                    return current;
            }

            return null;
        }

        protected abstract Movie AddCore(Movie movie);
        protected abstract Movie GetCore( int id );
        protected abstract IEnumerable<Movie> GetAllCore();
        protected abstract Movie RemoveCore( int id );
        protected abstract Movie UpdateCore( Movie newMovie );

        public int Count{ get { return _movies.Count; } }

        protected List<Movie> _movies = new List<Movie>();
        protected int _nextId = 1;
    }
}

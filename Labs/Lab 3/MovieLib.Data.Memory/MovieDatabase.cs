using System;
using System.Collections.Generic;

namespace MovieLib.Data.Memory
{
    public class MovieDatabase : IMovieDatabase
    {
        public Movie Add( Movie movie )
        {
            if (String.IsNullOrEmpty(movie.Title) || movie.Length < 0)
                return null;

            movie = GetCopy(movie);
            movie.Id = _nextId;
            _movies.Add(movie);

            _nextId++;
            return movie;
        }

        public Movie Get( int id )
        {
            if (id <= 0)
                return null;

            foreach (Movie movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            }

            return null;
        }

        public IEnumerable<Movie> GetAll()
        {
            foreach (Movie movie in _movies)
                yield return movie;
        }

        public Movie Remove( int id )
        {
            Movie movie = FindMovie(id);
            if (movie == null)
                return null;

            _movies.Remove(movie);

            foreach (Movie current in _movies)
            {
                if (current.Id > id)
                    current.Id--;
            }

            _nextId--;
            return movie;
        }

        public Movie Update( Movie movie )
        {
            Movie removeMovie = FindMovie(movie.Id);
            Movie newMovie = CopyMovie(movie);

            if (removeMovie == null)
                return null;
            if (String.IsNullOrEmpty(movie.Title) || movie.Length < 0)
                return null;

            int index = removeMovie.Id - 1;

            _movies.Remove(removeMovie);
            _movies.Insert(index, newMovie);

            return movie;
        }

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

        public Movie FindMovie( int id )
        {
            foreach (Movie current in _movies)
            {
                if (current.Id == id)
                    return current;
            }

            return null;
        }

        public Movie CopyMovie( Movie movie )
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

        public int Count{ get { return _movies.Count; } }

        List<Movie> _movies = new List<Movie>();
        int _nextId = 1;
    }
}

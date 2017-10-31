using System;
using System.Collections.Generic;

namespace MovieLib.Data.Memory
{
    interface IMovieDatabase
    {

        /// <summary> Adds movie to database /// </summary>
        /// <param name="movie"> Movie to add </param>
        /// <returns> Added movie </returns>
        Movie Add( Movie movie );

        /// <summary> Gets a movie from the database based on ID /// </summary>
        /// <param name="id"> ID of movie to get </param>
        /// <returns> return the movie if it's in the database </returns>
        Movie Get( int id );

        /// <summary> Gets all movies in the database </summary>
        /// <returns>  </returns>
        IEnumerable<Movie> GetAll();

        /// <summary> Removes a movie based on it's ID </summary>
        /// <param name="id"> ID of movie to be removed </param>
        /// <returns> Movie that was removed if it exists </returns>
        Movie Remove( int id );

        /// <summary> Updates a movie </summary>
        /// <param name="movie"> Movie to be updated </param>
        /// <returns> Updated Movie </returns>
        Movie Update( Movie movie );

    }
}

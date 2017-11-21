/*
 * Trevor Pence
 * ITSE-1430
 * 11/20/2017
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLib.Data.Memory;

namespace MovieLib.Data.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary> Adds Movie to the database </summary>
        /// <param name="movie"> Movie to be added to the database </param>
        /// <returns> Movie added to the database </returns>
        protected override Movie AddCore( Movie movie )
        {
            int id = 0;
            using (SqlConnection con = OpenDatabase())
            {
                SqlCommand cmd = new SqlCommand("Add Movie", con);

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = movie.Title;
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@price", movie.Length);
                cmd.Parameters.AddWithValue("@isDiscontinued", movie.IsOwned);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return GetCore(id);
        }

        /// <summary> Gets a Movie from the database </summary>
        /// <param name="id"> ID of Movie being retrieved from the database </param>
        /// <returns> corresponding movie with the ID if it exists </returns>
        protected override Movie GetCore( int id )
        {
            using (SqlConnection con = OpenDatabase())
            {
                SqlCommand cmd = new SqlCommand("GetProduct", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);

                var ds = new DataSet();
                var da = new SqlDataAdapter() {
                    SelectCommand = cmd,
                    DeleteCommand = cmd,
                    UpdateCommand = cmd,
                    InsertCommand = cmd
                };
            
                da.Fill(ds);

                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    var row = table.AsEnumerable().FirstOrDefault();
                    if (row != null)
                    {
                        return new Movie() {
                            Id = Convert.ToInt32(row["Id"]),
                            Title = row.Field<string>("title"),
                            Description = row.Field<string>("description"),
                            Length = row.Field<decimal>("length"),
                            IsOwned = row.Field<bool>("isowned")
                        };
                    }
                }
            }

            return null;
        }

        /// <summary> Returns a list of all movies in the database </summary>
        /// <returns> All the movies in the database </returns>
        protected override IEnumerable<Movie> GetAllCore()
        {
            List<Movie> movies = new List<Movie>();
            using (var connection = OpenDatabase())
            {
                //connection.CreateCommand();
                var cmd = new SqlCommand("GetAllProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //reader.GetName(0);
                        //reader.GetFieldType(1);
                        //Convert.ToInt32(reader["Id"]);
                        var product = new Movie() {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Title = reader.GetFieldValue<string>(1),
                            Length = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            IsOwned = reader.GetBoolean(4)
                        };
                        movies.Add(product);
                    }
                }
            }

            return movies;
        }

        /// <summary> Removes a movie from the database </summary>
        /// <param name="id"> ID of movie to be deleted </param>
        /// <returns> Movie deleted if it exists </returns>
        protected override Movie RemoveCore( int id )
        {
            using (var conn = OpenDatabase())
            {
                // var input = "0'; DELETE FROM Products;SELECT '";
                //var commandText = $"DELETE FROM Products WHERE Id = '{input}'";
                // DELETE FROM Products WHERE Id = '0'; DELETE FROM Products;SELECT ''

                //Alternative approach to creating command
                var cmd = conn.CreateCommand();
                //cmd.CommandText = "DELETE FROM Products WHERE Id = @id";
                cmd.CommandText = "RemoveProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                //Long way
                var parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
            }

            return null;
        }

        /// <summary> Updates a movie in the database </summary>
        /// <param name="movie"> Movie to update to </param>
        /// <returns> Updated movie </returns>
        protected override Movie UpdateCore( Movie movie )
        {
            Movie existing = GetCore(movie.Id);

            using (var conn = OpenDatabase())
            {
                var cmd = new SqlCommand("UpdateProduct", conn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@title", movie.Title);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@length", movie.Length);
                cmd.Parameters.AddWithValue("@isowned", movie.IsOwned);

                cmd.ExecuteNonQuery();
            };

            return GetCore(existing.Id);
        }

        /// <summary> Opens the database </summary>
        /// <returns> Connection to the database </returns>
        private SqlConnection OpenDatabase()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private readonly string _connectionString;
    }
}

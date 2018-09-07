using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using MySql.Data.MySqlClient;
using Vidly.Models;

namespace Vidly
{
    public class MovieRepository
    {
        private string ConnectionString;

        public MovieRepository(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public List<MovieViewModel> GetMovies()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Movies;";

                List<MovieViewModel> movies = new List<MovieViewModel>();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MovieViewModel movie = new MovieViewModel() { Id = (int)dr["MovieID"], Name = dr["Name"].ToString(), Year = (int)dr["Year"], Genre = dr["Genre"].ToString(), NumberInStock = (int)dr["NumberInStock"] };
                    movies.Add(movie);
                }

                return movies;
            }
        }

        public void AddMovie(MovieViewModel movie)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Movies (Name, Year, Genre, NumberInStock) VALUES (@Name, @Year, @Genre, @NumberInStock)";
                cmd.Parameters.AddWithValue("Name", movie.Name);
                cmd.Parameters.AddWithValue("Year", movie.Year);
                cmd.Parameters.AddWithValue("Genre", movie.Genre);
                cmd.Parameters.AddWithValue("NumberInStock", movie.NumberInStock);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMovie(int Id)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Movies WHERE movieid = @id;";
                cmd.Parameters.AddWithValue("id", Id);

                cmd.ExecuteNonQuery();
            }

        }

        public void UpdateMovie(MovieViewModel movie)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE movies SET Name = @name, Year = @year, Genre = @genre, NumberInStock = @numberinstock WHERE MovieID = @id;";
                cmd.Parameters.AddWithValue("name", movie.Name);
                cmd.Parameters.AddWithValue("year", movie.Year);
                cmd.Parameters.AddWithValue("genre", movie.Genre);
                cmd.Parameters.AddWithValue("numberinstock", movie.NumberInStock);
                cmd.Parameters.AddWithValue("id", Movie.MovieToUpdate.Id);
                cmd.ExecuteNonQuery();

            }

        }



    }
}
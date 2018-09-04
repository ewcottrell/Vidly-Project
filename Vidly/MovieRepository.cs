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

        public List<Movie> GetMovies()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Movies;";

                List<Movie> movies = new List<Movie>();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Movie movie = new Movie() { Id = (int)dr["MovieID"], Name = dr["Name"].ToString(), Year = (int)dr["Year"], Genre = dr["Genre"].ToString() };
                    movies.Add(movie);
                }

                return movies;
            }
        }

        public void AddMovie(Movie movie)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Movies (Name, Year, Genre) VALUES (@Name, @Year, @Genre)";
                cmd.Parameters.AddWithValue("Name", movie.Name);
                cmd.Parameters.AddWithValue("Year", movie.Year);
                cmd.Parameters.AddWithValue("Genre", movie.Genre);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMovie(string movieToDelete)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Movies WHERE Name LIKE '%@movieToDelete%";
                cmd.Parameters.AddWithValue("movieToDelete", movieToDelete);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
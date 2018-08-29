using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Vidly.Models
{
    public class MovieRepository
    {
        public string ConnectionString { get; set; }

        public MovieRepository(string connStr)
        {
            ConnectionString = connStr;
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

        public void AddMovie(string newMovie)
        {


            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Customers (Name) VALUES (newMovie)";
                cmd.Parameters.AddWithValue("newMovie", newMovie);

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
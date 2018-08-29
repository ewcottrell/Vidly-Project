using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

using MySql.Data.MySqlClient;
using Vidly.Models;


namespace Vidly
{
    //fix these methods to work with customers


    public class CustomerRepository
    {
        public string ConnectionString { get; set; }

        public CustomerRepository(string connStr)
        {
            ConnectionString = connStr;
        }

        public List<Customer> GetCustomers()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Customers;";

                List<Customer> customers = new List<Customer>();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Customer customer = new Customer() { Id = (int)dr["CustomerID"], FirstName = dr["FirstName"].ToString(), LastName = dr["LastName"].ToString(), Birthday = (DateTime)dr["Birthday"], PhoneNumber = dr["PhoneNumber"].ToString(), Email = dr["Email"] };
                    customers.Add(customer);
                }

                return customers;
            }
        }

        public void AddCustomer(string newCustomer)
        {


            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO categories (Name) VALUES (newCustomer)";
                cmd.Parameters.AddWithValue("newCustomer", newCustomer);

                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteCustomer(string customerToDelete)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Customers WHERE Name LIKE '%@customerToDelete%";
                cmd.Parameters.AddWithValue("customerToDelete", customerToDelete);

                cmd.ExecuteNonQuery();
            }

        }
    }

}


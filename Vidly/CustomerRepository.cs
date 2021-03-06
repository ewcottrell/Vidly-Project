﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using MySql.Data.MySqlClient;
using Vidly.Models;


namespace Vidly
{
    
    public class CustomerRepository
    {
        private string ConnectionString;

        public CustomerRepository(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public List<CustomerViewModel> GetCustomers()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            using(conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Customers;";
                List<CustomerViewModel> customers = new List<CustomerViewModel>();

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustomerViewModel customer = new CustomerViewModel() { Id = (uint)dr["CustomerID"], FirstName = dr["FirstName"].ToString(), LastName = dr["LastName"].ToString(), PhoneNumber = dr["PhoneNumber"].ToString(), Email = dr["Email"].ToString() };
                    customers.Add(customer);
                }
                return customers;
            }
        }

        public void AddCustomer(CustomerViewModel customer)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO customers (FirstName, LastName, Birthdate, Email, PhoneNumber) VALUES (@firstname, @lastname, @birthdate, @email, @phonenumber)";
                cmd.Parameters.AddWithValue("firstname", customer.FirstName);
                cmd.Parameters.AddWithValue("lastname", customer.LastName);
                cmd.Parameters.AddWithValue("birthdate", customer.Birthdate);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("phonenumber", customer.PhoneNumber);
                cmd.ExecuteNonQuery();
            }

        }
        public void UpdateCustomer(CustomerViewModel customer)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE customers SET FirstName = @firstname, LastName = @lastname, Birthdate = @birthdate, Email = @email, PhoneNumber = @phonenumber WHERE CustomerID = @id;";
                cmd.Parameters.AddWithValue("firstname", customer.FirstName);
                cmd.Parameters.AddWithValue("lastname", customer.LastName);
                cmd.Parameters.AddWithValue("birthdate", customer.Birthdate);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("phonenumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("id", Customer.Cust.Id);
                cmd.ExecuteNonQuery();

            }

        }

        public void DeleteCustomer(uint Id)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Customers WHERE customerid = @id;";
                cmd.Parameters.AddWithValue("id", Id);

                cmd.ExecuteNonQuery();
            }

        }

       


    }

}


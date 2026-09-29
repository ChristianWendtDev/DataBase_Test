using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelConsoleApp.Model
{
	public class HotelDBConnection
	{
		SqlConnection _conn;

		public HotelDBConnection() { }

		public void ConnectToDB()
		{
			//connection string
			string connString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = HotelTest; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False; Command Timeout = 30";
			// create connection

			_conn = new SqlConnection(connString);
			_conn.Open();
		}

		public void DisconnectFromDB()
		{
			_conn.Close();
		}

		public Customer Create(Customer customer)
		{

			ConnectToDB();

			string sql = $"INSERT INTO Customer (Name, Phone) VALUES (@n, @p)";

			SqlCommand cmd = new SqlCommand(sql, _conn);
			cmd.Parameters.AddWithValue("@n", customer.Name);
			cmd.Parameters.AddWithValue("@p", customer.Phone);

			int row = cmd.ExecuteNonQuery();

			if (row == 0)
			{
				throw new ArgumentException("fejl");
			}

			DisconnectFromDB();

			return customer;


		}

		public List<Customer> ReadAll()
		{
			List<Customer> list = new List<Customer>();
			ConnectToDB();

			string sql = $"SELECT * FROM CUSTOMER";

			SqlCommand cmd = new SqlCommand(sql, _conn);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				int id = (int)reader["Id"];
				string name = (string)reader["Name"];
				string phone = (string)reader["Phone"];

				Customer customer = new Customer(id, name, phone);
				list.Add(customer);
			}
			DisconnectFromDB();
			return list;
		}

		public Customer ReadById(int id)
		{
			ConnectToDB();
			string sql = "SELECT * FROM CUSTOMER WHERE Id = @id";

			SqlCommand cmd = new SqlCommand(sql, _conn);
			cmd.Parameters.AddWithValue("@id", id);

			SqlDataReader reader = cmd.ExecuteReader();

			Customer customer = null;

			if (reader.Read())
			{
				int dbId = (int)reader["Id"];
				string name = (string)reader["Name"];
				string phone = (string)reader["Phone"];

				customer = new Customer(dbId, name, phone);
			}
			else
			{
				DisconnectFromDB();
				throw new KeyNotFoundException("error");
			}

			DisconnectFromDB();
			return customer;
		}

		public Customer Delete(int idToRemove)
		{

			// First, check if customer exists
			Customer customer = ReadById(idToRemove);
			ConnectToDB();
			// Delete the customer from database
			string sql = "DELETE FROM CUSTOMER WHERE Id = @id";

			SqlCommand cmd = new SqlCommand(sql, _conn);
			cmd.Parameters.AddWithValue("@id", idToRemove);

			int row = cmd.ExecuteNonQuery();

			DisconnectFromDB();

			if (row == 1)
			{
				return customer;
			}
			throw new ArgumentException("kunden kunne ikke slettes");
		}

		public Customer Update(int id, Customer updatedCustomer)
		{

			Customer customer = ReadById(id);

			ConnectToDB();

			string sql = "UPDATE CUSTOMER SET Name = @n, Phone = @p WHERE Id = @id";

			SqlCommand cmd = new SqlCommand(sql, _conn);
			cmd.Parameters.AddWithValue("@n", updatedCustomer.Name);
			cmd.Parameters.AddWithValue("@p", updatedCustomer.Phone);
			cmd.Parameters.AddWithValue("@id", customer.Id);

			int row = cmd.ExecuteNonQuery();

			DisconnectFromDB();

			if (row == 1)
			{
				
				return updatedCustomer;
			}
			throw new KeyNotFoundException("kunden kan ikke updates");
		}
	}
}
	


	

using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;
using EFtestToDBMS.Model;

namespace EFtestToDBMS.Repo
{
	public class CustomerRepo
	{
		private readonly HotelTestContext _db;

			public CustomerRepo()
		{
			_db = new HotelTestContext();
		}

		public List<Customer> GetAllCustomers()
		{
			return _db.Customers.ToList();
		}

		public Customer GetCustomerById(int id)
		{

			Customer customer = _db.Customers.FirstOrDefault(c => c.Id == id);
			if (customer ==null)
			{
				throw new Exception($"Customer with ID {id} not found.");
			}
			return customer;
		}

		public Customer AddCustomer(Customer customer)
		{
			_db.Customers.Add(customer);
			_db.SaveChanges();
			return customer;
		}

		public Customer UpdateCustomer(Customer customer)
		{
			var existingCustomer = GetCustomerById(customer.Id);

			existingCustomer.Name = customer.Name;
			existingCustomer.Phone = customer.Phone;
			_db.SaveChanges();
			return existingCustomer;
		}

		public void DeleteCustomer(int id)
		{
			var customer = GetCustomerById(id);
			_db.Customers.Remove(customer);
			_db.SaveChanges();
		}
	}
}

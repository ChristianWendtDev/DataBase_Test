using System;
using System.Collections.Generic;
using System.Text;
using EFtestToDBMS.Repo;

namespace EFtestToDBMS
{
	public class dbworker
	{
	public void Start()
	{

			CustomerRepo customerrepo = new CustomerRepo();

			var customers = customerrepo.GetAllCustomers();

			foreach (var customer in customers)
			{
				Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.Phone}");
			}

		}
	}
}

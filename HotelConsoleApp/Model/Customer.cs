using System;
using System.Collections.Generic;
using System.Text;

namespace HotelConsoleApp.Model
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public  string  Phone { get; set; }

		public Customer()
		{ 
			Id = 0;
			Name = "Dummy";
			Phone = "000-000-0000";
		}

		public Customer(int id, string name, string phone)
		{
			Id = id;
			Name = name;
			Phone = phone;
		}

		public override string ToString()
		{
			return $"Customer [Id={Id}, Name={Name}, Phone={Phone}]";
		}
	}	
}

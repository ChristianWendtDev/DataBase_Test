using HotelConsoleApp.Model;

Console.WriteLine("Hello, World!");

HotelDBConnection db = new HotelDBConnection();

Customer custoer = new Customer(100, "kasten", "11222334");

//Console.WriteLine(db.Create(custoer));
Console.WriteLine();

Console.WriteLine("reads all customers in the database");
// read all customers in db
List<Customer> cus = db.ReadAll();
foreach (var c in  cus)
{
Console.WriteLine(c);
}
Console.WriteLine();

//get a customer from ID
Console.WriteLine("Reads a customer from ID");
Console.Write(db.ReadById(100));
Console.WriteLine();

// removes customer from DB
//Console.WriteLine("Remove a customer from the DB");
//Console.WriteLine(db.Delete(100));


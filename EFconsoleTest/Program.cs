using EFtestToDBMS;
using EFtestToDBMS.Repo;

Console.WriteLine("Hello, World!");



dbworker worker = new dbworker();
worker.Start();

Console.WriteLine("Slut");

CustomerRepo repo = new CustomerRepo();
Console.WriteLine(repo.GetCustomerById(110));
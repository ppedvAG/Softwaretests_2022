using ppedv.Autovermietung.Logic;
using ppedv.Autovermietung.Model;

Console.WriteLine("Hello, World!");

var core = new Core(new ppedv.Autovermietung.Data.EFCore.EfRepository());

foreach (var a in core.Repository.GetAll<Auto>())
{
    Console.WriteLine($"{a.Hersteller} {a.Modell} {a.PS}PS");
}

Console.WriteLine("Ende");
Console.ReadLine();
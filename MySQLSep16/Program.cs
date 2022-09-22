// See https://aka.ms/new-console-template for more information
using MySQLSep16.DataAccess;
using MySQLSep16.Models;
using System.ComponentModel;

CarData cardata = new CarData();

List<CarModel> cars = cardata.getAllCars();
/*
bool add = true;
while (add)
{
    Console.WriteLine("Whats the year?");
    int year = -1;
    bool worked = false;
    while (!worked)
    {
        worked = Int32.TryParse(Console.ReadLine(), out year);
    }
    Console.WriteLine("Whats the make?");
    string make = Console.ReadLine();
    Console.WriteLine("Whats the model?");
    string model = Console.ReadLine();

    CarModel car1 = new CarModel
    {
        Year = year,
        Make = make,
        Model = model
    };

    cardata.CreateCar(car1);
    Console.WriteLine("Continue?");
    bool checkcont = false;
    while (!checkcont)
    {
        checkcont = Boolean.TryParse(Console.ReadLine(), out add);
    }
}
*/


List<int> years = cardata.getYears();
List<string> makes = cardata.getMake();
List<CarModel> carYears = cardata.SearchYear();

Console.WriteLine("Distinct Years");
foreach (int x in years)
{
    Console.WriteLine(x);
}
Console.WriteLine("Distinct Makes");
foreach (string x in makes)
{
    Console.WriteLine(x);
}
Console.WriteLine("Cars with year 2022");
foreach (CarModel car in carYears) 
{
    Console.WriteLine($"CarID:{car.CarID}, Year:{car.Year}, Make:{car.Make}, Model:{car.Model}");
}

    Console.WriteLine("All Cars");
foreach (CarModel car in cars)
{
    Console.WriteLine($"CarID:{car.CarID}, Year:{car.Year}, Make:{car.Make}, Model:{car.Model}");
}
Console.ReadLine();
// See https://aka.ms/new-console-template for more information
using MySQLSep16.DataAccess;
using MySQLSep16.Models;

CarData cardata = new CarData();

List<CarModel> cars = cardata.getAllCars();

foreach(CarModel car in cars)
{
    Console.WriteLine($"CarID:{car.ID}, Year:{car.Year}, Make:{car.Make}, Model:{car.Model}");
}
Console.ReadLine();
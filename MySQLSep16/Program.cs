﻿// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using MySQLSep16.DataAccess;
using MySQLSep16.Models;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel;


BankData bankdata = new BankData();

static void RunCarStuff()
{
    CarData cardata = new CarData();
    Console.WriteLine("All current cars");
    List<CarModel> cars = cardata.getAllCars();
    
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

        CarModel car2 = new CarModel
        {
            Year = year,
            Make = make,
            Model = model
        };

        cardata.CreateCar(car2);
        Console.WriteLine("Continue?");
        bool checkcont = false;
        while (!checkcont)
        {
            checkcont = Boolean.TryParse(Console.ReadLine(), out add);
        }
    }
    

    CarModel car1 = new CarModel
    {
        Year = 2022,
        Make = "VM",
        Model = "Something2"
    };
    cardata.CreateCar(car1);


    List<int> years = cardata.GetYears();
    List<string> makes = cardata.GetMake();
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
    
    Console.WriteLine("All Cars Before update");
    foreach (CarModel car in cars)
    {
        Console.WriteLine($"CarID:{car.CarID}, Year:{car.Year}, Make:{car.Make}, Model:{car.Model}");
    }

    CarModel carHold = cardata.GetCarByID(7);

    carHold.Make = car1.Make;
    carHold.Model = car1.Model;
    carHold.Year = car1.Year;

    cardata.UpdateCar(carHold);

    cars=cardata.getAllCars();
    Console.WriteLine("All Cars after update");
    foreach (CarModel car in cars)
    {
        Console.WriteLine($"CarID:{car.CarID}, Year:{car.Year}, Make:{car.Make}, Model:{car.Model}");
    }
    
}

Console.WriteLine("Lets test our Bank Transactions!! Whoot whoot!");
BankModel b = new BankModel
{
    Amt = 200.00M,
    txDate = DateTime.Now,
    tx_type_typeID = 2

};

List<BankModel> transactions = bankdata.ReadAllTransactionsWithType();

foreach (BankModel tx in transactions)
{
    /*
    string type = "Deposit";
    if (tx.tx_type_typeID == 2)
    {
        type = "Withdraw";
    }
    */
    Console.WriteLine(tx);

}
//Console.WriteLine("Updating #2");
//Console.WriteLine("Deleating #13");
//Console.WriteLine("Making new tx");
//bankdata.deleteTx(bankdata.getTxByID(13));

//bankdata.CreateTx(b);
/*
BankModel holder = bankdata.getTxByID(2);
holder.Amt = 1234567M;
holder.tx_type_typeID = 1;
holder.txDate = DateTime.Now;
*/
//bankdata.UpdateTx(holder);

//bankdata.CreateTx(b);
/*
Console.WriteLine("AllCars after");
List<BankModel> afterList = bankdata.getAllTx();

foreach (BankModel tx in afterList)
{
    string type = "Deposit";
    if (tx.tx_type_typeID == 2)
    {
        type = "Withdraw";
    }
    Console.WriteLine(tx.txID+":"+type + " is " + tx.Amt + " on " + tx.txDate);
}

*/



Console.ReadLine();
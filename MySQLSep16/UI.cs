using Google.Protobuf.WellKnownTypes;
using MySQLSep16.DataAccess;
using MySQLSep16.GamePlay;
using MySQLSep16.Models;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Table = Spectre.Console.Table;

namespace MySQLSep16
{
    internal class UI
    {
        CarData cardata = new CarData();
        CarModelData carmodeldata = new CarModelData();
        ManufacturerDataAccess maunfacters = new ManufacturerDataAccess();
        OfferData offers = new OfferData();
        CheckingAccountData bankAccounts = new CheckingAccountData();
        EngineData enginedata = new EngineData();
        UserInfoData userinfo = new UserInfoData();
        SearchData searches = new SearchData();
        public int userID { get; set; }

        
        public void showLogInMain()
        {
            //stuff
            int choice = 0;
            logInTriggers(choice);
        }

        public void logInTriggers(int choice)
        {
            switch (choice) {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    showLogInScreen();
                    break;
                case 2:
                    showSignUp();
                    break;
            }
        }
        public void showSignUp()
        {
            //stuff
            showRules();
            
        }

        public void showRules()
        {
            //stuff
            showMainScreen();
        }
        public void showLogInScreen()
        {
            //stuff
            int usID = 0;
            userID = usID;

            showMainScreen();
        }
        public void showMainScreen()
        {
            //stuff
            int choice=0;
            var table = new Table();

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    Console.WriteLine("\r\n░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░  ████████╗██╗░░██╗███████╗\r\n░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗  ╚══██╔══╝██║░░██║██╔════╝\r\n░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║  ░░░██║░░░███████║█████╗░░\r\n░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║  ░░░██║░░░██╔══██║██╔══╝░░\r\n░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝  ░░░██║░░░██║░░██║███████╗\r\n░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚══════╝\r\n\r\n░██████╗░░█████╗░███╗░░░███╗███████╗\r\n██╔════╝░██╔══██╗████╗░████║██╔════╝\r\n██║░░██╗░███████║██╔████╔██║█████╗░░\r\n██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░\r\n╚██████╔╝██║░░██║██║░╚═╝░██║███████╗\r\n░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝");
                    table.Centered();



                    table.AddColumn(new TableColumn(" ").Centered());
                    table.AddColumn(new TableColumn("CAR GAME").Centered());


                    table.AddRow(new Markup("[blue]1[/]"), new Panel("Drive"));
                    table.AddRow(new Markup("[blue]2[/]"), new Panel("Market Place"));
                    table.AddRow(new Markup("[blue]3[/]"), new Panel("Garage"));
                    table.AddRow(new Markup("[blue]4[/]"), new Panel("Bank"));
                    table.AddRow(new Markup("[blue]5[/]"), new Panel("Soundtrack"));
                    table.AddRow(new Markup("[blue]6[/]"), new Panel("Exit"));


                });
            MainScreenTrigger(getInt("Enter a valid choice",new List<int> { 1,2,3,4,5,6}));
        }
        public void showDrive()
        {
           // userID = 1;
            List<CarModel> userCars = cardata.GetCarsByUserID(userID);
            List<int>ids = printUserCars();
           


            CarModel driving = cardata.GetCarByID(getInt("Enter a valid ID of car you wanna drive",ids));
            if (driving.sponsor != null)
            {
                CheckingAccountModel account=bankAccounts.GetAccountByUserID(userID);
                account.CurrentBalance += 100;//*****make specific once sponsershipdataaccess is available*****
                bankAccounts.UpdateAccount(account);
            }
            GP.makeGame(driving, 500, 1000, 100);
            int outcome=GP.drive();
            switch (outcome)
            {
                case 0:
                    Console.WriteLine("You ran out of gas");
                    break;
                case 1:
                    Console.WriteLine("You made it to starbucks");
                    driving.sponsor = 1;
                    
                break;
                case 2:
                    Console.WriteLine("You made it to tacobell");
                    driving.sponsor = 2;
                    break;
                case 3:
                    Console.WriteLine("You made it to mcdonalds");
                    driving.sponsor = 3;
                    break;
                case 4:
                    Console.WriteLine("You made it to Chicfila");
                    driving.sponsor = 4;
                    break;
                case 5:
                    Console.WriteLine("You made it to Houstons");
                    driving.sponsor = 5;
                    break;
                case 8:
                    Console.WriteLine("You hit a car");
 //****some punishment
                    break;
                case 7:
                    Console.WriteLine("You hit a person");
                    break;
                default:
                    Console.WriteLine("Congrats, you somehow broke the game, here's $1000");
//******add money
                    break;
                

            }
            cardata.UpdateCar(driving);

            showMainScreen();
        }
        public void showMPMain()
        {
            //stuff
            int choice = 0;
            Console.WriteLine("\r\n███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗████████╗██████╗░██╗░░░░░░█████╗░░█████╗░███████╗\r" +
                "\n████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝╚══██╔══╝██╔══██╗██║░░░░░██╔══██╗██╔══██╗██╔════╝\r" +
                "\n██╔████╔██║███████║██████╔╝█████═╝░█████╗░░░░░██║░░░██████╔╝██║░░░░░███████║██║░░╚═╝█████╗░░\r" +
                "\n██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░░░░██║░░░██╔═══╝░██║░░░░░██╔══██║██║░░██╗██╔══╝░░\r" +
                "\n██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗░░░██║░░░██║░░░░░███████╗██║░░██║╚█████╔╝███████╗\r" +
                "\n╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚═╝░░░░░╚══════╝╚═╝░░╚═╝░╚════╝░╚══════╝");


            var table = new Table();

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Centered();

                    // Add some Columns
                    table.AddColumn(new TableColumn(" ").Centered());
                    table.AddColumn(new TableColumn("MarketPlace").Centered());



                    // Add some rows

                    table.AddRow(new Markup("[blue]1[/]"), new Panel("Used Marketplace"));
                    table.AddRow(new Markup("[blue]2[/]"), new Panel("Search"));
                    table.AddRow(new Markup("[blue]3[/]"), new Panel("Buy"));
                    table.AddRow(new Markup("[blue]4[/]"), new Panel("Exit"));

                });
            // Render the table to the console
            //AnsiConsole.Write(table);

            MPTrigger(getInt("Enter a valid choice",new List<int> { 1,2,3,4}));
        }
        public void showCollection()
        {
            List<int> ids=printUserCars();
            int choice = getInt("Enter the Id of the car you want more info for", ids);
            CarModel showCar = cardata.GetCarByID(choice);
            
            printCar(showCar);

            showMainScreen();
        }
        public void MainScreenTrigger(int choice)
        {

            switch (choice)
            {
                case 0://quit game
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.Clear();
                    showDrive();
                    break;
                case 2:
                    Console.Clear();
                    showMPMain();
                    break;
                case 3:
                    Console.Clear();
                    showCollection();
                    break;
                case 4:
                    Console.Clear();
                    showBankMain();
                    break;
                case 5:
                    Console.Clear();
                    showSoundTrack();
                    break;
            }

        }
        public void showSoundTrack()
        {
            //stuff
            showMainScreen();
        }

        public void showBankMain()
        {
            //stuff
            int choice = 0;
            bankTriggers(choice);
        }

        public void showAccount()
        {
            //stuff
            showMainScreen();
        }
        public void showLoans()
        {
            //stuff
            showMainScreen();
        }

        public void bankTriggers(int choice)
        {
            switch (choice)
            {
                case 0:
                    showMainScreen();
                    break;
                case 1:
                    showAccount();
                    break;
                case 2:
                    showLoans();
                    break;
            }
        }
        public void showBuyFromMarketPlace()
        {
            //stuff
            int choice = 0;
            var table = new Table();

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    Console.WriteLine("\r\n█░█░█ █░█ ▄▀█ ▀█▀   █▀▄ █▀█   █▄█ █▀█ █░█   █░█░█ ▄▀█ █▄░█ ▀█▀   ▀█▀ █▀█   █▄▄ █░█ █▄█ ▀█\r\n▀▄▀▄▀ █▀█ █▀█ ░█░   █▄▀ █▄█   ░█░ █▄█ █▄█   ▀▄▀▄▀ █▀█ █░▀█ ░█░   ░█░ █▄█   █▄█ █▄█ ░█░ ░▄\r\n\r\n");
                    table.Centered();



                    table.AddColumn(new TableColumn(" ").Centered());
                    table.AddColumn(new TableColumn("Marketplace").Centered());


                    table.AddRow(new Markup("[blue]1[/]"), new Panel("Car"));
                    table.AddRow(new Markup("[blue]2[/]"), new Panel("Engine"));
                    table.AddRow(new Markup("[blue]3[/]"), new Panel("Exit"));


                });


            newMPTrigger(getInt("Enter a valid choice",new List<int> { 1,2,3}));
        }
        public void showBuyUsedMarketPlace()
        {
            //stuff
            int choice = 0;
            var text = new Table().Centered();
            AnsiConsole.Live(text)
                .Start(ctx =>
                {
                    text.AddColumn("[red]Used Marketplace[/]");
                    ctx.Refresh();
                    Thread.Sleep(300);
                    text.AddEmptyRow();
                    text.AddEmptyRow();

                });


           // Console.GetCursorPosition();

            //generating table
            var table = new Table().Centered();

            //editing table properties    
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border = TableBorder.AsciiDoubleHead;
                    table.Width(40);

                    table.AddColumn("");
                    ctx.Refresh();
                    Thread.Sleep(200);
                    table.AddColumn("   SELECT #   ");
                    ctx.Refresh();
                    Thread.Sleep(200);

                    
                    table.AddRow(new Panel("1."), new Panel("[green]BUY[/]"));
                    table.AddRow(new Panel("2."), new Panel("[red]SELL[/]"));
                    table.AddRow(new Panel("3."), new Panel("[blue]EXIT[/]"));
                    table.AddEmptyRow();



                });
            usedMPTrigger(getInt("Enter a valid choice",new List<int> { 1,2,3}));
            
        }
        public void showSearch()
        {
            ManufacturerModel choosenManu;
            

            List<ManufacturerModel> manus = maunfacters.getAllManufacturer();
            List<CarModelsModel> allcars = carmodeldata.getAllCarModels();
            List<int> manuIds = new List<int>();
            foreach (ManufacturerModel x in manus)
            {
                Console.WriteLine(x.ManufacturerID + "Name: " + x.ManufacturerName);
                manuIds.Add(x.ManufacturerID);
            }
            manuIds.Add(-1);
            int choice = getInt("Enter manufacter ID or -1 to go back", manuIds);
            choosenManu= maunfacters.GetManufacturerByID(choice);
            List<int>modelIds=new List<int>();
            if (choice != -1)
            {
                if (choice == 1)
                {
                    Console.WriteLine(allcars[0].ModelID + "Model Name: " + allcars[0].ModelName);
                    Console.WriteLine(allcars[1].ModelID + "Model Name: " + allcars[1].ModelName);
                    Console.WriteLine(allcars[2].ModelID + "Model Name: " + allcars[2].ModelName);
                    modelIds.Add(allcars[0].ModelID);
                    modelIds.Add(allcars[1].ModelID);
                    modelIds.Add(allcars[2].ModelID);
                }
                if (choice == 2)
                {
                    Console.WriteLine(allcars[3].ModelID + "Model Name: " + allcars[3].ModelName);
                    Console.WriteLine(allcars[4].ModelID + "Model Name: " + allcars[4].ModelName);
                    Console.WriteLine(allcars[5].ModelID + "Model Name: " + allcars[5].ModelName);
                    modelIds.Add(allcars[3].ModelID);
                    modelIds.Add(allcars[4].ModelID);
                    modelIds.Add(allcars[5].ModelID);
                }
                if (choice == 3)
                {
                    Console.WriteLine(allcars[6].ModelID + "Model Name: " + allcars[6].ModelName);
                    Console.WriteLine(allcars[7].ModelID + "Model Name: " + allcars[7].ModelName);
                    Console.WriteLine(allcars[8].ModelID + "Model Name: " + allcars[8].ModelName);
                    modelIds.Add(allcars[6].ModelID);
                    modelIds.Add(allcars[7].ModelID);
                    modelIds.Add(allcars[8].ModelID);
                }
                int choice2 = getInt("Enter the Model ID You want to see", modelIds);
                CarModelsModel searchedCar = carmodeldata.GetCarByID(choice2);
                Console.WriteLine($"The {choosenManu} {searchedCar.ModelName} has a MPG of {searchedCar.ModelMPG} and fuel capacity of {searchedCar.fuelCapacity}");

                SearchModel s = new SearchModel
                {
                    CarID = searchedCar.ModelID,
                    UserID = userID
                };
                searches.CreateSearch(s);
            }
            showMainScreen();
        }
        public void showBuyNewCar()
        {
            //stuff
            List<ManufacturerModel> manus = maunfacters.getAllManufacturer();
            List<CarModelsModel> allcars = carmodeldata.getAllCarModels();
            List<int> manuIds = new List<int>();
            foreach (ManufacturerModel x in manus)
            {
                Console.WriteLine(x.ManufacturerID+"Name: "+x.ManufacturerName);
                manuIds.Add(x.ManufacturerID);
            }
            manuIds.Add(-1);
            int choice = getInt("Enter manufacter ID or -1 to go back", manuIds);

            if (choice != -1)
            {
                if (choice == 1)
                {
                    Console.WriteLine(allcars[0].ModelID + "Model Name: "+allcars[0].ModelName);
                    Console.WriteLine(allcars[1].ModelID + "Model Name: " + allcars[1].ModelName);
                    Console.WriteLine(allcars[2].ModelID + "Model Name: " + allcars[2].ModelName);
                }
                if (choice == 2)
                {
                    Console.WriteLine(allcars[3].ModelID + "Model Name: " + allcars[3].ModelName);
                    Console.WriteLine(allcars[4].ModelID + "Model Name: " + allcars[4].ModelName);
                    Console.WriteLine(allcars[5].ModelID + "Model Name: " + allcars[5].ModelName);
                }
                if (choice == 3)
                {
                    Console.WriteLine(allcars[6].ModelID + "Model Name: " + allcars[6].ModelName);
                    Console.WriteLine(allcars[7].ModelID + "Model Name: " + allcars[7].ModelName);
                    Console.WriteLine(allcars[8].ModelID + "Model Name: " + allcars[8].ModelName);
                }
            }

            showMainScreen();
        }
        public void showBuyEngine()
        {
            List<EngineModel> currentEngines = enginedata.getAllEngines();
            List<int> engineIds = new List<int>();
            foreach (EngineModel x in currentEngines)
            {
                Console.WriteLine(x.EngineType+"Fuel Scalling: "+x.FuelScaling);
                engineIds.Add(x.EngineID);
            }
            engineIds.Add(-1);
            int choice = getInt("Choose engine you wanna buy, or -1 to go back",engineIds);
            if (choice != -1)
            {
                EngineModel currentEngine = enginedata.GetEngineByID(choice);
                List<int> carIDs=printUserCars();
                int choiceCar = getInt("Enter car you wanna inert the car into",carIDs);

                CarModel engineCar=cardata.GetCarByID(choiceCar);
                engineCar.fgn_EngineID = currentEngine.EngineID;
                cardata.UpdateCar(engineCar);

                CheckingAccountModel useraccount = bankAccounts.GetAccountByUserID(userID);
                useraccount.CurrentBalance -= currentEngine.Price;
                bankAccounts.UpdateAccount(useraccount);

            }
            showMainScreen();
        }
        public void newMPTrigger(int choice)
        {
            switch (choice) {
                case 0:
                    Console.Clear();
                    showMPMain();
                    break;
                case 1:
                    Console.Clear();
                    showBuyNewCar();
                    break;
                case 2:
                    Console.Clear();
                    showBuyEngine();
                    break;
                   
            }
        }
        public void sellUsed()
        {
            //stuff
            List<int> ids=printUserCars();
            CarModel selling = cardata.GetCarByID(getInt("Enter a valid ID of car you wanna sell",ids));
            int offerprice=getInt("Enter price that you wanna sell your car for");
            OfferModel offer = new OfferModel
            {
                SellerID = userID,
                CarID=selling.CarID,
                AskP=offerprice
            };

            offers.CreateOffer(offer);
            Console.WriteLine("Offer Created");
            Console.ReadLine();


            showMainScreen();
        }
        public void buyUsed()
        {
            List<OfferModel> currentOffers= offers.getAllOffers();
            List<int> offerIDs = new List<int>();
            foreach (OfferModel x in currentOffers)
            {
                Console.WriteLine($"OfferID: {x.OfferID}, Asking Price: {x.AskP}, From: {userinfo.GetUserByID(x.SellerID).UserName}");
                printCar(cardata.GetCarByID(x.CarID));
                offerIDs.Add(x.OfferID);
            }
            offerIDs.Add(-1);
            int response=getInt("Enter Offer ID you want to accept, or -1 to go back",offerIDs);
            if (response != -1)
            {
                OfferModel swap=offers.GetOfferByID(response);
                CarModel swappingCar = cardata.GetCarByID(swap.CarID);
                swappingCar.userID = swap.BuyerID;
                swap.Accepted=true;
                CheckingAccountModel buyer = bankAccounts.GetAccountByUserID(swap.BuyerID);
                buyer.CurrentBalance-= swap.AskP;
                CheckingAccountModel seller = bankAccounts.GetAccountByUserID(swap.SellerID);
                seller.CurrentBalance += swap.AskP;

                offers.DeleteOffer(swap);
                cardata.UpdateCar(swappingCar);
                bankAccounts.UpdateAccount(buyer);
                bankAccounts.UpdateAccount(seller);
                
                

            }
            showMainScreen();
        }
        public void usedMPTrigger(int choice)
        {
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    showMPMain();
                    break;
                case 1:
                    Console.Clear();
                    buyUsed();
                    break;
                case 2:
                    Console.Clear();
                    sellUsed();
                    break;


            }
        }
        public void MPTrigger(int choice)
        {
           
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    showMainScreen();
                    break;
                case 1:
                    Console.Clear();
                    showBuyFromMarketPlace();
                    break;
                case 2:
                    Console.Clear();
                    showBuyUsedMarketPlace();
                    break;
                case 3:
                    Console.Clear();
                    showSearch();
                    break;
            }

        }


        public int getInt(string msg)
        {
            bool cont = false;
            int output = -2;
            while (!cont)
            {
                Console.WriteLine(msg);
                cont = Int32.TryParse(Console.ReadLine(), out output);
                
                    cont = false;
               
            }
            return output;
        }
        public int getInt(string msg, List<int>potentials)
        {
            bool cont = false;
            int output=-2;
            while (!cont)
            {
                Console.WriteLine(msg);
                cont = Int32.TryParse(Console.ReadLine(), out output);
                if (potentials.Contains(output))
                {
                    cont = false;
                }
            }
            return output;
        }
        public List<int> printUserCars()
        {

            List<int> ids=new List<int>();
           
            var table = new Table().Centered();

            //editing table properties    
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border = TableBorder.AsciiDoubleHead;
                    table.Width(40);

                    
                    
                   
                    table.AddColumn("   SELECT Car ID #   ");
                    ctx.Refresh();
                    Thread.Sleep(200);

                    List<CarModel> userCars = cardata.GetCarsByUserID(userID);
                    
                    foreach (CarModel x in userCars)
                    {

                        Console.WriteLine();
                        table.AddRow(new Panel($"[green]{x.CarID + ":" + maunfacters.GetManufacturerByID(x.Brand).ManufacturerName + " Model:" + carmodeldata.GetCarByID(x.CarID).ModelName}[/]"));
                        ids.Add(x.CarID);


                    }


                    table.AddEmptyRow();



                });
            
            
            return ids;
        }
        public void printCar (CarModel x)
        {
            
            Console.WriteLine(x.CarID + ":" + maunfacters.GetManufacturerByID(x.Brand).ManufacturerName + "Model:" + carmodeldata.GetCarByID(x.CarID).ModelName);
            Console.WriteLine("Engine: "+enginedata.GetEngineByID(cardata.GetCarByID(x.CarID).fgn_EngineID)+"Sponser: "/*  ADD sponser part here when sponsership data access is there*/);
            
        }
        public void updatePrices()
        {
            List<CarModelsModel> allModels = carmodeldata.getAllCarModels();
            
            foreach (CarModelsModel x in allModels)
            {
                List<SearchModel> searchForCar = searches.GetSearchesByCarID(x.ModelID);
                if (searchForCar.Count > 20)
                {

                }
            }
        }
        
    }
}

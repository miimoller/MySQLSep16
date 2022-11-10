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
            MainScreenTrigger(getInt("Enter a valid choice",1,6));
        }
        public void showDrive()
        {
           // userID = 1;
            List<CarModel> userCars = cardata.GetCarsByUserID(userID);
            int maxID = printUserCars();
           


            CarModel driving = cardata.GetCarByID(getInt("Enter a valid ID of car you wanna drive",1,maxID));
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

            MPTrigger(getInt("Enter a valid choice", 1,4));
        }
        public void showGarageMain()
        {
            //stuff
            int choice = 0;

            // string text = System.IO.File.ReadAllText(@"C:\Users\wised\Documents\AppDev\used.txt");

            string text = "Garage";
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text.Length / 2) + "}", text));
            /*
            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;
            while (true)
            {
                Console.WriteLine("Left: " + left + " top: " + top);
            }

            */
            //generating table
            var table = new Table().Centered();

            //editing table properties    
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.AddColumn("Select #");
                    ctx.Refresh();
                    Thread.Sleep(200);

                    table.AddColumn("       ");
                    ctx.Refresh();
                    Thread.Sleep(200);

                    table.AddRow("1.", "[green]Mechanic[/]");
                    table.AddRow("2.", "[red]Collection[/]");
                    table.AddRow("3.", "[blue]Exit[/]");
                    table.AddEmptyRow();
                });
           
            
        
        GarageTrigger(getInt("Enter a valid choice",1,3));

        }
        public void showMechanic()
        {
            //stuff
            int choice = 0;
            string text = "Garage";
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text.Length / 2) + "}", text));
            
            var table = new Table().Centered();

            //editing table properties    
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.AddColumn("");
                    ctx.Refresh();
                    Thread.Sleep(200);

                    table.AddColumn("Mechanic");
                    ctx.Refresh();
                    Thread.Sleep(200);

                    table.AddRow("1.", "Repair all Damages");
                    table.AddRow("2.", "Install new parts");

                    table.AddEmptyRow();
                });
            Console.ReadLine();
           
        mechanicTriggers(getInt("Enter a valid choice",1,2));
        }

        public void showRepair()
        {
            //stuff
            showMainScreen();
        }

        public void showInstall()
        {
            //stuff
            showMainScreen();
        }
        public void mechanicTriggers(int choice)
        {
            switch (choice)
            {
                case 0:
                    showGarageMain();
                    break;
                case 1:
                    showRepair();
                    break;
                case 2:
                    showInstall();
                    break;
            }
        }
        public void showCollection()
        {
            //stuff
            showMainScreen();
        }
        public void GarageTrigger(int choice)
        {
            switch (choice)
            {
                case 0:
                    showMainScreen();
                    break;
                case 1:
                    showMechanic();
                    break;
                case 2:
                    showCollection();
                    break;
            }
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
                    showGarageMain();
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

            newMPTrigger(getInt("Enter a valid choice",1,3));
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
            usedMPTrigger(getInt("Enter a valid choice",1,2));
            
        }
        public void showSearch()
        {
            //stuff
            showMainScreen();
        }
        public void showBuyNewCar()
        {
            //stuff
            showMainScreen();
        }
        public void showBuyEngine()
        {
            //stuff
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
            int maxID=printUserCars();
            CarModel selling = cardata.GetCarByID(getInt("Enter a valid ID of car you wanna sell", 1,maxID));
            int offerprice=getInt("Enter price that you wanna sell your car for",0,1000000);
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
            foreach (OfferModel x in currentOffers)
            {
                Console.WriteLine($"OfferID: {x.OfferID}, Asking Price: {x.AskP}, From: {userinfo.GetUserByID(x.SellerID).UserName}");
                printCar(cardata.GetCarByID(x.CarID));
            }
            
            int response=getInt("Enter Offer ID you want to accept, or -1 to go back",-1,currentOffers.Count());
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

        public int getInt(string msg, int min, int max)
        {
            bool cont = false;
            int output=-2;
            while (!cont)
            {
                Console.WriteLine(msg);
                cont = Int32.TryParse(Console.ReadLine(), out output);
                if (output<min || output > max)
                {
                    cont = false;
                }
            }
            return output;
        }

        public int printUserCars()
        {
            List<CarModel> userCars = cardata.GetCarsByUserID(userID);
            int maxID = -1;
            foreach (CarModel x in userCars)
            {
                Console.WriteLine(x.CarID + ":" + maunfacters.GetManufacturerByID(x.Brand).ManufacturerName + "Model:" + carmodeldata.GetCarByID(x.CarID).ModelName);


            }
            return maxID;
        }
        public void printCar (CarModel x)
        {
            
            Console.WriteLine(x.CarID + ":" + maunfacters.GetManufacturerByID(x.Brand).ManufacturerName + "Model:" + carmodeldata.GetCarByID(x.CarID).ModelName);

            
        }

      
        
    }
}

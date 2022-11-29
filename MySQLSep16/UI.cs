using Google.Protobuf.WellKnownTypes;
using MultithreadingApplication;
using MySQLSep16.DataAccess;
using MySQLSep16.GamePlay;
using MySQLSep16.Models;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Configuration;
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
         LoanDataAccess loans = new LoanDataAccess();
         EngineData enginedata = new EngineData();
         UserInfoData userinfo = new UserInfoData();
        SearchData searches = new SearchData();
        TransactionDataAccess transactions = new TransactionDataAccess();
         SponsershipData sponsers = new SponsershipData();
         PwdDataAccess passwords = new PwdDataAccess();
         SecurityDataAccess questions = new SecurityDataAccess();
         TimeData times = new TimeData();

        public static int userID { get; set; }
        
        
        public void showLogInMain()
        {
            Console.Clear();
            var table = new Table();

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    Console.WriteLine("\r\n░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗\r\n░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝\r\n░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░\r\n░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░\r\n░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗\r\n░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝");
                    table.Centered();

                    table.AddColumn(new TableColumn(" ").Centered());
                    table.AddColumn(new TableColumn("User").Centered());


                    table.AddRow(new Markup("[blue]1[/]"), new Panel("Sign in"));
                    table.AddRow(new Markup("[blue]2[/]"), new Panel("Sign  up"));


                });




        
        int choice = getInt("Enter your choice",new List<int>{ 1,2});
            logInTriggers(choice);
        }

        public void logInTriggers(int choice)
        {
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n░░░░██████╗██╗░██████╗░███╗░░██╗░░░██╗░░░██╗██████╗░░░░\r\n░░░██╔════╝██║██╔════╝░████╗░██║░░░██║░░░██║██╔══██╗░░░\r\n░░░╚█████╗░██║██║░░██╗░██╔██╗██║░░░██║░░░██║██████╔╝░░░\r\n░░░░╚═══██╗██║██║░░╚██╗██║╚████║░░░██║░░░██║██╔═══╝░░░░\r\n░░░██████╔╝██║╚██████╔╝██║░╚███║░░░╚██████╔╝██║░░░░░░░░\r\n░░░╚═════╝░╚═╝░╚═════╝░╚═╝░░╚══╝░░░░╚═════╝░╚═╝░░░░░░░░\r\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n");
            

                Console.WriteLine("Please input your email");
                string email = Console.ReadLine();

                Console.WriteLine("Please input your password");
                string password = Console.ReadLine();

                Console.WriteLine("Please confirm your password");

                while (Console.ReadLine() != password)
                {
                    Console.WriteLine("Please try again");
                }

                Console.WriteLine("Please create a username");
                string username = Console.ReadLine();

                Console.WriteLine("We need you to add some security questions, you will later need these to access parts of the game");
                Console.WriteLine("What was the name of your first pet?");
                string sq1 = Console.ReadLine();
                Console.WriteLine("What City do you live in?");
                string sq2 = Console.ReadLine();
                Console.WriteLine("What Elemantary School did you attend?");
                string sq3 = Console.ReadLine();
               


                UserInfoModel person = new UserInfoModel
                {
                    Email = email,
                    Username = username,
                    SecurityQuestion=0

                };

                userinfo.CreateUser(person);

            List<UserInfoModel> allusers = userinfo.getAllUsers();

            UserInfoModel newperson = userinfo.getAllUsers().Last();

                SecurityQuestionModel q = new SecurityQuestionModel
                {
                    UserID = newperson.UserID,
                    Question1 = sq1,
                    Question2 = sq2,
                    Question3 = sq3

                };
                questions.CreateAnswers(q);

                NotPwdModel npwd = new NotPwdModel
                {
                    UserID = newperson.UserID,
                    Pwd = password
                };

                CheckingAccountModel newaccount = new CheckingAccountModel
                {
                    UserID = newperson.UserID,
                    CurrentBalence = 10000,
                    Loans = 0
                };

                TimeModel newtime = new TimeModel
                {
                    UserID = newperson.UserID,
                    TimePassed=0
                };
                times.CreateTime(newtime);
                bankAccounts.CreateAccount(newaccount);
                passwords.CreatePwd(npwd);

                showRules();
            }
        

        public void showRules()
        {
            Console.Clear();
            Console.WriteLine("Make money, dont die!!");
            showMainScreen();
        }
        public void showLogInScreen()
        {
            Console.Clear();
            Console.WriteLine("Enter your username");
            string user = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string pass = Console.ReadLine();

            List<UserInfoModel> allusers=userinfo.getAllUsers();
            bool cont = true;
            if (cont)
            {
                foreach (UserInfoModel x in allusers)
                {
                    if (x.Username == user)
                    {
                        if (passwords.GetPasswordByID(x.UserID).Pwd == pass)
                        {
                            userID = x.UserID;
                            cont = false;
                        }
                    }
                }
            }
            if (cont)
            {
                showLogInScreen();
            }


            ThreadCreationProgram.Run();
            showMainScreen();
        }
        public void showMainScreen()
        {
            Console.Clear();
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
                    
                    table.AddRow(new Markup("[blue]5[/]"), new Panel("Exit"));


                });
            MainScreenTrigger(getInt("Enter a valid choice",new List<int> { 0,1,2,3,4,5}));
        }
        public void showDrive()
        {
            Console.Clear();
            List<CarModel> userCars = cardata.GetCarsByUserID(userID);
            List<int>ids = printUserCars();

            ids.Add(-1);

            int choice = getInt("Enter a valid ID of car you wanna drive, or -1 to go back", ids);
            if (choice == -1)
            {
                showMainScreen();
            }
            CarModel driving = cardata.GetCarByID(choice);
            
            if (driving.sponsor != 6)
            {
                CheckingAccountModel account=bankAccounts.GetAccountByUserID(userID);
                account.CurrentBalence += sponsers.GetSponserByID(driving.sponsor).SponsorAmt;
                bankAccounts.UpdateAccount(account);
                TransactionModel sponser = new TransactionModel
                {
                    Amount= sponsers.GetSponserByID(driving.sponsor).SponsorAmt,
                    Date=DateTime.Now,
                    Source="Sponsership for CarID: "+driving.CarID,
                    Type=false,
                    UserID=userID
                };
                transactions.CreateTransaction(sponser);

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
                    driving.sponsor = 4;
                    
                break;
                case 2:
                    Console.WriteLine("You made it to tacobell");
                    driving.sponsor = 5;
                    break;
                case 3:
                    Console.WriteLine("You made it to mcdonalds");
                    driving.sponsor = 1;
                    break;
                case 4:
                    Console.WriteLine("You made it to Chicfila");
                    driving.sponsor = 2;
                    break;
                case 5:
                    Console.WriteLine("You made it to Houstons");
                    driving.sponsor = 3;
                    break;
                case 8:
                    Console.WriteLine("You hit a car");
 //****some punishment
                    break;
                case 7:
                    Console.WriteLine("You hit a person");
                    break;
                
                

            }
            cardata.UpdateCar(driving);

            showMainScreen();
        }
        public void showMPMain()
        {
            Console.Clear();
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

                    table.AddRow(new Markup("[blue]1[/]"), new Panel("New Marketplace"));
                    table.AddRow(new Markup("[blue]2[/]"), new Panel("Used Marketplace"));
                    table.AddRow(new Markup("[blue]3[/]"), new Panel("Search"));
                    table.AddRow(new Markup("[blue]4[/]"), new Panel("Exit"));

                });
            // Render the table to the console
            //AnsiConsole.Write(table);

            MPTrigger(getInt("Enter a valid choice",new List<int> { 1,2,3,4}));
        }
        public void showCollection()
        {
            Console.Clear();
            List<int> ids=printUserCars();
            ids.Add(-1);
            int choice = getInt("Enter the Id of the car you want more info for, or -1 to go back", ids);
            if (choice == -1)
            {
                showMainScreen();
            }
            CarModel showCar = cardata.GetCarByID(choice);
            
            printCar(showCar);

            showMainScreen();
        }
        public void MainScreenTrigger(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 5://quit game
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
               
            }

        }
       

        public void showBankMain()
        {
            Console.Clear();

            int choice = 0;
            var table = new Table();

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    Console.WriteLine("                      \r\n██████╗░░█████╗░███╗░░██╗██╗░░██╗\r\n██╔══██╗██╔══██╗████╗░██║██║░██╔╝\r\n██████╦╝███████║██╔██╗██║█████═╝░\r\n██╔══██╗██╔══██║██║╚████║██╔═██╗░\r\n██████╦╝██║░░██║██║░╚███║██║░╚██╗\r\n╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝");
                    table.Centered();

                    table.AddColumn(new TableColumn(" ").Centered());
                    table.AddColumn(new TableColumn("Bank").Centered());


                    table.AddRow(new Markup("[blue]1[/]"), new Panel("Account"));
                    table.AddRow(new Markup("[blue]2[/]"), new Panel("Loan"));
                    table.AddRow(new Markup("[blue]3[/]"), new Panel("Show transaction"));

                });
            choice = getInt("Enter choice for bank options", new List<int> { 1, 2, 3 });
            bankTriggers(choice);
        }

        public void showAccount()
        {
            Console.Clear();
            CheckingAccountModel x=bankAccounts.GetAccountByUserID(userID);
            Console.WriteLine("AccountID: "+x.AccountID+"Current Balance: "+x.CurrentBalence+"Current Loans: "+x.Loans);
            Console.ReadLine();
            showMainScreen();

        }
        public void showLoans()
        {
            Console.Clear();
            List<LoanModel> userLoans=loans.GetLoansByUserID(userID);
            foreach (LoanModel x in userLoans)
            {
                Console.WriteLine("Origional Amount: "+x.original_amount+" Term: "+x.Term+" Rate: "+x.rate);
            }
            Console.ReadLine();
            showMainScreen();
        }

        public void bankTriggers(int choice)
        {
            Console.Clear();
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
                case 3:
                    showTransactions();
                    break;
            }
        }

        public void showTransactions()
        {
            Console.Clear();
            List<TransactionModel>userTxs=transactions.GetTransactionByUserID(userID);
            foreach (TransactionModel x in userTxs)
            {
                string type;
                if (x.Type)
                {
                    type = "withdrawal";
                }
                else
                {
                    type = "deposit";
                }
                Console.WriteLine("ID: "+x.transaction_ID+"Date: "+x.Date+type+" on "+x.Date+" for "+x.Amount+"\nSource: "+x.Source);
            }
            Console.ReadLine();
            showMainScreen();
        }
        public void showBuyFromMarketPlace()
        {
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
                    int choice2 = getInt("Enter ModelID You want to buy", new List<int> { allcars[0].ModelID, allcars[1].ModelID, allcars[2].ModelID });
                    CarModelsModel x=carmodeldata.GetCarByID(choice2);
                    CarModel newCar = new CarModel
                    {
                        Brand = 1,
                        fgn_ModelID = x.ModelID,
                        sponsor = 6,
                        fgn_EngineID = 1,
                        userID = userID,
                        Finance = false

                    };
                    cardata.CreateCar(newCar);

                    if (bankAccounts.GetAccountByUserID(userID).CurrentBalence < x.Price)
                    {
                        LoanModel loan = new LoanModel
                        {
                            UserID= userID,
                            original_amount = x.Price,
                            rate =0.12,
                            Term=12,
                            MonthlyPayment =0
                        };
                        loans.CreateLoan(loan);
                        Console.WriteLine("You took out a loan for "+loan.original_amount);
                    }
                    else
                    {
                        bankAccounts.GetAccountByUserID(userID).CurrentBalence -= x.Price;
                        TransactionModel tx = new TransactionModel
                        {
                            Amount = x.Price,
                            Type = true,
                            Date = DateTime.Now,
                            Source = "Paying for Car with ModelID " + x.ModelID,
                            UserID = userID
                        };
                        transactions.CreateTransaction(tx);
                    }
                    
                }
                if (choice == 2)
                {
                    Console.WriteLine(allcars[3].ModelID + "Model Name: " + allcars[3].ModelName);
                    Console.WriteLine(allcars[4].ModelID + "Model Name: " + allcars[4].ModelName);
                    Console.WriteLine(allcars[5].ModelID + "Model Name: " + allcars[5].ModelName);

                    int choice2 = getInt("Enter ModelID You want to buy", new List<int> { allcars[3].ModelID, allcars[4].ModelID, allcars[5].ModelID });
                    CarModelsModel x = carmodeldata.GetCarByID(choice2);
                    CarModel newCar = new CarModel
                    {
                        Brand = 2,
                        fgn_ModelID = x.ModelID,
                        sponsor = 6,
                        fgn_EngineID = 1,
                        userID = userID,
                        Finance = false

                    };
                    cardata.CreateCar(newCar);



                    if (bankAccounts.GetAccountByUserID(userID).CurrentBalence < x.Price)
                    {
                        LoanModel loan = new LoanModel
                        {
                            UserID=userID,
                            original_amount = x.Price,
                            rate = 0.12,
                            Term = 12,
                            MonthlyPayment = 0
                        };
                        loans.CreateLoan(loan);
                        Console.WriteLine("You took out a loan for " + loan.original_amount);
                    }
                    else
                    {
                        bankAccounts.GetAccountByUserID(userID).CurrentBalence -= x.Price;
                        TransactionModel tx = new TransactionModel
                        {
                            Amount = x.Price,
                            Type = true,
                            Date = DateTime.Now,
                            Source = "Paying for Car with ModelID " + x.ModelID,
                            UserID = userID
                        };
                        transactions.CreateTransaction(tx);
                    }
                }
                if (choice == 3)
                {
                    Console.WriteLine(allcars[6].ModelID + "Model Name: " + allcars[6].ModelName);
                    Console.WriteLine(allcars[7].ModelID + "Model Name: " + allcars[7].ModelName);
                    Console.WriteLine(allcars[8].ModelID + "Model Name: " + allcars[8].ModelName);

                    int choice2 = getInt("Enter ModelID You want to buy", new List<int> { allcars[6].ModelID, allcars[7].ModelID, allcars[8].ModelID });
                    CarModelsModel x = carmodeldata.GetCarByID(choice2);
                    CarModel newCar = new CarModel
                    {
                        Brand=3,
                        fgn_ModelID= x.ModelID,
                        sponsor = 6,
                        fgn_EngineID = 1,
                        userID = userID,
                        Finance = false
                    };
                    cardata.CreateCar(newCar);

                    if (bankAccounts.GetAccountByUserID(userID).CurrentBalence < x.Price)
                    {
                        LoanModel loan = new LoanModel
                        {
                            UserID=userID,
                            original_amount = x.Price,
                            rate = 0.12,
                            Term = 12,
                            MonthlyPayment = 0
                        };
                        loans.CreateLoan(loan);
                        Console.WriteLine("You took out a loan for " + loan.original_amount);
                    }
                    else
                    {
                        bankAccounts.GetAccountByUserID(userID).CurrentBalence -= x.Price;
                        TransactionModel tx = new TransactionModel
                        {
                            Amount = x.Price,
                            Type = true,
                            Date = DateTime.Now,
                            Source = "Paying for Car with ModelID " + x.ModelID,
                            UserID = userID
                        };
                        transactions.CreateTransaction(tx);
                    }
                }
            }

            showMainScreen();
        }
        public void showBuyEngine()
        {
            Console.Clear();
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
                if (useraccount.CurrentBalence < currentEngine.Price)
                {
                    LoanModel engineLoan = new LoanModel
                    {
                        original_amount = currentEngine.Price,
                        rate = 0.12,
                        Term = 12,
                        MonthlyPayment = 0
                    };
                    loans.CreateLoan(engineLoan);
                    Console.WriteLine("You took out a loan of "+currentEngine.Price);
                }
                else
                {
                    useraccount.CurrentBalence -= currentEngine.Price;

                    TransactionModel tx = new TransactionModel
                    {
                        Amount = currentEngine.Price,
                        Type = true,
                        Date = DateTime.Now,
                        Source = "Paying for Engine with ID " + currentEngine.EngineID,
                        UserID=userID
                    };
                    transactions.CreateTransaction(tx);
                }

               
                bankAccounts.UpdateAccount(useraccount);

            }
            showMainScreen();
        }
        public void newMPTrigger(int choice)
        {
            Console.Clear();
            switch (choice) {
                case 3:
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
            Console.Clear();
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
            Console.Clear();
            List<OfferModel> currentOffers= offers.getAllOffers();
            List<int> offerIDs = new List<int>();
            foreach (OfferModel x in currentOffers)
            {
                Console.WriteLine($"OfferID: {x.OfferID}, Asking Price: {x.AskP}, From: {userinfo.GetUserByID(x.SellerID).Username}");
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

                
                CheckingAccountModel buyer = bankAccounts.GetAccountByUserID(userID);
                if (buyer.CurrentBalence < swap.AskP)
                {
                    LoanModel loan = new LoanModel
                    {
                        UserID = swap.BuyerID,
                        original_amount = swap.AskP,
                        MonthlyPayment = 0,
                        rate = .12,
                        Term = 12
                    };
                    loans.CreateLoan(loan);
                    Console.WriteLine("You took a loan to pay for the car of "+swap.AskP);
                }
                else
                {
                    buyer.CurrentBalence -= swap.AskP;
                    TransactionModel tx1 = new TransactionModel
                    {
                        Amount = swap.AskP,
                        Type = true,
                        Date = DateTime.Now,
                        Source = "Paying for Used Car with ID " + swappingCar.CarID,
                        UserID = swap.BuyerID
                    };
                    transactions.CreateTransaction(tx1);
                }


                CheckingAccountModel seller = bankAccounts.GetAccountByUserID(swap.SellerID);
                seller.CurrentBalence += swap.AskP;
                TransactionModel tx = new TransactionModel
                {
                    Amount = swap.AskP,
                    Type = false,
                    Date = DateTime.Now,
                    Source = "Payment for Used Car with ID " + swappingCar.CarID,
                    UserID = swap.SellerID
                };
                transactions.CreateTransaction(tx);

                swappingCar.userID = userID;

                offers.DeleteOffer(swap);
                cardata.UpdateCar(swappingCar);
                bankAccounts.UpdateAccount(buyer);
                bankAccounts.UpdateAccount(seller);
                
                

            }
            showMainScreen();
        }
        public void usedMPTrigger(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 3:
                    Console.Clear();
                    showMPMain();
                    break;
               
                case 2:
                    Console.Clear();
                    //sell**************************************************************************************************8
                    sellUsed();
                    break;
                case 1:
                    Console.Clear();
                    buyUsed();
                    break;


            }
        }
        public void MPTrigger(int choice)
        {
            
            switch (choice)
            {
                case 4:
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
                if (!potentials.Contains(output))
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
            
            Console.WriteLine(x.CarID + ":" + maunfacters.GetManufacturerByID(x.Brand).ManufacturerName + " Model:" + carmodeldata.GetCarByID(x.CarID).ModelName);
            Console.WriteLine("Engine: "+enginedata.GetEngineByID(cardata.GetCarByID(x.CarID).fgn_EngineID).toString()+" Sponser: "+sponsers.GetSponserByID(cardata.GetCarByID(x.CarID).sponsor).toString());
            
        }
        
        
        //put with timesystem
        public static void updatePrices()
        {
            CarModelData carmodeldata = new CarModelData();
            SearchData searches = new SearchData();

            List<CarModelsModel> allModels = carmodeldata.getAllCarModels();

            foreach (CarModelsModel x in allModels)
            {
                if (x.ModelID != 9) { 
                    List<SearchModel> searchForCar = searches.GetSearchesByCarID(x.ModelID);
                    if (searchForCar.Count > 20)
                    {
                        CarModelsModel changingCar = carmodeldata.GetCarByID(searchForCar[0].CarID);
                        changingCar.Price = (int)((double)changingCar.Price * 1.1);

                        carmodeldata.UpdateCar(changingCar);
                    }
                    if (searchForCar.Count > 40)
                    {
                        CarModelsModel changingCar = carmodeldata.GetCarByID(searchForCar[0].CarID);
                        changingCar.Price = (int)((double)changingCar.Price * 1.2);

                        carmodeldata.UpdateCar(changingCar);
                    }
                    if (searchForCar.Count > 60)
                    {
                        CarModelsModel changingCar = carmodeldata.GetCarByID(searchForCar[0].CarID);
                        changingCar.Price = (int)((double)changingCar.Price * 1.3);

                        carmodeldata.UpdateCar(changingCar);
                    }
                }
            }
        }
        public static void payLoans()
        {
            TimeData times = new TimeData();
            LoanDataAccess loans = new LoanDataAccess();
            CheckingAccountData bankAccounts = new CheckingAccountData();
            TransactionDataAccess transactions = new TransactionDataAccess();
            if (times.GetTimeByID(userID).TimePassed % 500 == 0) { 
            List<LoanModel> allLoans = loans.getAllLoans();
                foreach (LoanModel x in allLoans)
                {
                    if (x.Term < x.MonthlyPayment)
                    {
                        loans.DeletebyLoanID(x.LoanID);
                    }
                    else
                    {
                        CheckingAccountModel currentDebtor = bankAccounts.GetAccountByUserID(userID);
                        currentDebtor.CurrentBalence -= (int)loans.CalculatePayment(x.original_amount, x.Term);
                        x.MonthlyPayment++;
                        loans.UpdateLoan(x);
                        bankAccounts.UpdateAccount(currentDebtor);
                        TransactionModel loanPayment = new TransactionModel
                        {
                            Type = true,
                            UserID = userID,
                            Date = DateTime.Now,
                            Source = "Loan Payment for Load ID" + x.LoanID,
                            Amount = (int)loans.CalculatePayment(x.original_amount, x.Term)
                        };
                        transactions.CreateTransaction(loanPayment);
                    }
                }
            }
        }
    }
}

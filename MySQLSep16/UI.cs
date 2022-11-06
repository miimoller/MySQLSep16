using MySQLSep16.DataAccess;
using MySQLSep16.GamePlay;
using MySQLSep16.Models;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16
{
    internal class UI
    {
        CarData cardata = new CarData();
        CarModelData carmodeldata = new CarModelData();
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
            MainScreenTrigger(choice);
        }
        public void showDrive()
        {
            
            List<CarModel> userCars = cardata.GetCarsByUserID(userID);
            foreach (CarModel x in userCars)
            {
                Console.WriteLine(x);
            }
            CarModel driving = cardata.GetCarByID(UIHelperMethods.checkForInt("Enter a valid ID of car you wanna drive"));
            if (driving != null)
            {
//****add user money from sponserhip rate
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
                    driving.sponsor = 1;
                    break;
                case 4:
                    Console.WriteLine("You made it to Chicfila");
                    driving.sponsor = 4;
                    break;
                case 5:
                    Console.WriteLine("You made it to Houstons");
                    driving.sponsor = 5;
                    break;
                case 6:
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
            showMainScreen();
        }
        public void showMPMain()
        {
            //stuff
            int choice = 0;
            MPTrigger(choice);
        }
        public void showGarageMain()
        {
            //stuff
            int choice = 0;
            GarageTrigger(choice);

        }
        public void showMechanic()
        {
            //stuff
            int choice = 0;
            mechanicTriggers(choice);
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
            newMPTrigger(choice);
        }
        public void showBuyUsedMarketPlace()
        {
            //stuff
            int choice = 0;
            usedMPTrigger(choice);
            
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
        public void buyUsed()
        {
            //stuff
            showMainScreen();
        }
        public void sellUsed()
        {
            //stuff
            showMainScreen();
        }
        public void seeOffers()
        {
            //stuff
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
                case 3:
                    Console.Clear();
                    seeOffers();
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

       
        
    }
}

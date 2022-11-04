using MySQLSep16.DataAccess;
using MySQLSep16.GamePlay;
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
        public int userID { get; set; }
        public void showLogInScreen()
        {
            int usID = 0;
            userID = usID;

            showMainScreen();
        }

        public void showMainScreen()
        {
            int choice=0;
            MainScreenTrigger(choice);
        }
        public void showDrive()
        {
            int carDriving = 0;
            CarData cdata = new CarData();

            GP.makeGame(cdata.GetCarByID(UIHelperMethods.checkForInt("Enter a valid ID of car you wanna drive")), 500, 1000, 100);
            GP.drive();
            showMainScreen();
        }
        public void showMP()
        {
            int choice = 0;
            MPTrigger(choice);
        }
        public void showGarage()
        {
            int choice = 0;

        }
        public void GarageTrigger(int choice)
        {

        }
        
        public void MainScreenTrigger(int choice)
        {

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    showDrive();
                    break;
                case 2:
                    Console.Clear();
                    showMP();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine();
                    break;
            }

        }

        public void MPTrigger(int choice)
        {
           
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine();
                    break;
            }

        }

        public void UsedMPTrigger()
        {
            int i = Int32.Parse(Console.ReadLine());
            switch (i)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine();
                    break;
            }
        }
    }
}

﻿using MySQLSep16.Models;
using System.Windows.Input;
using Org.BouncyCastle.Asn1.X509.SigI;
using Org.BouncyCastle.Crypto;
using System;
using MySQLSep16.DataAccess;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MySQLSep16.GamePlay
{
    internal class GP
    {
        public static bool hit { get; set; }
        public static int gasAmount { get; set; }
        public static int moneySpent { get; set; }

        public static string[] userCar { get; set; }
        public static int xPos { get; set; }
        public static int yPos { get; set; }
        public static string[] car { get; set; }
        public static string[] gasStation { get; set; }
        public static string[] sponser { get; set; }
        public static string[] person { get; set; }

        public static GameSpace[,] gameBoard { get; set; }
        static Random random = new Random();
        public static CarModel drivingCar { get; set; }
        /*
        
        */
        public static void fillBoard()
        {
            GameSpace emptySpace = new GameSpace
            {
                symbol = ' ',
                symbolType = GameSpace.space.empty
            };
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameBoard[i, j] = emptySpace;
                }

            }
        }

        public static void makeModels()
        {
            gasStation = new string[7];
            gasStation[0] = "_________";
            gasStation[1] = "|  Gas  |";
            gasStation[2] = "|__Pump_|";
            gasStation[3] = " | [_] |\\";
            gasStation[4] = "_|oo []|_||l";
            gasStation[5] = "|_______|/";
            gasStation[6] = "|_______|";

            sponser = new string[7];
            sponser[0] = "____________";
            sponser[1] = "|          |";
            sponser[2] = "|McDonalds |";
            sponser[3] = "|__[Food]__| ______";
            sponser[4] = "     ||  ___|__|   |";
            sponser[5] = "     ||  |[_]|     |";
            sponser[6] = "     ||  |   |  [] |";

            person = new string[3];
            person[0] = " O";
            person[1] = "/|\\";
            person[2] = "/ \\";

            car = new string[5];
            car[0] = "/^^\\";
            car[1] = "*--*";
            car[2] = "|  |";
            car[3] = "*--*";
            car[4] = "\\__/";

            userCar = new string[5];
            userCar[0] = "/--\\";
            userCar[1] = "*--*";
            userCar[2] = "|U |";
            userCar[3] = "*--*";
            userCar[4] = "\\vv/";

        }
        public static void drive()
        {
            ConsoleKey input = ConsoleKey.W;
            gasAmount = (int)drivingCar.fuelCapacity * 10;



            for (int i = gameBoard.GetLength(0) - 51; i >= 0; i -= 5)
            {
                gasAmount -= 5;
                if (!hit)
                {
                    if (gasAmount < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You ran out of gas");
                        Console.Read();
                    }
                    else
                    {
                        Console.Clear();
                        yPos += 3;


                        if (Console.KeyAvailable)
                        {
                            Console.Clear();

                            input = Console.ReadKey(true).Key;
                        }

                        if (input == ConsoleKey.W || input == ConsoleKey.UpArrow)
                        {
                            //Console.Clear();
                            // Console.WriteLine("Moving up");
                            //Console.BackgroundColor = ConsoleColor.Red;
                            yPos -= 5;
                        }
                        if (input == ConsoleKey.A || input == ConsoleKey.LeftArrow)
                        {
                            // Console.Clear();
                            xPos -= 8;
                            // Console.BackgroundColor = ConsoleColor.DarkYellow;
                            // Console.WriteLine("Moving left");
                        }
                        if (input == ConsoleKey.D || input == ConsoleKey.RightArrow)
                        {
                            //Console.Clear();
                            xPos += 8;
                            // Console.BackgroundColor = ConsoleColor.Green;
                            // Console.WriteLine("Moving right");
                        }
                        if (input == ConsoleKey.S || input == ConsoleKey.DownArrow)
                        {
                            // Console.Clear();
                            yPos += 5;
                            // Console.BackgroundColor = ConsoleColor.Blue;
                            // Console.WriteLine("Moving down");

                        }

                        // printModel(userCar, xPos, yPos, 5, GameSpace.space.userCar);


                        printSection(i, i + 50, xPos, yPos);
                        //printModel(userCar, xPos, yPos, 0, GameSpace.space.userCar);

                        //Console.ReadLine();
                        Thread.Sleep(300);
                        Console.Clear();
                    }

                }

                else
                {
                    i = -1;
                }


            }
            Console.Clear();
            Console.WriteLine("You spent " + moneySpent);

        }
        public static void printSection(int x1, int x2, int x, int y)
        {
            try
            {
                Console.WriteLine("Total gas Amount:" + gasAmount);
                GameSpace[,] tempSect = new GameSpace[x2 - x1, gameBoard.GetLength(1)];
                for (int i = x1; i < x2; i++)
                {
                    for (int j = 0; j < gameBoard.GetLength(1); j++)
                    {
                        tempSect[i - x1, j] = gameBoard[i, j];
                    }
                }

                for (int i = 0; i < userCar.Length; i++)
                {
                    char[] line = userCar[i].ToCharArray();

                    for (int j = 0; j < line.Length; j++)
                    {

                        GameSpace temp = new GameSpace
                        {
                            symbol = line[j],
                            symbolType = GameSpace.space.userCar
                        };
                        if (tempSect[y + i, x + j].symbolType == GameSpace.space.car)
                        {
                            Console.WriteLine("you hit a car");
                            Console.Read();
                            hit = true;
                            break;
                        }
                        else if (tempSect[y + i, x + j].symbolType == GameSpace.space.person)
                        {

                            Console.WriteLine("You hit a person");
                            Console.Read();
                            hit = true;
                            break;
                        }
                        else if (tempSect[y + i, x + j].symbolType == GameSpace.space.gas)
                        {
                            gasAmount += 5;
                            moneySpent += 10;
                        }
                        else if (tempSect[y + i, x + j].symbolType == GameSpace.space.sponserS)
                        {
                            Console.WriteLine("You made it to starbucks, and got sponsered");
                            Console.Read();
                            hit = true;
                        }
                        else if (tempSect[y + i, x + j].symbolType == GameSpace.space.sponserT)
                        {
                            Console.WriteLine("You made it to tacobell, and got sponsered");
                            Console.Read();
                            hit = true;
                        }
                        else if (tempSect[y + i, x + j].symbolType == GameSpace.space.sponserM)
                        {
                            Console.WriteLine("You made it to mcdonalds, and got sponsered");
                            Console.Read();
                            hit = true;
                        }
                        else if (tempSect[y + i, x + j].symbolType == GameSpace.space.sponserC)
                        {
                            Console.WriteLine("You made it to chicfila, and got sponsered");
                            Console.Read();
                            hit = true;
                        }
                        else if (tempSect[y + i, x + j].symbolType == GameSpace.space.sponserH)
                        {
                            Console.WriteLine("You made it to houstons, and got sponsered");
                            Console.Read();
                            hit = true;
                        }
                        else { tempSect[y + i, x + j] = temp; }


                    }

                }

                for (int i = 0; i < tempSect.GetLength(0); i++)
                {
                    for (int j = 0; j < tempSect.GetLength(1); j++)
                    {
                        Console.Write(tempSect[i, j].symbol);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("You hit the boarder");
                hit = true;
            }



        }

        public static void makeGame(CarModel c, int min, int max, int width)
        {
            drivingCar = c;
            Console.SetWindowPosition(0, 0);
            //aConsole.MoveBufferArea(0,0,0,0,0,0);
            Console.SetWindowSize(100, 50);
            //Console


            hit = false;
            gasAmount = 200;
            makeModels();

            gameBoard = new GameSpace[random.Next(min, max), width];
            xPos = width / 2;
            yPos = 33;
            fillBoard();

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                GameSpace boarder = new GameSpace
                {
                    symbol = '|',
                    symbolType = GameSpace.space.boarder
                };
                gameBoard[i, 0] = boarder;
                gameBoard[i, gameBoard.GetLength(1) - 1] = boarder;
            }




            randomizeModels(gasStation, 12, 50, 60, GameSpace.space.gas);

            randomizeModels(sponser, 20, 100, 120, GameSpace.space.sponserM);
            randomizeModels(sponser, 20, 80, 100, GameSpace.space.sponserC);
            randomizeModels(sponser, 20, 100, 120, GameSpace.space.sponserH);
            randomizeModels(sponser, 20, 100, 120, GameSpace.space.sponserS);
            randomizeModels(sponser, 20, 130, 140, GameSpace.space.sponserT);

            randomizeModels(car, 5, 10, 15, GameSpace.space.car);
            randomizeModels(person, 4, 20, 30, GameSpace.space.person);




        }

        public static void randomizeModels(string[] model, int rad, int min, int max, GameSpace.space type)
        {
            for (int i = 0; i < gameBoard.GetLength(0) - 20; i = i + random.Next(min, max))
            {

                // int dy = random.Next(0, 20);
                int x = random.Next(0, gameBoard.GetLength(1));


                printModel(model, x, i, rad, type);

            }
        }
        public static bool checkRadius(int x, int y, int r)
        {
            for (int i = x - r; i < x + r; i++)
            {
                for (int j = y - r; j < y + r; j++)
                {
                    if (i < 0 || j < 0 || x + r + 1 > gameBoard.GetLength(1) || y + r + 1 > gameBoard.GetLength(0) || gameBoard[j, i].symbol != ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void printModel(string[] s, int x, int y, int r, GameSpace.space type)
        {

            if (checkRadius(x, y, r))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (type == GameSpace.space.sponserC)
                    {
                        s[2] = "|Chic-Fil-A|";
                    }
                    else if (type == GameSpace.space.sponserH)
                    {
                        s[2] = "|Houston   |";
                    }
                    else if (type == GameSpace.space.sponserS)
                    {
                        s[2] = "|Starbucks |";
                    }
                    else if (type == GameSpace.space.sponserT)
                    {
                        s[2] = "|TacoBell  |";
                    }

                    char[] line = s[i].ToCharArray();


                    for (int j = 0; j < line.Length; j++)
                    {

                        GameSpace temp = new GameSpace
                        {
                            symbol = line[j],
                            symbolType = type
                        };

                        gameBoard[y + i, x + j] = temp;
                    }

                }
                // Console.WriteLine("x:" + x + "y:" + y);
            }
        }
        public static void showScreen()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write(gameBoard[i, j].symbol);
                }
                Console.WriteLine();
            }
        }
    }

}

using Org.BouncyCastle.Asn1.X509.SigI;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16
{
    internal class GP
    {
        public string[] car { get; set; }
        public string[] gasStation { get; set; }
        public string[] sponser { get; set; }
        public string[] person { get; set; }

        public GameSpace[,] gameBoard { get; set; }
        Random random = new Random();

        public void fillBoard()
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

        public void makeModels()
        {
            gasStation = new string[7];
            gasStation[0] = "_________";
            gasStation[1] = "|  Gas  |";
            gasStation[2] = "|__Pump_|";
            gasStation[3] = " | [_] |\\";
            gasStation[4] = "_|oo []|_||l";
            gasStation[5] = "|_______|/";
            gasStation[6] = "|_______|";

            sponser=new string[7];
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


        }
        public void makeGame()
        {

            makeModels();
 
            gameBoard = new GameSpace[random.Next(500, 1000), 100];

            fillBoard();

            randomizeModels(gasStation, 12, 50, 60, GameSpace.space.gas);
            randomizeModels(sponser, 20, 80, 90, GameSpace.space.sponser);
            randomizeModels(car, 5, 10, 15, GameSpace.space.car);
            randomizeModels(person, 4, 20, 30, GameSpace.space.person);


            showScreen();
        }
        public void randomizeModels(string[] model, int rad, int min, int max, GameSpace.space type)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i = i + random.Next(min, max))
            {

                // int dy = random.Next(0, 20);
                int x = random.Next(0, gameBoard.GetLength(1));


                printModel(model, x, i, rad, type);

            }
        }
        public bool checkRadius(int x, int y, int r)
        {
            for (int i = x - r; i < x + r; i++)
            {
                for (int j = y - r; j < y + r; j++)
                {
                    if (i<0 || j<0 || x+r+1>gameBoard.GetLength(1) || y+r+1>gameBoard.GetLength(0) || gameBoard[j,i].symbol!=' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void printModel(string[] s, int x, int y, int r, GameSpace.space type)
        {

            if (checkRadius(x,y,r))
            {
                for (int i = 0; i < s.Length; i++)
                {
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
                Console.WriteLine("x:" + x + "y:" + y);
            }
        }
        public void showScreen()
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


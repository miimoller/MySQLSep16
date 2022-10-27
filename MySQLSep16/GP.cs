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
        public string car { get; set; }
        public string[] gasStation { get; set; }
        public string sponser { get; set; }

        public GameSpace[,] gameBoard { get; set; }


        public void fillBoard()
        {
            GameSpace emptySpace = new GameSpace
            {
                symbol = '0',
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
        }
        public void makeGame()
        {

            makeModels();
            Random random = new Random();
            

           
            int length = random.Next(500, 1000);


            gameBoard = new GameSpace[length, 100];

            fillBoard();

            
                Console.WriteLine((gameBoard.GetLength(0)));
                
                for (int i = 0; i <( gameBoard.GetLength(1)/20)-1; i++)
                {

                    int dy = random.Next(0, 20);
                    int x = random.Next(0, gameBoard.GetLength(0)-15);

                    Console.WriteLine("x:"+x+"y:"+ (i * 10));
                    printGasModel(x, i * 10 );

                }
            
            showScreen();
        }
        public void printGasModel(int x, int y)
        {

            if (x<gameBoard.GetLength(1)&&y<gameBoard.GetLength(1))
            {
                for (int i = 0; i < gasStation.Length; i++)
                {
                    char[] line = gasStation[i].ToCharArray();
                    for (int j = 0; j < line.Length; j++)
                    {

                        GameSpace temp = new GameSpace
                        {
                            symbol = line[j],
                            symbolType = GameSpace.space.gas
                        };

                        gameBoard[y + i, x + j] = temp;
                    }

                }
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


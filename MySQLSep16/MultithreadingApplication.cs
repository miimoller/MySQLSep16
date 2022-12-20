using MySQLSep16;
using MySQLSep16.DataAccess;
using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingApplication
{
    class ThreadCreationProgram
    {
        public static bool cont = true;
        public static void CallToTimeThread()
        {
            int x = 1;
            TimeData TStuff = new TimeData();
            TimeModel time=TStuff.GetTimeByID(UI.userID);
            int a = time.TimePassed;
            while (x == 1)
            {
                Thread.Sleep(5000);
                a++;
                TStuff.UpdateTime(time, a);


                UI.updatePrices();
                UI.payLoans();
            }
        }
        public static void CallToStartMusicThread()
        {
            SoundPlayer X = new SoundPlayer();

            string fileStart = Path.GetFullPath("WiiShop.wav");
            bool Continue = true;
            while (Continue && cont)
            {
                X.SoundLocation = fileStart;
                X.Play();
                Thread.Sleep(128000);
                X.Stop();
            }

        }

        public static void CallToMusicThread()
        {
            cont = false;
            SoundPlayer X = new SoundPlayer();

            string file1 = Path.GetFullPath("GiveYouTheWorld.wav");
            string file2 = Path.GetFullPath("CoconutMall.wav");
            string file3 = Path.GetFullPath("DelfinoPlaza.wav");
            string file4 = Path.GetFullPath("CrankThat.wav");
            string file5 = Path.GetFullPath("Gangnam.wav");
            string file6 = Path.GetFullPath("BackInBlack.wav");
            string file7 = Path.GetFullPath("HighwayToHell.wav");
            string file8 = Path.GetFullPath("Bangarang.wav");
            string file9 = Path.GetFullPath("Freestyle.wav");
            string file10 = Path.GetFullPath("NothingIsWorkingOut.wav");
            string file11 = Path.GetFullPath("OnThatTime.wav");
            string file12 = Path.GetFullPath("Panama.wav");
            string file13 = Path.GetFullPath("Passionfruit.wav");

            bool Continue = true;

            while (Continue)
            {
                Random random = new Random();
                int musicselect = random.Next(13) + 1;
                switch (musicselect)
                {
                    case 1:
                        X.SoundLocation = file1;
                        X.Play();
                        Thread.Sleep(275000);
                        X.Stop();
                        break;
                    case 2:
                        X.SoundLocation = file2;
                        X.Play();
                        Thread.Sleep(141000);
                        X.Stop();
                        break;
                    case 3:
                        X.SoundLocation = file3;
                        X.Play();
                        Thread.Sleep(177000);
                        X.Stop();
                        break;
                    case 4:
                        X.SoundLocation = file4;
                        X.Play();
                        Thread.Sleep(229000);
                        X.Stop();
                        break;
                    case 5:
                        X.SoundLocation = file5;
                        X.Play();
                        Thread.Sleep(222000);
                        X.Stop();
                        break;
                    case 6:
                        X.SoundLocation = file6;
                        X.Play();
                        Thread.Sleep(255000);
                        X.Stop();
                        break;
                    case 7:
                        X.SoundLocation = file7;
                        X.Play();
                        Thread.Sleep(209000);
                        X.Stop();
                        break;
                    case 8:
                        X.SoundLocation = file8;
                        X.Play();
                        Thread.Sleep(216000);
                        X.Stop();
                        break;
                    case 9:
                        X.SoundLocation = file9;
                        X.Play();
                        Thread.Sleep(179000);
                        X.Stop();
                        break;
                    case 10:
                        X.SoundLocation = file10;
                        X.Play();
                        Thread.Sleep(124000);
                        X.Stop();
                        break;
                    case 11:
                        X.SoundLocation = file11;
                        X.Play();
                        Thread.Sleep(104000);
                        X.Stop();
                        break;
                    case 12:
                        X.SoundLocation = file12;
                        X.Play();
                        Thread.Sleep(213000);
                        X.Stop();
                        break;
                    case 13:
                        X.SoundLocation = file13;
                        X.Play();
                        Thread.Sleep(300000);
                        X.Stop();
                        break;
                }
            }
        }
        public static void Run()
        {
            ThreadStart Musicref = new ThreadStart(CallToMusicThread);
            Thread MusicThread = new Thread(Musicref);
            MusicThread.Start();
            
            ThreadStart Timeref = new ThreadStart(CallToTimeThread);
            Thread TimeThread = new Thread(Timeref);
            TimeThread.Start();
        }
        public static void RunStartMusic()
        {
            ThreadStart StartMusicref = new ThreadStart(CallToStartMusicThread);
            
               

             Thread StartMusicThread = new Thread(StartMusicref);
             StartMusicThread.Start();
             
            
        }
    }
}

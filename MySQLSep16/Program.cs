// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using MySQLSep16;
using MultithreadingApplication;
using MySQLSep16.DataAccess;
using MySQLSep16.GamePlay;
using MySQLSep16.Models;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel;
using System.Net.Http.Headers;

Console.Clear();



ThreadCreationProgram.RunStartMusic();
UI ui = new UI();
ui.showLogInMain();


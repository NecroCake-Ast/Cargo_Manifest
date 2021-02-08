using Practic_3_curs.Models;
using Practic_3_curs.Views;
using System;
using System.Windows.Forms;

namespace Practic_3_curs
{
    static class Program
    {
        /// <summary>
        /// Параметры подключения к базе данных
        /// 
        /// TODO:
        ///      Это стоит утащить в какой-нибудь файлик (Necrocake, 05.02.2021)
        /// </summary>
        public const string DB_Connect_Setting = "Host=localhost;"
                                               + "Port=5432;"
                                               + "Username=postgres;"
                                               + "Password=qwerty123;"
                                               + "Database=Practic_3";
        public static IManifestFinder ManifestFinder = new PGDBManifestFinder(DB_Connect_Setting);
        public static ICarrierManager CarriersManager = new PGDBCarrierManager(DB_Connect_Setting);
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainContainer());
        }
    }
}

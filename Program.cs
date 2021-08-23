using Microsoft.Extensions.FileProviders;
using Practic_3_curs.Models;
using Practic_3_curs.Views;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Practic_3_curs
{
    static class Program
    {
        public static string            StoragePath       = Directory.GetCurrentDirectory() + "/Settings";
        public const  string            LogFilePath       = "Errors.log";
        public const  string            MailFilePath      = "Mail.xml";
        public const  string            DBSettingFilePath = "Connect.txt";

        public static string            DB_Connect_Setting;
        public static CMailData         MailData;

        public static IManifestFinder   ManifestFinder;
        public static ICarrierManager   CarriersManager;
        public static IClientManager    ClientManager;
        public static IWaybillManager   WaybillManager;
        public static ICargoTypeManager CargoTypeManager;
        public static IAirportManager   AirportManager;
        public static IManifestManager  ManifestManager;
        
        public static void Log(string msg)
        {
            StreamWriter writer = new StreamWriter(path: StoragePath + "/" + LogFilePath, append: true);
            writer.WriteLine(DateTime.Now + ": " + msg);
            writer.Close();
        }

        static void ReadMailData()
        {
            MailData = new CMailData();
            PhysicalFileProvider provider = new PhysicalFileProvider(StoragePath);
            if (provider.GetFileInfo(MailFilePath).Exists)
            {
                XmlDocument document = new XmlDocument();
                document.Load(StoragePath + "/" + MailFilePath);
                XmlNode root = document.DocumentElement;
                foreach (XmlNode node in root.ChildNodes)
                    switch (node.Name.ToLower())
                    {
                        case "логин":
                            MailData.Login = node.InnerText;
                            break;
                        case "пароль":
                            MailData.Password = node.InnerText;
                            break;
                        case "хост":
                            MailData.Host = node.InnerText;
                            break;
                        case "порт":
                            try
                            {
                                MailData.Port = int.Parse(node.InnerText);
                            }
                            catch
                            {
                                string err_msg = "Неправильно установлен параметр \"порт\" в файле с данными для отправки почты (\"" + MailFilePath + "\").";
                                Log(err_msg);
                                MessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            }
                            break;
                    }
            }
            else
            {
                string err_msg = "Не найден файл с данными для отправки почты (\"" + MailFilePath + "\").";
                Log(err_msg);
                MessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        static void ReadDBSettings()
        {
            DB_Connect_Setting = "";
            PhysicalFileProvider provider = new PhysicalFileProvider(StoragePath);
            if (provider.GetFileInfo(DBSettingFilePath).Exists)
            {
                StreamReader Inp = new StreamReader(StoragePath + "/" + DBSettingFilePath);
                while (!Inp.EndOfStream)
                    DB_Connect_Setting += " " + Inp.ReadLine();
                Inp.Close();
            }
            else
            {
                string err_msg = "Не найден файл с данными подключения к базе данных (\"" + DBSettingFilePath + "\").";
                Log(err_msg);
                MessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        [STAThread]
        static void Main()
        {
            try
            {
                ReadDBSettings();
                ReadMailData();

                ManifestFinder = new PGDBManifestFinder(DB_Connect_Setting);
                CarriersManager = new PGDBCarrierManager(DB_Connect_Setting);
                ClientManager = new PGDBClientManager(DB_Connect_Setting);
                WaybillManager = new PGDBWaybillManager(DB_Connect_Setting);
                CargoTypeManager = new PGDBCargoTypeManager(DB_Connect_Setting);
                AirportManager = new PGDBAirportManager(DB_Connect_Setting);
                ManifestManager = new PGDBManifestManager(DB_Connect_Setting);

                if (!ManifestFinder.Ping())
                {
                    string err_msg = "Не удалось получить доступ к базе данных.";
                    Log(err_msg);
                    MessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainContainer());
            }
            catch (Exception except)
            {
                try { Log(except.Message); } catch { }
                MessageBox.Show("Произошла непредвиденная ошибка. Выполнение программы прервано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}

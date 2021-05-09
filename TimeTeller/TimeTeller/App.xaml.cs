using System;
using System.IO;
using TimeTeller.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTeller
{
    public partial class App : Application
    {
        static TimeTellerDatabase database;

        public static TimeTellerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TimeTellerDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TimeTeller-va2.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

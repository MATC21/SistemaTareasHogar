using SistemaTareasHogar.Controller;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaTareasHogar
{
    public partial class App : Application
    {
        public static DataBaseConnection DataBaseConnection { get; set; }
        public App()
        {
            InitializeComponent();
            InitializeDatabase();

            MainPage = new NavigationPage(new MainPage());
        }
        private void InitializeDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "Tareadb.db3");
            DataBaseConnection = new DataBaseConnection(dbPath);
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

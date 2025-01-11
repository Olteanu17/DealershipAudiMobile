using DealershipAudiMobile.Data;
using System.IO;

namespace DealershipAudiMobile
{
    public partial class App : Application
    {
        private static DatabaseService database;

        public static DatabaseService Database =>
            database ??= new DatabaseService(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DealershipAudiMobile.db3"));

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}

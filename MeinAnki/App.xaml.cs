using MeinAnki.Service;

namespace MeinAnki
{
    public partial class App : Application
    {
        public static IServiceProvider Services;
        public static IAlertService AlertSvc;

        public App(IServiceProvider provider)
        {
            InitializeComponent();

            Services = provider;
            AlertSvc = Services.GetService<IAlertService>();

            MainPage = new AppShell();

            InitializeApp();
        }

        private void InitializeApp()
        {
            // Проверяем и создаем базу данных
            DB.CreateDatabase();
        }
    }
}

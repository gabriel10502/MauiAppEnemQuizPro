using MauiAppEnemQuizPro.MVVM.Views;
using MauiAppEnemQuizPro.Services;

namespace MauiAppEnemQuizPro
{
    public partial class App : Application
    {
        private readonly IUserService _userSrvice;
        public App(IUserService userService)
        {
            _userSrvice = userService;
            InitializeComponent();

            Connect();
        }

        private async void Connect()
        {
            string? user_logged = await SecureStorage.Default.GetAsync("user_logged");

            if (user_logged != null)
            {
                MainPage = new Protegida(_userSrvice);
            }
            else
            {
                MainPage = new Login(_userSrvice);
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 700;

            return window;
        }
    }
}

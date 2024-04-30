using MauiAppEnemQuizPro.MVVM.Models;
using MauiAppEnemQuizPro.Services;

namespace MauiAppEnemQuizPro.MVVM.Views;

public partial class Protegida : ContentPage
{
    private readonly IUserService _userService;
	public Protegida(IUserService userService)
	{
        _userService = userService;
		InitializeComponent();

        Connect();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Disconnect();
    }

	private async void Connect()
	{
        string? user_logged = await SecureStorage.Default.GetAsync("user_logged");

        if (user_logged != null)
        {
            var login = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(user_logged);
            lbl_boasvinda.Text = $"Boas vindas (a) {login.UserName}";
        }
    }

    private async void Disconnect()
    {
        bool confirm = await DisplayAlert("Tem certeza?", "Sair do App?", "Sim", "Não");
        if (confirm)
        {
            SecureStorage.Default.Remove("user_logged");
            App.Current.MainPage = new Login(_userService);
        }
    }
}
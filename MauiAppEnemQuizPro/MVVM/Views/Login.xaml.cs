using MauiAppEnemQuizPro.Services;

namespace MauiAppEnemQuizPro.MVVM.Views;

public partial class Login : ContentPage
{
    private readonly IUserService _userService;
    public Login(IUserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await _userService.InicializeAsync();
            var user = await _userService.GetUser(txt_email.Text, Util.Util.GerarHashMd5(txt_senha.Text));

            if (user != null)
            {
                var jsonUser = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                await SecureStorage.Default.SetAsync("user_logged", jsonUser);

                App.Current.MainPage = new Protegida(_userService);
            }
            else
            {
                throw new Exception("Usuário ou senha incorretos.");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        App.Current.MainPage = new NewUser(_userService);
    }
}
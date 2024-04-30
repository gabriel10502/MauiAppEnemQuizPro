using MauiAppEnemQuizPro.MVVM.Models;
using MauiAppEnemQuizPro.Services;
using System.Security.Cryptography;
using System.Text;

namespace MauiAppEnemQuizPro.MVVM.Views;

public partial class NewUser : ContentPage
{
    private readonly IUserService _userService;
    public NewUser(IUserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await _userService.InicializeAsync();

            User user = new()
            {
                Email = txt_email_cadastro.Text,
                Password = Util.Util.GerarHashMd5(txt_senha_cadastro.Text),
                UserName = txt_nome_cadastro.Text
            };

            var userDb = await _userService.GetUserByEmail(user.Email);
            if (userDb == null)
            {
                await _userService.CreateUser(user);
            }
            else
            {
                throw new Exception("Email já cadastrado!");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        App.Current.MainPage = new Login(_userService);
    }
}
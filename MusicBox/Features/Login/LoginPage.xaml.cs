
using MusicBox.Features.ColdStart.Selection;
using MusicBox.Features.Home;

namespace MusicBox.Features.Login;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (Utils.Settings.IsLogIn)
        {
            await Shell.Current.GoToAsync($"{nameof(SelectionPage)}");
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        (BindingContext as LoginPageViewModel).NavigateToCommand.Execute(null);
    }
}
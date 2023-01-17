
namespace MusicBox.Features.Settings;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        userNameLabel.Text = Utils.Settings.UserName;
        avatarView.Text = Utils.Settings.UserName.Substring(0, 2).ToUpper();

    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        Preferences.Clear();
        await Shell.Current.GoToAsync("//LoginPage");
    }


    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
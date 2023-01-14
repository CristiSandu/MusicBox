
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
        Utils.Settings.IsLogIn = false;

        await Shell.Current.GoToAsync("//LoginPage");
    }


    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        FeedbackEditor.Text = string.Empty;
    }
}
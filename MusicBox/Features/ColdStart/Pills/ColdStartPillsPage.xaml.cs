using MusicBox.Features.Home;

namespace MusicBox.Features.ColdStart.Pills;

public partial class ColdStartPillsPage : ContentPage
{
    public ColdStartPillsPage(ColdStartPillsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (Utils.Settings.IsColdStartDone)
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
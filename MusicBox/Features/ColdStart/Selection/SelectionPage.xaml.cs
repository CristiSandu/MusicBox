using MusicBox.Features.Home;

namespace MusicBox.Features.ColdStart.Selection;

public partial class SelectionPage : ContentPage
{
    public SelectionPage(SelectionPageViewModel viewModel)
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
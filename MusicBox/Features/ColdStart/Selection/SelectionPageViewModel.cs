using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using MusicBox.Controls.PopUps;
using MusicBox.Features.ColdStart.Pills;
using MusicBox.Features.Home;

namespace MusicBox.Features.ColdStart.Selection;

public partial class SelectionPageViewModel : BaseViewModel
{
    public SelectionPageViewModel()
    {

    }

    [RelayCommand]
    private async void GoToPreferences()
    {
        await Shell.Current.GoToAsync(nameof(ColdStartPillsPage));
    }

    [RelayCommand]
    private async void EnterPlaylistLink()
    {
        var popup = new AdvanceRequestPopUp();
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is bool option)
        {
            if (!option)
            {
                Utils.Settings.IsColdStartDone = true;
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
        }
    }
}

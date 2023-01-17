

using CommunityToolkit.Mvvm.Input;

namespace MusicBox.Features.Home;

public partial class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel()
    {

    }

    [RelayCommand]
    private async void GoBackFromHome()
    {
        if (!Utils.Settings.IsColdStartDone)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

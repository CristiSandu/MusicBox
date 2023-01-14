using CommunityToolkit.Mvvm.Input;
using MusicBox.Features.ColdStart.Pills;

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
}

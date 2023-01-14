using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MusicBox.Features.ColdStart.Pills;

public partial class ColdStartPillsPageViewModel : BaseViewModel
{

    [ObservableProperty]
    List<string> genre = new List<string>
    {
        "Pop",
        "Rock",
        "Hip-Hop/Rap",
        "Electronic/Dance",
        "R&B/Soul",
        "Jazz",
        "Country",
        "Classical",
        "Metal",
        "Blues",
    };

    [ObservableProperty]
    List<string> artists = new List<string>
    {
        "Taylor Swift",
        "Led Zeppelin",
        "Kendrick Lamar",
        "Daft Punk",
        "Aretha Franklin",
        "Louis Armstrong",
        "Johnny Cash",
        "Beethoven",
        "Metallica",
        "B.B. King"
    };

    [ObservableProperty]
    List<string> period = new List<string>
    {
        "1920s",
        "1930s",
        "1940s",
        "1950s",
        "1960s",
        "1970s",
        "1980s",
        "1990s",
        "2000s",
        "2010s"
    };

    public ColdStartPillsPageViewModel()
    {

    }

    [RelayCommand]

    private async void GetPillsValues(List<string> selections)
    {

    }
}

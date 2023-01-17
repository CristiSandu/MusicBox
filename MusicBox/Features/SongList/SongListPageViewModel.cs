
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicBox.Features.Recommandations;
using MusicBox.Services;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;

namespace MusicBox.Features.SongList;

public partial class SongListPageViewModel : BaseViewModel
{
    [ObservableProperty]
    string mainTitle;

    [ObservableProperty]
    ObservableCollection<TrackModel> tracks;

    private SongsDatabse _songDb;

    public SongListPageViewModel(SongsDatabse songsDatabse)
    {
        Tracks = new ObservableCollection<TrackModel>();
        _songDb = songsDatabse;

        GetDataCommand.Execute(null);
    }

    [RelayCommand]
    private async void GetData()
    {
        List<TrackModel> songs = await _songDb.GetItemsForUser();
        Tracks = new ObservableCollection<TrackModel>(songs);

        MainTitle = $"{songs.Count} Liked Tracks";
    }
}

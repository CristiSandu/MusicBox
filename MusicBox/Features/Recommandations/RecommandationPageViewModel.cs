
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicBox.Services;
using MusicBox.Services.Interfaces;
using SpotifyAPI.Web;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MusicBox.Features.Recommandations;

public partial class RecommandationPageViewModel : BaseViewModel
{
    private readonly ISpotifyService _spotifyService;

    [ObservableProperty]
    ObservableCollection<TrackModel> tracks;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Initials))]
    string userName;

    public string Initials => UserName[..2].ToUpper();

    public RecommandationPageViewModel()
    {
        UserName = Utils.Settings.UserName;
        _spotifyService = new SpotifyService();
        Tracks = new ObservableCollection<TrackModel>();
    }

    [RelayCommand]
    private async void GetTracks()
    {
        SpotifyClient client = _spotifyService.GetTokenOnDemand();

        var track = await client.Playlists.Get("1N4xs84Axvo6OptkGxvSLI");
        List<TrackModel> tracks = new List<TrackModel>();
        int i = 0;
        track.Tracks.Items.ForEach(track =>
        {
            var fullTrack = (FullTrack)track.Track;
            tracks.Add(new TrackModel
            {
                SongName = $"{fullTrack.Name}",
                Artist = fullTrack.Artists[0].Name,
                ImageLink = fullTrack.Album.Images[0].Url,
                SelectionColor = Color.FromArgb("#ff7a7a")
            });
            i++;
        });
        Tracks = new ObservableCollection<TrackModel>(tracks);
    }
}

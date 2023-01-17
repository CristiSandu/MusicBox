
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

    [ObservableProperty]
    TrackModel selectedElement;

    [ObservableProperty]
    int selectedColorsCount;

    [ObservableProperty]
    int totalCount;


    public string Initials => UserName[..2].ToUpper();

    private SongsDatabse _databse;

    public RecommandationPageViewModel(SongsDatabse songsDatabse)
    {
        UserName = Utils.Settings.UserName;
        _databse = songsDatabse;
        _spotifyService = new SpotifyService();
        Tracks = new ObservableCollection<TrackModel>();
        SelectedColorsCount = 0;
        GetTracksCommand.Execute(null);
    }

    partial void OnSelectedElementChanged(TrackModel value)
    {
        if (value != null)
        {
            int index = Tracks.IndexOf(value);

            string changedColor;
            string redColor = "#ff7a7a";

            if (Tracks[index].SelectionColor.Equals(redColor))
            {
                changedColor = "#8ff986";
                SelectedColorsCount++;
            }
            else
            {
                changedColor = "#ff7a7a";
                SelectedColorsCount--;
            }

            Tracks[index].SelectionColor = changedColor;
            SelectedElement = null;
        }
    }


    [RelayCommand]
    private async void PlaySong(string url)
    {
        try
        {
            Uri uri = new Uri(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            // An unexpected error occured. No browser may be installed on the device.
        }
    }


    [RelayCommand]
    private async void GetTracks()
    {
        IsBusy = true;
        SpotifyClient client = _spotifyService.GetTokenOnDemand();
        Random rng = new();

        string playlist = string.Empty;
        if (Utils.Settings.PlaylistName == "Zonga Music")
        {
            playlist = Utils.Constants.Zonga2Playlist;
        }
        else if (Utils.Settings.PlaylistName == "ALL")
        {
            playlist = Utils.Constants.All2Playlist;
        }
        else
        {
            playlist = Utils.Constants.GeneralPlaylist;
        }
        try
        {
            var track = await client.Playlists.Get(playlist);
            List<TrackModel> tracks = new List<TrackModel>();
            int i = 0;
            track.Tracks.Items.ForEach(track =>
            {
                var fullTrack = (FullTrack)track.Track;
                try
                {
                    tracks.Add(new TrackModel
                    {
                        SongId = fullTrack.Id,
                        SongName = $"{fullTrack.Name}",
                        Artist = fullTrack.Artists[0].Name,
                        ImageLink = fullTrack.Album.Images[0].Url,
                        SelectionColor = "#ff7a7a",
                        UserEmail = Utils.Settings.Email,
                        SongURL = fullTrack.Uri
                    });
                }
                catch (Exception ex) { }
                i++;
            });
            Tracks = new ObservableCollection<TrackModel>(tracks.OrderBy(a => rng.Next()).ToList().Take(10));

            TotalCount = Tracks.Count;
        }
        catch (Exception ex)
        {

        }
       
        IsBusy = false;
    }

    [RelayCommand]
    private async void GetUsersTopTrack()
    {
        int count = await _databse.SaveAllItemAsync(Tracks.Where(x => x.SelectionColor.Equals("#8ff986")).ToList());

        await Shell.Current.GoToAsync("..");
        //SpotifyClient client = _spotifyService.GetTokenOnDemand();
        //Paging<FullTrack> tracks = client.GetUsersTopTracks();
        //tracks.Items.ForEach(item => Console.WriteLine(item.Name)); //Display all fetched Track-Names (max 20)
        //Console.WriteLine(tracks.Total.ToString()) //Display total album track count
    }
}

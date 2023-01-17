using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicBox.Features;
using MusicBox.Features.Recommandations;
using MusicBox.Services;
using MusicBox.Services.Interfaces;
using SpotifyAPI.Web;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MusicBox.Controls.PopUps;

public partial class AdvanceRequestPopUpViewModel : BaseViewModel
{
    private readonly ISpotifyService _spotifyService;

    [ObservableProperty]
    string playlistLink;

    [ObservableProperty]
    string playlistLinkImage;

    [ObservableProperty]
    string playlistName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotImageVisible))]
    bool isImageVisible;

    public bool IsNotImageVisible => !IsImageVisible;


    public AdvanceRequestPopUpViewModel()
    {
        _spotifyService = new SpotifyService();
        IsImageVisible = false;
        PlaylistName = "Enter Spotify Playlist link";
    }

    [RelayCommand]
    private async void ImportPlaylistData()
    {
        IsBusy = true;
        SpotifyClient client = _spotifyService.GetTokenOnDemand();

        //https://open.spotify.com/playlist/1N4xs84Axvo6OptkGxvSLI?si=de63b08144d74b23

        string[] words = playlistLink.Split("/");
        string[] words2 = words.Last().Split("?");

        try
        {
            var track = await client.Playlists.Get(words2[0]);
            PlaylistName = track.Name;
            PlaylistLinkImage = track.Images[0].Url;

            Utils.Settings.PlaylistName = PlaylistName.Trim();
        }
        catch (Exception ex)
        {

        }


       

        IsImageVisible = true;
        //List<TrackModel> tracks = new List<TrackModel>();
        //int i = 0;
        //track.Tracks.Items.ForEach(track =>
        //{
        //    var fullTrack = (FullTrack)track.Track;
        //    tracks.Add(new TrackModel
        //    {
        //        SongName = $"{fullTrack.Name}",
        //        Artist = fullTrack.Artists[0].Name,
        //        ImageLink = fullTrack.Album.Images[0].Url,
        //        SelectionColor = Color.FromArgb("#ff7a7a"),
        //        SongURL = fullTrack.Uri
        //    });
        //    i++;
        //});

        IsBusy = false;
    }


    [RelayCommand]
    private async void RequestAdvancedRecomandation()
    {
        string subject = "Advanced Recomandation Request";
        string body = PlaylistLink;
        string[] recipients = new[] { "cristysandu3@gmail.com" };

        var message = new EmailMessage
        {
            Subject = subject,
            Body = body,
            BodyFormat = EmailBodyFormat.PlainText,
            To = new List<string>(recipients)
        };

        await Email.Default.ComposeAsync(message);
    }
}

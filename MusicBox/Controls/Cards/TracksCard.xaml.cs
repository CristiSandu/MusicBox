using System.Windows.Input;

namespace MusicBox.Controls.Cards;

public partial class TracksCard : Border
{
    public static readonly BindableProperty PlaySongCommandProperty =
       BindableProperty.CreateAttached(nameof(PlaySongCommand), typeof(ICommand), typeof(TracksCard), null);

    public static readonly BindableProperty AlbumImageProperty =
           BindableProperty.Create(nameof(AlbumImage), typeof(string), typeof(TracksCard), string.Empty);

    public static readonly BindableProperty TrackNameProperty =
          BindableProperty.Create(nameof(TrackName), typeof(string), typeof(TracksCard), string.Empty);

    public static readonly BindableProperty ArtistNameProperty =
          BindableProperty.Create(nameof(ArtistName), typeof(string), typeof(TracksCard), string.Empty);

    public static readonly BindableProperty SongUrlProperty =
          BindableProperty.Create(nameof(SongUrl), typeof(string), typeof(TracksCard), string.Empty);

    public static readonly BindableProperty SelectionStatusColorProperty =
          BindableProperty.Create(nameof(SelectionStatusColor), typeof(string), typeof(TracksCard), "#ff7a7a");

    public ICommand PlaySongCommand
    {
        get => (ICommand)GetValue(PlaySongCommandProperty);
        set => SetValue(PlaySongCommandProperty, value);
    }

    public string AlbumImage
    {
        get => (string)GetValue(AlbumImageProperty);
        set => SetValue(AlbumImageProperty, value);
    }

    public string TrackName
    {
        get => (string)GetValue(TrackNameProperty);
        set => SetValue(TrackNameProperty, value);
    }

    public string ArtistName
    {
        get => (string)GetValue(ArtistNameProperty);
        set => SetValue(ArtistNameProperty, value);
    }

    public string SongUrl
    {
        get => (string)GetValue(SongUrlProperty);
        set => SetValue(SongUrlProperty, value);
    }

    public string SelectionStatusColor
    {
        get => (string)GetValue(SelectionStatusColorProperty);
        set => SetValue(SelectionStatusColorProperty, value);
    }

    public TracksCard()
	{
		InitializeComponent();
	}
}
namespace MusicBox.Controls.Cards;

public partial class TracksCard : Border
{
    public static readonly BindableProperty AlbumImageProperty =
           BindableProperty.Create(nameof(AlbumImage), typeof(string), typeof(TracksCard), string.Empty);

    public static readonly BindableProperty TrackNameProperty =
          BindableProperty.Create(nameof(TrackName), typeof(string), typeof(TracksCard), string.Empty);

    public static readonly BindableProperty ArtistNameProperty =
          BindableProperty.Create(nameof(ArtistName), typeof(string), typeof(TracksCard), string.Empty);

    public static readonly BindableProperty SelectionStatusColorProperty =
          BindableProperty.Create(nameof(SelectionStatusColor), typeof(Color), typeof(TracksCard), Color.FromArgb("#ff7a7a"));

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

    public Color SelectionStatusColor
    {
        get => (Color)GetValue(SelectionStatusColorProperty);
        set => SetValue(SelectionStatusColorProperty, value);
    }

    public TracksCard()
	{
		InitializeComponent();
	}
}
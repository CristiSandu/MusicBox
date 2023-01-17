
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MusicBox.Features.Recommandations;

[Table("TrackModel")]
public partial class TrackModel : BaseViewModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string SongId { get; set; }
    public string UserEmail { get; set; }

    public string ImageLink { get; set; }

    [ObservableProperty]
    string selectionColor;
    public string SongName { get; set; }
    public string SongURL { get; set; }
    public string Artist { get; set; }
}

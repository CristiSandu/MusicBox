using MusicBox.Features.ColdStart.Pills;
using MusicBox.Features.ColdStart.Selection;
using MusicBox.Features.Home;
using MusicBox.Features.Recommandations;
using MusicBox.Features.Settings;
using MusicBox.Features.SongList;
using MusicBox.Utils;

namespace MusicBox;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ColdStartPillsPage), typeof(ColdStartPillsPage));
        Routing.RegisterRoute(nameof(SelectionPage), typeof(SelectionPage));
        Routing.RegisterRoute(nameof(RecommandationPage), typeof(RecommandationPage));
        Routing.RegisterRoute(nameof(SongListPage), typeof(SongListPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
    }
}

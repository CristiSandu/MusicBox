namespace MusicBox.Features.SongList;

public partial class SongListPage : ContentPage
{
	public SongListPage(SongListPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
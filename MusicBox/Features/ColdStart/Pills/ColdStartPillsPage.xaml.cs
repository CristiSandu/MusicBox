namespace MusicBox.Features.ColdStart.Pills;

public partial class ColdStartPillsPage : ContentPage
{
    public ColdStartPillsPage(ColdStartPillsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
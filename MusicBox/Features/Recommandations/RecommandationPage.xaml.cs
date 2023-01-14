namespace MusicBox.Features.Recommandations;

public partial class RecommandationPage : ContentPage
{
    public RecommandationPage(RecommandationPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
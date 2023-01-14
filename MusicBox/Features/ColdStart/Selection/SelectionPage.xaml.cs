namespace MusicBox.Features.ColdStart.Selection;

public partial class SelectionPage : ContentPage
{
    public SelectionPage(SelectionPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
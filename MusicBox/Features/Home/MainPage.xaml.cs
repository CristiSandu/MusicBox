using MusicBox.Features.Home;
using MusicBox.Services;
using MusicBox.Services.Interfaces;
using SpotifyAPI.Web;
using System.Collections.ObjectModel;

namespace MusicBox.Features.Home;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; 
    }
   
}


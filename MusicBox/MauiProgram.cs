using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using MusicBox.Features;
using MusicBox.Features.ColdStart.Pills;
using MusicBox.Features.ColdStart.Selection;
using MusicBox.Features.Home;
using MusicBox.Features.Login;
using MusicBox.Features.Recommandations;
using MusicBox.Services;
using MusicBox.Services.Interfaces;
using MusicBox.Features.SongList;
using MusicBox.Features.Settings;
#if IOS
using UIKit;
using CoreGraphics;
#endif

namespace MusicBox;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Medium-500.ttf", "PPM");
                fonts.AddFont("Poppins-SemiBold-600.ttf", "PPSB");
                fonts.AddFont("icomoon.ttf", "MOON");
            })
            .CustomComportament();

#if DEBUG
        builder.Logging.AddDebug();
#endif
#if ANDROID
        ImageHandler.Mapper.PrependToMapping(nameof(Microsoft.Maui.IImage.Source), (handler, view) => PrependToMappingImageSource(handler, view));
#endif

        builder.Services.AddSingleton<ISpotifyService, SpotifyService>();
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<SongsDatabse>();

        builder.Services.AddSingleton<MainPage, MainPageViewModel>();
        builder.Services.AddSingleton<LoginPage, LoginPageViewModel>();
        builder.Services.AddSingleton<SelectionPage, SelectionPageViewModel>();
        builder.Services.AddSingleton<ColdStartPillsPage, ColdStartPillsPageViewModel>();
        builder.Services.AddTransient<RecommandationPage, RecommandationPageViewModel>();
        builder.Services.AddTransient<SongListPage, SongListPageViewModel>();
        builder.Services.AddSingleton<SettingsPage>();


        return builder.Build();
    }

#if ANDROID
    public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
    {
        handler.PlatformView?.Clear();
    }
#endif

    private static MauiAppBuilder CustomComportament(this MauiAppBuilder builder)
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform());
#elif IOS
            handler.PlatformView.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform();
            handler.PlatformView.Layer.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToCGColor();
            UIView paddingView = new UIView(new CGRect(0, 0, 10.0f, 20.0f));
            handler.PlatformView.LeftView = paddingView;
            handler.PlatformView.LeftViewMode = UITextFieldViewMode.Always;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("BorderlessEditor", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform());
#elif IOS
            handler.PlatformView.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform();
            handler.PlatformView.Layer.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToCGColor();
#endif
        });
        Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("BorderlessDatePicker", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform());
            handler.PlatformView.SetPadding(0, 0, 0, 0);
#elif IOS
            handler.PlatformView.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform();
            handler.PlatformView.Layer.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToCGColor();
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
            UIView paddingView = new UIView(new CGRect(0, 0, 10.0f, 20.0f));
            handler.PlatformView.LeftView = paddingView;
            handler.PlatformView.LeftViewMode = UITextFieldViewMode.Always;
#endif
        });
        Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping("BorderlessTimePicker", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform());
#elif IOS
            handler.PlatformView.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform();
            handler.PlatformView.Layer.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToCGColor();
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
        return builder;
    }
}

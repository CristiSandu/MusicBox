
namespace MusicBox.Utils;

public static class Settings
{
    const int theme = 1;
    const string userName = "unknow";
    const string email = "unknow";
    const string playlistName = "none";
    const bool isLogIn = false;
    const bool isColdStartDone = false;



    public static int Theme
    {
        get => Preferences.Get(nameof(Theme), theme);
        set => Preferences.Set(nameof(Theme), value);
    }

    public static string UserName
    {
        get => Preferences.Get(nameof(UserName), userName);
        set => Preferences.Set(nameof(UserName), value);
    }

    public static string Email
    {
        get => Preferences.Get(nameof(Email), email);
        set => Preferences.Set(nameof(Email), value);
    }

    public static string PlaylistName
    {
        get => Preferences.Get(nameof(PlaylistName), playlistName);
        set => Preferences.Set(nameof(PlaylistName), value);
    }

    public static bool IsLogIn
    {
        get => Preferences.Get(nameof(IsLogIn), isLogIn);
        set => Preferences.Set(nameof(IsLogIn), value);
    }

    public static bool IsColdStartDone
    {
        get => Preferences.Get(nameof(IsColdStartDone), isColdStartDone);
        set => Preferences.Set(nameof(IsColdStartDone), value);
    }

    public static void SetTheme()
    {
        switch (Theme)
        {
            // default
            case 0:
                App.Current.UserAppTheme = AppTheme.Unspecified;
                break;
            // light
            case 1:
                App.Current.UserAppTheme = AppTheme.Light;
                break;
            // dark
            case 2:
                App.Current.UserAppTheme = AppTheme.Dark;
                break;
        }
    }
}

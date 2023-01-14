using Firebase.Auth;
using Firebase.Auth.Providers;
using MusicBox.Services.Interfaces;
using Newtonsoft.Json;

namespace MusicBox.Services;

public class AuthService : IAuthService
{
    private string _webApiKey;
    public AuthService()
    {
        _webApiKey = Utils.Constants.WebApiKey_Login;
    }

    public async Task<bool> LoginBtnTappedAsync(string email, string password)
    {
        var authProvider = new FirebaseAuthClient(new FirebaseAuthConfig
        {
            ApiKey =  _webApiKey,
            AuthDomain = "musicbox-88667.firebaseapp.com",
            Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        });

        try
        {
            var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            var serializedContent = JsonConvert.SerializeObject(auth);
            Preferences.Set("FreshFirebaseToken", serializedContent);

            Utils.Settings.UserName = auth.User.Info.DisplayName;
            Utils.Settings.Email = auth.User.Info.Email;
            Utils.Settings.IsLogIn = true;

            return true;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            return false;
            throw;
        }
        return false;
    }

    public async Task<bool> RegisterUserTappedAsync(string email, string password, string displayName)
    {
        try
        {
            var authProvider = new FirebaseAuthClient(new FirebaseAuthConfig
            {
                ApiKey = _webApiKey,
                AuthDomain = "musicbox-88667.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }

            });
            var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, displayName);
            string uid = auth.User.Uid;
            if (uid != null)
            {
                await Shell.Current.DisplayAlert("Alert", "User Registered successfully", "OK");
                return true;
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            return false;
            throw;
        }
        return false;
    }
}

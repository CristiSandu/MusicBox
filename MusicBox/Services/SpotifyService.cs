using MusicBox.Services.Interfaces;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using static System.Formats.Asn1.AsnWriter;

namespace MusicBox.Services;

public class SpotifyService : ISpotifyService
{
    public async Task<SpotifyClient> GetSpotifyAuthToken()
    {
        var config = SpotifyClientConfig.CreateDefault();

        var request = new ClientCredentialsRequest(Utils.Constants.CLIENT_ID, Utils.Constants.CLIENT_SECRET);
        var response = await new OAuthClient(config).RequestToken(request);

        var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

        return spotify;
    }

    public SpotifyClient GetTokenOnDemand()
    {
        var config = SpotifyClientConfig
                           .CreateDefault()
                           .WithAuthenticator(new ClientCredentialsAuthenticator(Utils.Constants.CLIENT_ID, Utils.Constants.CLIENT_SECRET));

        var spotify = new SpotifyClient(config);

        return spotify;
    }

    private static EmbedIOAuthServer _server;

    public async void LoginWithBearer()
    {
        _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
        await _server.Start();

        _server.AuthorizationCodeReceived += OnAuthorizationCodeReceived;
        _server.ErrorReceived += OnErrorReceived;

        var request = new LoginRequest(_server.BaseUri, Utils.Constants.CLIENT_ID, LoginRequest.ResponseType.Code)
        {
            Scope = new List<string> { Scopes.UserReadEmail }
        };
        await Browser.Default.OpenAsync(request.ToUri(), BrowserLaunchMode.SystemPreferred);

        //Device.OpenUri(request.ToUri()); 
    }

    private static async Task OnAuthorizationCodeReceived(object sender, AuthorizationCodeResponse response)
    {
        await _server.Stop();

        var config = SpotifyClientConfig.CreateDefault();
        var tokenResponse = await new OAuthClient(config).RequestToken(
          new AuthorizationCodeTokenRequest(
            Utils.Constants.CLIENT_ID, Utils.Constants.CLIENT_SECRET, response.Code, new Uri("http://localhost:5000/callback")
          )
        );

        var spotify = new SpotifyClient(tokenResponse.AccessToken);
        // do calls with Spotify and save token?
    }

    private static async Task OnErrorReceived(object sender, string error, string state)
    {
        Console.WriteLine($"Aborting authorization, error received: {error}");
        await _server.Stop();
    }

}

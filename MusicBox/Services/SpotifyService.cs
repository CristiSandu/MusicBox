using MusicBox.Services.Interfaces;
using SpotifyAPI.Web;
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
}

using SpotifyAPI.Web;

namespace MusicBox.Services.Interfaces;

public interface ISpotifyService
{
    Task<SpotifyClient> GetSpotifyAuthToken();
    SpotifyClient GetTokenOnDemand();
    void LoginWithBearer();

}
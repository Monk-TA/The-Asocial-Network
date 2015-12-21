namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    using System.Threading.Tasks;
    using Windows.Services.Maps;

    public interface IGeolocationService
    {
        Task<MapAddress> GetCurrentCivilAddresByLocationAsync();
    }
}
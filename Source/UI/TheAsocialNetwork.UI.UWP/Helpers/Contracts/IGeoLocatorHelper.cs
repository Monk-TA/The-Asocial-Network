namespace TheAsocialNetwork.UI.UWP.Helpers.Contracts
{
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;

    public interface IGeoLocatorHelper
    {
        Task<Geoposition> HandeleAccessStatus(GeolocationAccessStatus accessStatus);
        Task<MapAddress> GetCivilAddresByLocation(double latitude, double longtitude);
    }
}
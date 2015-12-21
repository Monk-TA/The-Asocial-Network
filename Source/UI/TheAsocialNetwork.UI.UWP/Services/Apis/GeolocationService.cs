namespace TheAsocialNetwork.UI.UWP.Services.Apis
{
    using System;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;
    using TheAsocialNetwork.UI.UWP.Helpers.Contracts;
    using TheAsocialNetwork.UI.UWP.Helpers.Geolocator;
    using TheAsocialNetwork.UI.UWP.Services.Contracts;

    public class GeolocationService : IGeolocationService
    {
        private IGeoLocatorHelper geolocatorHelper;

        public GeolocationService()
            :this(new GeoLocatorHelper())
        {
        }

        public GeolocationService(IGeoLocatorHelper geolocator)
        {
            this.geolocatorHelper = geolocator;
        }

        public async Task<MapAddress> GetCurrentCivilAddresByLocationAsync()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            var result = await this.geolocatorHelper.HandeleAccessStatus(accessStatus);

            MapAddress address = null;

            if (result != null)
            {
                var latitude = result.Coordinate.Latitude;
                var longtutude = result.Coordinate.Longitude;

                address = await this.geolocatorHelper.GetCivilAddresByLocation(latitude, longtutude);
            }

            return address;
        }
    }
}

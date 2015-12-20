namespace TheAsocialNetwork.UI.UWP.Services.Apis
{
    using System;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;
    using TheAsocialNetwork.UI.UWP.Helpers.Geolocator;

    public class GeolocationService
    {
        private GeoLocatorHelper geolocatorHelper;

        public GeolocationService()
        {
            this.geolocatorHelper = new GeoLocatorHelper();
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

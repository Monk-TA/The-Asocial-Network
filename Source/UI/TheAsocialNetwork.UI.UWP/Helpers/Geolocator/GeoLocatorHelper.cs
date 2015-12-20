namespace TheAsocialNetwork.UI.UWP.Helpers.Geolocator
{
    using System;
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Services.Apis;
    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;

    public class GeoLocatorHelper
    {
        private NotificationService notificator;

        public GeoLocatorHelper()
        {
            this.notificator = new NotificationService();
        }

        public async Task<Geoposition> HandeleAccessStatus(  GeolocationAccessStatus accessStatus)
        {
            Geoposition geoposition = null;

            var message = "";

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 1000 };
                    geoposition = await geolocator.GetGeopositionAsync();
                    break;

                case GeolocationAccessStatus.Denied:
                    message = "Access to location is denied!";
                    break;

                case GeolocationAccessStatus.Unspecified:
                    message = "Unspecified error!";
                    break;
            }

            if (message != "")
            {
                this.notificator.ShowErrorToastWithDismissButton(message);
            }

            return geoposition;
        }

        public async Task<MapAddress> GetCivilAddresByLocation(double latitude, double longtitude)
        {
            BasicGeoposition location = new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longtitude
            };

            Geopoint pointToReverseGeocode = new Geopoint(location);

            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            MapAddress addres = null; 

            if (result != null && result.Locations != null && result.Locations.Count > 0)
            {
                addres = result.Locations[0].Address;
            }

            return addres;
        }
    }
}

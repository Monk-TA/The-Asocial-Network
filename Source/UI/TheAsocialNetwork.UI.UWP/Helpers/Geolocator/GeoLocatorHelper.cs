﻿namespace TheAsocialNetwork.UI.UWP.Helpers.Geolocator
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;
    using Windows.UI.Notifications;
    using NotificationsExtensions.Toasts;
    using TheAsocialNetwork.UI.UWP.Helpers.ToastNotifications;

    public class GeoLocatorHelper
    {
        private ToastCrerator toaster;

        public GeoLocatorHelper()
        {
            this.toaster = new ToastCrerator();
        }

        public async Task<Geoposition> HandeleAccessStatus(  GeolocationAccessStatus accessStatus)
        {
            ToastVisual visual = null;
            Geoposition geoposition = null;

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 1000 };
                    geoposition = await geolocator.GetGeopositionAsync();
                    break;

                case GeolocationAccessStatus.Denied:
                    visual = this.toaster.GetVisualToast("Access to location is denied.", null, null);
                    break;

                case GeolocationAccessStatus.Unspecified:
                    visual = this.toaster.GetVisualToast("Unspecified error.", null, null);
                    break;
            }

            if (visual != null)
            {
                var button = new ToastButtonDismiss();
                ToastActionsCustom actios = this.toaster.GetToastCustomActions(null, new List<IToastButton>() { button });
                ToastContent content = this.toaster.GetToastContent(visual, actios);
                var doc = content.GetXml();
                var notification = new ToastNotification(doc);
                ToastNotificationManager.CreateToastNotifier().Show(notification);
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

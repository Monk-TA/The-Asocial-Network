namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;

    public class LocationViewModel : BaseViewModel
    {
        private int id;
        private string objectId;
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private string town;
        private double? latitude;
        private string country;
        private double? longitude;

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.OnPropertyChanged("Id");
            }
        }

        public string ObjectId
        {
            get { return this.objectId; }
            set
            {
                this.objectId = value;
                this.OnPropertyChanged("ObjectId");
            }
        }

        public DateTime? CreatedAt
        {
            get { return this.createdAt; }
            set
            {
                this.createdAt = value;
                this.OnPropertyChanged("CreatedAt");
            }
        }

        public DateTime? UpdatedAt
        {
            get { return this.updatedAt; }
            set
            {
                this.updatedAt = value;
                this.OnPropertyChanged("UpdatedAt");
            }
        }

        public string Country
        {
            get { return this.country; }
            set
            {
                this.country = value;
                this.OnPropertyChanged("Country");
            }
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                this.town = value;
                this.OnPropertyChanged("Town");
            }
        }

        public double? Latitude
        {
            get { return this.latitude; }
            set
            {
                this.latitude = value;
                this.OnPropertyChanged("Latitude");
            }
        }

        public double? Longitude
        {
            get { return this.longitude; }
            set
            {
                this.longitude = value;
                this.OnPropertyChanged("Longitude");
            }
        }
    }
}

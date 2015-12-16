namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using global::Parse;

    [ParseClassName("Location")]
    public class LocationParse : ParseObject
    {
        [ParseFieldName("Country")]
        public string Country
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("Town")]
        public string Town
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("Latitude")]
        public double? Latitude
        {
            get { return this.GetProperty<double?>(); }
            set { this.SetProperty<double?>(value); }
        }

        [ParseFieldName("Longitude")]
        public double? Longitude
        {
            get { return this.GetProperty<double?>(); }
            set { this.SetProperty<double?>(value); }
        }
    }
}
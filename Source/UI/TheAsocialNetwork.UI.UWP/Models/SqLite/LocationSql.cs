namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using SQLite.Net.Attributes;

    [Table("Location")]
    public class LocationSql
    {

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
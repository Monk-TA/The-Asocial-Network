namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using SQLite.Net.Attributes;

    public class AvatarSql
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ImageInfoSql ImageInfo { get; set; }
    }
}
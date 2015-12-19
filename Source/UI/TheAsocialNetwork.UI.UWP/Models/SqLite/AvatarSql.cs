namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;

    public class AvatarSql
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(typeof(ImageInfoSql))]
        public int ImageInfoId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public ImageInfoSql ImageInfo { get; set; }
    }
}
namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;

    public class ImageSql
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Title{get;set;}

        public string Description{get;set;}

        [ForeignKey(typeof(PostSql))]
        public int PostId { get; set; }

        [ForeignKey(typeof(ImageInfoSql))]
        public int ImageInfoId { get; set; }

        [OneToOne]
        public ImageInfoSql ImageInfo {get;set;}
    }
}

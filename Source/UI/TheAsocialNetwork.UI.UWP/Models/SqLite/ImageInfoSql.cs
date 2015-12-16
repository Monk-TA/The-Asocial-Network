namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using SQLite.Net.Attributes;

    [Table("ImageInfo")]
    public class ImageInfoSql
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string OriginalName { get; set; }

        public string FileExstension { get; set; }

        public byte[] ByteArrayContent { get; set; }
    }
}

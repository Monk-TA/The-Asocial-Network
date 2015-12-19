namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using System.Collections.Generic;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    [Table("Posts")]
    public class PostSql
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        [ForeignKey(typeof(LocationSql))]
        public int LocationId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public LocationSql Location { get; set; }

        public bool IsBest { get; set; }

        [ForeignKey(typeof(UserSql))]
        public int UserId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ImageSql> Images { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<VideoSql> Videos { get; set; }
    }
}